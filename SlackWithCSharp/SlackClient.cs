using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SlackWithCSharp
{
    public sealed class SlackClient
    {
        private readonly Uri _uri;
        private readonly Encoding _encoding = new UTF8Encoding();
        public SlackClient(string urlWithAccessToken)
        {
            _uri = new Uri(urlWithAccessToken);
        }

        public void PostMessage(string text, string userName=null, string channel = null, string iconEmoji=null)
        {
            SlackMessage message = new SlackMessage()
            {
                Channel=channel,
                UserName=userName,
                Text=text
               
            };
            PostMessage(message);
        }
        public void PostMessage(SlackMessage message)
        {
            using (WebClient client=new WebClient())
            {
                NameValueCollection data = new NameValueCollection();
                data["payload"] = JsonConvert.SerializeObject(message);
                var response = client.UploadValues(_uri, "POST", data);
                string responseText = _encoding.GetString(response);
            }
        }

       

    }
}
