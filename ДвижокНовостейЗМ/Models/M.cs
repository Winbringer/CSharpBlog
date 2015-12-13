using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДвижокНовостейЗМ.Models
{
    public class M
    {
        public delegate double Operation(double x, double y);
        public double Oper(double x, double y, Operation op)
        {
            return op(x, y);
        }
    }
}
