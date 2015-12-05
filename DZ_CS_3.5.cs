using System;
using England;
using France;
using Germany;

namespace England
{
    class London
    {
        int population = 0;
        public London(int p)
        {
            population = p;
        }
        public void ShowPopulation()
        {
            Console.WriteLine("The population of London "+population+" people");
        }
    }
}

namespace France
{
    class Paris
    {
        int population = 0;
        public Paris(int p)
        {
            population = p;
        }
        public void ShowPopulation()
        {
            Console.WriteLine("The population of Paris " + population + " people");
        }
    }
}

namespace Germany
{
    class Berlin
    {
        int population = 0;
        public Berlin(int p)
        {
            population = p;
        }
        public void ShowPopulation()
        {
            Console.WriteLine("The population of Berlin " + population + " people");
        }
    }
}

    class Program
    {
        static void Main()
        {
            London L = new London(8416999);
            Paris P = new Paris(219693);
            Berlin B = new Berlin(3419623);
            L.ShowPopulation();
            P.ShowPopulation();
            B.ShowPopulation();
        }
    }

