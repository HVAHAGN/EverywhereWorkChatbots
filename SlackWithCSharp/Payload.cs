using Newtonsoft.Json;

namespace SlackWithCSharp
{
    public class Payload
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("usernam")]
        public string UserName { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

    }
}
