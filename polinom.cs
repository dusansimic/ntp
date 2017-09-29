using System;

namespace polinom
{
    class Program
    {
        const int duzNiz = 5;
        class Polinom {
            private int[] koeficijenti = new int[duzNiz];
            private int lastIndex = 0;

            public void DodajKoeficijent(int k) {
                koeficijenti[lastIndex] = k;
                lastIndex++;
            }
            public int GetStepen() {
                return lastIndex;
            }
            public int GetKoeficijentNaStepenu(int i) {
                return koeficijenti[i];
            }
            public void SetKoeficijentNaStepenu(int i, int k) {
                koeficijenti[i] = k;
            }
            public void Saberi(Polinom p) {
                int longer;
                if (p.GetStepen() > GetStepen()) {
                    longer = p.GetStepen();
                } else {
                    longer = GetStepen();
                }

                for (int i = 0; i <= longer; i++) {
                    int zbir = 0;
                    if (i <= GetStepen()) {
                        zbir += GetKoeficijentNaStepenu(i);
                    } else if (i <= p.GetStepen()) {
                        zbir += p.GetKoeficijentNaStepenu(i);
                    }

                    SetKoeficijentNaStepenu(i, zbir);
                }

                lastIndex = longer;
            }
            public void Print() {
                Console.Write("{0}x", GetKoeficijentNaStepenu(0));
                for (int i = 1; i < koeficijenti.Length; i++) {
                    Console.Write(" + {0}x^({1})", GetKoeficijentNaStepenu(i), i);
                }
            }
        }
        static void Main(string[] args)
        {
            Polinom p1 = new Polinom();
            Polinom p2 = new Polinom();

            p1.DodajKoeficijent(5);
            p1.DodajKoeficijent(-2);
            p1.DodajKoeficijent(0);
            p1.DodajKoeficijent(4);

            p2.DodajKoeficijent(-3);
            p2.DodajKoeficijent(4);
            p2.DodajKoeficijent(1);
            p2.DodajKoeficijent(0);
            p2.DodajKoeficijent(8);

            p1.Saberi(p2);

            p1.Print();
        }
    }
}
