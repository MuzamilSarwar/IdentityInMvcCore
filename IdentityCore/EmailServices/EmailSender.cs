using IdentityCore.Models;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace IdentityCore.EmailServices
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfigration emailConfigration;

        public EmailSender(EmailConfigration emailConfigration)
        {
            this.emailConfigration = emailConfigration;
        }
        public void SendEmail(Message message)
        {
            var emailMessage = createEmailMessage(message);
            Send(emailMessage);
        }

        private MimeMessage createEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(MailboxAddress.Parse(emailConfigration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }
        private void Send(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.Connect(emailConfigration.SmtpServer, emailConfigration.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(emailConfigration.Username, emailConfigration.Password);

                client.Send(message);
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
