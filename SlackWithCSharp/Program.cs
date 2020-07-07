using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                SlackMessage(message);
                Console.WriteLine("Your message is sent!");
                Console.Clear();
            }
       

            //Console.ReadLine();
        }
        public static void SlackMessage(string message)
        {
            string urlWithAccesToken = "https://hooks.slack.com/services/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";
            SlackClient client = new SlackClient(urlWithAccesToken);
            client.PostMessage(text:message, channel: "#general");

            //"https://{your_account}.slack.com/services/hooks/incoming-webhook?token={your_access_token}";
        }
    }
}
