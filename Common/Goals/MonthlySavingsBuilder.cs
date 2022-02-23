using Common.MoneyUtils;
using JsonSerializable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Goals {
    public class MonthlySavingsBuilder : Goal {

        public readonly Money Amount;

        public override Money MonthlyExpense => Amount;

        public MonthlySavingsBuilder (Money amount) {
            this.Amount = amount;
        }

        #region JSON

        public static MonthlySavingsBuilder Parse(JsonData data) {
            if (data != null && data is JsonObject obj) {
                Money amount = Money.LoadFromJsonData(obj["Amount"]);
                return new MonthlySavingsBuilder(amount);
            }

            return null;
        }

        public override void LoadFromJson(JsonData Data) {
            throw new Exception();
        }

        public override JsonData SaveToJson() {
            JsonObject obj = new JsonObject();
            obj["Goal Type"] = (JsonString)TargetType.MonthlySavingsBuilder.ToString();
            obj["Amount"] = Amount.SaveToJson();

            return obj;
        }

        #endregion

    }
}
