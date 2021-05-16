using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EventApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserEvent> UserEvents { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}