using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДвижокНовостейЗМ.Models
{
  public  class VisitsTable
    {
        [Key]
        public string Url { get; set; }
        public int Count { get; set; }
    }
}
