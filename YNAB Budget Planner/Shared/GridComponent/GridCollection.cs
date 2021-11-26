using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YNAB_Budget_Planner.Shared.GridComponent {
	public class GridCollection : IEnumerable<IGridRow> {

		public event EventHandler<IGridRow> OnChildRemoved;

		private List<IGridRow> items = new List<IGridRow>();

		public GridCollection() {

		}

		public GridCollection(params IGridRow[] children) {
			items.AddRange(children);
		}

		public IGridRow Add(IGridRow newRow) {
			this.items.Add(newRow);
			return newRow;
		}

		public void Add(params IGridRow[] rows) {
			this.items.AddRange(rows);
		}

		public bool Remove(IGridRow row) {
			if (this.items.Remove(row)) {
				OnChildRemoved?.Invoke(this, row);
				return true;
			} else {
				return false;
			}
		}

		public IEnumerator<IGridRow> GetEnumerator() {
			return this.items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return ((IEnumerable)this.items).GetEnumerator();
		}
	}

	public class GridCollection<T> : GridCollection where T : IGridRow {

		public T Add(T newRow) {
			return (T)base.Add(newRow);
		}

	}
}
