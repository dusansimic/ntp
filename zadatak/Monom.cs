namespace zadatak {
	public class Monom {
		private double coef;
		private double power;

		public double Coef {
			get { return coef; }
			set { coef = value; }
		}
		public double Power {
			get { return power; }
			set { power = value; }
		}

		public Monom(double coef, double power) {
			this.coef = coef;
			this.power = power;
		}

		public override string ToString() {
			if (coef == 0) {
				return "0";
			}
			string str = "";
			str += coef;
			if (power == 0) {
				return str;
			}
			str += "x";
			if (power == 1) {
				return str;
			}
			str += "^";
			str += power;
			return str;
		}
	}
}