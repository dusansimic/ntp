using System;

namespace dvostrukalista
{
    class Program
    {
        static void Main(string[] args)
        {
            IntList lista = new IntList();

            lista.AddLast(1);
            lista.AddLast(2);
            lista.AddLast(3);

            System.Console.WriteLine(lista);

            lista.Reverse();

            System.Console.WriteLine(lista);

            lista.Clear();

            System.Console.WriteLine(lista);
        }
    }
}
