using JsonSerializable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.InteractiveCharts.Data.GroupedData {

	/// <inheritdoc cref="GroupValue"/>
	public class GroupCategory : IGroupedData, IEnumerable<IGroupedData> {

		private List<IGroupedData> elements = new List<IGroupedData>();
		public IEnumerable<IGroupedData> Elements => elements;

		public string Name { get; set; }
		public int Value => elements.Sum(x => x.Value);

		GroupCategory IGroupedData.Parent { get; set; }
		public GroupCategory Parent { get => ((IGroupedData)this).Parent; } // TODO not sure why this is needed to get the parent.

		public object Tag { get; set; }
		

		public GroupCategory(string name) {
			this.Name = name;
		}

		public GroupCategory(string name, params IGroupedData[] data) {
			this.Name = name;
			foreach(IGroupedData child in data) {
				this.Add(child);
			}
			//elements.AddRange(data);
		}

		public IGroupedData Add(IGroupedData data) {
			if (data.Parent == this) {
				return data;
			}

			data.Parent = this;
			this.elements.Add(data);
			return data;
		}

		public GroupCategory Add(string CategoryName) {
			GroupCategory cat = new GroupCategory(CategoryName);
			this.Add(cat);
			return cat;
		}

		public GroupValue Add(string Name, int Value) {
			GroupValue data = new GroupValue(Name, Value);
			this.Add(data);
			return data;
		}

		public void Remove(IGroupedData data) {
			if (this.elements.Remove(data)) {
				data.Parent = null;
			}
		}

		public void PruneData() {
			List<IGroupedData> pruning = new List<IGroupedData>();
			foreach(IGroupedData element in elements) {
				element.PruneData();
				if(element.Value <= 0) {
					pruning.Add(element);
				}
			}
			foreach(IGroupedData prune in pruning) {
				this.Remove(prune);
			}
		}

		public JsonData SaveToJson() {
			JsonObject group = new JsonObject();
			group["name"] = (JsonString)(Name ?? "null");

			JsonArray children = new JsonArray();
			foreach(IGroupedData element in elements) {
				children.Add(element.SaveToJson());
			}
			group["children"] = children;

			return group;
		}

		public void LoadFromJson(JsonData Data) {
			throw new NotImplementedException();
		}

		public IEnumerator<IGroupedData> GetEnumerator() {
			return elements.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return elements.GetEnumerator();
		}

		public Dictionary<string, object> AsJsonObject() {
			return new Dictionary<string, object>() {
				["name"] = this.Name,
				["children"] = this.elements.Select(x => x.AsJsonObject()).ToArray()
			};
		}
	}
}
