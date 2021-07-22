using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public interface Element
    {
        void Accept(Visitor visitor);
    }

    public class ConcreteElementA : Element
    {
        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class ConcreteElementB : Element
    {
        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public interface Visitor
    {
        void Visit(ConcreteElementA element);
        void Visit(ConcreteElementB element);
    }

    public class ConcreteVisitor : Visitor
    {
        public void Visit(ConcreteElementA element)
        {
            Console.WriteLine(element.ToString());
        }
        public void Visit(ConcreteElementB element)
        {
            Console.WriteLine(element.ToString());
        }
    }

    class Client
    {
/*        static void Main(string[] args)
        {
            HowToUse();
        }*/

        static void HowToUse()
        {
            ConcreteElementA elementA = new ConcreteElementA();
            ConcreteElementB elementB = new ConcreteElementB();

            ConcreteVisitor concreteVisitor = new ConcreteVisitor();

            elementA.Accept(concreteVisitor);
            elementB.Accept(concreteVisitor);

            concreteVisitor.Visit(elementA);
            concreteVisitor.Visit(elementB);
        }
    }
}

