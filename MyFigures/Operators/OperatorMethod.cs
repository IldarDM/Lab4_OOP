using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFigures.Operators
{
    public class OperatorMethod
    {
        public delegate void EmptyOperatorMethod();
        public delegate void UnaryOperatorMethod(Object operand);
        public delegate void BinaryOperatorMethod(Object operand1, Object operand2);
    }
}
