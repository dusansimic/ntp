using System;

namespace polinom {
	class Polinom {
		private int[] koeficijenti;
		private int izleti = 0;

		public Polinom(int[] niz)
		{
			if (niz != null) {
				koeficijenti = new int[niz.Length];
				for (int i = 0; i < niz.Length; i++) {
					koeficijenti[i] = niz[i];
				}
			} else {
				System.Console.WriteLine("Prosledjeni polinom nije definisan!");
			}
		}
		public int GetLength() {
			return koeficijenti.Length;
		}
		public int GetKoeficijentNaStepenu(int i) {
			if (i < 0 || i > koeficijenti.Length - 1) {
				izleti++;
				System.Console.WriteLine("Izleto si! {0}", izleti);
				return -1;
			}
			return koeficijenti[i];
		}
		public void SetKoeficijentNaStepenu(int i, int k) {
			koeficijenti[i] = k;
		}
		public Polinom Saberi(Polinom p) {
			int longer;
			if (p.GetLength() > GetLength()) {
				longer = p.GetLength();
			} else {
				longer = GetLength();
			}

			int[] niz = new int[longer];

			for (int i = 0; i < longer; i++) {
				int zbir = 0;
				if (i < GetLength()) {
					zbir += GetKoeficijentNaStepenu(i);
				}
				if (i < p.GetLength()) {
					zbir += p.GetKoeficijentNaStepenu(i);
				}

				niz[i] = zbir;
			}

			return new Polinom(niz);
		}
		public override string ToString() {
			string rez = "";
			
			if (GetLength() > 0) {
				if (GetKoeficijentNaStepenu(0) != 0) {
					rez += Convert.ToString(GetKoeficijentNaStepenu(0));
				}
			}
			if (GetLength() > 1) {
				if (GetKoeficijentNaStepenu(1) != 0) {
					rez += (" + " + Convert.ToString(GetKoeficijentNaStepenu(1) + "x"));
				}
			}
			
			for (int i = 2; i < koeficijenti.Length; i++) {
				if (GetKoeficijentNaStepenu(i) != 0) {
					rez += (" + " + Convert.ToString(GetKoeficijentNaStepenu(i)) +"x^(" + Convert.ToString(i) +")");
				}
			}
			return rez;
		}
	}
}