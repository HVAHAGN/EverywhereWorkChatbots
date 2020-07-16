using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

                //Regex reg = new Regex(@"/([#&][^\x07\x2C\s]{,200})/");
                //Match match;
                //var results = new List<string>();
                //for (match=reg.Match(channelss); match.Success; match=match.NextMatch())
                //{
                //    if (!results.Contains(match.Value))
                //    {
                //        results.Add(match.Value);
                //    }
                //}
                
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
                var a = new SlackAttachment();
                a.AuthorLink = @"C:\temp\data.txt";
               // slackMessage.Attachments.Add(a);
                // client.PostToChannels(slackMessage, channels);
                client.PostToChannels(slackMessage,channels);
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
