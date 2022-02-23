using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_Budget_Planner.Utils {
    public struct MonthValue {
        private int month;
        private string name;
        public int Month { get => month; }

        public MonthValue(int month) {
            this.month = month;
            this.name = new DateTime(2022, month, 1).ToString("MMMM");
        }

        public override string ToString() {
            return name;
        }

        public static IEnumerable<MonthValue> GetValues() {
            for (int i = 1; i <= 12; i++) {
                yield return new MonthValue(i);
            }
        }

        public static bool operator ==(MonthValue left, MonthValue right) {
            return left.month == right.month;
        }

        public static bool operator !=(MonthValue left, MonthValue right) {
            return left.month != right.month;
        }

        public override bool Equals([NotNullWhen(true)] object? obj) {
            if (obj is MonthValue compare) {
                return this.month == compare.month;
            } else {
                return base.Equals(obj);
            }
        }
    }
}
