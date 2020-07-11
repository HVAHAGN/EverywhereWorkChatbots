using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SendEmailWithSMTP
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter your message that you want to send");
            string message = Console.ReadLine();
            if (!string.IsNullOrEmpty(message))
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("vhoagamo2@gmail.com", "Vahagn H");
                    mail.To.Add("vahagn.hovhannisyan0203@gmail.com");
                    mail.To.Add("vhoagamo6@gmail.com");
                    mail.Subject = "Error message from Umbrella";
                    mail.Body = message;
                    mail.IsBodyHtml = true;
                    // mail.Attachments.Add(new Attachment("C:\\file.zip"));

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential(userName: "vhoagamo2@gmail.com", password: "133171vhan");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                    Console.WriteLine("Your Message is sent successfuly!");
                }
               
            }
            else
            {
                Console.WriteLine("Please enter message");
            }

            Console.ReadLine();
        }

        private static void Smtp_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error!=null)
            {
                Console.WriteLine(e.Error.Message+"some error occured");
            }
        }

        public static async Task SendEmail(string toEmailAddress, string emailSubject, string emailMessage)
        {
            var message = new MailMessage();
            message.To.Add(toEmailAddress);

            message.Subject = emailSubject;
            message.Body = emailMessage;

            using (var smtpClient = new SmtpClient())
            {
                await smtpClient.SendMailAsync(message);
            }
        }
    }
}
