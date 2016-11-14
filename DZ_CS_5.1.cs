using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_CS_5._1
{
    struct Article
    {
        int productCode;
        string productName;
        double productPrice;
        public Article(int productCode, string productName, double productPrice)
        {
            this.productCode = productCode;
            this.productName = productName;
            this.productPrice = productPrice;
        }
        public string ProductName
        {
            get { return productName; }
        }
        public double ProductPrice
        {
            get { return productPrice; }
        }
    }
    struct Client
    {
        int clientCode;
        string clientFullName;
        string clientAddress;
        string clientPhone;
        int clientNumberOfOrders;//количе-ство заказов осуществленных клиентом
        double clientTotalAmountOfOrders;//общая сумма заказов клиента
        public Client(int clientCode, string clientFullName, string clientAddress, string clientPhone)
        {
            this.clientCode = clientCode;
            this.clientFullName = clientFullName;
            this.clientAddress = clientAddress;
            this.clientPhone = clientPhone;
            this.clientPhone = clientPhone;
            this.clientTotalAmountOfOrders = 0;
            this.clientNumberOfOrders = 1;
        }
        public void Show()
        {
            Console.WriteLine("clientCode:{0}\nclientFullName:{1}\nclientAddress:{2}\nclientPhone:{3}\nclientNumberOfOrders:{4}\nclientTotalAmountOfOrders:{5}\n", 
                clientCode, clientFullName, clientAddress, clientPhone, clientNumberOfOrders, clientTotalAmountOfOrders);
        }
        public int ClientCode
        {
            get { return clientCode; }
        }
        public string ClientAddress
        {
            get { return clientAddress; }
        }
        public string ClientPhone
        {
            get { return clientPhone; }
        }
        public string ClientFullName
        {
            get { return clientFullName; }
        }
        public int ClientNumberOfOrders
        {
            set { clientNumberOfOrders = value; }
            get { return clientNumberOfOrders; }
        }
        public double ClientTotalAmountOfOrders
        {
            set { clientTotalAmountOfOrders = value; }
            get { return clientTotalAmountOfOrders; }
        }
    }
    struct RequestItem
    {
        public string product;
        public int numberOfProducts;
        public RequestItem(string product, int numberOfProducts)
        {
            this.product = product;
            this.numberOfProducts = numberOfProducts;
        }
        public void Show()
        {
            Console.WriteLine("{0}x{1}", product, numberOfProducts);
        }
    }
    struct Request
    {
        int orderCode;
        Client clientName;
        DateTime orderDate;
        List<RequestItem> listOfOrderedProducts;//перечень заказанных товаров
        double orderAmount;//сумма заказа (реализовать вычисляемым свойством).
        List<Article> listOfArticle;
        List<Client> listOfClient;
        public Request(int orderCode, Client clientName, DateTime orderDate,
                              List<RequestItem> listOfOrderedProducts, 
                                ref List<Article> listOfArticle, ref List<Client> listOfClient)
        {
            this.orderCode = orderCode;
            this.clientName = clientName;
            this.orderDate = orderDate;
            this.listOfOrderedProducts = listOfOrderedProducts;
            this.listOfArticle = listOfArticle;
            this.listOfClient = listOfClient;
            this.orderAmount = 0;
            Client();
        }
        public void Client()
        {
            int counter = 0;
            for (int i = 0; i < listOfClient.Count; ++i)
            {
                if (listOfClient[i].ClientCode.Equals(this.clientName.ClientCode))
                {
                    Client t = listOfClient[i];
                    t.ClientNumberOfOrders = t.ClientNumberOfOrders + 1;
                    t.ClientTotalAmountOfOrders = t.ClientTotalAmountOfOrders + this.order;
                    listOfClient[i] = t;
                    ++counter;
                    return;
                }
            }
            if (counter == 0)
            {
                this.clientName.ClientTotalAmountOfOrders = this.order;
                listOfClient.Add(this.clientName);
            }
            else
                counter = 0;
        }
        public void Show()
        {
            Console.WriteLine("orderCode:{0}\nclientName:{1}\norderDate:{2}",
                             orderCode, clientName.ClientFullName, orderDate);
            Console.WriteLine("listOfOrderedProducts:");
            foreach(RequestItem ri in listOfOrderedProducts)
                ri.Show();
            Console.WriteLine("orderAmount:{0}", orderAmount);
        }
        public double order
        {
            get
            {
                foreach (RequestItem ri in listOfOrderedProducts)
                {
                    foreach (Article art in listOfArticle)
                    {
                        if (art.ProductName.Equals(ri.product))
                            orderAmount += art.ProductPrice * ri.numberOfProducts;
                    }
                }
                return orderAmount;
            }
        }
    }
    class Program
    {
        static void Main()
        {
            List<Article> listOfArticle = new List<Article>();
            List<Client> listOfClient = new List<Client>();
            List<Request> listOfRequest = new List<Request>();
            List<RequestItem> listOfRequestItem = new List<RequestItem>();
            listOfArticle.Add(new Article(1, "ПИВО", 14000));
            listOfArticle.Add(new Article(1, "ВОДКА", 60000));
            listOfArticle.Add(new Article(1, "ВИНО", 40000));
            listOfArticle.Add(new Article(1, "ВИСКИ", 500000));
            Client client1 = new Client(1, "ВАСЯ", "Минск", "(8029)-345-34-23");
            Client client2 = new Client(2, "ПЕТЯ", "Минск", "(8029)-345-34-23");
            Client client3 = new Client(3, "ИРА", "Минск", "(8029)-345-34-23");
            Client client4 = new Client(1, "ВАСЯ", "Минск", "(8029)-345-34-23");
            RequestItem requestItem1 = new RequestItem("ПИВО", 100);
            RequestItem requestItem2 = new RequestItem("ВОДКА", 50);
            RequestItem requestItem3 = new RequestItem("ВИНО", 80);
            RequestItem requestItem4 = new RequestItem("ПИВО", 100);
            listOfRequestItem.Add(new RequestItem("ПИВО", 100));
            listOfRequest.Add(new Request(1, client1, new DateTime(2015, 12, 31),
                          listOfRequestItem, ref listOfArticle, ref listOfClient));
            listOfRequestItem.Add(new RequestItem("ВОДКА", 50));
            listOfRequest.Add(new Request(2, client2, new DateTime(2015, 12, 31),
                          listOfRequestItem, ref listOfArticle, ref listOfClient));
            listOfRequestItem.Add(new RequestItem("ВИНО", 80));
            listOfRequest.Add(new Request(3, client3, new DateTime(2015, 12, 31),
                          listOfRequestItem, ref listOfArticle, ref listOfClient));
            listOfRequestItem.Add(new RequestItem("ПИВО", 100));
            listOfRequest.Add(new Request(1, client4, new DateTime(2015, 12, 31),
                        listOfRequestItem, ref listOfArticle, ref listOfClient));
            listOfRequestItem.Add(new RequestItem("ПИВО", 10));
            listOfRequest.Add(new Request(2, client2, new DateTime(2015, 12, 31),
                          listOfRequestItem, ref listOfArticle, ref listOfClient));
            foreach (Client c in listOfClient)
            { 
                c.Show();
                Console.WriteLine("====================");
            }
            foreach (Request r in listOfRequest)
            {
                r.Show();
                Console.WriteLine("====================");
            }    
         }
    }
}
