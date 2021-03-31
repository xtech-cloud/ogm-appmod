
using System;
using XTC.oelMVCS;

namespace OGM.Module.File
{
    public class BucketController: Controller
    {
        public const string NAME = "File.BucketController";

        protected override void setup()
        {
            getLogger().Trace("setup BucketController");
        }
    }
}
