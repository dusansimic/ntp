using System;
using System.Collections.Generic;

namespace zadatak
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Prvi test");
            int[] niz1 = {5, 0, -2, 3};
            Polinom p1 = new Polinom(niz1);
            System.Console.WriteLine(p1);
            System.Console.WriteLine();

            System.Console.WriteLine("Drugi test");
            List<Monom> monomi2 = new List<Monom>();
            monomi2.Add(new Monom(3, 3));
            monomi2.Add(new Monom(5, 0));
            monomi2.Add(new Monom(0, 1));
            monomi2.Add(new Monom(-2, 2));
            Polinom p2 = new Polinom(monomi2);
            System.Console.WriteLine(p2);
            System.Console.WriteLine();

            System.Console.WriteLine("Treci test");
            p1.Dodaj(new Monom(4, 4));
            System.Console.WriteLine(p1);
            System.Console.WriteLine();

            System.Console.WriteLine("Cetvrti test");
            try {
                p1.Dodaj(new Monom(4, 4));
            } catch {
                System.Console.WriteLine("Doslo je do greske, i to ne bilo kakve nego nisu postovana navedena pravila za pravljenje polinoma!");
            }
            System.Console.WriteLine(p1);
            System.Console.WriteLine();

            System.Console.WriteLine("Peti test");
            p1.Dodaj(new Monom(-4, 4));
            System.Console.WriteLine(p1);
            System.Console.WriteLine();

            System.Console.WriteLine("Sesti test");
            Polinom p3 = new Polinom();
            p1.Dodaj(p3);
            System.Console.WriteLine(p1);
            System.Console.WriteLine();
            
            System.Console.WriteLine("Sedmi test");
            Polinom p4 = new Polinom();
            p4.Dodaj(p1);
            System.Console.WriteLine(p4);
            System.Console.WriteLine();

            System.Console.WriteLine("Osmi test");
            p1 = Polinom.Saberi(p1, p2);
            System.Console.WriteLine(p1);
            System.Console.WriteLine();

            System.Console.WriteLine("Deveti test");
            Polinom.Pomnozi(p1, p2);
            System.Console.WriteLine(p1);
            System.Console.WriteLine();

            System.Console.WriteLine("Deseti test");
            Polinom p5 = Polinom.Saberi(p2, p2);
            System.Console.WriteLine(p5);
            System.Console.WriteLine();

            System.Console.WriteLine("Jedanaesti test");
            p1.Pomnozi(new Polinom());
            System.Console.WriteLine(p1);
            System.Console.WriteLine();
        }
    }
}
