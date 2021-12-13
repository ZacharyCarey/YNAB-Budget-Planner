using Common.MoneyUtils;
using JsonSerializable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common {
	public class Budget : IJsonSerializable, IEnumerable<Budget> {

		/// <summary>
		/// The name of the budget.
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// The type of budget, which determines how the amount is calculated.
		/// </summary>
		public BudgetType BudgetType { get; private set; }

		public Budget Parent { get; private set; }

		// Used for the "FixedAmount" budget type.
		public Money FixedAmount { get; private set; }

		// Used for the "FixedPercentage" budget type.
		public decimal FixedPercentage { get; private set; }

		/// <summary>
		/// The calculated amount for the budget.
		/// </summary>
		public Money Amount { get; private set; }

		/// <summary>
		/// Used when saving / loading to setup vendor links correctly
		/// </summary>
		public uint UID { get; set; }

		private void Invalidate() {
			if (this.Parent == null) {
				Recalculate();
			} else {
				// Bubble re-calculation to the parent
				this.Parent.Invalidate();
			}
		}

		private string errorString = null;
		public string Error { 
			get => errorString;
			private set {
				if (value == null) {
					errorString = null;
				}else if(errorString == null) {
					errorString = value;
				}
			} 
		}

		public event EventHandler OnBudgetRecalculated;
		public event EventHandler OnBudgetAdded;
		public event EventHandler OnBudgetRemoved;
		public event EventHandler OnBudgetUpdated;
		public event EventHandler OnBudgetError;

		// Used for nested budgets, where certain parts of a budgets
		// can be allocated for different things.
		// e.x. "Insurance" can be listed under a "Car" budget
		private SerializableList<Budget> Children = new SerializableList<Budget>();

		/// <summary>
		/// Enumerates through the nested budgets.
		/// </summary>
		public IEnumerable<Budget> ChildBudgets => Children;

		public int Count => Children.Count;

		public Budget() : this("", new Money()) {
			this.Invalidate();
		}

		/// <summary>
		/// Creates a budget with the "FixedAmount" type.
		/// </summary>
		/// <param name="Name"></param>
		/// <param name="FixedAmount"></param>
		public Budget(string Name, Money Amount) {
			this.Name = Name;
			this.BudgetType = BudgetType.FixedAmount;
			this.FixedAmount = Amount;
			this.Invalidate();
		}

		/// <summary>
		/// Creates a budget with the "FixedPercentage" type.
		/// </summary>
		/// <param name="Name"></param>
		/// <param name="Percentage">Must be between 0 and 1, inclusive.</param>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public Budget(string Name, decimal Percentage) {
			if (Percentage < 0.0m || Percentage > 1.0m) {
				throw new ArgumentOutOfRangeException("Percentage", "Percentage must be between 0 and 1, inclusive.");
			}
			this.Name = Name;
			this.BudgetType = BudgetType.FixedPercentage;
			this.FixedPercentage = Percentage;
			this.Invalidate();
		}

		/// <summary>
		/// Creates a budget with the "Dynamic" type.
		/// </summary>
		/// <param name="Name"></param>
		public Budget(string Name) {
			this.Name = Name;
			this.BudgetType = BudgetType.Dynamic;
			this.Invalidate();
		}

		/// <summary>
		/// Updates this budget using information from a new budget.
		/// </summary>
		/// <param name="budget"></param>
		public void Update(Budget budget) {
			this.Name = budget.Name;
			this.BudgetType = budget.BudgetType;
			this.FixedAmount = budget.FixedAmount;
			this.FixedPercentage = budget.FixedPercentage;
			Invalidate();
			OnBudgetUpdated?.Invoke(this, new EventArgs());
		}

		public Budget Add(Budget Child) {
			if (Child.Parent == this) {
				return Child;
			}

			this.Children.Add(Child);
			Child.Parent = this;
			this.Invalidate();
			OnBudgetAdded?.Invoke(this, new EventArgs());
			return Child;
		}

		public bool Remove(Budget Child) {
			if (Child.Parent != this) {
				return false;
			}

			this.Children.Remove(Child);
			Child.Parent = null;
			this.Invalidate();
			OnBudgetRemoved?.Invoke(this, new EventArgs());
			return true;
		}

		private void Recalculate() {
			Money oldAmount = this.Amount;
			this.CalculateAmount();
			if (this.Amount != oldAmount) {
				OnBudgetRecalculated?.Invoke(this, new EventArgs());
			}
		}

		private void CalculateAmount() {
			Error = null;
			switch (this.BudgetType) {
				case BudgetType.FixedAmount:
					CalculateFixedAmount();
					break;
				case BudgetType.FixedPercentage:
					CalculateFixedPercentage();
					break;
				case BudgetType.Dynamic:
					CalculateDynamic();
					break;
				default:
					throw new ArgumentException("BudgetType enum was not a known type.", "this.BudgetType");
			}

			// Check for "overflow" error
			if (Error == null) {
				Money sum = this.Children.Sum(x => x.Amount);
				if (sum > this.Amount) {
					Error = "Sum of budgets exceed parent budget amount.";
				}
			}

			if (Error != null) {
				OnBudgetError?.Invoke(this, new EventArgs());
			}
		}

		#region Budget Type Calculations
		private void CalculateDynamic() {
			List<Budget> percentageTypes = new List<Budget>();

			// Recalculate and sum all children budgets that are not percentage types, but
			// keep track of percentage type children for later.
			Money nonPercentageAmount = new Money();
			foreach (Budget child in this.Children) {
				if (child.BudgetType == BudgetType.FixedPercentage) {
					percentageTypes.Add(child);
				} else {
					child.Recalculate();
					nonPercentageAmount += child.Amount;
				}
			}

			// Early exit to save a little processing, if possible
			if (percentageTypes.Count == 0) {
				this.Amount = nonPercentageAmount;
				return;
			} 

			// Here is where the the "hacky" part starts. We set the budget amount to a "true"
			// amount that is calculated using math based on the sum of the child percentages.
			// Amount = NonPercentageAmount / SumOfPercentages
			decimal percentageSum = percentageTypes.Sum(x => x.FixedPercentage);
			Moneyf trueAmount = (Moneyf)nonPercentageAmount / percentageSum;
			this.Amount = (Money)trueAmount;

			// Then, we let the percentage types re-calculate using the "true" calculated value
			// and sum the calculated result of the children
			Money percentageAmount = new Money();
			foreach (Budget child in percentageTypes) {
				child.Recalculate();
				percentageAmount += child.Amount;
			}

			// Now we should have the ACTUAL sum for the dynamic budget, which depending on the number
			// of percentage types should only be a few cents lower than the "true" amount due to
			// rounding errors.
			this.Amount = percentageAmount + nonPercentageAmount;
		}

		private void CalculateFixedAmount() {
			this.Amount = this.FixedAmount;
			this.Children.ForEach(x => x.Recalculate());
		}

		private void CalculateFixedPercentage() {
			if (this.Parent == null) {
				Error = "\'Fixed Percentage\' budget type must have a parent budget.";
				this.Amount = new Money();
			} else {
				Moneyf parentAmount = (Moneyf)this.Parent.Amount;
				// This should round towards zero, thus always making the actual
				// amount less than what a dynamic budget would "guess" the budget
				// to be.
				this.Amount = (Money)(parentAmount * this.FixedPercentage);
			}

			this.Children.ForEach(x => x.Recalculate());
		}
		#endregion

		public override string ToString() {
			return Name;
		}

		public IEnumerator<Budget> GetEnumerator() {
			return Children.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return Children.GetEnumerator();
		}

		public JsonData SaveToJson() {
			JsonObject data = new JsonObject();

			data["Name"] = (JsonString)this.Name;
			data["UID"] = (JsonInteger)(long)this.UID;
			data["Type"] = (JsonString)this.BudgetType.ToString();
			if(this.BudgetType == BudgetType.FixedAmount) {
				data["Amount"] = (JsonInteger)this.FixedAmount.AsLong();
			}else if(this.BudgetType == BudgetType.FixedPercentage) {
				data["Percentage"] = (JsonDecimal)Convert.ToDouble(this.FixedPercentage); // Verified in unit tests
			}else if(this.BudgetType == BudgetType.Dynamic) {

			}else {
				Console.WriteLine("WARNING: Saving a budget with an unknown budget type.");
			}
			data["Children"] = Children.SaveToJson();

			return data;
		}

		public void LoadFromJson(JsonData Data) {
			JsonObject obj = (JsonObject)Data;

			this.Name = (JsonString)obj["Name"];
			this.UID = (uint)(JsonInteger)obj["UID"];
			this.BudgetType = Enum.Parse<BudgetType>((JsonString)obj["Type"]);
			if(this.BudgetType == BudgetType.FixedAmount) {
				this.FixedAmount = Money.FromLong((JsonInteger)obj["Amount"]);
			}else if(this.BudgetType == BudgetType.FixedPercentage) {
				this.FixedPercentage = Convert.ToDecimal((JsonDecimal)obj["Percentage"]); // Verified in unit tests
			} else if(this.BudgetType == BudgetType.Dynamic) {

			} else {
				throw new System.ComponentModel.InvalidEnumArgumentException("BudgetType", (int)this.BudgetType, typeof(BudgetType));
			}
			this.Children.LoadFromJson(obj["Children"]);
			foreach(Budget child in this.Children) {
				child.Parent = this;
			}
			// TODO this may cause recalculation several times, is it still efficient??
			// In theory, the children get updated first, so the entire tree gets fully traversed each
			// time a parent is added
			this.Invalidate();
		}
	}

}
