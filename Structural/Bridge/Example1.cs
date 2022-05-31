using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatten.Practice.Structural.Bridge
{
    public interface IImplementation
    {
        string DoWork();
    }

    public class Abstraction
    {
        protected IImplementation _implementation;

        public Abstraction(IImplementation implementation)
        {
            this._implementation = implementation;
        }

        public void DoSomething()
        {
            Console.WriteLine("Abstraction: get work from: " + _implementation.DoWork());
        }
    }

    public class ConcreteImplementationA: IImplementation
    {
        public string DoWork()
        {
            return "This is ConcreteImplementationA";
        }
    }

    public class ConcreteImplementationB : IImplementation
    {
        public string DoWork()
        {
            return "This is ConcreteImplementationB";
        }
    }

    public class Example1Client
    {
        public static void Test()
        {
            ConcreteImplementationA a = new ConcreteImplementationA();
            Abstraction absA = new Abstraction(a);
            absA.DoSomething();

            ConcreteImplementationB b = new ConcreteImplementationB();
            Abstraction absB = new Abstraction(b);
            absB.DoSomething();
        }
    }
}
