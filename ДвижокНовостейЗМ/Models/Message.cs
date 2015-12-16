using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ДвижокНовостейЗМ.Models
{
   public class Message
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Заголовок")]
        [Required(ErrorMessage ="Заголовок не задан")]
        [StringLength(5000,MinimumLength =3)]
        [Remote("CheckTitle", "Messages",ErrorMessage = "Новость с таким заголовком уже есть в БД")]
        public string Title { get; set; }

        [Display(Name ="Текст новости")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Текст новости не задан")]
        public string Text { get; set; }

        [Display(Name ="Дата публикации")]
        [Required(ErrorMessage = "Не указана дата публикации")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ConvertEmptyStringToNull =true,DataFormatString ="{0:d}",NullDisplayText ="Дата не указана",ApplyFormatInEditMode =true)]
        public DateTime PubDate { get; set; }
        public virtual ICollection<Reply> Replys { get; set; }        
        public virtual ICollection<Tag> Tags { get; set; }
        public Message()
        {
            Replys = new List<Reply>();
            Tags = new List<Tag>();
        }

    }
}
