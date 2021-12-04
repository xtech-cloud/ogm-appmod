
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.file
{
    public class BucketView: BucketBaseView
    {
        public const string NAME = "ogm.file.BucketView";

        public void OpenObjectUi()
        {
            model.Broadcast("/sidemenu/active/tab", "ogm.file.Object");
        }
    }
}
