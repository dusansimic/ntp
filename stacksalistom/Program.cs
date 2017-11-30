using System;

namespace stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stek = new Stack<int>();

            stek.Push(3);
            stek.Push(2);
            stek.Push(1);

            System.Console.WriteLine(stek.Pop());
            System.Console.WriteLine(stek.Top());
            System.Console.WriteLine(stek.Pop());
            System.Console.WriteLine(stek.Top());
        }
    }
}
