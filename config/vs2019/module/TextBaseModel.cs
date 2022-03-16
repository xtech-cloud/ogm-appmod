
using System;
using XTC.oelMVCS;

namespace ogm.config
{
    public class TextBaseModel : Model
    {

        public class TextBaseStatus : Model.Status
        {
            public const string NAME = "ogm.config.TextStatus";
        }

        protected TextController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(TextController.NAME) as TextController;
            Error err;
            status_ = spawnStatus<TextModel.TextStatus>(TextModel.TextStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.config.TextStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.config.TextModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(TextModel.TextStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected TextModel.TextStatus status
        {
            get
            {
                return status_ as TextModel.TextStatus;
            }
        }


        public virtual void SaveWrite(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/config/Text/Write", _rsp);
        }


        public virtual void SaveRead(Proto.TextReadResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/config/Text/Read", _rsp);
        }


        public virtual void SaveDelete(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/config/Text/Delete", _rsp);
        }


        public virtual void SaveGet(Proto.TextGetResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/config/Text/Get", _rsp);
        }


        public virtual void SaveList(Proto.TextListResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/config/Text/List", _rsp);
        }


        public virtual void SaveSearch(Proto.TextSearchResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/config/Text/Search", _rsp);
        }



    }
}
