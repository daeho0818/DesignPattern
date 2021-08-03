using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class Context
    {
        public State CurrentState { get; set; }

        public Context()
        {
            CurrentState = new NormalState();
        }

        public void SetCreditScore(int creditScore)
        {
            Console.WriteLine($"{creditScore}");
            CurrentState.ChangeScore(this, creditScore);
        }
    }

    public abstract class State
    {
        public decimal InterestRate { get; protected set; }

        public abstract void ChangeScore(Context context, int score);
    }

    public class VIPState : State
    {
        public VIPState()
        {
            InterestRate = 15.00M;
        }
        public override void ChangeScore(Context context, int score)
        {
            if (score < 750)
            {
                context.CurrentState = new NormalState();

                context.CurrentState.ChangeScore(context, score);
            }
        }
    }

    public class NormalState : State
    {
        public NormalState()
        {
            InterestRate = 25.00M;
        }
        public override void ChangeScore(Context context, int score)
        {
            if (score < 600)
            {
                context.CurrentState = new BadState();

                context.CurrentState.ChangeScore(context, score);
            }
            else if (score >= 750)
            {
                context.CurrentState = new VIPState();

                context.CurrentState.ChangeScore(context, score);
            }
        }
    }

    public class BadState : State
    {
        public BadState()
        {
            InterestRate = 35.00M;
        }
        public override void ChangeScore(Context context, int score)
        {
            if (score >= 600)
            {
                context.CurrentState = new NormalState();

                context.CurrentState.ChangeScore(context, score);
            }
        }
    }

    class Clent
    {
        static void _Main(string[] args)
        {
            HowToTest();
        }

        public static void HowToTest()
        {
            var ctx = new Context();
            ctx.SetCreditScore(550);
            Console.WriteLine($"{ctx.CurrentState.InterestRate}");

            ctx.SetCreditScore(760);
            Console.WriteLine($"{ctx.CurrentState.InterestRate}");
        }
    }
}
