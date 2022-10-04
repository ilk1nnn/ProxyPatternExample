using System;




namespace ProxyPatternExample
{


    // Example #1

   
    public interface ISubject
    {
        void Request();
    }

    class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("RealSubject: Handling Request.");
        }
    }

    class Proxy : ISubject
    {
        private RealSubject _realSubject;

        public Proxy(RealSubject realSubject)
        {
            this._realSubject = realSubject;
        }

        
        public void Request()
        {
            if (this.CheckAccess())
            {
                this._realSubject.Request();

                this.LogAccess();
            }
        }

        public bool CheckAccess()
        {
            Console.WriteLine("Proxy: Checking access prior to firing a real request.");

            return true;
        }

        public void LogAccess()
        {
            Console.WriteLine("Proxy: Logging the time of request.");
        }
    }

    public class Client
    {
       
        public void ClientCode(ISubject subject)
        {

            subject.Request();

        }
    }





    // Example #2


    interface Image
    {
        void Display();

    }


    class RealImage : Image // (DataBase)
    {

        public string Filename { get; set; }

        public RealImage(string filename)
        {
            Filename = filename;
        }

        public void Display()
        {
            Console.WriteLine("Displaying from RealImage");
        }

        public void LoadFromDisk()
        {
            Console.WriteLine("Loading (RealImage)");
        }

    }


    class ProxyImage : Image 
    {

        RealImage realImage;

        public ProxyImage(RealImage realImage)
        {
            this.realImage = realImage;
        }

        public void Display()
        {
            realImage.Display();
            realImage.LoadFromDisk();
        }
    }


    class ProxyPatternDemo // Client (Application)
    {
        public void ProxyPattern(Image image)
        {
            image.Display();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            //Client client = new Client();

            //Console.WriteLine("Client: Executing the client code with a real subject:");
            //RealSubject realSubject = new RealSubject();
            //client.ClientCode(realSubject);

            //Console.WriteLine();

            //Console.WriteLine("Client: Executing the same client code with a proxy:");
            //Proxy proxy = new Proxy(realSubject);
            //client.ClientCode(proxy);


            ProxyPatternDemo proxy = new ProxyPatternDemo();
            Console.WriteLine("Real Image: ");
            RealImage realImage = new RealImage("somethning.jpg");
            proxy.ProxyPattern(realImage);


            Console.WriteLine();


            Console.WriteLine("Proxy Image : ");
            ProxyImage proxyImage = new ProxyImage(realImage);
            proxy.ProxyPattern(proxyImage);


            Console.WriteLine();


        }
    }

}