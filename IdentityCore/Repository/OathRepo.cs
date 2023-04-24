using IdentityCore.Helper;
using IdentityCore.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityCore.Repository
{
    public class OathRepo : IOathRepo
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IGenralPurpose genralPurpose;

        public OathRepo(UserManager<User> userManager, SignInManager<User> signInManager,
            IGenralPurpose genralPurpose)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.genralPurpose = genralPurpose;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpDto obj)
        {
            var user = new User()
            {
                FirstName= obj.FirstName,
                LastName= obj.LastName,
                ProfileImage = obj.ProfileImage,
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

        public async Task<IdentityResult> ChnagePasswordAsync(ChangePasswordDto obj)
        {
            var userId = genralPurpose.GetLogedInUserId();
            
            
            var userget = await userManager.FindByIdAsync(userId);
            var result = await userManager.ChangePasswordAsync(userget, obj.OldPassword, obj.NewPassword);
            return result;
            
            
        }
    }
}
