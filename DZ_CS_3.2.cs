using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_CS_3._2
{
    class Coefficients_of_the_linear_equation_v1
    {
        static int coefficient_A = 1;
        static int coefficient_B = 1;
        static public void Parse(string str)
        {
            string [] strg=str.Split(' ', ',');
            if (strg.Length == 2)
            {
                coefficient_A = int.Parse(strg[0]);
                coefficient_B = int.Parse(strg[1]);
            }
            else
                throw new CoefficientsExeption("Wrong number of coefficients");
        }
        static public void Show_coefficients()
        {
            Console.WriteLine("Coefficient A = {0}\nCoefficient B = {1}", coefficient_A, coefficient_B);
        }
    }

    class Coefficients_of_the_linear_equation_v2
    {
        int coefficient_A1;
        int coefficient_B1;
        public Coefficients_of_the_linear_equation_v2()
        {
            coefficient_A1 = 1;
            coefficient_B1 = 1;
        }
        static public void Parse(string str, Coefficients_of_the_linear_equation_v2 obj)
        {
            string[] strg = str.Split(' ', ',');
            if (strg.Length == 2)
            {
                obj.coefficient_A1 = int.Parse(strg[0]);
                obj.coefficient_B1 = int.Parse(strg[1]);
            }
            else
                throw new CoefficientsExeption("Wrong number or values of the coefficients");
        }
        public void Show_coefficients()
        {
            Console.WriteLine("Coefficient A = {0}\nCoefficient B = {1}", coefficient_A1, coefficient_B1);
        }
    }

    class CoefficientsExeption: ApplicationException
    {
        public CoefficientsExeption(): base() {}
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
                Coefficients_of_the_linear_equation_v1.Show_coefficients();
                Coefficients_of_the_linear_equation_v1.Parse("10,20");
                Coefficients_of_the_linear_equation_v1.Show_coefficients();
                Coefficients_of_the_linear_equation_v1.Parse("20 10");
                Coefficients_of_the_linear_equation_v1.Show_coefficients();
                Coefficients_of_the_linear_equation_v2 cle = new Coefficients_of_the_linear_equation_v2();
                cle.Show_coefficients();
                Coefficients_of_the_linear_equation_v2.Parse("23,31", cle);
                cle.Show_coefficients();
                Coefficients_of_the_linear_equation_v2.Parse("wds", cle);
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
