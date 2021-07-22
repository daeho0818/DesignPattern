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

    public class IcecreamPrintVisitor : IcecreamVisitor
    {
        public void Visit(DogBar icecream, string content)
        {
            Console.WriteLine($"갈색 색깔인 {content}");
        }
        public void Visit(SuperCon icecream, string content)
        {
            Console.WriteLine($"여려 가지 색깔인 {content}");
        }
        public void Visit(ShootingStar icecream, string content)
        {
            Console.WriteLine($"하늘색 색깔인 {content}");
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
            Iceceream dogBar = new DogBar();
            Iceceream superCon = new SuperCon();
            Iceceream shootingStar = new ShootingStar();

            IcecreamVisitor visitor = new IcecreamPrintVisitor();

            dogBar.Accept(visitor);
            superCon.Accept(visitor);
            shootingStar.Accept(visitor);
        }
    }
}
