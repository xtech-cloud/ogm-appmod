
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.file
{
    public class BucketViewBridge : BucketBaseViewBridge, IBucketExtendViewBridge
    {
        public void OnOpenObjectUi()
        {
            view.OpenObjectUi();
        }
    }
}
