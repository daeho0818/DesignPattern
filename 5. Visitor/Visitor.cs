using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    // 요소 인터페이스 (클래스가 추가될 때마다 상속받아 함수 구현)
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
        // 클래스가 추가될 때마다 해당 클래스를 매개변수로 받는 함수 추가
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

