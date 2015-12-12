


using System.Data.Entity;

namespace ДвижокНовостейЗМ.Models
{
    class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("DefaultConnection")
        {
        }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Reply> Replys { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
