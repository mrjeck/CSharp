using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C5._3
{
    public delegate bool Dfound(object obj, object obj2);
    class Program
    {
        static public object Find(object[] arr, object obj, Dfound f)
        {
            foreach (object o in arr)
                if (f(obj, o))
                    return o;
            return null; 
        }
        static public bool Found(object obj1, object obj2)
        {
                if (obj1.Equals(obj2))
                    return true;
                else
                    return false;
        }
        static void Main()
        {
            Dfound f = new Dfound(Found);
            Console.WriteLine(Find(new object[] { 'q', "asd", 10, 3.14 }, 3.14, f));
        }
    }
}
