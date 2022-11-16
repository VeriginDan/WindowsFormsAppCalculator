using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Operations;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        protected Operation curOp;

        public Form1()
        {
            InitializeComponent();
            btn1.Click += btnNumbers;
            btn2.Click += btnNumbers;
            btn3.Click += btnNumbers;
            btn4.Click += btnNumbers;
            btn5.Click += btnNumbers;
            btn6.Click += btnNumbers;
            btn7.Click += btnNumbers;
            btn8.Click += btnNumbers;
            btn9.Click += btnNumbers;
            btn0.Click += btnNumbers;
            btnComma.Click += btnNumbers;
        }

        private void btnNumbers(object sender, EventArgs e)
        {
            textBox1.Text += ((Button)sender).Tag.ToString();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (curOp == null)
            {
                curOp = new Plus();
                initOperation();
            }
            else
                calc();
        }

        private void initOperation()
        {
            curOp.firstValue = ConvertToDouble(textBox1.Text);
            textBox1.Text = string.Empty;
        }

        CultureInfo commaCulture = new CultureInfo("en")
        {
            NumberFormat =
            {
                NumberDecimalSeparator = ","
            }
        };
        
        CultureInfo pointCulture = new CultureInfo("ru")
        {
            NumberFormat =
            {
                NumberDecimalSeparator = "."
            }
        };

        public double ConvertToDouble (string input)
        {
            input = input.Trim();
            if (input.Contains(",") && input.Split(',').Length == 2)
            {
                return Convert.ToDouble(input, commaCulture);
            }
            if (input.Contains(".") && input.Split('.').Length == 2)
            {
                return Convert.ToDouble(input, pointCulture);
            }

            return Convert.ToDouble(input);
        }

        private void calc()
        {
            if (curOp != null)
            {
                curOp.secondValue = ConvertToDouble(textBox1.Text);
                textBox1.Text = Convert.ToString(curOp.doOperation());
                curOp = null;
            }
            
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (curOp != null)
                calc();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (curOp == null)
            {
                curOp = new Minus();
                initOperation();
            }
            else
                calc();
        }

        private void btnMultply_Click(object sender, EventArgs e)
        {
            if (curOp == null)
            {
                curOp = new Multiply();
                initOperation();
            }
            else
                calc();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            curOp = null;
            textBox1.Text = String.Empty;
        }

        private void button3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (curOp == null)
            {
                curOp = new Divide();
                initOperation();
            }
            else
                calc();
        }
    }
}
