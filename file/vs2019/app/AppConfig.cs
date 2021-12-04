
using System.Text.Json;
using XTC.oelMVCS;

namespace app
{
    class ConfigSchema
    {
        public string domain {get;set;}
        public string apikey {get;set;}
    }
    class AppConfig: Config
    {
        public override void Merge(string _content)
        {
            ConfigSchema schema = JsonSerializer.Deserialize<ConfigSchema>(_content);
            fields_["domain"] = Any.FromString(schema.domain);
            fields_["apikey"] = Any.FromString(schema.apikey);
        }
    }//class
}//namespace
