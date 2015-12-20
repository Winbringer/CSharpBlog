


using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using ДвижокНовостейЗМ.Models.Identity;

namespace ДвижокНовостейЗМ.Models
{
    class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext() : base("DefaultConnection")
        {
        }
        public static ApplicationDBContext Create()
        {
            return new ApplicationDBContext();
        }        
        public DbSet<Message> Messages { get; set; }
        public DbSet<Reply> Replys { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
