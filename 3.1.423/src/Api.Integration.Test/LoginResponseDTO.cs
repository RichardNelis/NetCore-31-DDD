using System;
using Newtonsoft.Json;

namespace Api.Integration.Test
{
    public class LoginResponseDTO
    {
        [JsonProperty("auhenticated")]
        public bool Authenticated { get; set; }

        [JsonProperty("create")]
        public DateTime Create { get; set; }

        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
