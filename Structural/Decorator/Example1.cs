using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatten.Practice.Structural.Decorator
{
    //Decorator is a structural pattern that allows adding new behaviors
    //to objects dynamically by placing them inside special wrapper objects.
    //Using decorators you can wrap objects countless number of times since both target objects
    //and decorators follow the same interface. The resulting object will get a stacking behavior of all wrappers.
    public interface IComponent
    {
        string DoWork();
    }

    public class Component: IComponent
    {
        public virtual string DoWork()
        {
            return "DoWork from Component.";
        }
    }

    public class BaseDecorator: Component
    {
        private IComponent _component;

        public BaseDecorator(IComponent component)
        {
            this._component = component;
        }
        public override string DoWork()
        {
            if (this._component != null)
                return this._component.DoWork();
            else
                return string.Empty;
        }
    }

    public class DecoratorA : BaseDecorator
    {
        public DecoratorA(IComponent component) : base(component) { }
        public override string DoWork()
        {
            return $"DoWork from DecoratorA. {base.DoWork()}";
        }
    }

    public class DecoratorB : BaseDecorator
    {
        public DecoratorB(IComponent component) : base(component) { }
        public override string DoWork()
        {
            return $"DoWork from DecoratorB. {base.DoWork()}";
        }
    }

    public class DecoratorC : BaseDecorator
    {
        public DecoratorC(IComponent component) : base(component) { }
        public override string DoWork()
        {
            return $"DoWork from DecoratorC. {base.DoWork()}";
        }
    }

    public class Example1Client
    {
        public static void Test()
        {
            Component component = new Component();
            DecoratorA compA = new DecoratorA(component);
            DecoratorB compB = new DecoratorB(compA);
            DecoratorC compC = new DecoratorC(compB);

            Console.WriteLine(compC.DoWork());
        }
    }
}
