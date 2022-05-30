using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatten.Practice.Behavioral.Observer.Example1
{
    //Basic example
    //When customer create order, factory and service desk classes will receive the notification from EventHub class
    public interface ISubject
    {
        void Attach(IObserver subscriber);

        void Detach(IObserver subscriber);

        void Notify(string e);
    }

    public interface IObserver
    {
        void Update(string e);
    }

    public class EventHub : ISubject
    {
        private List<IObserver> subscribers = new List<IObserver>();

        public void Attach(IObserver subscriber)
        {
            this.subscribers.Add(subscriber);
        }

        public void Detach(IObserver subscriber)
        {
            this.subscribers.Remove(subscriber);
        }

        public void Notify(string e)
        {
            foreach (var s in subscribers)
            {
                s.Update(e);
            }
        }
    }

    public class Customer : IObserver
    {
        private ISubject eventHub;
        public Customer(ISubject eventHub)
        {
            this.eventHub = eventHub;
        }

        public void Update(string e)
        {
            Console.WriteLine($"Received event {e} in Customer class!");
        }

        public void CreateOrder()
        {
            this.eventHub.Notify("OrderCreated");
        }
    }

    public class Factory : IObserver
    {
        private ISubject eventHub;
        public Factory(ISubject eventHub)
        {
            this.eventHub = eventHub;
        }

        public void Update(string e)
        {
            Console.WriteLine($"Received event {e} in Factory class!");
        }

        public void Produce()
        {
            StartProduce();
            System.Threading.Thread.Sleep(3000);
            FinishProduce();
        }

        private void StartProduce()
        {
            Console.WriteLine($"Factory start to produce.");
            this.eventHub.Notify("ProduceStarted");
        }

        private void FinishProduce()
        {
            Console.WriteLine($"Factory finished produce.");
            this.eventHub.Notify("ProduceFinished");
        }
    }

    public class ServiceDesk : IObserver
    {
        private ISubject eventHub;
        public ServiceDesk(ISubject eventHub)
        {
            this.eventHub = eventHub;
        }

        public void Update(string e)
        {
            Console.WriteLine($"Received event {e} in ServiceDesk class!");
        }

        public void PhoneCall()
        {
            Console.WriteLine($"Service desk is calling customer to confirm the order.");
            this.eventHub.Notify("OrderConfirmed");
        }
    }

    public class Example1Client
    {
        public static void Test()
        {
            EventHub eventHub = new EventHub();
            Customer cust = new Customer(eventHub);
            Factory factory = new Factory(eventHub);
            ServiceDesk sd = new ServiceDesk(eventHub);
            eventHub.Attach(factory);
            eventHub.Attach(sd);

            cust.CreateOrder();

            eventHub.Detach(factory);
            eventHub.Detach(sd);

            cust.CreateOrder();
        }
    }

}
