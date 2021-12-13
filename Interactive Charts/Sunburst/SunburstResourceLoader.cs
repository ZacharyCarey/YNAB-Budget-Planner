using Common.InteractiveCharts.Data.GroupedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Charts.Sunburst {
	internal class SunburstResourceLoader : ResourceLoader {

		internal new IGroupedData Data {
			get => (IGroupedData)base.Data;
			set => base.Data = value;
		}

		internal string TooltipTitle = null;
		internal string TooltipContent = null;

		protected override void LoadConfig(JavascriptWriter writer) {
			if (TooltipTitle != null) {
				writer.WriteFunction("tooltipTitle", TooltipTitle, "data", "d");
			}

			if (TooltipContent != null) {
				writer.WriteFunction("tooltipContent", TooltipContent, "data", "d");
			}
		}

	}
}
