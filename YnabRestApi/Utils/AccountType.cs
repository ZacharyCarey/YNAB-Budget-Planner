using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace YnabRestApi.Utils {
    public enum AccountType {
        [Description("checking")]
        Checking, 

        [Description("savings")]
        Savings, 
        
        [Description("cash")]
        Cash, 

        [Description("creditCard")]
        CreditCard, 
        
        [Description("lineOfCredit")]
        LineOfCredit, 
        
        [Description("otherAsset")]
        OtherAsset, 

        [Description("otherLiability")]
        OtherLiability, 

        [Obsolete("No longer used.")]
        [Description("payPal")]
        PayPal, 

        [Obsolete("No longer used.")]
        [Description("merchantAccount")]
        MerchantAccount, 

        [Obsolete("No longer used.")]
        [Description("investmentAccount")]
        InvestmentAccount, 

        [Obsolete("No longer used.")]
        [Description("mortgage")]
        Mortgage
    }

    public static class AccountTypeExtensions {
        private static IDictionary<string, AccountType> enumValues = EnumExtensions.GetValues<AccountType>();

        public static AccountType Parse(string name) {
            return enumValues[name];
        }
        
    }

}
