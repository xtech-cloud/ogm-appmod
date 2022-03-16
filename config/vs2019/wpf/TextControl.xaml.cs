using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ogm.config
{
    public partial class TextControl : UserControl
    {
        public class TextUiBridge : BaseTextUiBridge, ITextExtendUiBridge
        {
            public override void UpdatePermission(Dictionary<string, string> _permission)
            {
                control.PermissionCreate = _permission.ContainsKey("/ogm/config/Text/Create");
                control.PermissionEdit = _permission.ContainsKey("/ogm/config/Text/Update");
                control.PermissionDelete = _permission.ContainsKey("/ogm/config/Text/Delete");
            }

            public override void ReceiveWrite(string _json)
            {
                base.ReceiveWrite(_json);
                Reply reply = JsonSerializer.Deserialize<Reply>(_json);
                if(reply.status.code == 0)
                {
                    control.formNewText.Visibility = Visibility.Collapsed;
                    control.listText();
                }
            }

            public override void ReceiveList(string _json)
            {
                base.ReceiveList(_json);
                TextListReply reply = JsonSerializer.Deserialize<TextListReply>(_json);
                control.TextList.Clear();
                foreach(var e in reply.entity)
                {
                    control.TextList.Add(e);
                }
            }

            public override void ReceiveSearch(string _json)
            {
                ReceiveList(_json);
            }

            public void HandleTabActivated()
            {
                if(string.IsNullOrEmpty(control.tbPath.Text) && control.TextList.Count == 0)
                    control.listText();
            }
        }

        public TextFacade facade { get; set; }
        public ObservableCollection<TextEntity> TextList { get; set; }

        public static readonly DependencyProperty PermissionCreateProperty = DependencyProperty.Register("PermissionCreate", typeof(bool), typeof(TextControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionDeleteProperty = DependencyProperty.Register("PermissionDelete", typeof(bool), typeof(TextControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionEditProperty = DependencyProperty.Register("PermissionEdit", typeof(bool), typeof(TextControl), new PropertyMetadata(true));

        public bool PermissionCreate
        {
            get { return (bool)GetValue(PermissionCreateProperty); }
            set { SetValue(PermissionCreateProperty, value); }
        }
        public bool PermissionDelete
        {
            get { return (bool)GetValue(PermissionDeleteProperty); }
            set { SetValue(PermissionDeleteProperty, value); }
        }
        public bool PermissionEdit
        {
            get { return (bool)GetValue(PermissionEditProperty); }
            set { SetValue(PermissionEditProperty, value); }
        }

        public TextControl()
        {
            TextList = new ObservableCollection<TextEntity>();
            InitializeComponent();
            formNewText.Visibility = Visibility.Collapsed;
        }

        private void onResetCliked(object sender, System.Windows.RoutedEventArgs e)
        {
            formNewText.Visibility = Visibility.Collapsed;
            tbPath.Text = "";
            listText();
        }

        private void onSearchClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formNewText.Visibility = Visibility.Collapsed;
            if(string.IsNullOrEmpty(tbPath.Text))
                listText();
            else
                searchText(tbPath.Text);
        }

        private void onNewSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["path"] = tbNewPath.Text;
            param["content"] = tbNewPath.Text;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as ITextViewBridge;
            bridge.OnWriteSubmit(json);
        }

        private void onNewCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formNewText.Visibility = Visibility.Collapsed;
        }

        private void onCreateClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formNewText.Visibility = Visibility.Visible;
        }

        private void onTextSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            formNewText.Visibility = Visibility.Collapsed;
        }

        private void onEditTextClicked(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void onDeleteTextClicked(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void listText()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as ITextViewBridge;
            bridge.OnListSubmit(json);
        }
        private void searchText(string _path)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            param["path"] = _path;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as ITextViewBridge;
            bridge.OnSearchSubmit(json);
        }
    }
}
