
using System.Text.Json;
using System.Collections.Generic;
using HandyControl.Controls;

namespace ogm.actor
{
    public class BaseGuardUiBridge: IGuardUiBridge
    {
        public GuardControl control {get;set;}

        public object getRootPanel()
        {
            return control;
        }

        public virtual void Alert(string _message) {}

        public virtual void UpdatePermission(Dictionary<string, string> _permission) {}



        public virtual void ReceiveFetch(string _json) 
        {
            Reply reply = JsonSerializer.Deserialize<Reply>(_json);
            if (reply.status.code == 0)
                Growl.Success("Success", "StatusGrowl");
            else
                Growl.Warning(reply.status.message, "StatusGrowl");
        }

        public virtual void ReceiveEdit(string _json) 
        {
            Reply reply = JsonSerializer.Deserialize<Reply>(_json);
            if (reply.status.code == 0)
                Growl.Success("Success", "StatusGrowl");
            else
                Growl.Warning(reply.status.message, "StatusGrowl");
        }

        public virtual void ReceiveDelete(string _json) 
        {
            Reply reply = JsonSerializer.Deserialize<Reply>(_json);
            if (reply.status.code == 0)
                Growl.Success("Success", "StatusGrowl");
            else
                Growl.Warning(reply.status.message, "StatusGrowl");
        }


    }
}
