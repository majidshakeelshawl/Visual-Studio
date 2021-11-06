using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSheet1
{
    class Calculator
    {
        private float number1;
        private float number2;
        
    
        // Methods for calculation
        public float add()
        {
            Console.WriteLine("Enter First Number");
            this.number1 = (float) Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Second Number");
            this.number2 = (float)Convert.ToDouble(Console.ReadLine());
            return number1 + number2;
        }

        public float subtract()
        {
            Console.WriteLine("Enter First Number");
            this.number1 = (float)Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Second Number");
            this.number2 = (float)Convert.ToDouble(Console.ReadLine());
            return number1 - number2;
        }

        public float multiply()
        {
            Console.WriteLine("Enter First Number");
            this.number1 = (float)Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Second Number");
            this.number2 = (float)Convert.ToDouble(Console.ReadLine());
            return number1 * number2;
        }

        public void generatePrimeNumbers()
        {
            int flag = 0;
            Console.WriteLine("Enter the Number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            for(int i = 2;i<= (number / 2); i++)
            {
                if(number%i == 0)
                {
                    flag = 1;
                    Console.WriteLine("Not A Prime Number");
                    break;

                }
                    
            }
            if (flag == 0)
                Console.WriteLine("It\'s A Prime Number");
            
        }

        public void generateSeries()
        {
            Console.WriteLine("Enter Range:\nEnter Starting Point:");
            int start = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter End Point:");
            int end = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            for (int i = start; i <= end; i++)
                Console.WriteLine(i);
        }

        public void generateFibonacciSeries()
        {
            int num1 = 1;
            int num2 = -1;
            int temp;
            Console.WriteLine("Enter Limit");
            int limit = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i< limit; i++)
            {
                temp = num1;
                num1 += num2;
                num2 = temp;
                Console.Write(num1 + " ");
          
            }
            Console.WriteLine("");
        }
    }
}
