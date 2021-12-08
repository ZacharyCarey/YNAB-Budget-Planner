using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabRestApi.Utils {

    // See https://api.youneedabudget.com/#formats
    public struct YnabMoney {

        public long Milliunits;

        public bool IsNegative {
            get => Milliunits < 0;
        }

        public long Dollars {
            get => Math.Abs(Milliunits) / 1000;
        }

        public long Cents {
            get => (Math.Abs(Milliunits) / 10) % 100;
        }

        public long Thousandths {
            get => Math.Abs(Milliunits) % 10;
        }

        public override string ToString() {
            return ((Milliunits < 0) ? "-" : "") + "$";
        }

    }
}
