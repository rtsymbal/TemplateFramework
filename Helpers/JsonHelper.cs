using Newtonsoft.Json;

namespace TemplateFramework.Helpers
{
    public class JsonHelper
    {
        public static string Serialize(object obj)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}
