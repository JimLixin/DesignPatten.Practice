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
            Console.ReadLine();
        }
    }
}
