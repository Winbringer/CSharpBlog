using Microsoft.AspNet.Identity.EntityFramework;

namespace ДвижокНовостейЗМ.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public int Year { get; set; }        
        public Sex Sex { get; set; }
        public string FIO { get; set; }
        public ApplicationUser()
        {
        }
    }
    public enum Sex
    {
        Мужской,
        Женский
    }
}
