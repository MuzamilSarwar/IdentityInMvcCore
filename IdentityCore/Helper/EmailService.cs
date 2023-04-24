using IdentityCore.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace IdentityCore.Helper
{
    public class EmailService : IEmailService
    {
        private const string templatePath = @"EmailTemplate/{0}.html";
        private readonly SmtpConfigModel smtpConfig;

        public EmailService(IOptions<SmtpConfigModel> smtpConfig)
        {
            this.smtpConfig = smtpConfig.Value;
        }

        public async Task SendTestEmail(UserEmailOptions emailOptions)
        {
            emailOptions.Subject = "Testing Email";
            emailOptions.Body = GetEmailBody("TestEmail");

            await SendEmail(emailOptions);

        }
        private async Task SendEmail(UserEmailOptions userEmailOptions)
        {
            MailMessage mail = new MailMessage
            {
                Subject = userEmailOptions.Subject,
                Body = userEmailOptions.Body,
                From = new MailAddress(smtpConfig.SenderAddress, smtpConfig.SenderDisplayName),
                IsBodyHtml = smtpConfig.IsBodyHTML,

            };
            foreach (var toEmail in userEmailOptions.ToEmails)
            {
                mail.To.Add(toEmail);
            }
            NetworkCredential networkCredential = new NetworkCredential(smtpConfig.UserName, smtpConfig.Password);
            SmtpClient smtpClient = new SmtpClient
            {
                Host = smtpConfig.Host,
                Port = smtpConfig.Port,
                EnableSsl = smtpConfig.EnableSSL,
                UseDefaultCredentials = smtpConfig.UseDefaultCredentials,
                Credentials = networkCredential
            };
            mail.BodyEncoding = Encoding.Default;
            await smtpClient.SendMailAsync(mail);
        }
        private string GetEmailBody(string templateName)
        {
            var body = File.ReadAllText(string.Format(templatePath, templateName));
            return body;
        }
    }
}
