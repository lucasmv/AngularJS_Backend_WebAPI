using Newtonsoft.Json;

namespace TesteWebAPI.Models
{
    public class UserTeste
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}