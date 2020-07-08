using Newtonsoft.Json;

namespace SlackWithCSharp
{
    public class SlackMessage
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("usernam")]
        public string UserName { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("icon_emoji")]
        public string Icon
        {
            get
            {
                return ":umbrella:";
            }
           
        }

    }
}
