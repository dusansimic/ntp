using System;

namespace lista
{
    class Program
    {
        static void Main(string[] args)
        {
            IntList lista1 = new IntList();
            IntList lista2 = new IntList();

            lista1.AddLast(1);
            lista1.AddLast(2);
            lista1.AddLast(3);

            System.Console.WriteLine(lista1);

            lista1.Reverse();
            
            System.Console.WriteLine(lista1);
        }
    }
}
