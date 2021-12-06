using System.Text;
using YNAB.Rest;

namespace YNAB_Budget_Planner {
    public static class ToStringExtensions {

        public static string PrintAll(this CategoriesData data) {
            StringBuilder sb = new();

            sb.AppendLine("categories: [");
            if (data.Categories != null) {
                foreach (var category in data.Categories) {
                    sb.Append("\tid: ");
                    sb.AppendLine(category.Id);

                    sb.Append("\tcategory_group_id: ");
                    sb.AppendLine(category.CategoryGroupId);

                    sb.Append("\tname: ");
                    sb.AppendLine(category.Name);

                    sb.Append("\thidden: ");
                    sb.AppendLine(category.Hidden.ToString());

                    sb.Append("\toriginal_category_group_id: ");
                    sb.AppendLine(category.OriginalCategoryGroupId);

                    sb.Append("\tnote: ");
                    sb.AppendLine(category.Note);

                    sb.Append("\tbudgeted: ");
                    sb.AppendLine(category.Budgeted.ToString());

                    sb.Append("\tactivity: ");
                    sb.AppendLine(category.Activity.ToString());

                    sb.Append("\tbalance: ");
                    sb.AppendLine(category.Balance.ToString());

                    sb.Append("\tgoal_type: ");
                    sb.AppendLine(category.GoalType.ToString());

                    //sb.Append("\tgoal_creation_month: ");
                    //sb.AppendLine(category)

                    //sb.Append("\tgoal_target: ");
                    //sb.AppendLine(category.target);

                    //sb.Append("\tgoal_target_month: ");
                    //sb.AppendLine(category.mon);

                    sb.Append("\tgoal_percentage_complete: ");
                    sb.AppendLine(category.GoalPercentageComplete.ToString());

                    //sb.Append("\tgoal_months_to_budget: ");
                    //sb.AppendLine(category.mon);

                    //sb.Append("\tgoal_under_funded: ");
                    //sb.AppendLine(category.goal);

                    //sb.Append("\tgoal_overall_funded: ");
                    //sb.AppendLine(category.fun);

                    //sb.Append("\tgoal_overall_funded: ");
                    //sb.AppendLine(category.goal);

                    //sb.Append("\tgoal_overall_left: ");
                    //sb.AppendLine(category.overall);

                    sb.Append("\tdeleted: ");
                    sb.AppendLine(category.Deleted.ToString());
                }
            }
            sb.Append("]");

            //data.ServerKnowledge

            return sb.ToString();
        }

    }
}
