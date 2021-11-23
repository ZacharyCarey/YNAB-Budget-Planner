using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YNAB_Budget_Planner.Backend.MoneyUtils {
	public static class MoneyLinq {

		public static Money Sum(this IEnumerable<Money>  collection) {
			Money sum = new Money();
			foreach(Money element in collection) {
				sum += element;
			}
			return sum;
		}

		public static Money Sum<T>(this IEnumerable<T> collection, Func<T, Money> selector) {
			return collection.Select(selector).Sum();
		}

	}
}
