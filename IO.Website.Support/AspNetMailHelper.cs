using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace IO.Website.Support
{
    public class AspNetMailHelper
    {
        SmtpClient _SmtpClient = default(SmtpClient);

        public AspNetMailHelper(string smtpServer)
        {
            _SmtpClient = new SmtpClient(smtpServer);
        }

        public AspNetMailHelper(string smtpServer, int port, bool useSSL, string username, string password)
        {
            _SmtpClient = new SmtpClient(smtpServer, port);
            _SmtpClient.Credentials = new NetworkCredential(username, password);
            _SmtpClient.EnableSsl = useSSL;
        }

        public void SendHtmlMail(string from, string to, string subject, string htmlContent)
        {
            MailMessage message = new MailMessage(from, to);
            message.Body = htmlContent;
            message.BodyEncoding = UTF8Encoding.UTF8;
            message.IsBodyHtml = true;
            message.Subject = subject;
            _SmtpClient.Send(message);
        }

        public void SendHtmlMail(string from, string to, string subject, string htmlContent, string attachmentName, byte[] attachmentData)
        {
            MailMessage message = new MailMessage(from, to);
            message.Body = htmlContent;
            message.BodyEncoding = UTF8Encoding.UTF8;
            message.IsBodyHtml = true;
            message.Subject = subject;
            using (MemoryStream attachmentMemoryStream = new MemoryStream(attachmentData))
            {
                message.Attachments.Add(new Attachment(attachmentMemoryStream, attachmentName));
                _SmtpClient.Send(message);
            }            
            
        }

        public void SendHtmlMail(string from, string to, string subject, string htmlContent, Dictionary<string, object> tokens)
        {
            string combinedHtmlContent = htmlContent;
            foreach (KeyValuePair<string, object> token in tokens)
            {
                combinedHtmlContent = combinedHtmlContent.Replace(token.Key, token.Value.ToString());
            }
            MailMessage message = new MailMessage(from, to);
            message.Body = combinedHtmlContent;
            message.BodyEncoding = UTF8Encoding.UTF8;
            message.IsBodyHtml = true;
            message.Subject = subject;

            _SmtpClient.Send(message);
        }

        public void SendHtmlMail(string from, string to, string subject, string htmlContent, Dictionary<string, object> tokens, string attachmentName, byte[] attachmentData)
        {
            string combinedHtmlContent = htmlContent;
            foreach (KeyValuePair<string, object> token in tokens)
            {
                combinedHtmlContent = combinedHtmlContent.Replace(token.Key, token.Value.ToString());
            }
            MailMessage message = new MailMessage(from, to);
            message.Body = combinedHtmlContent;
            message.BodyEncoding = UTF8Encoding.UTF8;
            message.IsBodyHtml = true;
            message.Subject = subject;
            using (MemoryStream attachmentMemoryStream = new MemoryStream(attachmentData))
            {
                message.Attachments.Add(new Attachment(attachmentMemoryStream, attachmentName));
                _SmtpClient.Send(message);
            }            
        }

        public void SendTextMail(string from, string to, string subject, string textContent)
        {
            MailMessage message = new MailMessage(from, to);
            message.Body = textContent;
            message.BodyEncoding = UTF8Encoding.UTF8;
            message.IsBodyHtml = false;
            message.Subject = subject;
            _SmtpClient.Send(message);
        }

        public void SendTextMail(string from, string to, string subject, string textContent, string attachmentName, byte[] attachmentData)
        {
            MailMessage message = new MailMessage(from, to);
            message.Body = textContent;
            message.BodyEncoding = UTF8Encoding.UTF8;
            message.IsBodyHtml = false;
            message.Subject = subject;
            using (MemoryStream attachmentMemoryStream = new MemoryStream(attachmentData))
            {
                message.Attachments.Add(new Attachment(attachmentMemoryStream, attachmentName));
                _SmtpClient.Send(message);
            }
        }

        public void SendTextMail(string from, string to, string subject, string textContent, Dictionary<string, object> tokens)
        {
            string combinedTextContent = textContent;
            foreach (KeyValuePair<string, object> token in tokens)
            {
                combinedTextContent = combinedTextContent.Replace(token.Key, token.Value.ToString());
            }
            MailMessage message = new MailMessage(from, to);
            message.Body = combinedTextContent;
            message.BodyEncoding = UTF8Encoding.UTF8;
            message.IsBodyHtml = false;
            message.Subject = subject;

            _SmtpClient.Send(message);
        }

        public void SendTextMail(string from, string to, string subject, string textContent, Dictionary<string, object> tokens, string attachmentName, byte[] attachmentData)
        {
            string combinedTextContent = textContent;
            foreach (KeyValuePair<string, object> token in tokens)
            {
                combinedTextContent = combinedTextContent.Replace(token.Key, token.Value.ToString());
            }
            MailMessage message = new MailMessage(from, to);
            message.Body = combinedTextContent;
            message.BodyEncoding = UTF8Encoding.UTF8;
            message.IsBodyHtml = true;
            message.Subject = subject;
            using (MemoryStream attachmentMemoryStream = new MemoryStream(attachmentData))
            {
                message.Attachments.Add(new Attachment(attachmentMemoryStream, attachmentName));
                _SmtpClient.Send(message);
            }
        }

    }
}
