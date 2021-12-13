using Desktop_Budget_Planner.Forms;

namespace Desktop_Budget_Planner {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            InteractiveCharts.InteractiveCharts.Initialize();

            ApplicationConfiguration.Initialize();
            Application.Run(new AnalysisForm());
        }
    }
}