using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Operations
{
    public abstract class Operation 
    {
        public double firstValue { get; set; }
        public double secondValue { get; set; }

        public abstract double doOperation();
    }

    // summation

    public class Plus : Operation
    {
        public override double doOperation()
        {
            return firstValue + secondValue;
        }
    }

    public class Minus : Operation
    {
        public override double doOperation()
        {
            return firstValue - secondValue;
        }
    }

    public class Multiply : Operation
    {
        public override double doOperation()
        {
            return firstValue * secondValue;
        }
    }

    public class Divide : Operation
    {
        public override double doOperation()
        {
            if (secondValue != 0)
            {
                return firstValue / secondValue;
            }
            else
            {
                MessageBox.Show("Деление на ноль!");
                return firstValue;
            }
        }
    }
}

