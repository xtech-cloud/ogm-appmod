
using System;
using XTC.oelMVCS;

namespace ogm.license
{
    public class CertificateBaseModel : Model
    {

        public class CertificateBaseStatus : Model.Status
        {
            public const string NAME = "ogm.license.CertificateStatus";
        }

        protected CertificateController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(CertificateController.NAME) as CertificateController;
            Error err;
            status_ = spawnStatus<CertificateModel.CertificateStatus>(CertificateModel.CertificateStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.license.CertificateStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.license.CertificateModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(CertificateModel.CertificateStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected CertificateModel.CertificateStatus status
        {
            get
            {
                return status_ as CertificateModel.CertificateStatus;
            }
        }


        public virtual void SaveGet(Proto.CerGetResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/license/Certificate/Get", _rsp);
        }


        public virtual void SaveList(Proto.CerListResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/license/Certificate/List", _rsp);
        }


        public virtual void SaveSearch(Proto.CerListResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/license/Certificate/Search", _rsp);
        }



    }
}
