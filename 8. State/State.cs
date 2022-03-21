using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class Context
    {
        // Stage 상황에 따라 파생클래스 객체를 할당하여 함수 실행
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

    // State 1
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

    // State 2
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

    // State 3
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
