using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public abstract class Node
    {
        public string Name { get; protected set; }
        public abstract void Display();
    }

    public class File : Node
    {
        public File(string name)
        {
            Name = name;
        }

        public override void Display()
        {
            Console.WriteLine($"File : {Name}");
        }
    }

    public class Directory : Node
    {
        private List<Node> children = new List<Node>();

        public Directory(string name)
        {
            Name = name;
        }

        public override void Display()
        {
            Console.WriteLine($"DIS : {Name}");
            foreach (Node comp in children)
            {
                comp.Display();
            }
        }

        public void AddChild(Node child)
        {
            if (child != null)
            {
                children.Add(child);
            }
        }
    }

    class Client
    {
        public static void HowToTest()
        {
            Directory dir = new Directory("Folder");
            File file1 = new File("a1.doc");
            File file2 = new File("a2.doc");
            File file3 = new File("a3.doc");
            Directory sub = new Directory("SubFolder");

            dir.AddChild(file1);
            dir.AddChild(file2);
            dir.AddChild(file3);
            dir.AddChild(sub);

            DisplayNodes(dir);
        }

        static void DisplayNodes(params Node[] component)
        {
            // File와 Directory 둘 다 공통된 함수 실행 가능
            foreach (Node item in component)
            {
                item.Display();
            }
        }
    }
}
