using System.Windows.Controls;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Text.Json;
using Microsoft.Win32;
using System.IO;
using System.Security.Cryptography;
using System;
using System.Net;
using Forms = System.Windows.Forms;

namespace ogm.file
{
    public partial class ObjectControl : UserControl
    {
        //页面参数，用于页面间跳转时传递数据
        public Dictionary<string, object> PageExtra = new Dictionary<string, object>();

        public class UploadObject
        {
            public string path { get; set; } // 存储桶中的对象路径
            public string filepath { get; set; } // 对象的本地文件路径
            public long size { get; set; }
            public string uname { get; set; } // 在存储引擎中
            public string md5 { get; set; }
            public bool valid { get; set; } // 是否有效
        }

        private Queue<UploadObject> uploadQueue_ = new Queue<UploadObject>();

        public class ObjectUiBridge : BaseObjectUiBridge, IObjectExtendUiBridge
        {
            public override void UpdatePermission(Dictionary<string, string> _permission)
            {
                control.PermissionUpload = _permission.ContainsKey("/ogm/file/Object/Upload");
                control.PermissionEdit = _permission.ContainsKey("/ogm/file/Object/Update");
                control.PermissionDelete = _permission.ContainsKey("/ogm/file/Object/Delete");
                control.PermissionPreview = _permission.ContainsKey("/ogm/file/Object/Preview");
                control.PermissionPublish = _permission.ContainsKey("/ogm/file/Object/Publish");
            }

            public override void ReceiveList(string _json)
            {
                base.ReceiveList(_json);
                ObjectListReply reply = JsonSerializer.Deserialize<ObjectListReply>(_json);
                control.ObjectList.Clear();
                foreach (var e in reply.entity)
                {
                    e._size = formatSize(e.size);
                    control.ObjectList.Add(e);
                }
            }

            public override void ReceiveSearch(string _json)
            {
                ReceiveList(_json);
            }

            public override void ReceivePrepare(string _json)
            {
                base.ReceivePrepare(_json);
                object o_uuid;
                if (!control.PageExtra.TryGetValue("bucket.uuid", out o_uuid))
                    return;
                string uuid = (string)o_uuid;
                object o_scope;
                if (!control.PageExtra.TryGetValue("bucket.scope", out o_scope))
                    return;
                string scope = (string)o_scope;

                var uo = control.uploadQueue_.Peek();
                long size = uo.size;
                string uname = uo.uname;
                string md5 = uo.md5;

                var reply = JsonSerializer.Deserialize<ObjectPrepareReply>(_json);
                if (reply.status.code == 200)
                {
                    control.pbUpload.Visibility = Visibility.Collapsed;
                    control.flushObject(uuid, uname, md5, uo.path);
                    return;
                }

                int total_minio_chunk_count = (int)Math.Ceiling(Convert.ToDouble(size) / 1024 / 5120);
                if (2 == reply.engine)
                {
                    putFile(uuid, scope, uname, size, md5, uo.filepath, uo.path, reply.accessToken);
                }
            }

            public override void ReceiveFlush(string _json)
            {
                base.ReceiveFlush(_json);
                Reply reply = JsonSerializer.Deserialize<Reply>(_json);
                control.pbUpload.Visibility = Visibility.Collapsed;
                var uo = control.uploadQueue_.Dequeue();
                if (reply.status.code == 0)
                {
                    control.uploadSuccessCount_ += 1;
                    control.tbUploadSuccess.Visibility = Visibility.Visible;
                    control.tbPrefix.Text = "";
                    control.tbName.Text = "";
                    control.listObject(control.tbBucket.Uid);
                    control.UploadObjects.Remove(uo.path);
                }
                else
                {
                    control.uploadFailureCount_ += 1;
                    control.tbUploadFailury.Visibility = Visibility.Visible;
                }
                control.tbUploadSuccess.Text = string.Format(control.uploadSuccessFormat_, control.uploadSuccessCount_);
                control.tbUploadFailury.Text = string.Format(control.uploadFailureFormat_, control.uploadFailureCount_);
                control.prepareFile();
            }

            public override void ReceiveRemove(string _json)
            {
                base.ReceiveRemove(_json);
                UuidReply reply = JsonSerializer.Deserialize<UuidReply>(_json);
                if (reply.status.code != 0)
                    return;
                control.tbPrefix.Text = "";
                control.tbName.Text = "";
                control.listObject(control.tbBucket.Uid);
            }

            public override void ReceivePublish(string _json)
            {
                base.ReceivePublish(_json);
                PublishReply reply = JsonSerializer.Deserialize<PublishReply>(_json);
                if (reply.status.code == 0)
                    Clipboard.SetDataObject(reply.url);
            }

            private void putFile(string _uuid, string _scope, string _uname, long _size, string _md5, string _filepath, string _uri, string _url)
            {
                WebClient wc = new WebClient();
                wc.UploadFileCompleted += new UploadFileCompletedEventHandler((_sender, _args) =>
                {
                    control.flushObject(_uuid, _uname, _md5, _uri);
                });
                wc.UploadProgressChanged += new UploadProgressChangedEventHandler((_sender, _args) =>
                {
                    control.pbUpload.Value = _args.BytesSent * 100 / _size;
                });
                try
                {
                    wc.UploadFileAsync(new Uri(_url), "PUT", _filepath);
                }
                catch (System.Exception e)
                {
                    control.pbUpload.Visibility = Visibility.Collapsed;
                    control.tbUploadFailury.Visibility = Visibility.Visible;
                    return;
                }
            }


            private string formatSize(long _size)
            {
                if (_size < 1024)
                    return string.Format("{0} B", _size);
                if (_size < 1024 * 1024)
                    return string.Format("{0} K", _size / 1024);
                if (_size < 1024 * 1024 * 1024)
                    return string.Format("{0} M", _size / 1024 / 1024);
                if (_size < (long)1024 * 1024 * 1024 * 1024)
                    return string.Format("{0} G", _size / 1024 / 1024 / 1024);
                if (_size < (long)1024 * 1024 * 1024 * 1024 * 1024)
                    return string.Format("{0} T", _size / 1024 / 1024 / 1024 / 1024);
                return "?";
            }
        }

        public ObjectFacade facade { get; set; }
        public ObservableCollection<ObjectEntity> ObjectList { get; set; }
        public ObservableCollection<string> UploadObjects { get; set; }

        public static readonly DependencyProperty PermissionUploadProperty = DependencyProperty.Register("PermissionUpload", typeof(bool), typeof(ObjectControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionEditProperty = DependencyProperty.Register("PermissionEdit", typeof(bool), typeof(ObjectControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionDeleteProperty = DependencyProperty.Register("PermissionDelete", typeof(bool), typeof(ObjectControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionPreviewProperty = DependencyProperty.Register("PermissionPreview", typeof(bool), typeof(ObjectControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionPublishProperty = DependencyProperty.Register("PermissionPublish", typeof(bool), typeof(ObjectControl), new PropertyMetadata(true));

        public bool PermissionUpload
        {
            get { return (bool)GetValue(PermissionUploadProperty); }
            set { SetValue(PermissionUploadProperty, value); }
        }

        public bool PermissionEdit
        {
            get { return (bool)GetValue(PermissionEditProperty); }
            set { SetValue(PermissionEditProperty, value); }
        }

        public bool PermissionDelete
        {
            get { return (bool)GetValue(PermissionDeleteProperty); }
            set { SetValue(PermissionDeleteProperty, value); }
        }
        public bool PermissionPreview
        {
            get { return (bool)GetValue(PermissionPreviewProperty); }
            set { SetValue(PermissionPreviewProperty, value); }
        }
        public bool PermissionPublish
        {
            get { return (bool)GetValue(PermissionPublishProperty); }
            set { SetValue(PermissionPublishProperty, value); }
        }

        private string uploadSuccessFormat_ { get; set; }
        private string uploadFailureFormat_ { get; set; }
        private int uploadSuccessCount_;
        private int uploadFailureCount_;



        public ObjectControl()
        {
            ObjectList = new ObservableCollection<ObjectEntity>();
            UploadObjects = new ObservableCollection<string>();
            InitializeComponent();
            formEditObject.Visibility = Visibility.Collapsed;
            formUploadObject.Visibility = Visibility.Collapsed;
            pbUpload.Visibility = Visibility.Collapsed;
            uploadSuccessFormat_ = tbUploadSuccess.Text;
            uploadFailureFormat_ = tbUploadFailury.Text;
        }

        public void RefreshWithExtra()
        {
            object o_uuid;
            if (!PageExtra.TryGetValue("bucket.uuid", out o_uuid))
                return;
            object o_name;
            if (!PageExtra.TryGetValue("bucket.name", out o_name))
                return;
            tbBucket.Uid = (string)o_uuid;
            tbBucket.Text = (string)o_name;
            tbBucket.IsEnabled = false;
            tbPrefix.Text = "";
            tbName.Text = "";

            listObject(tbBucket.Uid);
        }

        private void onResetCliked(object sender, System.Windows.RoutedEventArgs e)
        {
            tbPrefix.Text = "";
            tbName.Text = "";
            listObject(tbBucket.Uid);
        }

        private void onSearchClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbBucket.Uid))
            {
                //TODO 错误提示
                return;
            }
            var bridge = facade.getViewBridge() as IObjectViewBridge;
            if (!string.IsNullOrEmpty(tbPrefix.Text) || !string.IsNullOrEmpty(tbName.Text))
            {
                searchObject(tbBucket.Uid, tbPrefix.Text, tbName.Text);
            }
            else
            {
                listObject(tbBucket.Uid);
            }
        }

        private void onOpenFileClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            resetUpload();

            OpenFileDialog dialog = new OpenFileDialog();
            if (false == dialog.ShowDialog())
                return;

            string filepath = dialog.FileName;
            //TODO 多文件上传

            btnUploadSubmit.IsEnabled = false;
            btnUploadCancel.IsEnabled = false;
            UploadObject uo = buildUploadObject(Path.GetDirectoryName(filepath), filepath);
            if (uo.valid)
                uploadQueue_.Enqueue(uo);
            else
                tbUploadFailury.Visibility = Visibility.Visible;
            UploadObjects.Add(uo.path);
            btnUploadSubmit.IsEnabled = true;
            btnUploadCancel.IsEnabled = true;
        }

        private void onUploadCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formUploadObject.Visibility = Visibility.Collapsed;
        }

        private void onEditSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgObjectList.SelectedItem as ObjectEntity;
            if (null == item)
                return;

            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = item.uuid;
            param["filepath"] = tbEditFilepath.Text;

            var bridge = facade.getViewBridge() as IObjectViewBridge;
            string json = JsonSerializer.Serialize(param);
            //bridge.OnUpdateSubmit(json);
        }

        private void onUploadClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formUploadObject.Visibility = Visibility.Visible;
            formEditObject.Visibility = Visibility.Collapsed;
            btnUploadSubmit.IsEnabled = false;
            resetUpload();
        }

        private void onObjectSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            formUploadObject.Visibility = Visibility.Collapsed;
            var item = dgObjectList.SelectedItem as ObjectEntity;
            if (null == item)
                return;

            tbEditFilepath.Text = item.filepath;
        }

        private void onEditObjectClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgObjectList.SelectedItem as ObjectEntity;
            if (null == item)
                return;
            formEditObject.Visibility = Visibility.Visible;
            formUploadObject.Visibility = Visibility.Collapsed;

            tbEditFilepath.Text = item.filepath;
        }

        private void onDownloadObjectClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgObjectList.SelectedItem as ObjectEntity;
            if (null == item)
                return;
            var bridge = facade.getViewBridge() as IObjectViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = item.uuid;
            string json = JsonSerializer.Serialize(param);
            //bridge.OnPreviewSubmit(json);
            bridge.OnPublishSubmit(json);
        }

        private void onDeleteObjectClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgObjectList.SelectedItem as ObjectEntity;
            if (null == item)
                return;
            var bridge = facade.getViewBridge() as IObjectViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = item.uuid;
            string json = JsonSerializer.Serialize(param);
            bridge.OnRemoveSubmit(json);
        }

        private void onEditCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formEditObject.Visibility = Visibility.Collapsed;
        }

        private void listObject(string _bucketUUID)
        {

            var bridge = facade.getViewBridge() as IObjectViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["bucket"] = _bucketUUID;
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            string json = JsonSerializer.Serialize(param);
            bridge.OnListSubmit(json);
        }
        private void searchObject(string _bucketUUID, string _prefix, string _name)
        {

            var bridge = facade.getViewBridge() as IObjectViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["bucket"] = _bucketUUID;
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            param["prefix"] = _prefix;
            param["name"] = _name;
            string json = JsonSerializer.Serialize(param);
            bridge.OnSearchSubmit(json);
        }

        private void flushObject(string _bucket, string _uname, string _md5, string _path)
        {
            var bridge = facade.getViewBridge() as IObjectViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["bucket"] = _bucket;
            param["uname"] = _uname;
            param["path"] = _path;
            param["md5"] = _md5;
            string json = JsonSerializer.Serialize(param);
            bridge.OnFlushSubmit(json);
        }

        private void onUploadSubmitClicked(object sender, RoutedEventArgs e)
        {
            btnUploadSubmit.IsEnabled = false;
            prepareFile();
        }

        private void onClearClicked(object sender, RoutedEventArgs e)
        {

        }

        private void onOpenDirClicked(object sender, RoutedEventArgs e)
        {
            resetUpload();

            Forms.FolderBrowserDialog dialog = new Forms.FolderBrowserDialog();
            if (Forms.DialogResult.OK != dialog.ShowDialog())
                return;

            btnUploadSubmit.IsEnabled = false;
            btnUploadCancel.IsEnabled = false;
            string dir = dialog.SelectedPath;
            foreach (var file in Directory.GetFiles(dir, "*", SearchOption.AllDirectories))
            {
                UploadObject uo = buildUploadObject(dir, file);
                if (uo.valid)
                {
                    uploadQueue_.Enqueue(uo);
                }
                UploadObjects.Add(uo.path);
            }
            btnUploadSubmit.IsEnabled = true;
            btnUploadCancel.IsEnabled = true;
        }

        private void prepareFile()
        {
            object uuid;
            if (!PageExtra.TryGetValue("bucket.uuid", out uuid))
                return;
            if (uploadQueue_.Count == 0)
                return;

            var uo = uploadQueue_.Peek();
            pbUpload.Visibility = Visibility.Visible;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["bucket"] = (string)uuid;
            param["uname"] = uo.uname;
            param["size"] = uo.size;
            var bridge = facade.getViewBridge() as IObjectViewBridge;
            string json = JsonSerializer.Serialize(param);
            bridge.OnPrepareSubmit(json);
        }

        private UploadObject buildUploadObject(string _dir, string _file)
        {
            string path = Path.GetRelativePath(_dir, _file).Replace("\\", "/");
            UploadObject uo = new UploadObject();
            uo.valid = true;
            uo.path = string.Format("{0}{1}", tbUploadPrefix.Text, path);
            uo.filepath = _file;
            try
            {
                FileStream fs = new FileStream(_file, FileMode.Open, FileAccess.Read, FileShare.Read);
                uo.size = fs.Length;
                MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
                byte[] buffer = md5Provider.ComputeHash(fs);
                string md5str = "";
                md5str = BitConverter.ToString(buffer);
                md5str = md5str.Replace("-", "");
                md5Provider.Clear();
                fs.Close();
                uo.md5 = md5str;
            }
            catch (Exception ex)
            {
                uo.valid = false;
            }
            if (true == cbSaveAsMD5.IsChecked)
                uo.uname = uo.md5;
            else
                uo.uname = uo.path;
            return uo;
        }

        private void resetUpload()
        {
            uploadQueue_.Clear();
            UploadObjects.Clear();
            pbUpload.Value = 0;
            pbUpload.Visibility = Visibility.Collapsed;
            tbUploadSuccess.Visibility = Visibility.Collapsed;
            tbUploadFailury.Visibility = Visibility.Collapsed;
            uploadFailureCount_ = 0;
            uploadSuccessCount_ = 0;
        }
    }
}
