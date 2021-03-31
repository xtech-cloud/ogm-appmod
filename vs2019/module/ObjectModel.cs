
using System;
using XTC.oelMVCS;

namespace OGM.Module.File
{
    public class ObjectModel : Model
    {
        public const string NAME = "File.ObjectModel";

        public class ObjectStatus : Model.Status
        {
            public const string NAME = "File.ObjectStatus";
        }

        protected override void preSetup()
        {
            Error err;
            status_ = spawnStatus<ObjectStatus>(ObjectStatus.NAME, out err);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ObjectModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(ObjectStatus.NAME, out err);
        }

        private ObjectStatus status
        {
            get
            {
                return status_ as ObjectStatus;
            }
        }
    }
}
