using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iceacream
{
    public abstract class Iceceream
    {
        public abstract void Accept(IcecreamVisitor visitor);
    }

    public class DogBar : Iceceream
    {
        public override void Accept(IcecreamVisitor visitor)
        {
            visitor.Visit(this, "먹으면 돼지가 되는 돼지바!");
        }
    }
    public class SuperCon : Iceceream
    {
        public override void Accept(IcecreamVisitor visitor)
        {
            visitor.Visit(this, "오마이걸이 광고한 슈퍼콘!");
        }
    }
    public class ShootingStar : Iceceream
    {
        public override void Accept(IcecreamVisitor visitor)
        {
            visitor.Visit(this, "입안에서 겁나게 터지는 슈팅스타!");
        }
    }

    public interface IcecreamVisitor
    {
        void Visit(DogBar icecream, string content);
        void Visit(SuperCon icecream, string content);
        void Visit(ShootingStar icecream, string content);
    }

    public interface IcecreamEater
    {
        void Eat(DogBar icecream, string content);
        void Eat(SuperCon icecream, string content);
        void Eat(ShootingStar icecream, string content);
    }

    public interface IcecreamNamePrinter
    {
        void Print(DogBar icecream);
        void Print(SuperCon icecream);
        void Print(ShootingStar icecream);
    }

    public class IcecreamPrintVisitor : IcecreamVisitor
    {
        public void Visit(DogBar icecream, string content)
        {
            Console.WriteLine($"{icecream} : 갈색 색깔인 {content}");
        }
        public void Visit(SuperCon icecream, string content)
        {
            Console.WriteLine($"{icecream} :여려 가지 색깔인 {content}");
        }
        public void Visit(ShootingStar icecream, string content)
        {
            Console.WriteLine($"{icecream} :하늘색 색깔인 {content}");
        }
    }

    public class IcecreamEatVisitor : IcecreamEater
    {
        public void Eat(DogBar icecream, string content)
        {
            Console.WriteLine($"{icecream}의 맛 : {content}");
        }
        public void Eat(SuperCon icecream, string content)
        {
            Console.WriteLine($"{icecream}의 맛 : {content}");
        }
        public void Eat(ShootingStar icecream, string content)
        {
            Console.WriteLine($"{icecream}의 맛 : {content}");
        }
    }

    public class IcecreamNamePrintVisitor : IcecreamNamePrinter
    {
        public void Print(DogBar icecream)
        {
            Console.WriteLine("이름 : 돼지바");
        }
        public void Print(SuperCon icecream)
        {
            Console.WriteLine("이름 : 슈퍼콘");
        }
        public void Print(ShootingStar icecream)
        {
            Console.WriteLine("이름 : 슈팅스타");
        }
    }

    class Client
    {
        static void _Main(string[] args)
        {
            HowToTest();
        }
        static void HowToTest()
        {
            DogBar dogBar = new DogBar();
            SuperCon superCon = new SuperCon();
            ShootingStar shootingStar = new ShootingStar();

            IcecreamVisitor visitor = new IcecreamPrintVisitor();
            IcecreamEater eater = new IcecreamEatVisitor();
            IcecreamNamePrinter printer = new IcecreamNamePrintVisitor();

            dogBar.Accept(visitor);
            superCon.Accept(visitor);
            shootingStar.Accept(visitor);

            eater.Eat(dogBar, "초코와 딸기 맛이 난다.");
            eater.Eat(superCon, "여러 가지 맛이 있지만 개인적으로 쿠앤크가 맛있다.");
            eater.Eat(shootingStar, "톡 쏘는 맛이 난다.");

            printer.Print(dogBar);
            printer.Print(superCon);
            printer.Print(shootingStar);
        }
    }
}
