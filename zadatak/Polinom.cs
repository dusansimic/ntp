using System;
using System.Collections.Generic;

namespace zadatak {
	class Polinom {
		private List<Monom> poly = new List<Monom>();
		private bool isNull;

		/*
		 * Konstruktor za svtaranje nula polinoma.
		 */
		public Polinom() {
			isNull = true;
		}
		/*
		 * Konstruktor za stvaranje polinoma od prosledjenog niza realnih brojeva.
		 * Ovaj konstruktor postuje navedena pravila za redjanje monoma u polinomu
		 * zbog strukture podataka u nizu realnih brojeva.
		 */
		public Polinom(int[] niz) {
			for (int i = 0; i < niz.Length; i++) {
				poly.Add(new Monom(niz[i], i));
			}
			isNull = false;
		}
		/*
		 * Konstruktor za stvaranje polinoma od prosledjenog niza monoma.
		 * Ovaj konstruktor postuje navedena pravlia za redjanje monoma u polinomu
		 * usled koriscenja metode `Dodaj()`.
		 */
		public Polinom(List<Monom> monomi) {
			for (int i = 0; i < monomi.Count; i++) {
				try {
					Dodaj(new Monom(monomi[i].Coef, monomi[i].Power));
				} catch (Exception e) {
					System.Console.WriteLine("Exception caught: {0}", e);
				}
			}
			isNull = false;
		}
		/*
		 * Metoda za dodavanje monoma u polinom.
		 * Ova metoda postuje navedena pravila za redjanje monoma u polinomu.
		 */
		public void Dodaj(Monom m) {
			if (poly.Count == 0) {
				poly.Add(m);
				isNull = false;
				return;
			}
			int left = 0, right = poly.Count, border = (left + right) / 2;
			while  (left <= right) {
				border = (left + right) / 2;
				if (border == poly.Count) {
					poly.Add(m);
					return;
				}
				if (poly[border].Power == m.Power && poly[border].Coef == - m.Coef) {
					poly.RemoveAt(border);
					return;
				}
				if (poly[border].Power == m.Power && m.Coef == 0) {
					throw new System.Exception("Monom ne zadovoljava pravila!");
				}
				if (poly[border].Power < m.Power) {
					left = border + 1;
				} else if (poly[border].Power > m.Power) {
					right = border - 1;
				} else {
					throw new System.Exception("Monom ne zadovoljava pravila!");
				}
			}
			if (poly[border].Power < m.Power) {
				poly.Insert(border + 1, m);
			} else if (poly[border].Power > m.Power) {
				poly.Insert(border, m);
			} else {
				throw new System.Exception("Monom ne zadovoljava pravila!");
			}
		}
		/*
		 * Metoda koja dodaje monome prosledjenok polinoma ukoliko je to moguce.
		 */
		public void Dodaj(Polinom p) {
			if (p.isNull) return;
			for (int i = 0; i < p.poly.Count; i++) {
				Dodaj(p.poly[i]);
			}
		}
		/*
		 * Metoda koja mnozi polinom i monom.
		 */
		public void Pomnozi(Monom m) {
			for (int i = 0; i < poly.Count; i++) {
				poly[i].Coef *= m.Coef;
				poly[i].Power += m.Power;
			}
		}
		/*
		 * Metoda koja mnozi dva polinoma (lokalni i prosledjeni).
		 */
		public void Pomnozi(Polinom p) {
			if (p.isNull) {
				poly.Clear();
				isNull = true;
				return;
			} else if (isNull) {
				p.poly.Clear();
				p.isNull = true;
				return;
			}
			Polinom novi = new Polinom();
			for (int i = 0; i < p.poly.Count; i++) {
				Polinom pPrim = new Polinom(poly);
				pPrim.Pomnozi(p.poly[i]);
				Saberi(novi, pPrim);
			}
			poly = novi.poly;
		}
		/*
		 * Staticka metoda koja sabira dva polinoma.
		 * Prvi parametar je polinom koji je rezultat sabiranja.
		 */
		public static void Saberi(Polinom p1, Polinom p2) {
			for (int i = 0; i < p2.poly.Count; i++) {
				try {
					p1.Dodaj(p2.poly[i]);
				} catch {
					for (int j = 0; j < p1.poly.Count; j++) {
						if (p1.poly[j].Power == p2.poly[i].Power) {
							p1.poly[j].Coef += p2.poly[i].Coef;
							if (p1.poly[j].Coef == 0) {
								p1.poly.RemoveAt(j);
							}
						}
					}
				}
			}
			if (p1.poly.Count == 0) {
				p1.isNull = true;
			}
		}
		/*
		 * Staticka metoda koja mnozi dva polinoma.
		 * Prvi parametar je polinom koji je rezultat mnozenja.
		 */
		public static void Pomnozi(Polinom p1, Polinom p2) {
			p1.Pomnozi(p2);
		}
		/*
		 * Prepisana sistemska metoda za vracanje stringa.
		 */
		public override string ToString() {
			if (isNull) {
				return "0";
			}
			string str = "";
			for (int i = 0; i < poly.Count; i++) {
				string temp = poly[i].ToString();
				if (temp == "0") {
					continue;
				} else if (temp.StartsWith("-")) {
					str += "(";
					temp += ")";
				}
				str += temp;
				if (i != poly.Count - 1) {
					str += " + ";
				}
			}
			return str;
		}
	}
}