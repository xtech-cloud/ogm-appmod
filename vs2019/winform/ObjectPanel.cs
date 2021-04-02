
using System;
using System.Windows.Forms;
using XTC.oelMVCS;

namespace OGM.Module.File
{
    public partial class ObjectPanel : UserControl
    {
        public class ObjectUiBridge : IObjectUiBridge
        {
            public ObjectPanel panel { get; set; }

            public object getRootPanel()
            {
                return panel;
            }

            public void Alert(string _message)
            {
                MessageBox.Show(_message);
            }
        }

        public ObjectFacade facade { get; set; }

        public ObjectPanel()
        {
            InitializeComponent();

            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Location = new System.Drawing.Point(10, 10);
            this.Name = "rootPanel";
            this.TabIndex = 0;
        }
    }
}
