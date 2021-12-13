using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Charts.Sunburst {
	public class Sunburst : SunburstGraph {

		protected override string URL => "Sunburst/index.html";

		protected override string DesignModeName => "Sunburst";

		public Sunburst() : base() {
		}
	}
}
