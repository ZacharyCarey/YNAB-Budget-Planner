using JsonSerializable;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace YNAB_Budget_Planner.Backend.MoneyUtils {

	/// <summary>
	/// A structure to hold an amount of money. Tracks fractions of pennies with functions to round up and down and other useful things.
	/// </summary>
	public readonly struct Money : IJsonSerializable {

		#region Rounding Constants
		/// <summary>
		/// Used for rounding digits.
		/// </summary>
		/// <see cref="RoundUp"/>
		/// <see cref="RoundDown"/>
		/// <see cref="Round"/>
		public const int CENTS = -1;

		/// <summary>
		/// Used for rounding digits.
		/// </summary>
		/// <see cref="RoundUp"/>
		/// <see cref="RoundDown"/>
		/// <see cref="Round"/>
		public const int DOLLAR = 0;

		/// <summary>
		/// Used for rounding digits.
		/// </summary>
		/// <see cref="RoundUp"/>
		/// <see cref="RoundDown"/>
		/// <see cref="Round"/>
		public const int TENS = 1;

		/// <summary>
		/// Used for rounding digits.
		/// </summary>
		/// <see cref="RoundUp"/>
		/// <see cref="RoundDown"/>
		/// <see cref="Round"/>
		public const int HUNDREDS = 2;

		/// <summary>
		/// Used for rounding digits.
		/// </summary>
		/// <see cref="RoundUp"/>
		/// <see cref="RoundDown"/>
		/// <see cref="Round"/>
		public const int THOUSANDS = 3;
		#endregion

		public readonly bool IsNegative;

		//Not going to lie, if someone who actually needs a long to store their money is using this program then
		//that means this must be the most popular finance software in the world. Not sure how that happened.
		//If that happens though, THEN this variable can finally be upgraded to a long! :D
		public readonly uint Dollars;
		public readonly uint Cents;

		#region Constructors
		public Money(bool Negative = false, uint Dollars = 0, uint Cents = 0) {
			if (Cents >= 100) throw new ArgumentOutOfRangeException("Cents", Cents, "Cents must be a non-negative number less than 100.");
			this.IsNegative = Negative;
			this.Dollars = Dollars;
			this.Cents = Cents;
			if ((Dollars == 0) && (Cents == 0)) IsNegative = false;
		}
		//TODO should these constructors instead be "Parse" functions to imply that they may round?
		//Converts a float to Money. Accuracy not guranteed due to the nature of floats.
		public Money(float value) {
			if (value >= 0) {
				IsNegative = false;
			} else {
				IsNegative = true;
				value = -value;
			}
			Dollars = (uint)value;
			Cents = (uint)((ulong)(value * 100) % 100);
			if ((Dollars == 0) && (Cents == 0)) IsNegative = false;
		}

		//Converts a double to Money. Accuracy not guranteed due to the nature of doubles.
		public Money(double value) {
			if (value >= 0) {
				IsNegative = false;
			} else {
				IsNegative = true;
				value = -value;
			}
			Dollars = (uint)value;
			Cents = (uint)((ulong)(value * 100) % 100);
			if ((Dollars == 0) && (Cents == 0)) IsNegative = false;
		}

		//Converts a decimal to Money. Accuracy not guranteed due to the nature of decimals.
		public Money(decimal value) {
			if (value >= 0) {
				IsNegative = false;
			} else {
				IsNegative = true;
				value = -value;
			}
			Dollars = (uint)value;
			Cents = (uint)((ulong)(value * 100) % 100);
			if ((Dollars == 0) && (Cents == 0)) IsNegative = false;
		}

		// Converts Moneyf to Money. Accuracy not guranteed due to rounding errors.
		public Money(Moneyf value) : this((decimal)value){

		}
		#endregion

		#region Math
		#region Rounding
		/// </summary>
		/// Rounds the money up to the nearest digit.
		/// -1 = nearest tens of cents
		/// 0 = nearest dollar
		/// 1 = nearest tens of dollars
		/// </summary>
		/// <param name="digits"></param>
		/// <param name="func">Params are: money, sig figs, result</param>
		/// <returns></returns>
		private Money DigitRounding(int digits, Func<bool, ulong, ulong, ulong, ulong> func) { //func params = (ulong Money, ulong Operand, ulong SigFigs)
			if (digits < -1) throw new ArgumentOutOfRangeException("digits", digits, "Digits must be a valid number.");
			if (digits > 10) throw new ArgumentOutOfRangeException("digits", digits, "Digits must be 10 or less");

			ulong money = (ulong)Dollars * 100 + Cents;
			ulong sigfigs = 1;
			for (int i = -1; i <= digits; i++) {
				sigfigs *= 10;
			}
			ulong operand = money % sigfigs;
			money /= sigfigs;
			money = func(IsNegative, money, operand, sigfigs / 10);
			money = money * sigfigs;

			ulong dollars = money / 100;
			ulong cents = money % 100;
			if (dollars > uint.MaxValue) throw new OverflowException();
			return new Money(IsNegative, (uint)dollars, (uint)cents);
		}

		/// <summary>
		/// Rounds away from zero to the nearest dollar.
		/// </summary>
		/// <returns></returns>
		public readonly Money RoundUp() {
			return DigitRounding(0, RoundUpFunction);
		}

		/// <summary>
		/// Rounds the money up away from zero to the nearest digit.
		/// -1 = nearest tens of cents
		/// 0 = nearest dollar
		/// 1 = nearest tens of dollars
		/// etc.
		/// </summary>
		/// <param name="digits"></param>
		/// <returns></returns>
		public readonly Money RoundUp(int digits) {
			return DigitRounding(digits, RoundUpFunction);
		}

		private static ulong RoundUpFunction(bool Negative, ulong Money, ulong Operand, ulong SigFigs) {
			if (Operand > 0) {
				checked {
					return Money + 1;
				}
			} else {
				return Money;
			}
		}

		/// <summary>
		/// Rounds the money to the nearest dollar towards zero.
		/// </summary>
		/// <returns></returns>
		public readonly Money RoundDown() {
			return DigitRounding(0, RoundDownFunction);
		}

		/// <summary>
		/// Rounds the money down towards zero to the nearest digit.
		/// -1 = nearest tens of cents
		/// 0 = nearest dollar
		/// 1 = nearest tens of dollars
		/// etc.
		/// </summary>
		/// <param name="digits"></param>
		/// <returns></returns>
		public readonly Money RoundDown(int digits) {
			return DigitRounding(digits, RoundDownFunction);
		}

		private static ulong RoundDownFunction(bool Negative, ulong Money, ulong Operand, ulong SigFigs) {
			return Money;
		}

		/// <summary>
		/// Rounds money to the nearest dollar.
		/// </summary>
		/// <returns></returns>
		public readonly Money Round() {
			return DigitRounding(0, RoundFunction);
		}

		/// <summary>
		/// Rounds the money to the nearest digit.
		/// -1 = nearest tens of cents
		/// 0 = nearest dollar
		/// 1 = nearest tens of dollars
		/// etc.
		/// </summary>
		/// <param name="digits"></param>
		/// <returns></returns>
		public readonly Money Round(int digits) {
			return DigitRounding(digits, RoundFunction);
		}

		private static ulong RoundFunction(bool Negative, ulong Money, ulong Operand, ulong SigFigs) {
			if ((Operand / SigFigs) >= 5) {
				return RoundUpFunction(Negative, Money, Operand, SigFigs);
			} else {
				return RoundDownFunction(Negative, Money, Operand, SigFigs);
			}
		}

		/// <summary>
		/// Returns the smallest money value that is greater than or equal to the specified number.
		/// </summary>
		/// <returns></returns>
		public readonly Money Ceiling() {
			return DigitRounding(0, CeilingFunction);
		}

		/// <summary>
		/// Returns the smallest money value that is greater than or equal to the specified number.
		/// -1 = nearest tens of cents
		/// 0 = nearest dollar
		/// 1 = nearest tens of dollars
		/// etc.
		/// </summary>
		/// <returns></returns>
		public readonly Money Ceiling(int digits) {
			return DigitRounding(digits, CeilingFunction);
		}

		private static ulong CeilingFunction(bool Negative, ulong Money, ulong Operand, ulong SigFigs) {
			if (!Negative && (Operand > 0)) {
				checked {
					return Money + 1;
				}
			} else {
				return Money;
			}
		}

		/// <summary>
		/// Returns the largest money value that is less than or equal to the specified number.
		/// </summary>
		/// <returns></returns>
		public readonly Money Floor() {
			return DigitRounding(0, FloorFunction);
		}

		/// <summary>
		/// Returns the largest money value that is less than or equal to the specified number.
		/// -1 = nearest tens of cents
		/// 0 = nearest dollar
		/// 1 = nearest tens of dollars
		/// etc.
		/// </summary>
		/// <returns></returns>
		public readonly Money Floor(int digits) {
			return DigitRounding(digits, FloorFunction);
		}

		private static ulong FloorFunction(bool Negative, ulong Money, ulong Operand, ulong SigFigs) {
			if (Negative && (Operand > 0)) {
				checked {
					return Money + 1;
				}
			} else {
				return Money;
			}
		}
		#endregion

		public readonly Money Abs() {
			return new Money(false, Dollars, Cents);
		}
		#endregion

		#region Operators
		public long AsLong() {
			return (IsNegative ? -1 : 1) * ((long)Dollars * 100 + Cents);
		}

		public static Money FromLong(long value) {
			bool isNegative = (value < 0);
			ulong abs = (ulong)Math.Abs(value);
			if (abs > uint.MaxValue * 100L + 99) throw new ArgumentOutOfRangeException("value", "Invalid value was given.");
			return new Money(
				isNegative,
				(uint)(abs / 100),
				(uint)(abs % 100)
			);
		}

		public static Money operator +(Money a) => a;
		public static Money operator -(Money a) => new Money(!a.IsNegative, a.Dollars, a.Cents);

		public static Money operator +(Money a, Money b) {
			long result = 0;
			checked {
				result = a.AsLong() + b.AsLong();
			}

			bool neg = false;
			if(result < 0) {
				neg = true;
				result = -result;
			}

			uint cents = (uint)(result % 100);
			result /= 100;
			if (result > uint.MaxValue) throw new OverflowException();
			return new Money(neg, (uint)result, cents);
		}
			

		public static Money operator -(Money a, Money b) => a + (-b); //We are lazy lol

		public static Money operator *(Money a, int mul) {
			bool neg = mul < 0;
			uint m = (uint)Math.Abs(mul);

			ulong dollars = a.Dollars;
			ulong cents = a.Cents;
			checked {
				dollars *= m;
				cents *= m;

				dollars += cents / 100;
			}
			cents %= 100;

			if (dollars > uint.MaxValue) throw new OverflowException();
			return new Money(a.IsNegative ^ neg, (uint)dollars, (uint)cents);
		}

		public static Money operator *(int mul, Money a) => a * mul; //Same operation, just backwards

		/// <summary>
		/// Does integer division, rounding towards zero if needed.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="div"></param>
		/// <returns></returns>
		public static Money operator /(Money a, int div) {
			bool neg = (div < 0);
			uint d = (uint)Math.Abs(div);

			checked {
				//Do all the division math
				ulong dollars = a.Dollars / d;
				ulong dollarsCarry = ((a.Dollars % d) * (ulong)100) / d;
				ulong cents = (a.Cents / d) + dollarsCarry;

				//Start floating the carry's up
				dollars += cents / 100;
				cents %= 100;

				//Return the result
				if (dollars > uint.MaxValue) throw new OverflowException();
				return new Money(a.IsNegative ^ neg, (uint)dollars, (uint)cents);
			}
		}

		// this is first one '=='
		public static bool operator ==(Money a, Money b) {
			return (a.IsNegative == b.IsNegative) 
				&& (a.Dollars == b.Dollars) 
				&& (a.Cents == b.Cents);
		}

		// this is second one '!='
		public static bool operator !=(Money a, Money b) {
			return (a.IsNegative != b.IsNegative)
				|| (a.Dollars != b.Dollars)
				|| (a.Cents != b.Cents);
		}

		public static bool operator <(Money a, Money b) {
			return a.AsLong() < b.AsLong();
		}

		public static bool operator <=(Money a, Money b) {
			return a.AsLong() <= b.AsLong();
		}

		public static bool operator >(Money a, Money b) {
			return a.AsLong() > b.AsLong();
		}

		public static bool operator >=(Money a, Money b) {
			return a.AsLong() >= b.AsLong();
		}
		#endregion

		#region Conversion
		public static bool TryParse(string input, out Money result) {
			/*uint dollars = 0;
			uint cents = 0;
			bool negative = false;
			input = input.TrimStart();
			if (input.StartsWith('-')) {
				//Look for valid negative signs at the start
				negative = true;
				input = input.Substring(1);
			}
			if (input.StartsWith('$')) {
				//Look for valid currency sign at the start, immediately after the negative sign if there is one
				input = input.Substring(1);
			}

			if (input.Contains('-')) {
				//Check for invalid negative signs
				result = new Money();
				return false;
			}

			int index = input.IndexOf('.');
			if (index > -1) {
				string left = input.Substring(0, index);
				string right = input.Substring(index + 1).TrimEnd().PadRight(2, '0');
				if (left.Any(char.IsWhiteSpace)
					|| right.Any(char.IsWhiteSpace)
					|| ((left.Length > 0) && !uint.TryParse(left, out dollars))
					|| ((right.Length > 0) && !uint.TryParse(right, out cents))
				){
					result = new Money();
					return false;
				}
			} else {
				if (!uint.TryParse(input, out dollars)) {
					result = new Money();
					return false;
				}
			}

			if(cents >= 100) {
				result = new Money();
				return false;
			}

			result = new Money(negative, dollars, cents);
			return true;*/

			decimal value;
			if(decimal.TryParse(input, NumberStyles.Currency, null, out value)) {
				decimal decimals = value * 100;
				decimals = decimals - Math.Truncate(decimals);
				if (decimals == 0) {
					try {
						result = new Money(value);
						return true;
					} catch (OverflowException) {
						//Do nothing, let the code fall to the default bad parse code.
					}
				}
			}

			//Default, bad parse
			result = new Money();
			return false;
		}

		public static explicit operator Moneyf(Money money) {
			return new Moneyf(money);
		}
		#endregion

		#region Object Overrides
		public readonly override string ToString() {
			return (IsNegative ? "-" : "") + Dollars.ToString() + "." + Cents.ToString().PadLeft(2, '0');
		}

		public readonly string ToString(bool dollarSign, bool twoDecimalPlaces = true) {
			return (IsNegative ? "-" : "") + (dollarSign ? "$" : "") + Dollars.ToString("N0") + "." + Cents.ToString().PadLeft(2, '0');
		}

		public readonly string ToString(string format) {
			long Value = (IsNegative ? -1L : 1L) * Dollars * 100L + Cents;
			return Value.ToString(format);
		}

		public readonly override bool Equals(object obj) {
			if (ReferenceEquals(obj, null)) 
				return false;
			if (ReferenceEquals(this, obj)) 
				return true;
			if (!(obj is Money))
				return false;
			Money other = (Money)obj;
			return this == other;
		}

		public override int GetHashCode() {
			uint hash = 23;
			hash = hash * 31 + Dollars;
			hash = hash * 31 + Cents;

			return (int)hash;
		}
		#endregion

		#region JSON
		public JsonData SaveToJson() {
			return new JsonInteger((IsNegative ? -1L : 1L) * Dollars * 100L+ Cents);
		}

		/// <exception cref="NotImplementedException"></exception>
		public void LoadFromJson(JsonData Data) {
			throw new NotImplementedException("Money can't be loaded from Json directly. Use Money.LoadFromJsonData(JsonData) instead.");
		}

		/// <exception cref="InvalidCastException"></exception>
		public static Money LoadFromJsonData(JsonData data) {
			long value = (JsonInteger)data;
			return new Money(
				value < 0,
				(uint)(value / 100),
				(uint)(value % 100)
			);
		}
		#endregion
	}
}
