using System;

namespace kruznadvostrukalista
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Start");
            IntList lista1 = new IntList();
            IntList lista2 = new IntList();

            lista1.AddLast(1);
            lista1.AddLast(2);
            lista1.AddLast(2);
            lista1.AddLast(3);
            lista1.AddLast(4);
            lista1.AddLast(4);

            lista1.RemoveDuplicates();

            System.Console.WriteLine(lista1);
        }
    }
}
