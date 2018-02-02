using System;
using System.Collections.Generic;

namespace exception {
	class Artikal {
		private string naziv;
		private double cena;

		public Artikal(string naziv, double cena) {
			this.Naziv = naziv;
			this.Cena = cena;
		}

		public string Naziv {
			get { return naziv; }
			set { naziv = value; }
		}

		public double Cena {
			get { return cena; }
			set { cena = value; }
		}
	}
	class Kupac {
		private List<Artikal> korpa;
		private int novac;

		public Kupac(int novac) {
			korpa = new List<Artikal>();
			this.Novac = novac;
		}

		public int Novac {
			get { return novac; }
			set { novac = value; }
		}

		public void DodajArtikal(Artikal a) {
			korpa.Add(a);
		}

		public void VratiArtikal(Artikal a) {
			try {
				korpa.Remove(a);
			} catch {
				System.Console.WriteLine("Artikal nije uspesno vracen!");
			}
		}

		public double GetUkupnaCena() {
			if (korpa.Count == 0) {
				return 0.0;
			}
			double count = 0.0;
			foreach(Artikal art in korpa) {
				count += art.Cena;
			}
			return count;
		}
	}

	class Kasa {
		private Queue<Kupac> kupcovi;
		private double ukupnoNovca;

		public Kasa(double ukupnoNovca = 0) {
			kupcovi = new Queue<Kupac>();
			this.ukupnoNovca = ukupnoNovca;
		}

		public void DodajKupca(Kupac k) {
			kupcovi.Enqueue(k);
		}

		public void UsluziKupca() {
			Kupac k = kupcovi.Dequeue();
			ukupnoNovca += k.GetUkupnaCena();
		}
	}

	class Univer {
		 private List<Kasa> kase;

		 public Univer() {
			 kase = new List<Kasa>();
		 }

		 public void AddKasa(Kasa k) {
			 kase.Add(k);
		 }
	}
}