
using System;
using XTC.oelMVCS;

namespace OGM.Module.File
{
    public class ObjectController: Controller
    {
        public const string NAME = "File.ObjectController";

        protected override void setup()
        {
            getLogger().Trace("setup ObjectController");
        }
    }
}
