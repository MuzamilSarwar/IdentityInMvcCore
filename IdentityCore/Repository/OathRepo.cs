using IdentityCore.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityCore.Repository
{
    public class OathRepo : IOathRepo
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public OathRepo(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpDto obj)
        {
            var user = new User()
            {
                Email = obj.Email,
                UserName = obj.Email
            };
            var result = await userManager.CreateAsync(user, obj.Password);
            return result;
        }

        public async Task<SignInResult> LoginAsync(SignInDto obj)
        {
            var result =  await signInManager.PasswordSignInAsync(obj.Email, obj.Password,obj.RemaberMe,false);
            return result;
        }

        public async Task logout()
        {
            await signInManager.SignOutAsync();
        }
    }
}
