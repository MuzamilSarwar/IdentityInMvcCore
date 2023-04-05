using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityCore.Data
{
    public class ProjectContext : IdentityDbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options): base(options) { }

        
          
    }
}
