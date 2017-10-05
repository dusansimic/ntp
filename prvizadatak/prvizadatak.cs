using System;

namespace prvizadatak
{
    class Program
    {
        // napravio sam funkciju getInt() da bi bilo preglednije od dugacke funckije
				// Convert.ToInt32()
				static Int32 getInt(Char broj) {
					return Convert.ToInt32(new String(broj, 1));
				}

				// isto sam uradio za char
				static Char getChar(Int32 broj) {
					return Convert.ToChar(broj);
				}

				static String getStr (Int32 broj) {
					return Convert.ToString(broj);
				}

				static String zbir(String prviBr, String drugiBr) {
					Int32 duzZbir;
					if (prviBr.Length > drugiBr.Length) {
						duzZbir = prviBr.Length + 1;
					} else {
						duzZbir = drugiBr.Length + 1;
					}

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
							zbirBrInt[i] = zbirBrInt[i] - 10;
						}
						iPrvi--;
						iDrugi--;
					}
					
					String[] zbir = new String[duzZbir];
					Boolean startWriting = false;

					for (int i = 0; i < duzZbir; i++) {
						if (zbirBrInt[i] != 0 && !startWriting)
							startWriting = !startWriting;
						if (zbirBrInt[i] == 0 && !startWriting)
							continue;

						zbir[i] += getStr(zbirBrInt[i]);
					}

					String final = String.Join("", zbir);

					return final;
				}

				static String razlika(String prviBr1, String drugiBr1) {
					Int32 duzRaz;
					Char[] prviBr = prviBr1.ToCharArray();
					Char[] drugiBr = drugiBr1.ToCharArray();

					Boolean isNegative = false;

					if (prviBr.Length > drugiBr.Length)
						duzRaz = prviBr.Length;
					else
						duzRaz = drugiBr.Length;
					
					Int32[] razBrInt = new Int32[duzRaz];

					Int32 iPrvi = prviBr.Length - 1, iDrugi = drugiBr.Length - 1;
					for (int i = duzRaz - 1; i > 0; i--) {
						Int32 temp = 0;
						if (iPrvi >= 0) {
							temp += getInt(prviBr1[iPrvi]);
						}
						if (iDrugi >= 0) {
							temp -= getInt(drugiBr1[iDrugi]);
						}
						if (temp < 0) {
							Int32 tempBr = 0;
							if (iPrvi > 0) {
								tempBr += 10;
								tempBr += getInt(prviBr1[iPrvi]);
								prviBr[iPrvi - 1] = getChar(getInt(prviBr[iPrvi - 1]) - 1);
								tempBr -= getInt(drugiBr1[iDrugi]);
								prviBr[iPrvi] = getChar(tempBr);
							} else {
								isNegative = !isNegative;
								prviBr[iPrvi] = getChar(Math.Abs(temp));
							}
							
						}
						iPrvi--;
						iDrugi--;
					}

					String[] raz = new String[duzRaz];

					String finalNum = new String(prviBr);
					String final;

					if (isNegative) {
						final = String.Concat("-", finalNum);
					} else {
						final = String.Join("", finalNum);
					}
					
					return final;
				}

				static void Main(string[] args)
				{
					Console.WriteLine("Ready.");
					String prviBr, drugiBr;

					Console.Write("Prvi broj: ");
					prviBr = Console.ReadLine();
					Console.Write("Drugi broj: ");
					drugiBr = Console.ReadLine();

					Console.Write("Zbir: ");
					Console.WriteLine(zbir(prviBr, drugiBr));
					Console.Write("Razlika: ");
					Console.WriteLine(razlika(prviBr, drugiBr));
					
				}
    }
}
