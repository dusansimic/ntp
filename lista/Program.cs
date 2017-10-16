using System;

namespace lista
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
        }
    }
}
