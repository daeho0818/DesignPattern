using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public abstract class Abstraction
    {
        public IImplementor Implementor { get; set; }
        public abstract void Operation();
    }
    public class RefinedAbstraction : Abstraction
    {
        public override void Operation()
        {
            Implementor.ImplementorOperation();
        }
    }

    public interface IImplementor
    {
        void ImplementorOperation();
    }

    public class ImplementorA : IImplementor
    {
        public void ImplementorOperation()
        {
            Console.WriteLine("ImplementorA : ImplementorOperation()");
        }
    }

    public class ImplementorB : IImplementor
    {
        public void ImplementorOperation()
        {
            Console.WriteLine("ImplementorB : ImplementorOperation()");
        }
    }

    class Client
    {
        public static void HowToUse()
        {
            Abstraction ab = new RefinedAbstraction();

            // 상황에 맞게 할당하여 각자 클래스에 구현된 인터페이스 함수 실행
            ab.Implementor = new ImplementorA();
            ab.Operation();

            ab.Implementor = new ImplementorB();
            ab.Operation();
        }
    }
}
