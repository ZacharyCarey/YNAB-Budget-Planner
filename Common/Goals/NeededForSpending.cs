using Common.MoneyUtils;
using Common.Utils;
using JsonSerializable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Goals {
    public class NeededForSpending : Goal {

        // All
        public readonly Money Amount;
        public readonly Frequency BudgetFrequency;

        // Frequency = Monthy
        public readonly int EveryMonth;

        // Frequency = Weekly
        public readonly DayOfWeek EveryWeek;

        // Frequency = ByDate
        public readonly DateTime StartDate;
        public readonly DateTime ByDate;
        public readonly bool Repeats;
        public readonly int RepeatTimes; //Only when repeats
        public readonly RepeatType RepeatType; //Only when repeats

        private readonly Money monthlyCost;
        public override Money MonthlyExpense => monthlyCost;

        /// <summary> Monthly </summary>
        public NeededForSpending(Money amount, int everyMonth) {
            this.Amount = amount;
            this.BudgetFrequency = Frequency.Monthly;
            this.EveryMonth = everyMonth;

            this.monthlyCost = amount;
        }

        /// <summary> Weekly </summary>
        public NeededForSpending(Money amount, DayOfWeek everyWeek) {
            this.Amount = amount;
            this.BudgetFrequency = Frequency.Weekly;
            this.EveryWeek = everyWeek;

            checked {
                // NOTE: 13/3 is used as the reduced form of 52/12, which is the average number of weeks in a month
                this.monthlyCost = amount * 13 / 3;
            }
        }

        /// <summary> By Date, no repeat </summary>
        public NeededForSpending(Money amount, DateTime startDate, DateTime targetDate) {
            this.Amount = amount;
            this.BudgetFrequency = Frequency.ByDate;
            this.StartDate = startDate;
            this.ByDate = targetDate;
            this.Repeats = false;

            int numberOfMonths = targetDate.MonthsSince(startDate) + 1;
            this.monthlyCost = amount / numberOfMonths;
        }

        /// <summary> By Date, repeat </summary>
        public NeededForSpending(Money amount, DateTime startDate, DateTime targetDate, int repeatTimes, RepeatType repeatType) {
            this.Amount = amount;
            this.BudgetFrequency = Frequency.ByDate;
            this.StartDate = startDate;
            this.ByDate = targetDate;
            this.Repeats = true;
            this.RepeatTimes = repeatTimes;
            this.RepeatType = repeatType;

            if (repeatType == RepeatType.Months) {
                this.monthlyCost = amount / repeatTimes;
            } else if (repeatType == RepeatType.Years) {
                this.monthlyCost = amount / (repeatTimes * 12);
            } else {
                throw new Exception("Unknon repeat type.");
            }
        }

        #region JSON

        public static NeededForSpending Parse(JsonData data) {
            if (data != null && data is JsonObject obj) {
                Money amount = Money.LoadFromJsonData(obj["Amount"]);
                Frequency frequency = Enum.Parse<Frequency>((JsonString)obj["Frequency"] ?? "");
                int everyMonth = (int)(long)((JsonInteger)obj["Every Month"] ?? new JsonInteger(0));
                DayOfWeek everyWeek = EnumUtils.ParseEnumOrDefault<DayOfWeek>((JsonString)obj["Every Week"] ?? "");
                DateTime startDate = DateTimeUtils.ParseDateOrDefault((JsonString)obj["Start Date"] ?? "");
                DateTime byDate = DateTimeUtils.ParseDateOrDefault((JsonString)obj["By Date"] ?? "");
                bool repeats = ((JsonBool)obj["Repeats"] ?? new JsonBool(false));
                int repeatTimes = (int)(long)((JsonInteger)obj["Repeat Times"] ?? new JsonInteger(0));
                RepeatType repeatType = EnumUtils.ParseEnumOrDefault<RepeatType>((JsonString)obj["Repeat Type"] ?? "");

                switch (frequency) {
                    case Frequency.Monthly:
                        return new NeededForSpending(amount, everyMonth);
                    case Frequency.Weekly:
                        return new NeededForSpending(amount, everyWeek);
                    case Frequency.ByDate:
                        if (repeats) {
                            return new NeededForSpending(amount, startDate, byDate, repeatTimes, repeatType);
                        } else {
                            return new NeededForSpending(amount, startDate, byDate);
                        }
                    default:
                        throw new Exception("Unknown frequency");
                }
            }

            return null;
        }

        public override void LoadFromJson(JsonData Data) {
            throw new Exception();
        }

        public override JsonData SaveToJson() {
            JsonObject obj = new JsonObject();
            obj["Goal Type"] = (JsonString)TargetType.NeededForSpending.ToString();
            obj["Amount"] = Amount.SaveToJson();
            obj["Frequency"] = (JsonString)BudgetFrequency.ToString();

            if (BudgetFrequency == Frequency.Monthly) {
                obj["Every Month"] = (JsonInteger)EveryMonth;
            } else if (BudgetFrequency == Frequency.Weekly) {
                obj["Every Week"] = (JsonString)EveryWeek.ToString();
            } else if (BudgetFrequency == Frequency.ByDate) {
                obj["Start Date"] = (JsonString)StartDate.ToString();
                obj["By Date"] = (JsonString)ByDate.ToString();
                obj["Repeats"] = (JsonBool)Repeats;
                if (Repeats) {
                    obj["Repeat Times"] = (JsonInteger)RepeatTimes;
                    obj["Repeat Type"] = (JsonString)RepeatType.ToString();
                }
            } else {
                throw new Exception("Unknown frequency.");
            }

            return obj;
        }

        #endregion

    }
}
