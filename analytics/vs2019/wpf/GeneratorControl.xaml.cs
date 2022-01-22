using System.Windows.Controls;
using System.Collections.Generic;
using System.Text.Json;
using HandyControl.Controls;
using System.Collections.ObjectModel;
using System.IO;

namespace ogm.analytics
{
    public partial class GeneratorControl : UserControl
    {
        public class GeneratorUiBridge : BaseGeneratorUiBridge, IGeneratorExtendUiBridge
        {
            public override void Alert(string _message)
            {
                Growl.Warning(_message, "StatusGrowl");
            }

            public override void ReceiveRecord(string _json)
            {
                control.ActivityList.Clear();
                var reply = JsonSerializer.Deserialize<GeneratorRecordReply>(_json);
                if (reply.status.code != 0)
                {
                    Alert(reply.status.message);
                    return;
                }

                if(string.IsNullOrEmpty(reply.content))
                {
                    return;
                }

                try
                {
                    byte[] contnet = System.Convert.FromBase64String(reply.content.Replace("-", "/").Replace("_", "+"));
                    string json = System.Text.Encoding.UTF8.GetString(contnet);
                    ActivityEntity[] activity = System.Text.Json.JsonSerializer.Deserialize<ActivityEntity[]>(json);
                    foreach(var e in activity)
                    {
                        control.ActivityList.Add(e);
                    }
                }
                catch (System.Exception ex)
                {
                    Alert(ex.Message);
                }

            }
        }

        public GeneratorFacade facade { get; set; }
        public ObservableCollection<ActivityEntity> ActivityList { get; set; }

        public GeneratorControl()
        {
            ActivityList = new ObservableCollection<ActivityEntity>();
            InitializeComponent();
        }

        private void onResetCliked(object sender, System.Windows.RoutedEventArgs e)
        {
            tbAppID.Text = "";
            tbDeviceID.Text = "";
            tbUserID.Text = "";
            tbEventID.Text = "";
            tbEventParameter.Text = "";
            generateRecord();
        }

        private void onSearchClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            generateRecord();
        }

        private void generateRecord()
        {
            var bridge = facade.getViewBridge() as IGeneratorViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            param["appID"] = tbAppID.Text;
            param["deviceID"] = tbDeviceID.Text;
            param["userID"] = tbUserID.Text;
            param["eventID"] = tbEventID.Text;
            param["eventParameter"] = tbEventParameter.Text;
            string json = JsonSerializer.Serialize(param);
            bridge.OnRecordSubmit(json);
        }

    }
}
