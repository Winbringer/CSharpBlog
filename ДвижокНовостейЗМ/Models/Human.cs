using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДвижокНовостейЗМ.Models
{
   public class Human
    {
        public Human()
        {
            this.Name ="Никто";
            this.Age = 0;
            this.Birthplace ="Нигде";
        }
        public Human(string n, int a, string b)
        {
            this.Name = n;
            this.Age = a;
            this.Birthplace = b;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthplace { get; set; }
    }
}
