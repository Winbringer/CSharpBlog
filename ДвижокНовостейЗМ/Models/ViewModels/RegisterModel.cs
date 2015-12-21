using System;
using System.ComponentModel.DataAnnotations;
using ДвижокНовостейЗМ.Models.Identity;

namespace ДвижокНовостейЗМ.Models.ViewModels
{
   public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Адресс электронной почты")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Возраст")]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Пол")]      
        public Sex Sex { get; set; }

        [Required]
        [Display(Name ="Имя пользователя")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20,MinimumLength =4, ErrorMessage ="Пароль должень быть не короче 6 символо и не длиннее 20")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
