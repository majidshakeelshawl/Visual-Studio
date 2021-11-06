using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSheet1
{
    class Program
    {
        //Menu Driven Program
        static void Main(string[] args)
        {
            while (true) { 
            Console.WriteLine("1: Add two Numbers:");
            Console.WriteLine("2: Subtract Two Numbers:");
            Console.WriteLine("3: Multiply Two Numbers");
            Console.WriteLine("4: Print n to n Numbers:");
            Console.WriteLine("5: Generate Fibonaci Series");
            Console.WriteLine("6: Generate Prime Numbers");
            Console.WriteLine("7: Exit");
            Console.WriteLine("Enter Choice: ");
            byte choice = Convert.ToByte(Console.ReadLine());

            var myCalculator = new Calculator();
            
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(myCalculator.add());
                        break;
                    case 2:
                        Console.WriteLine(myCalculator.subtract());
                        break;
                    case 3:
                        Console.WriteLine(myCalculator.multiply());
                        break;
                    case 4:
                        myCalculator.generateSeries();
                        break;
                    case 5:
                        myCalculator.generateFibonacciSeries();
                        break;
                    case 6:
                        myCalculator.generatePrimeNumbers();
                        break;
                    case 7:
                        Environment.Exit(1);
                        break;

                }
            }

            
            Console.ReadLine();

        }
    }
}
