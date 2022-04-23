using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Thread_Pool
{
    class Program
    {
        static void Test(string[] args)
        {
            ThreadPool.QueueUserWorkItem(Calc);
            ThreadPool.QueueUserWorkItem(Calc, 10.0);
            ThreadPool.QueueUserWorkItem(Calc, 20.0);

            Console.ReadLine();
        }

        static void Calc(object radius)
        {
            if (radius == null) return;

            double r = (double)radius;
            double area = r * r * 3.14f;
            Console.WriteLine($"r = {r}, area = {area}");
        }
    }
}
