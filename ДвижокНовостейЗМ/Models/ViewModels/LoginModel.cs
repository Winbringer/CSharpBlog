using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДвижокНовостейЗМ.Models.ViewModels
{
   public class LoginModel
    {
        [Required]
        [Display(Name ="Имя")]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
