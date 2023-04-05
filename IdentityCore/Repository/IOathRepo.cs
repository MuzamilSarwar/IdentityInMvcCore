using IdentityCore.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityCore.Repository
{
    public interface IOathRepo
    {
        Task<IdentityResult> CreateUserAsync(SignUpDto obj);
        Task<SignInResult> LoginAsync(SignInDto obj);
        Task logout();
    }
}