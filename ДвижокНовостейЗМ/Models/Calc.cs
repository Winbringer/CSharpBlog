using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДвижокНовостейЗМ.Models
{
    class Calc
    {
        int x;
        int y;
        char oper;
        public Calc(int x, int y, char oper)
        {
            this.x = x;
            this.y = y;
            this.oper = oper;
        }
        public int Res()
        {
            switch (oper)
            {
                case '+': return x + y;
                case '-': return x - y;
                case '*': return x * y;
                case '/': return x / y;
                default: return 0;
            }
        }
    }
}
