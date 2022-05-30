using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatten.Practice.Behavioral.Observer.Example2
{
    public enum EventType
    {
        OrderCreated,
        OrderConfirmed,
        ProduceStarted,
        ProduceFinished,
        DeliverStarted,
        DeliverFinished,
        OrderReceived
    }

    public interface ISubject
    {
        void Attach(BaseEntity subscriber, EventType e);

        void Detach(BaseEntity subscriber, EventType e);

        void Notify(EventType e);
    }

    public interface IObserver
    {
        void Update(EventType e);

        void Subscribe(EventType e);

        void UnSubscribe(EventType e);
    }

    public class EventHub : ISubject
    {
        private Dictionary<BaseEntity, List<int>> subscribers = new Dictionary<BaseEntity, List<int>>();

        public void Attach(BaseEntity subscriber, EventType e)
        {
            if (subscribers.ContainsKey(subscriber))
            {
                subscribers[subscriber].Add((int)e);
            }
            else
            {
                subscribers.Add(subscriber, new List<int>(new []{ (int)e }));
            }
        }

        public void Detach(BaseEntity subscriber, EventType e)
        {
            if (subscribers.ContainsKey(subscriber))
            {
                subscribers[subscriber].Remove((int)e);
            }
        }

        public void Notify(EventType e)
        {
            foreach (var s in subscribers)
            {
                if (s.Value.Contains((int)e))
                {
                    s.Key.Update(e);
                }
            }
        }
    }

    public abstract class BaseEntity
    {
        protected ISubject eventHub;

        public BaseEntity(ISubject eventHub)
        {
            this.eventHub = eventHub;
        }

        public void Subscribe(EventType e)
        {
            this.eventHub.Attach(this, e);
        }

        public void UnSubscribe(EventType e)
        {
            this.eventHub.Detach(this, e);
        }

        public virtual void Update(EventType e)
        {
            Console.WriteLine($"Received event {e} in Customer class!");
        }
    }

    public class Customer : BaseEntity, IObserver
    {
        public Customer(ISubject eventHub): base(eventHub) { } 

        public override void Update(EventType e)
        {
            base.Update(e);
            switch (e)
            {
                case EventType.ProduceStarted:
                    WhenKnowProduceStarted();
                    break;
                case EventType.ProduceFinished:
                    WhenKnowProduceFinished();
                    break;
                case EventType.DeliverStarted:
                    WhenKnowDeliverStarted();
                    break;
                case EventType.DeliverFinished:
                    WhenKnowDeliverFinished();
                    break;
            }
        }

        public void CreateOrder()
        {
            this.eventHub.Notify(EventType.OrderCreated);
        }

        public void WhenKnowProduceStarted()
        {
            Console.WriteLine("[Customer] I know my order has been started to produced!");
        }

        public void WhenKnowProduceFinished()
        {
            Console.WriteLine("[Customer] I'm glad to know my order has been finished!");
        }

        public void WhenKnowDeliverStarted()
        {
            Console.WriteLine("[Customer] I know my delivery has been started!");
        }

        public void WhenKnowDeliverFinished()
        {
            Console.WriteLine("[Customer] I'm glad toknow the delivery has been finished!");
            this.eventHub.Notify(EventType.OrderReceived);
        }
    }

    public class Factory : BaseEntity, IObserver
    {
        public Factory(ISubject eventHub): base(eventHub) { }

        public override void Update(EventType e)
        {
            base.Update(e);
            switch (e)
            {
                case EventType.OrderConfirmed:
                    Produce();
                    break;
            }
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
            this.eventHub.Notify(EventType.ProduceStarted);
        }

        private void FinishProduce()
        {
            Console.WriteLine($"Factory finished produce.");
            this.eventHub.Notify(EventType.ProduceFinished);
        }
    }

    public class DeliveryTeam : BaseEntity, IObserver
    {
        public DeliveryTeam(ISubject eventHub) : base(eventHub) { }

        public override void Update(EventType e)
        {
            base.Update(e);
            switch (e)
            {
                case EventType.ProduceFinished:
                    Delivery();
                    break;
            }
        }

        public void Delivery()
        {
            DeliveryStart();
            System.Threading.Thread.Sleep(5000);
            DeliveryFinished();
        }

        private void DeliveryStart()
        {
            Console.WriteLine("[Delivery Team] We are going to delivery the package!");
            this.eventHub.Notify(EventType.DeliverStarted);
        }

        private void DeliveryFinished()
        {
            Console.WriteLine("[Delivery Team] We are finished to delivery the package!");
            this.eventHub.Notify(EventType.DeliverFinished);
        }
    }

    public class ServiceDesk : BaseEntity, IObserver
    {
        public ServiceDesk(ISubject eventHub): base(eventHub) { }
        public override void Update(EventType e)
        {
            base.Update(e);
            switch (e)
            {
                case EventType.OrderCreated:
                    PhoneCall();
                    break;
                case EventType.OrderReceived:
                    ProcessCustomerFeedback();
                    break;
            }
        }

        public void PhoneCall()
        {
            Console.WriteLine($"Service desk is calling customer to confirm the order.");
            this.eventHub.Notify(EventType.OrderConfirmed);
        }

        public void ProcessCustomerFeedback()
        {
            Console.WriteLine($"Service desk received feedback that customer has received his products.");
        }
    }

    public class Example1Client
    {
        public static void Test()
        {
            EventHub eventHub = new EventHub();
            Customer cust = new Customer(eventHub);
            Factory factory = new Factory(eventHub);
            DeliveryTeam deliv = new DeliveryTeam(eventHub);
            ServiceDesk sd = new ServiceDesk(eventHub);
            factory.Subscribe(EventType.OrderConfirmed);
            deliv.Subscribe(EventType.ProduceFinished);
            sd.Subscribe(EventType.OrderCreated);
            sd.Subscribe(EventType.OrderReceived);
            cust.Subscribe(EventType.ProduceStarted);
            cust.Subscribe(EventType.ProduceFinished);
            cust.Subscribe(EventType.DeliverStarted);
            cust.Subscribe(EventType.DeliverFinished);

            cust.CreateOrder();
            Console.WriteLine("<============== Factory and ServiceDesk has unsubscribed from their events! =================>");

            factory.UnSubscribe(EventType.OrderCreated);
            sd.UnSubscribe(EventType.OrderCreated);

            cust.CreateOrder();
        }
    }

}
