using Newtonsoft.Json;

namespace TemplateFramework.Models
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
    }
}
