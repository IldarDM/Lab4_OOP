using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFigures.Operators
{
    public static class OperatorContainer
    {
        public static List<Operator> operators = new List<Operator>();
        static OperatorContainer()
        {
            operators.Add(new Operator('R'));
            operators.Add(new Operator('M'));
            operators.Add(new Operator('D'));
            operators.Add(new Operator(','));
            operators.Add(new Operator('('));
            operators.Add(new Operator(')'));
        }
        public static Operator FindOperator(char s)
        {
            foreach(Operator op in operators)
            {
                if(op.symbolOperator == s)
                {
                    return op;
                }
            }
            return null;
        }
    }
}
