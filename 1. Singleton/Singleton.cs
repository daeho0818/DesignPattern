using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class Singleton
    {
        // Singleton 객체
        public static Singleton Instance { get; } = new Singleton();

        private Singleton()
        {
        }

        public void Method()
        {
            Console.WriteLine("Singleton Pettern");
        }
    }

    class Clent
    {
        public static void HowToTest()
        {
            // Singleton 객체를 활용하여 함수 호출
            Singleton.Instance.Method();
        }
    }
}