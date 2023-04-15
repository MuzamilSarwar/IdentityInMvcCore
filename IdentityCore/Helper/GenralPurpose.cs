using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace IdentityCore.Helper
{
    public class GenralPurpose : IGenralPurpose
    {
        private readonly IHttpContextAccessor httpContext;

        public GenralPurpose(IHttpContextAccessor httpContext)
        {
            this.httpContext = httpContext;
        }
        //Code for getting logedInd user Id in Controller
        public string GetLogedInUserId()
        {
            string result = httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            //can also be achive by this way
            //return httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return result;
        }

        //code for checking that the user is loggedin or not
        public bool IsAuthenticated()
        {
            return httpContext.HttpContext.User.Identity.IsAuthenticated;
            
           
        }
    }
}
