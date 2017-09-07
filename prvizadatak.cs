using System;

namespace prvizadatak
{
    class Program
    {
        // napravio sam funkciju getInt() da bi bilo preglednije od dugacke funckije
		// Convert.ToInt32()
		static Int32 getInt(char broj) {
			return Convert.ToInt32(new String(broj, 1));
		}

		// isto sam uradio za char
		static String getChar(Int32 broj) {
			return Convert.ToString(broj);
		}

		static String zbir(String prviBr, String drugiBr) {
			Int32 duzZbir;
			if (prviBr.Length > drugiBr.Length)
				duzZbir = prviBr.Length + 1;
			else
				duzZbir = drugiBr.Length + 1;

			Int32[] zbirBrInt = new Int32[duzZbir];

			Int32 iPrvi = prviBr.Length - 1, iDrugi = drugiBr.Length - 1;
			for (int i = duzZbir - 1; i > 0; i--) {
				if (iPrvi >= 0) {
					zbirBrInt[i] += getInt(prviBr[iPrvi]);
				}
				if (iDrugi >= 0) {
					zbirBrInt[i] += getInt(drugiBr[iDrugi]);
				}
				if (zbirBrInt[i] > 9) {
					zbirBrInt[i - 1] ++;
					zbirBrInt[i] += zbirBrInt[i] - 10;
				}
				Console.WriteLine("{0} {1}", zbirBrInt[i - 1], i);
				iPrvi--;
				iDrugi--;
			}
			
			String[] zbir = new String[duzZbir];
			Boolean startWriting = false;

			for (int i = 0; i < duzZbir; i++) {
				if (zbirBrInt[i] == 0 && !startWriting)
					continue;
				else
					startWriting = !startWriting;

				zbir[i] += getChar(zbirBrInt[i]);
			}

            String final = String.Join("", zbir);

			return final;
		}

		static String razlika(String prviBr, String drugiBr) {
			Int32 duzRaz;
			if (prviBr.Length > drugiBr.Length)
				duzRaz = prviBr.Length;
			else
				duzRaz = drugiBr.Length;
			
			Int32[] razBrInt = new Int32[duzRaz];

			Int32 iPrvi = prviBr.Length - 1, iDrugi = drugiBr.Length - 1;
			for (int i = duzRaz - 1; i > 0; i--) {
				if (iPrvi >= 0) {
					razBrInt[i] += getInt(prviBr[iPrvi]);
				}
				if (iDrugi >= 0) {
					razBrInt[i] -= getInt(drugiBr[iDrugi]);
				}
				if (razBrInt[i] < 0) {
					razBrInt[i] = Math.Abs(razBrInt[i]);
				}
				iPrvi--;
				iDrugi--;
			}

			String[] raz = new String[duzRaz];
			Boolean startWriting = false;

			for (int i = 0; i < duzRaz; i++) {
				if (razBrInt[i] == 0 && !startWriting)
					continue;
				else
					startWriting = !startWriting;
				
				raz[i] += getChar(razBrInt[i]);
			}

			String final = String.Join("", raz);
			
			return final;
		}

		static void Main(string[] args)
		{
			String prviBr, drugiBr;

			prviBr = Console.ReadLine();
			drugiBr = Console.ReadLine();

			Console.WriteLine(zbir(prviBr, drugiBr));
			Console.WriteLine(razlika(prviBr, drugiBr));
			
		}
    }
}
