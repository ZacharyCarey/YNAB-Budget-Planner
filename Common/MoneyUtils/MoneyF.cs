using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Common.MoneyUtils {

	/// <summary>
	/// A structure to hold an amount of money stored internally as a decimal. 
	/// </summary>
	public readonly struct Moneyf {

		public readonly decimal Value;

		public Moneyf(decimal value) {
			this.Value = value;
		}

		public Moneyf(Money value) {
			this.Value = value.AsLong() / 100.0m;
		}

		public bool Negative => (Value < 0);
		public ulong Dollars => (ulong)Math.Abs(Value);
		public uint Cents => (uint)Math.Abs((Value - Math.Truncate(Value)) * 100);
		public decimal Fraction => Math.Abs((Value * 100) - Math.Truncate(Value * 100));

		#region Math
		#region Rounding
		private Moneyf DigitRounding(int digits, Func<decimal, decimal> func) {
			decimal value = Value;
			int d = digits;
			while (d < 0) {
				d++;
				value *= 10;
			}
			while (d > 0) {
				d--;
				value /= 10;
			}

			value = func(value);

			while (digits < 0) {
				digits++;
				value /= 10;
			}
			while (digits > 0) {
				digits--;
				value *= 10;
			}
			return new Moneyf(value);
		}

		/// <summary>
		/// Returns the smallest integral value that is greater than or equal to the specified number.
		/// </summary>
		/// <returns></returns>
		public readonly Moneyf Ceiling() {
			//TODO rewrite so this and Ceiling(int digits) uses same rounding function
			return new Moneyf(Math.Ceiling(Value));
		}

		/// <summary>
		/// Returns the smallest integral value that is greater than or equal to the specified number.
		/// -2 = cents
		/// -1 = tens of cents
		/// 0 = dollar
		/// 1 = tens of dollars
		/// 2 = hundreds of dollars
		/// etc.
		/// </summary>
		/// <returns></returns>
		public readonly Moneyf Ceiling(int digits) {
			return DigitRounding(digits, Math.Ceiling);
		}

		/// <summary>
		/// Returns the largest integral value that is less than or equal to the specified number.
		/// </summary>
		/// <returns></returns>
		public readonly Moneyf Floor() {
			//TODO rewrite so this and Floor(int digits) uses same rounding function
			return new Moneyf(Math.Floor(Value));
		}

		/// <summary>
		/// Returns the largest integral value that is less than or equal to the specified number.
		/// -2 = cents
		/// -1 = tens of cents
		/// 0 = dollar
		/// 1 = tens of dollars
		/// 2 = hundreds of dollars
		/// etc.
		/// </summary>
		/// <returns></returns>
		public readonly Moneyf Floor(int digits) {
			return DigitRounding(digits, Math.Floor);
		}

		/// <summary>
		/// Rounds the number away from zero.
		/// </summary>
		/// <returns></returns>
		public readonly Moneyf RoundUp() {
			//TODO rewrite so this and RoundUp(int digits) uses same rounding function
			if (Value >= 0) return new Moneyf(Math.Ceiling(Value));
			else return new Moneyf(Math.Floor(Value));
		}

		/// <summary>
		/// Rounds the number away from zero with a digit.
		/// -2 = cents
		/// -1 = tens of cents
		/// 0 = dollar
		/// 1 = tens of dollars
		/// 2 = hundreds of dollars
		/// etc.
		/// </summary>
		/// <param name="digits"></param>
		/// <returns></returns>
		public readonly Moneyf RoundUp(int digits) {
			return DigitRounding(digits, (decimal value) => {
				if (value >= 0) return Math.Ceiling(value);
				else return Math.Floor(value);
			});
		}

		/// <summary>
		/// Rounds the number closer to zero.
		/// </summary>
		/// <returns></returns>
		public readonly Moneyf RoundDown() {
			//TODO rewrite so this and RoundDown(int digits) uses same rounding function
			return new Moneyf(Math.Truncate(Value));
		}

		/// <summary>
		/// Rounds the number closer to zero with a digit.
		/// -2 = cents
		/// -1 = tens of cents
		/// 0 = dollar
		/// 1 = tens of dollars
		/// 2 = hundreds of dollars
		/// etc.
		/// </summary>
		/// <param name="digits"></param>
		/// <returns></returns>
		public readonly Moneyf RoundDown(int digits) {
			return DigitRounding(digits, (decimal value) => {
				return Math.Truncate(value);
			});
		}

		/// <summary>
		/// Rounds to the nearest dollar.
		/// </summary>
		/// <returns></returns>
		public readonly Moneyf Round() {
			//TODO rewrite so this and Round(int digits) uses same rounding function
			return new Moneyf(Math.Round(Value, MidpointRounding.AwayFromZero));
		}

		/// <summary>
		/// Rounds to the nearest digit.
		/// -2 = cents
		/// -1 = tens of cents
		/// 0 = dollar
		/// 1 = tens of dollars
		/// 2 = hundreds of dollars
		/// etc.
		/// </summary>
		/// <param name="digits"></param>
		/// <returns></returns>
		public readonly Moneyf Round(int digits) {
			return DigitRounding(digits, (decimal value) => {
				return Math.Round(value, MidpointRounding.AwayFromZero);
			});
		}
		#endregion

		public readonly Moneyf Abs() {
			return new Moneyf(Math.Abs(Value));
		}
		#endregion

		#region Operators
		public static Moneyf operator +(Moneyf a) => a;
		public static Moneyf operator -(Moneyf a) => new Moneyf(-a.Value);
		public static Moneyf operator +(Moneyf a, Moneyf b) => new Moneyf(a.Value + b.Value);
		public static Moneyf operator -(Moneyf a, Moneyf b) => new Moneyf(a.Value - b.Value);
		public static Moneyf operator *(Moneyf a, decimal mul) => new Moneyf(a.Value * mul);
		public static Moneyf operator *(decimal mul, Moneyf a) => new Moneyf(a.Value * mul);
		public static Moneyf operator /(Moneyf a, decimal div) => new Moneyf(a.Value / div);
		public static bool operator ==(Moneyf a, Moneyf b) => a.Value == b.Value;
		public static bool operator !=(Moneyf a, Moneyf b) => a.Value != b.Value;
		public static bool operator <(Moneyf a, Moneyf b) => a.Value < b.Value;
		public static bool operator <=(Moneyf a, Moneyf b) => a.Value <= b.Value;
		public static bool operator >(Moneyf a, Moneyf b) => a.Value > b.Value;
		public static bool operator >=(Moneyf a, Moneyf b) => a.Value >= b.Value;
		#endregion

		#region Conversion
		public static explicit operator Moneyf(decimal d) => new Moneyf(d);
		public static explicit operator decimal(Moneyf d) => d.Value;

		public static bool TryParse(string input, out Moneyf result) {
			decimal value;
			if(decimal.TryParse(input, NumberStyles.Currency, null, out value)) {
				result = new Moneyf(value);
				return true;
			} else {
				result = new Moneyf();
				return false;
			}
		}

		public static explicit operator Money(Moneyf money) {
			return new Money(money);
		}
		#endregion

		#region Object Overrides
		public readonly override string ToString() {
			return Value.ToString("0.00############################");
		}

		public readonly string ToString(bool dollarSign, bool twoDecimalPlaces = true) {
			return (dollarSign ? "?" : "") + Value.ToString("N" + (twoDecimalPlaces ? "2" : ""));
		}

		public readonly string ToString(string format) {
			return Value.ToString(format);
		}

		public override bool Equals(object obj) {
			if (ReferenceEquals(obj, null))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (!(obj is Moneyf))
				return false;
			Moneyf other = (Moneyf)obj;
			return Value == other.Value;
		}

		public override int GetHashCode() {
			return Value.GetHashCode();
		}
		#endregion
	}
}
