using NewCProject;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList l = new LinkedList();
            l.Append(4);
            l.Display();
            l.Append(1);
            l.Append(11);
            l.Display();
            l.Prepend(0);
            l.Display();
            Console.WriteLine(l.Pop());
            l.Display();
            Console.WriteLine(l.Unqueue());
            l.Display();
            l.Sort();
            l.Display();
            Console.WriteLine(l.ToList());
            Console.WriteLine(l.GetMaxNode().GetValue());
            Console.WriteLine(l.GetMinNode().GetValue());

            Console.WriteLine(l.IsCircular());

        }
      
    }
}
