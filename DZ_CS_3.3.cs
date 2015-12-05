using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_CS_3._3
{
    class Coefficients_of_the_linear_equation
    {
        int coefficient_A1;
        int coefficient_B1;
        int coefficient_A2;
        int coefficient_B2;
        public Coefficients_of_the_linear_equation()
        {
            coefficient_A1 = 1;
            coefficient_B1 = 1;
            coefficient_A2 = 2;
            coefficient_B2 = 2;
        }
        public Coefficients_of_the_linear_equation(int A1,int B1,int A2,int B2)
        {
            coefficient_A1 = 1;
            coefficient_B1 = 1;
            coefficient_A2 = 2;
            coefficient_B2 = 2;
        }
        static public void Parse(string str, Coefficients_of_the_linear_equation obj)
        {
            string[] strg = str.Split(' ', ',');
            if (strg.Length == 4)
            {
                obj.coefficient_A1 = int.Parse(strg[0]);
                obj.coefficient_B1 = int.Parse(strg[1]);
                obj.coefficient_A2 = int.Parse(strg[2]);
                obj.coefficient_B2 = int.Parse(strg[3]);
            }
            else
                throw new CoefficientsExeption("Wrong number of coefficients");
        }
        public void Show_coefficients()
        {
            Console.WriteLine("Coefficient A1 = {0}\nCoefficient B1 = {1}\nCoefficient A2 = {2}\nCoefficient B2 = {3}", 
                coefficient_A1, coefficient_B1, coefficient_A2,coefficient_B2);
        }
        public void Solution(out int x, out int y)
        {
            if ((double)coefficient_A1 / coefficient_A2 != (double)coefficient_B1 / coefficient_B2)
            {
                x = 0;
                y = 0;
            }
            else
                throw new CoefficientsExeption("The system of equations has an infinite set of solutions");
        }
    }

    class CoefficientsExeption : ApplicationException
    {
        public CoefficientsExeption() : base() { }
        public CoefficientsExeption(string str) : base(str) { }
        public override string ToString()
        {
            return Message;
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                int x,y;
                Console.WriteLine("A1*x+B1*y=0\nA2*x+B2*y=0");
                Coefficients_of_the_linear_equation cle = new Coefficients_of_the_linear_equation();
                Console.WriteLine("Enter coefficients:");
                Coefficients_of_the_linear_equation.Parse(Console.ReadLine(), cle);
                cle.Show_coefficients();
                cle.Solution(out x,out y);
                Console.WriteLine("x="+x+"\ny="+y);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Incorrect coefficients");
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
}
