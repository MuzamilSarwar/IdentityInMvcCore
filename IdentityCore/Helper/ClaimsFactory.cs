using IdentityCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace IdentityCore.Helper
{
    public class ClaimsFactory : UserClaimsPrincipalFactory<User, IdentityRole>
    {
        public ClaimsFactory( UserManager<User> userManager , RoleManager<IdentityRole> roleManager ,
            IOptions<IdentityOptions> options) : base(userManager, roleManager, options) { }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await  base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("UserFirstName", user.FirstName ?? ""));
            identity.AddClaim(new Claim("UserLastName", user.LastName ?? ""));
            identity.AddClaim(new Claim("UserId", user.Id.ToString() ));


            return identity;
        }

    }
}
