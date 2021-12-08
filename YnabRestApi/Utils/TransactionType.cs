using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabRestApi.Utils {
    public enum TransactionType {

        [Description("transaction")]
        Transaction, 
        
        [Description("subtransaction")]
        Subtransaction

    }

    public static class TransactionTypeExtensions {
        private static IDictionary<string, TransactionType> enumValues = EnumExtensions.GetValues<TransactionType>();

        public static TransactionType Parse(string name) {
            return enumValues[name];
        }

    }

}
