using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_Budget_Planner.Utils {
    public struct DayOfMonth {
        private int day;
        private string name;
        public int Day { get => day; }

        public DayOfMonth(int day) {
            this.day = day;
            if (day >= 10 && day <= 19) {
                name = day.ToString() + "th";
            } else {
                int ones = day % 10;
                if (day == 32) {
                    name = "End of Month";
                } else if (ones == 1) {
                    name = day.ToString() + "st";
                } else if (ones == 2) {
                    name = day.ToString() + "nd";
                } else if (ones == 3) {
                    name = day.ToString() + "rd";
                } else {
                    name = day.ToString() + "th";
                }
            }
        }

        public override string ToString() {
            return name;
        }

        public static IEnumerable<DayOfMonth> GetValues() {
            for (int i = 1; i <= 32; i++) {
                yield return new DayOfMonth(i);
            }
        }

        public static bool operator ==(DayOfMonth left, DayOfMonth right) {
            return left.day == right.day;
        }

        public static bool operator !=(DayOfMonth left, DayOfMonth right) {
            return left.day != right.day;
        }

        public override bool Equals([NotNullWhen(true)] object? obj) {
            if (obj is DayOfMonth compare) {
                return this.day == compare.day;
            } else {
                return base.Equals(obj);
            }
        }

    }
}
