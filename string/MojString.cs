using System;

namespace mojtipstring {
	class MojString {
		private char[] str;

		private void Add(char c) {
			if (str != null) {
				char[] newStr = new char[GetLength() + 1];
				for (int i = 0; i < GetLength(); i++) {
					newStr[i] = str[i];
				}
				newStr[GetLength()] = c;
				str = newStr;
			}
		}
		private MojString[] AddStringToArray(MojString[] baseS, MojString s) {
			MojString[] newBaseS = new MojString[baseS.Length + 1];
			for (int i = 0; i < baseS.Length; i++) {
				newBaseS[i] = baseS[i].Copy();
			}
			newBaseS[newBaseS.Length - 1] = s.Copy();

			return newBaseS;
		}

		public MojString(char[] niz)
		{
			if (niz != null) {
				str = new char[niz.Length];
				for (int i = 0; i < niz.Length; i++) {
					str[i] = niz[i];
				}
			} else {
				System.Console.WriteLine("Prosledjeni niz nije definisan!");
			}
		}
		public int GetLength() {
			if (str != null) {
				return str.Length;
			}
			return -1;
		}
		public char[] GetArray() {
			if (str != null) {
				return str;
			}
			return new char[0];
		}
		public char GetCharAt(int i) {
			return str[i];
		}
		public void SetCharAt(int i, char c) {
			str[i] = c;
		}
		public int GetIndexOf(char c) {
			for (int i = 0; i < GetLength(); i++) {
				if (GetCharAt(i) == c) {
					return i;
				}
			}
			return -1;
		}
		public MojString Copy() {
			MojString s = new MojString(str);
			return s;
		}
		public void Append(MojString s) {
			char[] newStr = new char[GetLength() + s.GetLength()];
			for (int i = 0; i < GetLength(); i++) {
				newStr[i] = GetCharAt(i);
			}
			for (int i = GetLength(); i < GetLength() + s.GetLength(); i++) {
				newStr[i] = s.GetCharAt(i - GetLength());
			}
			str = newStr;
		}
		public void Prepend(MojString s) {
			char[] newStr = new char[GetLength() + s.GetLength()];
			for (int i = 0; i < s.GetLength(); i++) {
				SetCharAt(i, s.GetCharAt(i));
			}
			for (int i = s.GetLength(); i < GetLength() + s.GetLength(); i++) {
				SetCharAt(i, GetCharAt(i - s.GetLength()));
			}
			str = newStr;
			//s.Append(this);
		}
		public void Insert(int i, MojString s) {
			char[] newStr = new char[GetLength() + s.GetLength()];
			for (int j = 0; j < GetLength() + s.GetLength(); j++) {
				if (j == i) {
					for (; j < s.GetLength() + i; j++) {
						newStr[j] = s.GetCharAt(j - i);
					}
					j--;
				} else if (j < i) {
					newStr[j] = GetCharAt(j);
				} else {
					newStr[j] = GetCharAt(j - s.GetLength());
				}
			}
			str = newStr;
		}
		public MojString[] Split(char c) {
			MojString[] s = new MojString[0];

			int begin = 0;
			for (int i = 0; i < GetLength(); i++) {
				if (GetCharAt(i) == c) {
					s = AddStringToArray(s, Substring(begin, i - 1));
					begin = i + 1;
				} else if (i == GetLength() - 1) {
					s = AddStringToArray(s, Substring(begin, i));
				}
			}

			return s;
		}
		public MojString Substring(int i, int n) {
			if (str != null) {
				if (i >= 0 && i + n < GetLength()) {
					MojString s = new MojString(new char[0]);
					for (int j = i; j <= i + n; j++) {
						s.Add(GetCharAt(j));
					}
					return s;
				}
			}
			return new MojString(new char[0]);
		}
		public void Print(bool nl) {
			if (str != null) {
				for (int i = 0; i < GetLength(); i++) {
					System.Console.Write("{0}", GetCharAt(i));
				}
				if (nl) {
					System.Console.WriteLine();
				}
			}
		}
	}
}
