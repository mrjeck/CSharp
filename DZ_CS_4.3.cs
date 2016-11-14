using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Serialization;

namespace DZ_CS_4._3
{
    public interface IPerishableGoods
    {
        void StorageConditions(int temperature, string description);
    }
    public interface IAlcoholTobacco
    {
        void SetAgeLimit(int age);
    }
    public interface IFlammableProducts
    {
        void SetLevelOfDanger(int level);
    }
    public interface IBreakableItems
    {
        void SetPackageTYype(string Package);
    }
    abstract class Product
    { 
        public  string _title;
        public  double _weight;
        public  DateTime _produced;
        public  DateTime _valid_until;
        public  double _price;
        public  uint _code;
        public  string _type_of_product;
        public  string _producer;
        public Product() { }
        public Product(string title, double weight, DateTime produced,
                                    DateTime valid_until, double price, uint code,
                                            string type_of_product, string producer)
        {
            _title = title;
            _weight = weight;
            _produced = produced;
            _valid_until = valid_until;
            _price = price;
            _code = code;
            _type_of_product = type_of_product;
            _producer = producer;
        }
    }
    class Fruit : Product, IPerishableGoods
    {
        public int temperature;
        public string description;
        public Fruit() { }
        public Fruit(string title, double weight, DateTime produced,
                                    DateTime valid_until, double price, uint code,
                                            string type_of_product, string producer)
            : base(title, weight, produced, valid_until, price,
                             code, type_of_product, producer)
        { }
        public void StorageConditions(int temperature, string description) 
        {
            this.temperature = temperature;
            this.description = String.Copy(description);
        }
    }
    class Wine : Product, IAlcoholTobacco
    {
        public int ageLimit;
        public Wine() {}
        public Wine(string title, double weight, DateTime produced,
                                    DateTime valid_until, double price, uint code,
                                            string type_of_product, string producer)
            : base(title, weight, produced, valid_until, price,
                             code, type_of_product, producer)
        { }
        public void SetAgeLimit(int age)
        {
            ageLimit = age;
        }

    }
    class Cleaners : Product, IFlammableProducts
    {
        public int Dangerlevel;
        public Cleaners() { }
        public Cleaners(string title, double weight, DateTime produced,
                                    DateTime valid_until, double price, uint code,
                                            string type_of_product, string producer)
            : base(title, weight, produced, valid_until, price,
                             code, type_of_product, producer)
        { }
        public void SetLevelOfDanger(int level)
        {
            Dangerlevel = level;
        }
    }
    class AcceptedProducts
    {
        LinkedList<Product> productslist;
        public AcceptedProducts() 
        {
            productslist = new LinkedList<Product>();
        }
        void DateCheck(Product p)
        {
            if (DateTime.Today > p._valid_until)
                throw new ProductExeption("Expiration date is exceeded!");
        }
        public void AddProduct(Product pr)
        {
            DateCheck(pr);
            if (pr is Cleaners)
            {
                Cleaners c = pr as Cleaners;
                Console.Write("Danger level:");
                c.SetLevelOfDanger(int.Parse(Console.ReadLine()));
                productslist.AddLast(c);
            }
            else if (pr is Wine)
            {
                Wine c = pr as Wine;
                Console.Write("Age limit:");
                c.SetAgeLimit(int.Parse(Console.ReadLine()));
                productslist.AddLast(c);
            }
            else if (pr is Fruit)
            {
                Fruit c = pr as Fruit;
                Console.Write("Temperature and description:");
                c.StorageConditions(int.Parse(Console.ReadLine()), Console.ReadLine());
                productslist.AddLast(c);
            }
            Console.Clear();
        }
        public void ShowProductsList()
        {
            if (productslist.Count != 0)
                foreach (Product p in productslist)
                {
                    Console.WriteLine("{0}\nCode:{1}\nPrice:{2}\nProduced:{3}\nValid_until:{4}\nProducer:{5}\nType_of_product:{6}\nWeight:{7}",
                                p._title, p._code, p._price, p._produced, p._valid_until, p._producer, p._type_of_product, p._weight);
                    if (p is Cleaners)
                    {
                        Cleaners c = p as Cleaners;
                        Console.WriteLine("Danger level:{0}", c.Dangerlevel);
                    }
                    else if (p is Wine)
                    {
                        Wine c = p as Wine;
                        Console.WriteLine("Age limit:{0}", c.ageLimit);
                    }
                    else if (p is Fruit)
                    {
                        Fruit c = p as Fruit;
                        Console.WriteLine("Temperature:{0}\nDescription:{1}", c.temperature, c.description);
                    }
                    Console.WriteLine("\n");
                }
            else
                throw new ProductExeption("The list contains no products!");
        }
        public void FindProductInsList(string str)
        { 
            Product prod = null;
            foreach(Product p in productslist)
                if (String.Compare(p._title, str) == 0)
                { 
                    Console.WriteLine("{0}\nCode:{1}\nPrice:{2}\nProduced:{3}\nValid_until:{4}\nProducer:{5}\nType_of_product:{6}\nWeight:{7}\n\n",
                                p._title, p._code, p._price, p._produced, p._valid_until, p._producer, p._type_of_product, p._weight);
                    prod = p;
                }
            if (prod == null)
                throw new ProductExeption("Product not found!");
        }
    }
    public class ProductExeption : ApplicationException
    {
        public ProductExeption() : base() { }
        public ProductExeption(string message) : base(message) { }
        public ProductExeption(string message, Exception inner) : base(message, inner) { }
        protected ProductExeption(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
    class Program
    {
            static void Main()
            {
                 try
                 {
                    AcceptedProducts prodbase = new AcceptedProducts();
                    prodbase.AddProduct(new Cleaners("Vanish", 0.3, new DateTime(2013, 11, 10),
                                    new DateTime(2016, 10, 1), 62700, 1234,
                                            "bleach", "Reckitt Benckiser"));
                    prodbase.ShowProductsList();
                    prodbase.FindProductInsList("Vanish");
                    prodbase.FindProductInsList("Apple");
                 }
                 catch (ProductExeption exp)
                 {
                     Console.WriteLine(exp.Message);
                 }
            }
     }
}
