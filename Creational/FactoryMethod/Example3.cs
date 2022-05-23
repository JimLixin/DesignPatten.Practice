using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatten.Practice.Creational.FactoryMethod
{
    public interface IShape
    {
        string Draw();
    }

    public class Circle : IShape
    {
        public string Draw()
        {
            return "This ia a circle!";
        }
    }

    public class Rectangle : IShape
    {
        public string Draw()
        {
            return "This ia a Rectangle!";
        }
    }

    public class Square : IShape
    {
        public string Draw()
        {
            return "This ia a Square!";
        }
    }

    public enum ShapeType
    {
        Circle,
        Rectangle,
        Square
    }

    public static class ShapeFactory
    {
        public static IShape GetShape(ShapeType type)
        {
            switch (type)
            {
                case ShapeType.Circle:
                    return new Circle();
                case ShapeType.Rectangle:
                    return new Rectangle();
                case ShapeType.Square:
                    return new Square();
                default:
                    return default(IShape);
            }
        }
    }

    public class Example3Client
    {
        public void Test()
        {
            IShape rect = ShapeFactory.GetShape(ShapeType.Rectangle);
            Console.WriteLine(rect.Draw());
            IShape square = ShapeFactory.GetShape(ShapeType.Square);
            Console.WriteLine(square.Draw());
            IShape circle = ShapeFactory.GetShape(ShapeType.Circle);
            Console.WriteLine(circle.Draw());
        }
    }
}
