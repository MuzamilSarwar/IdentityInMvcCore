using IdentityCore.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityCore.Repository
{
    public class OathRepo : IOathRepo
    {
        private readonly UserManager<IdentityUser> userManager;

        public OathRepo(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpDto obj)
        {
            var user = new IdentityUser()
            {
                Email = obj.Email,
                UserName = obj.Email
            };
            var result = await userManager.CreateAsync(user, obj.Password);
            return result;
        }
    }
}
