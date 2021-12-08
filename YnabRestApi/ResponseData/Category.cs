using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class Category {

        /// <summary>
        /// $uuid
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        [JsonPropertyName("category_group_id")]
        public string CategoryGroupId { get; set; } = "";

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        /// <summary>
        /// Whether or not the category is hidden
        /// </summary>
        [JsonPropertyName("hidden")]
        public bool Hidden { get; set; } = false;

        /// <summary>
        /// If category is hidden this is the id of the category group it originally belonged to before it was hidden.
        /// </summary>
        [JsonPropertyName("original_category_group_id")]
        public string? OriginalCategoryGroupId { get; set; }

        [JsonPropertyName("note")]
        public string? Note { get; set; }

        /// <summary>
        /// Budgeted amount in milliunits format
        /// See <see cref="Utils.YnabMoney"/>
        /// </summary>
        [JsonPropertyName("budgeted")]
        public Int64 Budgeted { get; set; }

        /// <summary>
        /// Activity amount in milliunits format
        /// See <see cref="Utils.YnabMoney"/>
        /// </summary>
        [JsonPropertyName("activity")]
        public Int64 Activity { get; set; }

        /// <summary>
        /// Balance in milliunits format
        /// See <see cref="Utils.YnabMoney"/>
        /// </summary>
        [JsonPropertyName("balance")]
        public Int64 Balance { get; set; }

        /// <summary>
        /// The type of goal, if the category has a goal.
        /// See <see cref="Utils.GoalType"/>
        /// </summary>
        [JsonPropertyName("goal_type")]
        public string? GoalType { get; set; } = "";

        /// <summary>
        /// The month a goal was created
        /// $date
        /// </summary>
        [JsonPropertyName("goal_creation_month")]
        public DateTime? GoalCreationMonth { get; set; }

        /// <summary>
        /// The goal target amount in milliunits
        /// See <see cref="Utils.YnabMoney"/>
        /// </summary>
        [JsonPropertyName("goal_target")]
        public Int64? GoalTarget { get; set; }

        /// <summary>
        /// The original target month for the goal to be completed.Only some goal types specify this date.
        /// $date
        /// </summary>
        [JsonPropertyName("goal_target_month")]
        public DateTime? GoalTargetMonth { get; set; }

        /// <summary>
        /// The percentage completion of the goal
        /// </summary>
        [JsonPropertyName("goal_percentage_complete")]
        public Int32? GoalPercentageComplete { get; set; }

        /// <summary>
        /// The number of months, including the current month, left in the current goal period.
        /// </summary>
        [JsonPropertyName("goal_months_to_budget")]
        public Int32? GoalMonthsToBudget { get; set; }

        /// <summary>
        /// The amount of funding still needed in the current month to stay on track towards completing the goal within 
        /// the current goal period.This amount will generally correspond to the ‘Underfunded’ amount in the web and 
        /// mobile clients except when viewing a category with a Needed for Spending Goal in a future month.The web and 
        /// mobile clients will ignore any funding from a prior goal period when viewing category with a Needed for 
        /// Spending Goal in a future month.
        /// </summary>
        [JsonPropertyName("goal_under_funded")]
        public Int64? GoalUnderFunded { get; set; }

        /// <summary>
        /// The total amount funded towards the goal within the current goal period.
        /// </summary>
        [JsonPropertyName("goal_overall_funded")]
        public Int64? GoalOverallFunded { get; set; }

        /// <summary>
        /// The amount of funding still needed to complete the goal within the current goal period.
        /// </summary>
        [JsonPropertyName("goal_overall_left")]
        public Int64? GoalOverallLeft { get; set; }

        /// <summary>
        /// Whether or not the category has been deleted.Deleted categories will only be included in delta requests.
        /// </summary>
        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; } = false;


        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

    }

    /*
id*	string($uuid)
category_group_id*	string($uuid)
name*	string
hidden*	boolean
Whether or not the category is hidden

original_category_group_id	string($uuid)
If category is hidden this is the id of the category group it originally belonged to before it was hidden.

note	string
budgeted*	integer($int64)
Budgeted amount in milliunits format

activity*	integer($int64)
Activity amount in milliunits format

balance*	integer($int64)
Balance in milliunits format

goal_type	string
The type of goal, if the category has a goal (TB=’Target Category Balance’, TBD=’Target Category Balance by Date’, MF=’Monthly Funding’, NEED=’Plan Your Spending’)

Enum:
[ TB, TBD, MF, NEED, ]
goal_creation_month	string($date)
The month a goal was created

goal_target	integer($int64)
The goal target amount in milliunits

goal_target_month	string($date)
The original target month for the goal to be completed. Only some goal types specify this date.

goal_percentage_complete	integer($int32)
The percentage completion of the goal

goal_months_to_budget	integer($int32)
The number of months, including the current month, left in the current goal period.

goal_under_funded	integer($int64)
The amount of funding still needed in the current month to stay on track towards completing the goal within the current goal period. This amount will generally correspond to the ‘Underfunded’ amount in the web and mobile clients except when viewing a category with a Needed for Spending Goal in a future month. The web and mobile clients will ignore any funding from a prior goal period when viewing category with a Needed for Spending Goal in a future month.

goal_overall_funded	integer($int64)
The total amount funded towards the goal within the current goal period.

goal_overall_left	integer($int64)
The amount of funding still needed to complete the goal within the current goal period.

deleted*	boolean
Whether or not the category has been deleted. Deleted categories will only be included in delta requests.
     */
}
