using Microsoft.AspNet.Identity.EntityFramework;

namespace ДвижокНовостейЗМ.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public int Year { get; set; }
        public ApplicationUser()
        {
        }
    }
}
