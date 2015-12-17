using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДвижокНовостейЗМ.Models
{
  public  class Reply
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Введите текст ответа!")]
        [DataType(DataType.MultilineText)]
        [Display(Name ="Текст ответа")]
        public string Text { get; set; }
        [Display(Name ="Дата ответа")]
        public DateTime Date { get; set; }
        public virtual Message Message { get; set; }       
    }
}
