using System;

namespace polinom
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] niz1 = {5, -2, 0, 4};
            int[] niz2 = {-3, 4, 1, -4, 8};
            Polinom p1 = new Polinom(niz1);
            Polinom p2 = new Polinom(niz2);

            Polinom p3 = p1.Saberi(p2);

            System.Console.WriteLine(p3);
        }
    }
}
