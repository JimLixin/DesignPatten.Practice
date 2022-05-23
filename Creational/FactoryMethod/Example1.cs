using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatten.Practice.Creational.FactoryMethod
{
    public interface IProduct
    {
        string DoSomething();
    }

    public class ConcreteProductA : IProduct
    {
        public string DoSomething()
        {
            return "Doing task from ProductA!";
        }
    }

    public class ConcreteProductB : IProduct
    {
        public string DoSomething()
        {
            return "Doing task from ProductB!";
        }
    }

    public abstract class Creator
    {
        public abstract IProduct FactoryMethod();

        public string DoSomething()
        {
            var product = FactoryMethod();
            var result = $"Creator: The same creator's code has just worked with {product.DoSomething()}";
            return result;
        }
    }

    public class ConcreteCreatorA : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    public class ConcreteCreatorB : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }

    public class Example1Client
    {
        public void Test()
        {
            ClientWork(new ConcreteCreatorA());
            Console.WriteLine("");
            ClientWork(new ConcreteCreatorB());
        }

        private void ClientWork(Creator creator)
        {
            Console.WriteLine("Client: I'm not aware of the creator's class, but it still works.\n" + creator.DoSomething());
        }
    }
}
