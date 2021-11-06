using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * I have used different methods to handle each and every Operation.
 * Eg, Addition:- add_click(), Subtraction:- sub_click() etc.
 */
namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        //Check if Input is numeric
        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private void Add_Click(object sender, EventArgs e)
        {
            //Checking whether the inputs are valid and not empty
            if (!((string.IsNullOrEmpty(inputOne.Text)) || (string.IsNullOrEmpty(inputTwo.Text)))){
                if (IsDigitsOnly(inputOne.Text) && IsDigitsOnly(inputTwo.Text))
                {
                    var x = Convert.ToDouble(inputOne.Text);
                    var y = Convert.ToDouble(inputTwo.Text);

                    var result = x + y;
                    resultLabel.Text = result.ToString();
                }
                else
                    MessageBox.Show("Invalid Inputs");
            }
            else
            {
                MessageBox.Show("Invalid Inputs");
            }
        }

        private void Sub_Click(object sender, EventArgs e)
        {
            //Checking whether the inputs are valid and not empty
            if (!((string.IsNullOrEmpty(inputOne.Text)) || (string.IsNullOrEmpty(inputTwo.Text))))
            {
                if (IsDigitsOnly(inputOne.Text) && IsDigitsOnly(inputTwo.Text))
                {
                    var x = Convert.ToDouble(inputOne.Text);
                    var y = Convert.ToDouble(inputTwo.Text);
                    var result = x - y;
                    resultLabel.Text = result.ToString();
                }
                else
                    MessageBox.Show("Invalid Inputs");
            }
            else
            {
                MessageBox.Show("Invalid Inputs");
            }
        }

        private void Divide_Click(object sender, EventArgs e)
        {
            //Checking whether the inputs are valid AND not empty
            if (!((string.IsNullOrEmpty(inputOne.Text)) || (string.IsNullOrEmpty(inputTwo.Text))))
            {
                if (IsDigitsOnly(inputOne.Text) && IsDigitsOnly(inputTwo.Text))
                {
                    var x = Convert.ToDouble(inputOne.Text);
                    var y = Convert.ToDouble(inputTwo.Text);

                    try
                    {
                        var result = x / y;
                        resultLabel.Text = result.ToString();
                    }
                    catch (DivideByZeroException)
                    {
                        MessageBox.Show("Cannot Divide by Zero");
                    }
                }
                else
                    MessageBox.Show("Invalid Inputs");
            }
            else
            {
                MessageBox.Show("Invalid Inputs");
            }
        }

        private void Multiply_Click(object sender, EventArgs e)
        {
            //Checking whether the inputs are valid AND not empty
            if (!((string.IsNullOrEmpty(inputOne.Text)) || (string.IsNullOrEmpty(inputTwo.Text))))
            {
                if (IsDigitsOnly(inputOne.Text) && IsDigitsOnly(inputTwo.Text))
                {
                    var x = Convert.ToDouble(inputOne.Text);
                    var y = Convert.ToDouble(inputTwo.Text);
                    var result = x * y;
                    resultLabel.Text = result.ToString();
                }
                else
                    MessageBox.Show("Invalid Inputs");
            }
            else
            {
                MessageBox.Show("Invalid Inputs");
            }

        }

        private void inputOneClick(object sender, EventArgs e)
        {

        }

        private void inputTwoClick(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void moduloClick(object sender, EventArgs e)
        {
            //Checking whether the inputs are valid and not empty
            if (!((string.IsNullOrEmpty(inputOne.Text)) || (string.IsNullOrEmpty(inputTwo.Text))))
            {
                //modulo is used for integers only.
                if (IsDigitsOnly(inputOne.Text) && IsDigitsOnly(inputTwo.Text))
                {
                    var x = Convert.ToInt32(inputOne.Text);
                    var y = Convert.ToInt32(inputTwo.Text);
                    try
                    {
                        var result = x % y;
                        resultLabel.Text = result.ToString();
                    }
                    catch (DivideByZeroException)
                    {
                        MessageBox.Show("Cannot Divide by Zero");
                    }

                }
                else
                    MessageBox.Show("Invalid Inputs");
            }
            else
            {
                MessageBox.Show("Invalid Inputs");
            }
        }

        private void squareClick(object sender, EventArgs e)
        {
            //Checking whether the inputs are valid and not empty
            if (!((string.IsNullOrEmpty(inputOne.Text)) || (string.IsNullOrEmpty(inputTwo.Text))))
            {
                if (IsDigitsOnly(inputOne.Text) && IsDigitsOnly(inputTwo.Text))
                {
                    var x = Convert.ToDouble(inputOne.Text);
                    var y = Convert.ToDouble(inputTwo.Text);
                    var result = x * x;
                    resultLabel.Text = result.ToString();
                }
                else
                    MessageBox.Show("Invalid Inputs");
            }
            else
            {
                MessageBox.Show("Invalid Inputs");
            }
        }

        private void resetClick(object sender, EventArgs e)
        {
            inputOne.Text = inputTwo.Text = "";
            resultLabel.Text = "0";
        }
    }
}
