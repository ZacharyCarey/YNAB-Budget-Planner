using Common.MoneyUtils;
using JsonSerializable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Goals {
    public abstract class Goal : IJsonSerializable {

        public abstract Money MonthlyExpense { get; }

        public static Goal ParseFromJson(JsonData json) {
            if (json != null && json is JsonObject obj) {
                switch(Enum.Parse<TargetType>((string)(JsonString)obj["Goal Type"])) {
                    case TargetType.NeededForSpending:
                        return NeededForSpending.Parse(json);
                    case TargetType.SavingsBalance:
                        return SavingsBalance.Parse(json);
                    case TargetType.MonthlySavingsBuilder:
                        return MonthlySavingsBuilder.Parse(json);
                    case TargetType.MonthlyDebtPayment:
                        return null;
                    default:
                        return null;
                }
            }

            return null;
        }

        public abstract JsonData SaveToJson();

        public abstract void LoadFromJson(JsonData Data);
    }
}
