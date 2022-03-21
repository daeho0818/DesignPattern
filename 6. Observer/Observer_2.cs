using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Observer_2
{
    class Subject
    {
        public event EventHandler Changed;

        public Subject()
        {
            var timer = new System.Timers.Timer(1000);
            // 1초(1000ms)가 지날 때마다 호출할 동작 지정
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        public void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, EventArgs.Empty);
            }
        }
    }
    class Observer
    {
        private Subject subject = new Subject();
        private string status;

        public void Test()
        {
            // Changed 이벤트가 호출될 때마다 실행할 동작 지정
            subject.Changed += Subject_Changed;

            Thread.Sleep(5000);
        }

        private void Subject_Changed(object sender, EventArgs e)
        {
            status = "Subject Updated at " + DateTime.Now;
            Console.WriteLine(status);
        }
    }

    class Program
    {
        static void _Main(string[] args)
        {
            Observer objserver = new Observer();

            objserver.Test();
        }
    }
}
