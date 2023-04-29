namespace IdentityCore.EmailServices
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}