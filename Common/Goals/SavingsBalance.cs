using Common.MoneyUtils;
using Common.Utils;
using JsonSerializable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Goals {
    public class SavingsBalance : Goal {

        public readonly Money Amount;
        public readonly bool ByDate;
        public readonly DateTime StartDate;
        public readonly int Month;
        public readonly int Year;

        private readonly Money monthlyCost;
        public override Money MonthlyExpense => monthlyCost;

        // If there is no target, there is no monthly payment needed
        public SavingsBalance(Money amount) {
            this.Amount = amount;
            ByDate = false;

            this.monthlyCost = new Money();
        }

        public SavingsBalance(Money amount, DateTime startDate, int month, int year) {
            this.Amount = amount;
            this.ByDate = true;
            this.StartDate = startDate;
            this.Month = month;
            this.Year = year;

            DateTime target = new DateTime(year, month, 1);
            int months = target.MonthsSince(startDate) + 1;
            monthlyCost = amount / months;
        }

        #region JSON

        public static SavingsBalance Parse(JsonData data) {
            if (data != null && data is JsonObject obj) {
                Money amount = Money.LoadFromJsonData(obj["Amount"]);
                bool byDate = (JsonBool)obj["By Date"] ?? false;
                DateTime startDate = DateTimeUtils.ParseDateOrDefault((JsonString)obj["Start Date"] ?? "");
                int month = (int)((JsonInteger)obj["Month"] ?? new JsonInteger(0));
                int year = (int)((JsonInteger)obj["Year"] ?? new JsonInteger(0));

                if (byDate) {
                    return new SavingsBalance(amount, startDate, month, year);
                } else {
                    return new SavingsBalance(amount);
                }
            }

            return null;
        }

        public override void LoadFromJson(JsonData Data) {
            throw new Exception();
        }

        public override JsonData SaveToJson() {
            JsonObject obj = new JsonObject();
            obj["Goal Type"] = (JsonString)TargetType.SavingsBalance.ToString();
            obj["Amount"] = Amount.SaveToJson();
            obj["By Date"] = (JsonBool)ByDate;

            if (ByDate) {
                obj["Start Date"] = (JsonString)StartDate.ToString();
                obj["Month"] = (JsonInteger)Month;
                obj["Year"] = (JsonInteger)Year;
            }

            return obj;
        }

        #endregion

    }
}
