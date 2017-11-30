using System;

namespace stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stek = new Stack<int>();

            for (int i = 1; i < 20; i++) {
                stek.Push(i);
            }

            for (int i = 1; i < 20; i++) {
                System.Console.WriteLine("{0} {1}", stek.Pop(), stek.Space);
            }
        }
    }
}
