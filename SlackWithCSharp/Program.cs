using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slack.Webhooks;

namespace SlackWithCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter your message to send by slack");
                string message = Console.ReadLine();
                Console.WriteLine("Please mention which channel you want to add this message");
                var channelss = Console.ReadLine();
                
                Console.WriteLine($"Your message '{message}' is sent!");
                SlackClient client = new SlackClient("https://hooks.slack.com/services/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");
                var channels = new List<string>();
                if (channelss.Count()!=0 && channelss.Any())
                {
                    foreach (var channel in channelss.Split(','))
                    {
                       channels.Add( "#" + channel);
                    }
                }
                var slackMessage = new SlackMessage()
                {
                    Username = "Mister X",
                    IconEmoji = ":umbrella:",
                    Channel="#general",
                    Text = message
                };
                
                client.PostToChannels(slackMessage, channels);
            }
       

            //Console.ReadLine();
        }
        public static void SlackMessage(string message)
        {
            string urlWithAccesToken = "https://hooks.slack.com/services/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";
            SlackClient client = new SlackClient(urlWithAccesToken);
           // client.PostMessage(text:message, userName:"vhoagamo6", channel: "#general", iconEmoji:":umbrella:");

            //"https://{your_account}.slack.com/services/hooks/incoming-webhook?token={your_access_token}";
        }
    }
}
