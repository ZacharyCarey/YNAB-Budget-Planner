using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_Budget_Planner.Utils {
	public class MoneyTextBoxUtils {

		public delegate void TextChangedHandler(TextBox Control, string NewText);
		public event TextChangedHandler OnTextChanged;

		public readonly TextBox Control;

		public MoneyTextBoxUtils(TextBox textBox) {
			this.Control = textBox;
			textBox.TextChanged += TextBox_OnTextChanged;
		}

		private void TextBox_OnTextChanged(object sender, EventArgs e) {
			//Remove previous formatting, or the decimal check will fail including leading zeros
			string value = Control.Text.Replace(",", "").Replace("$", "").Replace(".", "").TrimStart('0');
			decimal ul;
			//Check we are indeed handling a number
			if (decimal.TryParse(value, out ul)) {
				ul /= 100;
				//Unsub the event so we don't enter a loop
				Control.TextChanged -= TextBox_OnTextChanged;
				{
					//Format the text as currency
					Control.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C2}", ul);
				}
				Control.TextChanged += TextBox_OnTextChanged;
				Control.Select(Control.Text.Length, 0);

				OnTextChanged?.Invoke(Control, Control.Text);
			}
		}

	}
}
