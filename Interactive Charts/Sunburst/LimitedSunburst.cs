using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Charts.Sunburst {
	public class LimitedSunburst : SunburstGraph {

		protected override string URL => "LimitedSunburst/index.html";
		protected override string DesignModeName => "Limited Sunburst";

		public LimitedSunburst() : base() {
		}
	}
}
