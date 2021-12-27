
using System.Text.Json;
using System.Collections.Generic;
using HandyControl.Controls;

namespace ogm.group
{
    public class BaseElementUiBridge: IElementUiBridge
    {
        public ElementControl control {get;set;}

        public object getRootPanel()
        {
            return control;
        }

        public virtual void Alert(string _message) {}

        public virtual void UpdatePermission(Dictionary<string, string> _permission) {}



        public virtual void ReceiveAdd(string _json) 
        {
            Reply reply = JsonSerializer.Deserialize<Reply>(_json);
            if (reply.status.code == 0)
                Growl.Success("Success", "StatusGrowl");
            else
                Growl.Warning(reply.status.message, "StatusGrowl");
        }

        public virtual void ReceiveUpdate(string _json) 
        {
            Reply reply = JsonSerializer.Deserialize<Reply>(_json);
            if (reply.status.code == 0)
                Growl.Success("Success", "StatusGrowl");
            else
                Growl.Warning(reply.status.message, "StatusGrowl");
        }

        public virtual void ReceiveList(string _json) 
        {
            Reply reply = JsonSerializer.Deserialize<Reply>(_json);
            if (reply.status.code == 0)
                Growl.Success("Success", "StatusGrowl");
            else
                Growl.Warning(reply.status.message, "StatusGrowl");
        }

        public virtual void ReceiveSearch(string _json) 
        {
            Reply reply = JsonSerializer.Deserialize<Reply>(_json);
            if (reply.status.code == 0)
                Growl.Success("Success", "StatusGrowl");
            else
                Growl.Warning(reply.status.message, "StatusGrowl");
        }

        public virtual void ReceiveRemove(string _json) 
        {
            Reply reply = JsonSerializer.Deserialize<Reply>(_json);
            if (reply.status.code == 0)
                Growl.Success("Success", "StatusGrowl");
            else
                Growl.Warning(reply.status.message, "StatusGrowl");
        }

        public virtual void ReceiveGet(string _json) 
        {
            Reply reply = JsonSerializer.Deserialize<Reply>(_json);
            if (reply.status.code == 0)
                Growl.Success("Success", "StatusGrowl");
            else
                Growl.Warning(reply.status.message, "StatusGrowl");
        }

        public virtual void ReceiveWhere(string _json) 
        {
            Reply reply = JsonSerializer.Deserialize<Reply>(_json);
            if (reply.status.code == 0)
                Growl.Success("Success", "StatusGrowl");
            else
                Growl.Warning(reply.status.message, "StatusGrowl");
        }


    }
}
