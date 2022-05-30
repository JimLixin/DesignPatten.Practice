using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatten.Practice.Behavioral.Mediator
{
    //Mediator模式也可以理解为迪米特法则的实际体现。
    //一个类只需要跟自己的直接朋友进行交流，这里的OrderMgt和DeliveryMgt都只跟Mediator进行交流，而并不直接跟对方交流。
    public interface IMediator
    { 
        void Notify(object sender, string e);
    }

    public abstract class BaseComponent
    {
        protected IMediator _mediator;
        public BaseComponent(IMediator mediator = null)
        {
            this._mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            this._mediator = mediator;
        }
    }

    public class OrderMgt : BaseComponent
    {
        public void CreatOrder()
        {
            Console.WriteLine($"Order has been created!");
            this._mediator.Notify(this, "OrderCreated");
        }

        public void CancelOrder()
        {
            Console.WriteLine($"Order has been cancelled!");
            this._mediator.Notify(this, "OrderCancelled");
        }
    }

    public class DelivertMgt : BaseComponent
    {
        public void DeliveryOrder()
        {
            Console.WriteLine($"Prepare for delivering order ...");
        }

        public void CancelDelivery()
        {
            Console.WriteLine($"Cancel for delivering order!");
        }
    }

    public class Mediator : IMediator
    {
        private OrderMgt orderMgt;
        private DelivertMgt deliveryMgt;

        public Mediator(OrderMgt orderMgt, DelivertMgt deliveryMgt)
        {
            this.orderMgt = orderMgt;
            this.deliveryMgt = deliveryMgt;
            this.orderMgt.SetMediator(this);
            this.deliveryMgt.SetMediator(this);
        }

        public void Notify(object sender, string e)
        {
            switch (e)
            {
                case "OrderCreated":
                    this.deliveryMgt.DeliveryOrder();
                    break;
                case "OrderCancelled":
                    this.deliveryMgt.CancelDelivery();
                    break;
            }
        }
    }

    public class Example1Client
    {
        public static void Test()
        {
            OrderMgt orderMgt = new OrderMgt();
            DelivertMgt delivertMgt = new DelivertMgt();
            Mediator mediator = new Mediator(orderMgt, delivertMgt);
            orderMgt.CreatOrder();
            orderMgt.CancelOrder();
        }
    }
}
