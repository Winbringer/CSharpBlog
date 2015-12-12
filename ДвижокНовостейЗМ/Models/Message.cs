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
        public string Title { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Reply> Replys { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public Message()
        {
            Replys = new List<Reply>();
            Tags = new List<Tag>();
        }

    }
}
