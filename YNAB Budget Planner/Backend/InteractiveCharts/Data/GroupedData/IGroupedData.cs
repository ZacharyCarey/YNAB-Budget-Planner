using JsonSerializable;
using System;
using System.Collections.Generic;
using System.Text;

namespace YNAB_Budget_Planner.Backend.InteractiveCharts.Data.GroupedData {
	public interface IGroupedData : IJsonSerializable {

		public string Name { get; }

		public int Value { get; }

		public GroupCategory Parent { get; internal set; }

		/// <summary>
		/// Can be used to store any data for any reason or use.
		/// </summary>
		public object Tag { get; set; }

		/// <summary>
		/// Prune any children that do not have a value assigned to them, and call this function in the other children.
		/// </summary>
		void PruneData();

		public Dictionary<string, object> AsJsonObject();

	}
}
