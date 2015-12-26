
using System.ComponentModel.DataAnnotations;

namespace ДвижокНовостейЗМ.Models
{
  public  class File
    {
        [Key]
        public int Id { get; set; }
        public string Ex { get; set; }
        public string FileName
        {
            get { return Id + Ex; }
        }
    }
}
