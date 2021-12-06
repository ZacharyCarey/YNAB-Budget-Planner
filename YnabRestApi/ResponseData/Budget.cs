using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace YnabRestApi.ResponseData {
    public class Budget {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("last_modified_on")]
        public DateTime? LastModifiedOn { get; set; }

        [JsonPropertyName("first_month")]
        public string? FirstMonth { get; set; }

        [JsonPropertyName("last_month")]
        public string? LastMonth { get; set; }

        [JsonPropertyName("date_format")]
        public DateFormat? date_format { get; set; }

        [JsonPropertyName("currency_format")]
        public CurrencyFormat? CurrencyFormat { get; set; }

        [JsonPropertyName("accounts")]
        public IList<Account>? Accounts { get; set; }

        [JsonPropertyName("payees")]
        public IList<Payee>? Payees { get; set; }
        
        [JsonPropertyName("payee_locations")]
        public IList<PayeeLocation>? PayeeLocations { get; set; }

        [JsonPropertyName("category_groups")]
        public IList<CategoryGroup>? CategoryGroups { get; set; }

        [JsonPropertyName("categories")]
        public IList<Category>? Categories { get; set; }

        [JsonPropertyName("months")]
        public IList<BudgetMonth>? Months { get; set; }

        [JsonPropertyName("transactions")]
        public IList<Transaction>? Transactions { get; set; }

        [JsonPropertyName("subtransactions")]
        public IList<Subtransaction>? Subtransactions { get; set; }
        
        [JsonPropertyName("scheduled_transactions")]
        public IList<ScheduledTransaction>? ScheduledTransactions { get; set; }
        
        [JsonPropertyName("scheduled_subtransactions")]
        public IList<ScheduledSubtransaction>? ScheduledSubtransactions { get; set; }

        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }


        /* JSON
"id": "string",
"name": "string",
"last_modified_on": "2021-12-05T01:30:57.454Z",
"first_month": "string",
"last_month": "string",
"date_format": {
    ...
},
"currency_format": {
    ...
},
"accounts": [
    {
        ...
    }
],
"payees": [
    {
        ...
    }
],
"payee_locations": [
    {
        ...
    }
],
"category_groups": [
    {
        ...
    }
],
"categories": [
    {
        ...
    }
],
"months": [
    {
        ...
    }
],
"transactions": [
    {
        ...
    }
],
"subtransactions": [
    {
        ...
    }
],
"scheduled_transactions": [
    {
        ...
    }
],
"scheduled_subtransactions": [
    {
        ...
    }
]
*/
    }
}
