using Microsoft.Win32;
using Minio;
using Minio.DataModel.Tracing;
using Minio.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ogm.file
{
    public partial class ObjectControl : UserControl
    {
        //页面参数，用于页面间跳转时传递数据
        public static Dictionary<string, object> PageExtra = new Dictionary<string, object>();
        public class ObjectEntity
        {
            public string uuid { get; set; }
            public string name { get; set; }
            public string filepath { get; set; }
            public long size { get; set; }
            public string md5 { get; set; }

            public string _size { get; set; }
        }

        public class ReplyStatus
        {
            public int code { get; set; }
            public string message { get; set; }
        }

        public class ListReply
        {
            public long total { get; set; }
            public ObjectEntity[] entity { get; set; }
        }


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

        public class ObjectUiBridge : IObjectUiBridge
        {
            public ObjectControl control { get; set; }

            public object getRootPanel()
            {
                return control;
            }

            public void Alert(string _message)
            {
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

            public void receivePrepare(string _json)
            {
                object o_uuid;
                if (!PageExtra.TryGetValue("bucket.uuid", out o_uuid))
                    return;
                string uuid = (string)o_uuid;
                object o_scope;
                if (!PageExtra.TryGetValue("bucket.scope", out o_scope))
                    return;
                string scope = (string)o_scope;
                object o_md5;
                if (!PageExtra.TryGetValue("object.md5", out o_md5))
                    return;
                string md5 = (string)o_md5;
                object o_filepath;
                if (!PageExtra.TryGetValue("object.file", out o_filepath))
                    return;
                string filepath = (string)o_filepath;
                object o_size;
                if (!PageExtra.TryGetValue("object.size", out o_size))
                    return;
                long size = (long)o_size;

                Dictionary<string, string> param = JsonSerializer.Deserialize<Dictionary<string, string>>(_json);
                bool exist = param["exist"].Equals("True");
                if (exist)
                {
                    control.pbUpload.Visibility = Visibility.Collapsed;
                    control.flushObject(uuid, md5, Path.GetFileName(filepath));
                    return;
                }

                int total_minio_chunk_count = (int)Math.Ceiling(Convert.ToDouble(size) / 1024 / 5120);
                string accessToken = param["accessToken"];
                if (param["engine"].Equals("ENGINE_MINIO"))
                {
                    string[] token = accessToken.Split(' ');
                    MinioClient minio = new MinioClient(param["url"], token[0], token[1]);
                    minio.SetTraceOn(new MinioLog()
                    {
                        Callback = number =>
                        {
                            double process = Math.Round(Convert.ToDouble(number) / total_minio_chunk_count, 2) * 100;
                            control.pbUpload.Dispatcher.Invoke(new Action(() => { control.pbUpload.Value = process; }));
                        }
                    });
                    upload(minio, uuid, scope, md5, filepath);
                }
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
                control.flushObject(_uuid, _md5, Path.GetFileName(_filepath));
            }

            public void receiveFlush(string _json)
            {
                ReplyStatus status = JsonSerializer.Deserialize<ReplyStatus>(_json);
                control.pbUpload.Visibility = Visibility.Collapsed;
                if (status.code == 0)
                {
                    control.tbUploadSuccess.Visibility = Visibility.Visible;
                }
                else
                {
                    control.tbUploadFailury.Visibility = Visibility.Visible;
                }
                PageExtra.Remove("bucket.md5");
                PageExtra.Remove("bucket.file");
            }

            public void receiveList(string _json)
            {
                ListReply reply = JsonSerializer.Deserialize<ListReply>(_json);
                control.ObjectList.Clear();
                foreach (var e in reply.entity)
                {
                    e._size = formatSize(e.size);
                    control.ObjectList.Add(e);
                }
            }
        }

        public ObjectFacade facade { get; set; }
        public ObservableCollection<ObjectEntity> ObjectList { get; set; }

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

        private void onEditCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
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

        private void onUploadClicked(object sender, RoutedEventArgs e)
        {
            formUploadObject.Visibility = Visibility.Visible;
            formEditObject.Visibility = Visibility.Collapsed;
        }

        private void onRefreshCliked(object sender, RoutedEventArgs e)
        {
            object o_uuid;
            if (!PageExtra.TryGetValue("bucket.uuid", out o_uuid))
                return;
            string uuid = (string)o_uuid;

            var bridge = facade.getViewBridge() as IObjectViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["bucket"] = uuid;
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            string json = JsonSerializer.Serialize(param);
            bridge.OnListSubmit(json);
        }

        private void onSearchClicked(object sender, RoutedEventArgs e)
        {
            //清除页面参数
            PageExtra.Clear();

            var bridge = facade.getViewBridge() as IObjectViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            //param["bucket"] = "";
            string json = JsonSerializer.Serialize(param);
            bridge.OnSearchSubmit(json);
        }

        private void onUploadSubmitClicked(object sender, RoutedEventArgs e)
        {
            formEditObject.Visibility = Visibility.Collapsed;
            formUploadObject.Visibility = Visibility.Visible;
        }

        private void onUploadCancelClicked(object sender, RoutedEventArgs e)
        {
            formUploadObject.Visibility = Visibility.Collapsed;
        }

        private void onOpenFileClicked(object sender, RoutedEventArgs e)
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
