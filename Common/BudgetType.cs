using System;
using System.Collections.Generic;
using System.Text;

namespace Common {
	public enum BudgetType {
		/// <summary>
		/// Budget is constrained with a fixed dollar amount.
		/// </summary>
		FixedAmount,

		/// <summary>
		/// Budget is constrained with an amount that is a percentage of the parent budget.
		/// </summary>
		FixedPercentage,

		/// <summary>
		/// Budget amount is equal to the total of the child budgets, or zero if there are no child budgets.
		/// </summary>
		Dynamic
	}
}
