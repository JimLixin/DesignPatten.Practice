using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatten.Practice.Behavioral.Command
{
    public interface ICommand
    {
        void Execute();
    }

    public class Monitor
    {
        public void TurnOn()
        {
            Console.WriteLine("Monitor has been turned on!");
        }

        public void TurnOff()
        {
            Console.WriteLine("Monitor has been turned off...");
        }
    }

    public class MainUnit
    {
        public void PowerOn()
        {
            Console.WriteLine("MainUnit is power on!");
        }

        public void PowerOff()
        {
            Console.WriteLine("MainUnit is power off...");
        }

        public void Sleep()
        {
            Console.WriteLine("MainUnit is going to sleep...");
        }
    }

    public class MonitorOnCommand : ICommand
    {
        private Monitor _monitor;
        public MonitorOnCommand(Monitor monitor)
        {
            this._monitor = monitor;
        }
        public void Execute()
        {
            this._monitor.TurnOn();
        }
    }

    public class MonitorOffCommand : ICommand
    {
        private Monitor _monitor;
        public MonitorOffCommand(Monitor monitor)
        {
            this._monitor = monitor;
        }
        public void Execute()
        {
            this._monitor.TurnOff();
        }
    }

    public class MainUnitPowerOnCommand : ICommand
    {
        private MainUnit _mainUnit;
        public MainUnitPowerOnCommand(MainUnit mainUnit)
        {
            this._mainUnit = mainUnit;
        }

        public void Execute()
        {
            this._mainUnit.PowerOn();
        }
    }

    public class MainUnitPowerOffCommand : ICommand
    {
        private MainUnit _mainUnit;
        public MainUnitPowerOffCommand(MainUnit mainUnit)
        {
            this._mainUnit = mainUnit;
        }

        public void Execute()
        {
            this._mainUnit.PowerOff();
        }
    }

    public class MainUnitSleepCommand : ICommand
    {
        private MainUnit _mainUnit;
        public MainUnitSleepCommand(MainUnit mainUnit)
        {
            this._mainUnit = mainUnit;
        }

        public void Execute()
        {
            this._mainUnit.Sleep();
        }
    }

    public class Worker
    {
        ICommand _command;
        public Worker() {}

        public void ReceiveCommand(ICommand command)
        {
            this._command = command;
        }

        public void ExecuteCommand()
        {
            this._command.Execute();
        }
    }

    public class Example1Client
    {
        public static void Test()
        {
            MainUnit mainUnit = new MainUnit();
            Monitor monitor = new Monitor();
            Worker worker = new Worker();
            worker.ReceiveCommand(new MainUnitPowerOnCommand(mainUnit));
            worker.ExecuteCommand();
            worker.ReceiveCommand(new MonitorOffCommand(monitor));
            worker.ExecuteCommand();
            worker.ReceiveCommand(new MonitorOnCommand(monitor));
            worker.ExecuteCommand();
            worker.ReceiveCommand(new MainUnitSleepCommand(mainUnit));
            worker.ExecuteCommand();
            worker.ReceiveCommand(new MainUnitPowerOffCommand(mainUnit));
            worker.ExecuteCommand();
        }
    }
}
