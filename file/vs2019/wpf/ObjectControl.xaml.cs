
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Text.Json;
using Microsoft.Win32;
using System.IO;
using System.Security.Cryptography;
using System;
using Minio;
using Minio.DataModel.Tracing;
using Minio.Exceptions;
using System.Threading.Tasks;

namespace ogm.file
{
    public class MinioLog : IRequestLogger
    {
        public Action<int> Callback;
        public void LogRequest(RequestToLog requestToLog, ResponseToLog responseToLog, double durationMs)
        {
            if (responseToLog.statusCode == System.Net.HttpStatusCode.OK)
            {
                foreach (var header in requestToLog.parameters)
                {
                    if (header.value == null)
                        continue;
                    if (header.name.Equals("partNumber"))
                    {
                        int partNumber = Convert.ToInt32(header.value);
                        Callback(partNumber);
                    }
                }
            }
        }
    }


    public partial class ObjectControl : UserControl
    {
        //页面参数，用于页面间跳转时传递数据
        public Dictionary<string, object> PageExtra = new Dictionary<string, object>();

        public class ObjectUiBridge : BaseObjectUiBridge, IObjectExtendUiBridge
        {
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
                object o_md5;
                if (!control.PageExtra.TryGetValue("object.md5", out o_md5))
                    return;
                string md5 = (string)o_md5;
                object o_filepath;
                if (!control.PageExtra.TryGetValue("object.file", out o_filepath))
                    return;
                string file_fullpath = (string)o_filepath;
                object o_size;
                if (!control.PageExtra.TryGetValue("object.size", out o_size))
                    return;
                long size = (long)o_size;

                var reply = JsonSerializer.Deserialize<ObjectPrepareReply>(_json);
                if (reply.status.code == 200)
                {
                    control.pbUpload.Visibility = Visibility.Collapsed;
                    string filepath = Path.Combine(control.tbUploadPrefix.Text, Path.GetFileName(file_fullpath));
                    control.flushObject(uuid, md5, filepath);
                    return;
                }

                int total_minio_chunk_count = (int)Math.Ceiling(Convert.ToDouble(size) / 1024 / 5120);
                if (2 == reply.engine)
                {
                    string[] token = reply.accessToken.Split(' ');
                    Uri uri = new Uri(reply.url);
                    MinioClient minio = new MinioClient(uri.Authority, token[0], token[1]);
                    minio.SetTraceOn(new MinioLog()
                    {
                        Callback = number =>
                        {
                            double process = Math.Round(Convert.ToDouble(number) / total_minio_chunk_count, 2) * 100;
                            control.pbUpload.Dispatcher.Invoke(new Action(() => { control.pbUpload.Value = process; }));
                        }
                    });
                    upload(minio, uuid, scope, md5, file_fullpath);
                }
            }

            public override void ReceiveFlush(string _json)
            {
                base.ReceiveFlush(_json);
                Reply reply = JsonSerializer.Deserialize<Reply>(_json);
                control.pbUpload.Visibility = Visibility.Collapsed;
                if (reply.status.code == 0)
                {
                    control.tbUploadSuccess.Visibility = Visibility.Visible;
                    control.tbPrefix.Text = "";
                    control.tbName.Text = "";
                    control.listObject(control.tbBucket.Uid);
                }
                else
                {
                    control.tbUploadFailury.Visibility = Visibility.Visible;
                }
                control.PageExtra.Remove("bucket.md5");
                control.PageExtra.Remove("bucket.file");
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

            private async Task upload(MinioClient _minio, string _uuid, string _scope, string _md5, string _filepath)
            {
                try
                {
                    await _minio.PutObjectAsync(_scope, _md5, _filepath);
                }
                catch (MinioException e)
                {
                    control.pbUpload.Visibility = Visibility.Collapsed;
                    control.tbUploadFailury.Visibility = Visibility.Visible;
                    return;
                }
                string filepath = Path.Combine(control.tbUploadPrefix.Text, Path.GetFileName(_filepath));
                control.flushObject(_uuid, _md5, filepath);
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


        public ObjectControl()
        {
            ObjectList = new ObservableCollection<ObjectEntity>();
            InitializeComponent();
            formEditObject.Visibility = Visibility.Collapsed;
            formUploadObject.Visibility = Visibility.Collapsed;
            pbUpload.Visibility = Visibility.Collapsed;
            tbFilename.Visibility = Visibility.Collapsed;
            tbUploadSuccess.Visibility = Visibility.Collapsed;
            tbUploadFailury.Visibility = Visibility.Collapsed;
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
            tbFilename.Text = "";
            pbUpload.Value = 0;
            pbUpload.Visibility = Visibility.Collapsed;
            tbFilename.Visibility = Visibility.Collapsed;
            tbUploadSuccess.Visibility = Visibility.Collapsed;
            tbUploadFailury.Visibility = Visibility.Collapsed;
            OpenFileDialog dialog = new OpenFileDialog();
            if (false == dialog.ShowDialog())
                return;

            tbFilename.Visibility = Visibility.Visible;
            tbFilename.Text = Path.GetFileName(dialog.FileName);
            string filepath = dialog.FileName;
            string md5str = "";
            long size = 0;
            try
            {
                FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
                size = fs.Length;
                MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
                byte[] buffer = md5Provider.ComputeHash(fs);
                md5str = BitConverter.ToString(buffer);
                md5str = md5str.Replace("-", "");
                md5Provider.Clear();
                fs.Close();

            }
            catch (Exception ex)
            {
                //
                tbUploadFailury.Visibility = Visibility.Visible;
                return;
            }
            if (string.IsNullOrEmpty(md5str))
                return;

            //TODO 多文件上传
            object uuid;
            if (!PageExtra.TryGetValue("bucket.uuid", out uuid))
                return;
            PageExtra["object.file"] = filepath;
            PageExtra["object.md5"] = md5str;
            PageExtra["object.size"] = size;

            pbUpload.Visibility = Visibility.Visible;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["bucket"] = (string)uuid;
            param["uname"] = md5str;
            param["size"] = size;
            var bridge = facade.getViewBridge() as IObjectViewBridge;
            string json = JsonSerializer.Serialize(param);
            bridge.OnPrepareSubmit(json);
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

        private void flushObject(string _bucket, string _md5, string _filename)
        {
            var bridge = facade.getViewBridge() as IObjectViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["bucket"] = _bucket;
            param["uname"] = _md5;
            param["path"] = _filename;
            string json = JsonSerializer.Serialize(param);
            bridge.OnFlushSubmit(json);
        }
    }
}
