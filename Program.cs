using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatten.Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            (new DesignPatten.Practice.Creational.FactoryMethod.Example1Client()).Test();
            Console.WriteLine("<======================================================>");
            (new DesignPatten.Practice.Creational.FactoryMethod.Example2Client()).Test();
            Console.WriteLine("<======================================================>");
            (new DesignPatten.Practice.Creational.FactoryMethod.Example3Client()).Test();
            Console.WriteLine("<======================================================>");
            (new DesignPatten.Practice.Creational.AbstractFactory.Example1Client()).Test();
            Console.WriteLine("<======================================================>");
            (new DesignPatten.Practice.Creational.Singleton.Example1Client()).Test();
            Console.WriteLine("<======================================================>");
            (new DesignPatten.Practice.Creational.ProtoType.Example1Client()).Test();
            Console.WriteLine("<======================================================>");
            DesignPatten.Practice.Behavioral.Command.Example1Client.Test();
            Console.WriteLine("<======================================================>");
            DesignPatten.Practice.Behavioral.Mediator.Example1Client.Test();
            Console.WriteLine("<======================================================>");
            DesignPatten.Practice.Behavioral.Observer.Example2.Example1Client.Test();
            Console.WriteLine("<======================================================>");
            DesignPatten.Practice.Behavioral.Strategy.Example1Client.Test();
            Console.WriteLine("<======================================================>");
            DesignPatten.Practice.Behavioral.TemplateMethod.Example1Client.Test();
            Console.WriteLine("<======================================================>");
            DesignPatten.Practice.Structural.Adapter.Example1Client.Test();
            Console.WriteLine("<======================================================>");
            DesignPatten.Practice.Structural.Bridge.Example1Client.Test();
            Console.ReadLine();
        }
    }
}
