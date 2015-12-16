using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДвижокНовостейЗМ.Models
{
   public class Message
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Заголовок")]
        public string Title { get; set; }
        [Display(Name ="Текст новости")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        [Display(Name ="Дата публикации")]
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
