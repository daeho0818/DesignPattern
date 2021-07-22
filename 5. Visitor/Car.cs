using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    public interface ICarElement
    {
        void Accept(ICarVisitor visitor);
    }

    public class Engine : ICarElement
    {
        public string Spec = "V4";
        public void Accept(ICarVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class Body : ICarElement
    {
        public string Spec = "Silver";
        public void Accept(ICarVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class Wheel : ICarElement
    {
        public string Spec = "p26";
        public void Accept(ICarVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public interface ICarVisitor
    {
        void Visit(Engine engine);
        void Visit(Body body);
        void Visit(Wheel wheel);
        void Visit(Car wheel);
    }

    public class CarPrintVisitor : ICarVisitor
    {
        public void Visit(Engine engine)
        {
            Console.WriteLine(engine.ToString());
        }

        public void Visit(Body body)
        {
            Console.WriteLine(body.ToString());
        }

        public void Visit(Wheel wheel)
        {
            Console.WriteLine(wheel.ToString());
        }
        public void Visit(Car car)
        {
            Console.WriteLine(car.ToString());
        }
    }

    public class Car : ICarElement
    {
        public string Market = "BMW";
        private List<ICarElement> elements;
        public Car()
        {
            elements = new List<ICarElement> {
                new Engine(),
                new Body(),
                new Wheel()
         };
        }

        public void Accept(ICarVisitor visitor)
        {
            foreach (var element in elements)
            {
                element.Accept(visitor);
            }
            visitor.Visit(this);
        }
    }
    class Client
    {
        public static void HowToTest()
        {
            ICarElement car = new Car();
            ICarVisitor visitor = new CarPrintVisitor();

            car.Accept(visitor);
        }
    }
}

