using IdentityCore.Models;

namespace IdentityCore.Helper
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions emailOptions);
    }
}