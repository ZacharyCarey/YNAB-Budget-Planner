using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YNAB_Budget_Planner.Shared.GridComponent {
	public abstract class IGridRow : IEnumerable<string> {

		public event EventHandler<IGridRow> OnChildRemoved;

		public IGridRow Parent { get; private set; }
		public IEnumerable<IGridRow> Children { get => children; }
		private List<IGridRow> children = new List<IGridRow>();

		public abstract IEnumerable<string> GetContent();

		protected IGridRow() {
		}

		protected IGridRow(IGridRow parent) {
			this.Parent = parent;
			this.Parent.children.Add(this);
		}

		protected IGridRow(params IGridRow[] children) {
			foreach (IGridRow child in children) {
				this.children.Add(child);
				child.Parent = this;
			}
		}

		public IGridRow Add(IGridRow newRow) {
			this.children.Add(newRow);
			newRow.Parent = this;
			return newRow;
		}

		public bool Remove(IGridRow row) {
			if (this.children.Remove(row)) {
				row.Parent = null;
				OnChildRemoved?.Invoke(this, row);
				return true;
			} else {
				return false;
			}
		}

		public IEnumerator<string> GetEnumerator() {
			return GetContent().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return ((IEnumerable)GetContent()).GetEnumerator();
		}
	}

}
