using System;

namespace DZ_CS_3._7
{
    class Fraction
    {
        public int numerator;//числитель
        int denominator;//знаменатель
        public bool sign;

        public int Denominator
        {
            get
            {
                return denominator;
            }
            set
            {
                if (value != 0)
                    denominator = value;
                else
                    throw new DivideByZeroException();
            }
        }
        public Fraction()
        {}

        public Fraction(int numer, int denomin)
        {

            numerator = numer;
            if (denomin != 0)
                denominator = denomin;
            else
                throw new DivideByZeroException();
        }
        public void CutFraction()
        {
            int divisor;
            if (numerator > denominator)
                divisor = denominator;
            else
                divisor = numerator;
            for (int i = divisor; i >= 2; --i)
            {
                //Console.WriteLine("\n" + i);
                if (i > numerator || i > denominator)
                        continue;
                if (numerator % i == 0 && denominator % i == 0)
                {
                    numerator = numerator / i;
                    denominator = denominator / i;
                    //Console.WriteLine("\n" + numerator + "\n" + denominator);
                }
            }
        }
        public void Print()
        {
            int line;
            int displacement;
            if (numerator < 0 & denominator > 0 || numerator > 0 & denominator < 0)
                sign = true;
            if (sign)
                Console.Write("  ");
                numerator = Math.Abs(numerator);
                denominator = Math.Abs(denominator);
                if (denominator > numerator)
                {
                    line = (denominator.ToString()).Length;
                    displacement = line - (numerator.ToString()).Length;

                    for (int i = 0; i < displacement; ++i)
                        Console.Write(" ");
                    Console.WriteLine(numerator);
                    if (sign)
                    {
                        Console.Write("- ");
                    }
                    for (int i = 0; i < line; ++i)
                        Console.Write("-");

                    Console.WriteLine();
                    if (sign)
                        Console.Write("  ");
                    Console.WriteLine(denominator);
                }
                else
                {
                    line = (numerator.ToString()).Length;
                    displacement = line - (denominator.ToString()).Length;
                    Console.WriteLine(numerator);
                    if (sign)
                    {
                        Console.Write("- ");
                    }
                    for (int i = 0; i < line; ++i)
                        Console.Write("-");

                    Console.WriteLine();
                    if (sign)
                        Console.Write("  ");
                    for (int i = 0; i < displacement; ++i)
                        Console.Write(" ");
                    Console.WriteLine(denominator);
                }
        }
        public static Fraction operator + (Fraction obj1,Fraction obj2)
        {
            int i;
            Fraction result = new Fraction();
            if (obj1.denominator >= obj2.denominator)
                for (i = 1; (obj1.denominator * i) % obj2.denominator != 0; ++i);
            else
                for (i = 1; (obj2.denominator * i) % obj1.denominator != 0; ++i) ;
                if (obj1.sign == false & obj2.sign == true)
                { 
                    result.numerator = obj1.numerator * i - (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
                    if(result.numerator < 0)
                    result.sign = true;
                }
                else if (obj1.sign == true & obj2.sign == false)
                {
                    result.numerator = obj1.numerator * i - (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
                    if (result.numerator > 0)
                        result.sign = true;
                }
                else if (obj1.sign == true & obj2.sign == true)
                {
                    result.numerator = obj1.numerator * i + (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
                    result.sign = true;
                }
                else if (obj1.sign == false & obj2.sign == false)
                {
                    result.numerator = obj1.numerator * i + (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
                }
                result.denominator = obj1.denominator*i; 
                result.CutFraction();
            result.numerator = Math.Abs(result.numerator);
            result.denominator = Math.Abs(result.denominator);
            return result;
        }
        public static Fraction operator +(Fraction obj1, double num)
        {
            int i;
            Fraction obj2 = new Fraction();
            string number = num.ToString();
            int index = number.IndexOf(',');
            if (number[0] == '-')
            {
                obj2.sign = true;
                --index;
            }
            if (index < 0)
            {
                obj2.numerator = (int)num * obj1.denominator;
                obj2.denominator = obj1.denominator;
            }
            else
            {
                int factor = (int)Math.Pow(10, number.Length - 1 - index);
                obj2.numerator = (int)(num * factor);
                obj2.denominator = factor;
                obj2.CutFraction();
            }
            Fraction result = new Fraction();
            if (obj1.denominator >= obj2.denominator)
                for (i = 1; (obj1.denominator * i) % obj2.denominator != 0; ++i) ;
            else
                for (i = 1; (obj2.denominator * i) % obj1.denominator != 0; ++i) ;
            if (obj1.sign == false & obj2.sign == true)
            {
                result.numerator = obj1.numerator * i - (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
                if (result.numerator < 0)
                    result.sign = true;
            }
            else if (obj1.sign == true & obj2.sign == false)
            {
                result.numerator = obj1.numerator * i - (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
                if (result.numerator > 0)
                    result.sign = true;
            }
            else if (obj1.sign == true & obj2.sign == true)
            {
                result.numerator = obj1.numerator * i + (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
                result.sign = true;
            }
            else if (obj1.sign == false & obj2.sign == false)
            {
                result.numerator = obj1.numerator * i + (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
            }
            result.denominator = obj1.denominator * i;
            result.CutFraction();
            result.numerator = Math.Abs(result.numerator);
            result.denominator = Math.Abs(result.denominator);
            return result;
        }
        public static Fraction operator +(double num, Fraction obj2)
        {
            int i;
            Fraction obj1 = new Fraction();
            string number = num.ToString();
            int index = number.IndexOf(',');
            if (number[0] == '-')
            {
                obj1.sign = true;
                --index;
            }
            if (index < 0)
            {
                obj1.numerator = (int)num * obj2.denominator;
                obj1.denominator = obj2.denominator;
            }
            else
            {
                int factor = (int)Math.Pow(10, number.Length - 1 - index);
                obj1.numerator = (int)(num * factor);
                obj1.denominator = factor;
                obj1.CutFraction();
            }
            Fraction result = new Fraction();
            if (obj1.denominator >= obj2.denominator)
                for (i = 1; (obj1.denominator * i) % obj2.denominator != 0; ++i) ;
            else
                for (i = 1; (obj2.denominator * i) % obj1.denominator != 0; ++i) ;
            if (obj1.sign == false & obj2.sign == true)
            {
                result.numerator = obj1.numerator * i - (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
                if (result.numerator < 0)
                    result.sign = true;
            }
            else if (obj1.sign == true & obj2.sign == false)
            {
                result.numerator = obj1.numerator * i - (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
                if (result.numerator > 0)
                    result.sign = true;
            }
            else if (obj1.sign == true & obj2.sign == true)
            {
                result.numerator = obj1.numerator * i + (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
                result.sign = true;
            }
            else if (obj1.sign == false & obj2.sign == false)
            {
                result.numerator = obj1.numerator * i + (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
            }
            result.denominator = obj1.denominator * i;
            result.CutFraction();
            result.numerator = Math.Abs(result.numerator);
            result.denominator = Math.Abs(result.denominator);
            return result;
        }
        public static Fraction operator -(Fraction obj1, Fraction obj2)
        {
            int i;
            Fraction result = new Fraction();
            if (obj1.denominator >= obj2.denominator)
                for (i = 1; (obj1.denominator * i) % obj2.denominator != 0; ++i);
            else
                for (i = 1; (obj2.denominator * i) % obj1.denominator != 0; ++i) ;
                if (obj1.sign == false & obj2.sign == true)
                {
                    result.numerator = obj1.numerator * i + (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
                }
                else if (obj1.sign == true & obj2.sign == false)
                {
                    result.numerator = obj1.numerator * i + (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
                        result.sign = true;
                }
                else if (obj1.sign == true & obj2.sign == true)
                {
                    result.numerator = obj1.numerator * i - (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
                    if (result.numerator >= 0)
                    result.sign = true;
                }
                else if (obj1.sign == false & obj2.sign == false)
                {
                    result.numerator = obj1.numerator * i - (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
                    if (result.numerator <= 0)
                        result.sign = true;
                }
                result.denominator = obj1.denominator * i;
                result.CutFraction();
            result.numerator = Math.Abs(result.numerator);
            result.denominator = Math.Abs(result.denominator);
            return result;
        }
        public static Fraction operator -(Fraction obj1, double num)
        {
            int i;
            Fraction obj2 = new Fraction();
            string number = num.ToString();
            int index = number.IndexOf(',');
            if (number[0] == '-')
            {
                obj2.sign = true;
                --index;
            }
            if (index < 0)
            {
                obj2.numerator = (int)num * obj1.denominator;
                obj2.denominator = obj1.denominator;
            }
            else
            {
                int factor = (int)Math.Pow(10, number.Length - 1 - index);
                obj2.numerator = (int)(num * factor);
                obj2.denominator = factor;
                obj2.CutFraction();
            }
            Fraction result = new Fraction();
            if (obj1.denominator >= obj2.denominator)
                for (i = 1; (obj1.denominator * i) % obj2.denominator != 0; ++i) ;
            else
                for (i = 1; (obj2.denominator * i) % obj1.denominator != 0; ++i) ;
            if (obj1.sign == false & obj2.sign == true)
            {
                result.numerator = obj1.numerator * i + (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
            }
            else if (obj1.sign == true & obj2.sign == false)
            {
                result.numerator = obj1.numerator * i + (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
                result.sign = true;
            }
            else if (obj1.sign == true & obj2.sign == true)
            {
                result.numerator = obj1.numerator * i - (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
                if (result.numerator >= 0)
                    result.sign = true;
            }
            else if (obj1.sign == false & obj2.sign == false)
            {
                result.numerator = obj1.numerator * i - (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
                if (result.numerator <= 0)
                    result.sign = true;
            }
            result.denominator = obj1.denominator * i;
            result.CutFraction();
            result.numerator = Math.Abs(result.numerator);
            result.denominator = Math.Abs(result.denominator);
            return result;
        }
        public static Fraction operator -(double num, Fraction obj2)
        {
            int i;
            Fraction obj1 = new Fraction();
            string number = num.ToString();
            int index = number.IndexOf(',');
            if (number[0] == '-')
            {
                obj1.sign = true;
                --index;
            }
            if (index < 0)
            {
                obj1.numerator = (int)num * obj2.denominator;
                obj1.denominator = obj2.denominator;
            }
            else
            {
                int factor = (int)Math.Pow(10, number.Length - 1 - index);
                obj1.numerator = (int)(num * factor);
                obj1.denominator = factor;
                obj1.CutFraction();
            }
            Fraction result = new Fraction();
            if (obj1.denominator >= obj2.denominator)
                for (i = 1; (obj1.denominator * i) % obj2.denominator != 0; ++i) ;
            else
                for (i = 1; (obj2.denominator * i) % obj1.denominator != 0; ++i) ;
            if (obj1.sign == false & obj2.sign == true)
            {
                result.numerator = obj1.numerator * i + (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
            }
            else if (obj1.sign == true & obj2.sign == false)
            {
                result.numerator = obj1.numerator * i + (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
                result.sign = true;
            }
            else if (obj1.sign == true & obj2.sign == true)
            {
                result.numerator = obj1.numerator * i - (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
                if (result.numerator >= 0)
                    result.sign = true;
            }
            else if (obj1.sign == false & obj2.sign == false)
            {
                result.numerator = obj1.numerator * i - (obj2.numerator * ((obj1.denominator * i) / obj2.denominator));
                if (result.numerator <= 0)
                    result.sign = true;
            }
            result.denominator = obj1.denominator * i;
            result.CutFraction();
            result.numerator = Math.Abs(result.numerator);
            result.denominator = Math.Abs(result.denominator);
            return result;
        }
        public static Fraction operator *(Fraction obj1, Fraction obj2)
        {
            Fraction result = new Fraction();
            result.numerator = obj1.numerator * obj2.numerator;
            result.denominator = obj1.denominator * obj2.denominator;
            if ((obj1.sign && !obj2.sign) || (!obj1.sign && obj2.sign))
                result.sign = true;
            result.CutFraction();
            result.numerator = Math.Abs(result.numerator);
            result.denominator = Math.Abs(result.denominator);
            result.CutFraction();
            return result;
        }
        public static Fraction operator *(double num, Fraction obj2)
        {
            Fraction obj1 = new Fraction();
            string number = num.ToString();
            int index = number.IndexOf(',');
            if (number[0] == '-')
            {
                obj1.sign = true;
                --index;
            }
            if (index < 0)
            {
                obj1.numerator = (int)num * obj2.denominator;
                obj1.denominator = obj2.denominator;
            }
            else
            {
                int factor = (int)Math.Pow(10, number.Length - 1 - index);
                obj1.numerator = (int)(num * factor);
                obj1.denominator = factor;
                obj1.CutFraction();
            }
            Fraction result = new Fraction();
            result.numerator = obj1.numerator * obj2.numerator;
            result.denominator = obj1.denominator * obj2.denominator;
            if ((obj1.sign && !obj2.sign) || (!obj1.sign && obj2.sign))
                result.sign = true;
            result.CutFraction();
            result.numerator = Math.Abs(result.numerator);
            result.denominator = Math.Abs(result.denominator);
            result.CutFraction();
            return result;
        }
        public static Fraction operator *(Fraction obj1, double num)
        {
            Fraction obj2 = new Fraction();
            string number = num.ToString();
            int index = number.IndexOf(',');
            if (number[0] == '-')
            { 
                obj2.sign = true;
                --index;
            }
            if (index < 0)
            {
                obj2.numerator = (int)num * obj1.denominator;
                obj2.denominator = obj1.denominator;
            }
            else
            {
                int factor = (int)Math.Pow(10, number.Length - 1 - index);
                obj2.numerator = (int)(num * factor);
                obj2.denominator = factor;
                obj2.CutFraction();
            }
            Fraction result = new Fraction();
            result.numerator = obj1.numerator * obj2.numerator;
            result.denominator = obj1.denominator * obj2.denominator;
            if ((obj1.sign && !obj2.sign) || (!obj1.sign && obj2.sign))
                result.sign = true;
            result.CutFraction();
            result.numerator = Math.Abs(result.numerator);
            result.denominator = Math.Abs(result.denominator);
            result.CutFraction();
            return result;
        }
        public static Fraction operator /(Fraction obj1, Fraction obj2)
        {
            Fraction result = new Fraction();
            result.numerator = obj1.numerator * obj2.denominator;
            result.denominator = obj1.denominator * obj2.numerator;
            if ((obj1.sign && !obj2.sign) || (!obj1.sign && obj2.sign))
                result.sign = true;
            result.CutFraction();
            result.numerator = Math.Abs(result.numerator);
            result.denominator = Math.Abs(result.denominator);
            result.CutFraction();
            return result;
        }
        public static Fraction operator /(double num, Fraction obj2)
        {
            Fraction obj1 = new Fraction();
            string number = num.ToString();
            int index = number.IndexOf(',');
            if (number[0] == '-')
            {
                obj1.sign = true;
                --index;
            }
            if (index < 0)
            {
                obj1.numerator = (int)num * obj2.denominator;
                obj1.denominator = obj2.denominator;
            }
            else
            {
                int factor = (int)Math.Pow(10, number.Length - 1 - index);
                obj1.numerator = (int)(num * factor);
                obj1.denominator = factor;
                obj1.CutFraction();
            }
            Fraction result = new Fraction();
            result.numerator = obj1.numerator * obj2.denominator;
            result.denominator = obj1.denominator * obj2.numerator;
            if ((obj1.sign && !obj2.sign) || (!obj1.sign && obj2.sign))
                result.sign = true;
            result.CutFraction();
            result.numerator = Math.Abs(result.numerator);
            result.denominator = Math.Abs(result.denominator);
            result.CutFraction();
            return result;
        }
        public static Fraction operator /(Fraction obj1, double num)
        {
            Fraction obj2 = new Fraction();
            string number = num.ToString();
            int index = number.IndexOf(',');
            if (number[0] == '-')
            {
                obj2.sign = true;
                --index;
            }
            if (index < 0)
            {
                obj2.numerator = (int)num * obj1.denominator;
                obj2.denominator = obj1.denominator;
            }
            else
            {
                int factor = (int)Math.Pow(10, number.Length - 1 - index);
                obj2.numerator = (int)(num * factor);
                obj2.denominator = factor;
                obj2.CutFraction();
            }
            Fraction result = new Fraction();
            result.numerator = obj1.numerator * obj2.denominator;
            result.denominator = obj1.denominator * obj2.numerator;
            if ((obj1.sign && !obj2.sign) || (!obj1.sign && obj2.sign))
                result.sign = true;
            result.CutFraction();
            result.numerator = Math.Abs(result.numerator);
            result.denominator = Math.Abs(result.denominator);
            result.CutFraction();
            return result;
        }
        public static bool operator >(Fraction obj1, Fraction obj2)
        {
            if ((((double)obj1.numerator / obj1.denominator > (double)obj2.numerator / obj2.denominator) && !obj1.sign) ||
                (((double)obj1.numerator / obj1.denominator < (double)obj2.numerator / obj2.denominator) && (obj1.sign && obj2.sign)))
                return true;
            else
                return false;
        }
        public static bool operator <(Fraction obj1, Fraction obj2)
        {
            if ((((double)obj1.numerator / obj1.denominator < (double)obj2.numerator / obj2.denominator) && !obj1.sign) ||
                (((double)obj1.numerator / obj1.denominator > (double)obj2.numerator / obj2.denominator) && (obj1.sign && obj2.sign)))
                return true;
            else
                return false;
        }
        public static bool operator ==(Fraction obj1, Fraction obj2)
        {
            if ((obj1.numerator == obj2.numerator) && (obj1.denominator == obj2.denominator) && (obj1.sign == obj2.sign))
                return true;
            else
                return false;
        }
        public static bool operator !=(Fraction obj1, Fraction obj2)
        {
            if ((obj1.numerator != obj2.numerator) || (obj1.denominator != obj2.denominator) || (obj1.sign != obj2.sign))
                return true;
            else
                return false;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Fraction f = obj as Fraction; 
            if (f as Fraction == null)
                return false;
            return (f.numerator == this.numerator) && (f.denominator == this.denominator);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator true(Fraction obj1)
        {
            if (obj1.numerator < obj1.denominator)
                return true;
            else 
                return false;
        }
        public static bool operator false(Fraction obj1)
        {
            if (obj1.numerator >= obj1.denominator)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main()
        {
            try
            {
                Fraction f = new Fraction(3, 4);
                int a = 10;
                Fraction f1 = f * a;
                Fraction f2 = a * f;
                double d = 1.5;
                Fraction f3 = f + d;
                f.Print();
                Console.WriteLine();
                f1.Print();
                Console.WriteLine();
                f2.Print();
                Console.WriteLine();
                f3.Print();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Denominator must not be zero");
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
}
