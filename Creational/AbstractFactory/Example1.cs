using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatten.Practice.Creational.AbstractFactory
{
    public interface IMonitor
    {
        void Display();
    }

    public interface IMemory
    {
        void Store();
    }

    public interface IHardDisk
    {
        void Write();
    }

    public interface ICpu
    {
        void Calculate();
    }

    public interface IComputerFactory
    {
        IMonitor createMonitor();
        IMemory createMemory();
        IHardDisk createHardDisk();
        ICpu createCpu();
    }

    public class HighendMonitor : IMonitor
    {
        public void Display()
        {
            Console.WriteLine("Display from Highend Monitor!");
        }
    }

    public class LowendMonitor : IMonitor
    {
        public void Display()
        {
            Console.WriteLine("Display from Lowend Monitor!");
        }
    }

    public class HighendMemory : IMemory
    {
        public void Store()
        {
            Console.WriteLine("Storing data from Highend Memory!");
        }
    }

    public class LowendMemory : IMemory
    {
        public void Store()
        {
            Console.WriteLine("Storing data from Lowend Memory!");
        }
    }

    public class HighendHardDisk : IHardDisk
    {
        public void Write()
        {
            Console.WriteLine("Writing data from Highend HDD!");
        }
    }

    public class LowendHardDisk : IHardDisk
    {
        public void Write()
        {
            Console.WriteLine("Writing data from Lowend HDD!");
        }
    }

    public class HighendCpu : ICpu
    {
        public void Calculate()
        {
            Console.WriteLine("Calculating from Highend CPU!");
        }
    }

    public class LowendCpu : ICpu
    {
        public void Calculate()
        {
            Console.WriteLine("Calculating from Lowend CPU!");
        }
    }

    public class HighendComputerFactory : IComputerFactory
    {
        public IMonitor createMonitor()
        {
            return new HighendMonitor();
        }

        public IMemory createMemory()
        {
            return new HighendMemory();
        }

        public IHardDisk createHardDisk()
        {
            return new HighendHardDisk();
        }

        public ICpu createCpu()
        {
            return new HighendCpu();
        }
    }

    public class LowendComputerFactory : IComputerFactory
    {
        public IMonitor createMonitor()
        {
            return new LowendMonitor();
        }

        public IMemory createMemory()
        {
            return new LowendMemory();
        }

        public IHardDisk createHardDisk()
        {
            return new LowendHardDisk();
        }

        public ICpu createCpu()
        {
            return new LowendCpu();
        }
    }

    public class Example1Client
    {
        private void AssembleComputer(IComputerFactory factory)
        {
            var cpu = factory.createCpu();
            var ram = factory.createMemory();
            var monitor = factory.createMonitor();
            var hdd = factory.createHardDisk();

            cpu.Calculate();
            ram.Store();
            hdd.Write();
            monitor.Display();
        }

        public void Test()
        {
            AssembleComputer(new HighendComputerFactory());
            Console.WriteLine("<======================================================>");
            AssembleComputer(new LowendComputerFactory());
        }

    }

}
