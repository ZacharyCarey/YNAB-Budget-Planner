using System;
using System.Collections.Generic;
using System.Text;

namespace YNAB_Budget_Planner.Backend {
	public enum AllowIncomeType {
		No,
		Yes,
		NoDoNotAsk
	}

	public static class AllowIncomeUtils {

		public const string No = "No";
		public const string Yes = "Yes";
		public const string NoDoNotAsk = "No - Do Not Ask";

		public static string GetString(AllowIncomeType type) {
			switch (type) {
				case AllowIncomeType.No: return No;
				case AllowIncomeType.Yes: return Yes;
				case AllowIncomeType.NoDoNotAsk: return NoDoNotAsk;
				default: throw new ArgumentException("Enum was not a valid type.", "type");
			}
		}

		public static AllowIncomeType Parse(string input) {
			switch (input) {
				case Yes: return AllowIncomeType.Yes;
				case No: return AllowIncomeType.No;
				case NoDoNotAsk: return AllowIncomeType.NoDoNotAsk;
				default: throw new ArgumentException("String was not a valid enum type.", "input");
			}
		}

	}

}
