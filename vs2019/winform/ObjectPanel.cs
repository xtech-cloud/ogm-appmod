
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
        }

        public ObjectFacade facade { get; set; }

        public ObjectPanel()
        {
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Location = new System.Drawing.Point(1, -3);
            this.Name = "rootPanel";
            this.Size = new System.Drawing.Size(1050, 801);
            this.TabIndex = 0;

            InitializeComponent();
        }
    }
}
