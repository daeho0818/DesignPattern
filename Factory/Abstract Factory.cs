using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public abstract class AbstractFactory
    {
        public abstract ProductA CreateProductA();
        public abstract ProductB CreateProductB();
    }

    public class ConcreteFactory1 : AbstractFactory
    {
        public override ProductA CreateProductA()
        {
            return new ConcreteProduct1A();
        }

        public override ProductB CreateProductB()
        {
            return new ConcreteProduct1B();   
        }
    }

    public class ConcreteFactory2 : AbstractFactory
    {
        public override ProductA CreateProductA()
        {
            return new ConcreteProduct2A();
        }

        public override ProductB CreateProductB()
        {
            return new ConcreteProduct2B();
        }
    }

    public class ProductA { }
    public class ConcreteProduct1A : ProductA { }
    public class ConcreteProduct2A : ProductA { }

    public class ProductB { }
    public class ConcreteProduct1B : ProductB { }
    public class ConcreteProduct2B : ProductB { }

    class Client
    {
        public void HowToTest()
        {
            AbstractFactory factory = new ConcreteFactory1();

            ProductA prodA = factory.CreateProductA();
            ProductB prodB = factory.CreateProductB();
        }
    }
}
