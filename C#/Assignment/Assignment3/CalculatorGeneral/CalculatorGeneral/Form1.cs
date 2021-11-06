using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        Double inputvalue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((textBox_Result.Text == "0") || (isOperationPerformed))
                textBox_Result.Clear();
            if (!string.IsNullOrEmpty(operationPerformed))
            {
                operationPerformed = string.Empty;
                textBox_Result.Clear();
            }
            
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!textBox_Result.Text.Contains("."))
                    textBox_Result.Text = textBox_Result.Text + button.Text;

            }
            else
                textBox_Result.Text = textBox_Result.Text + button.Text;

            
        }

        private void operator_click(object sender, EventArgs e)
        {

            Button button = (Button)sender;

           
            double.TryParse(textBox_Result.Text, out inputvalue);
           
            operationPerformed = button.Text;
           
            textBox_Result.Text = string.Empty;
           
            resultValue = Calculate(resultValue, inputvalue);
            if (resultValue != 0)
            {
                textBox_Result.Text = resultValue.ToString();
            }
            
        }

        

        private void backSpace(object sender, EventArgs e)
        {
            //may be the string can be empty, so keep an eye on it
            if(textBox_Result.Text != "")
            textBox_Result.Text = textBox_Result.Text.Remove(textBox_Result.TextLength - 1);
        }

        private void clearAll(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            resultValue = 0;
        }
        private void equalTo(object sender, EventArgs e)
        {
            double.TryParse(textBox_Result.Text, out inputvalue);
            resultValue = Calculate(resultValue, inputvalue);
            textBox_Result.Text= resultValue.ToString();

        }

        double Calculate(double val1, double val2)
        {
            if (val1 != 0)
            {
                switch (operationPerformed)
                {
                    case "+":
                        val1 = (val1 + val2);
                        break;
                    case "-":
                        val1 = (val1 - val2);
                        break;
                    case "*":
                        val1 = (val1 * val2);
                        break;
                    case "/":
                        val1 = (val1 / val2);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                val1 = val2;
            }
            return val1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
    }
}