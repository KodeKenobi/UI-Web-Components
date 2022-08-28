using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using PolicyManagementMailer.Models;

namespace PolicyManagementMailer
{
    public class Mailer
    {
        private IHostingEnvironment _env;
        private readonly IConfiguration _config;

        public Mailer(IHostingEnvironment env, IConfiguration config)
        {
            _env = env;
            _config = config;
        }
        public void SendApprovalNotification(string webRootPath, string userName, string toEmail, string changeLink)
        {
            var pathToFile = webRootPath
                            + Path.DirectorySeparatorChar.ToString()
                            + "Templates"
                            + Path.DirectorySeparatorChar.ToString()
                            + "ApprovalNotification.html";

            var builder = new BodyBuilder();

            //Read the email template
            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {

                builder.HtmlBody = SourceReader.ReadToEnd();
            }

            //Assign values in to email template
            var messageBody = string.Format(builder.HtmlBody, userName, changeLink);

            builder.HtmlBody = messageBody;

            //Build the message to send
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("PIB", "techsupport@mfundopedia.co.za");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress(userName, toEmail);
            message.To.Add(to);

            message.Subject = "Application Approval Notification";

            //Set the email content to be sent
            message.Body = builder.ToMessageBody();

            //Send the email
            Send(message);
        }

        public void SendConfirmationRegistrationEmail(string webRootPath, string userName, string toEmail, string confirmationLink)
        {
            var pathToFile = webRootPath
                            + Path.DirectorySeparatorChar.ToString()
                            + "Templates"
                            + Path.DirectorySeparatorChar.ToString()
                            + "Confirm_Account_Registration.html";

            var builder = new BodyBuilder();

            //Read the email template
            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {

                builder.HtmlBody = SourceReader.ReadToEnd();
            }

            //Assign values in to email template
            var messageBody = string.Format(builder.HtmlBody, confirmationLink);

            builder.HtmlBody = messageBody;

            //Build the message to send
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("PIB", "techsupport@mfundopedia.co.za");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress(userName, toEmail);
            message.To.Add(to);

            message.Subject = "Confirm Account Registration";

            //Set the email content to be sent
            message.Body = builder.ToMessageBody();

            //Send the email
            Send(message);
        }

        public void SendApplicationNotificationEmail(string webRootPath, string userName, string toEmail, string verificationLink)
        {
            var pathToFile = webRootPath
                            + Path.DirectorySeparatorChar.ToString()
                            + "Templates"
                            + Path.DirectorySeparatorChar.ToString()
                            + "Application_Notification.html";

            var builder = new BodyBuilder();

            //Read the email template
            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {

                builder.HtmlBody = SourceReader.ReadToEnd();
            }

            //Assign values in to email template
            var messageBody = string.Format(builder.HtmlBody, verificationLink);

            builder.HtmlBody = messageBody;

            //Build the message to send
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("PIB", "techsupport@mfundopedia.co.za");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress(userName, toEmail);
            message.To.Add(to);

            message.Subject = "Application Notification";

            //Set the email content to be sent
            message.Body = builder.ToMessageBody();

            //Send the email
            Send(message);
        }

        public void SendDeclineApplicationNotificationEmail(string webRootPath, string userName,string reason, string toEmail, string changeLink)
        {
            var pathToFile = webRootPath
                            + Path.DirectorySeparatorChar.ToString()
                            + "Templates"
                            + Path.DirectorySeparatorChar.ToString()
                            + "Application_Decline_Notification.html";

            var builder = new BodyBuilder();

            //Read the email template
            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {

                builder.HtmlBody = SourceReader.ReadToEnd();
            }

            //Assign values in to email template
            var messageBody = string.Format(builder.HtmlBody, userName, reason, changeLink);

            builder.HtmlBody = messageBody;

            //Build the message to send
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("PIB", "techsupport@mfundopedia.co.za");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress(userName, toEmail);
            message.To.Add(to);

            message.Subject = "Application Decline Notification";

            //Set the email content to be sent
            message.Body = builder.ToMessageBody();

            //Send the email
            Send(message);
        }

        private static void Send(MimeMessage message)
        {
            //Set the SMTP
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
            client.Authenticate("techsupport@mfundopedia.co.za", "T3cH@Mfundo123");

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();

        }
        protected string Generate_otp()
        {
            char[] charArr = "0123456789".ToCharArray();
            string strrandom = string.Empty;
            Random objran = new Random();
            for (int i = 0; i < 4; i++)
            {
                //It will not allow Repetation of Characters
                int pos = objran.Next(1, charArr.Length);
                if (!strrandom.Contains(charArr.GetValue(pos).ToString())) strrandom += charArr.GetValue(pos);
                else i--;
            }
            return strrandom;
        }
        public string SendSMS(string MblNo, string Msg)
        {
            string MainUrl = "SMSAPIURL"; //Here need to give SMS API URL
            string SenderId = "SenderId";
            string strMobileno = MblNo;
            string URL = "";
            URL = MainUrl + "&sender_id=" + SenderId + "&message=" + System.Web.HttpUtility.UrlEncode(Msg).Trim() + "&mobile=" + strMobileno.Trim() + "";
            string strResponce = GetResponse(URL);
            string msg = "";
            if (strResponce.Equals("Fail"))
            {
                msg = "Fail";
            }
            else
            {
                msg = strResponce;
            }
            return msg;
        }
        // End SMS Sending function
        // Get Response function
        public static string GetResponse(string smsURL)
        {
            try
            {
                WebClient objWebClient = new System.Net.WebClient();
                System.IO.StreamReader reader = new System.IO.StreamReader(objWebClient.OpenRead(smsURL));
                string ResultHTML = reader.ReadToEnd();
                return ResultHTML;
            }
            catch (Exception)
            {
                return "Fail";
            }
        }
        // End Get Response function
    }
}
