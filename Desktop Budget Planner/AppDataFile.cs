using Common.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_Budget_Planner {
	public class AppDataFile : IAppData {

		private static string AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		private const string AppName = "Monthly Expenses Calculator";
		private const string FileName = "Settings.json";

		public AppDataFile() : base() {
		}

		protected override Stream LoadStream() {
			try {
				string filePath = Path.Combine(AppDataFolder, AppName, FileName);
				return File.OpenRead(filePath);
			} catch (Exception) { //DirectoryNotFoundException || FileNotFoundException) {
				return null;
			}
		}

		protected override Stream SaveStream() {
			string folderPath = Path.Combine(AppDataFolder, AppName);
			string filePath = Path.Combine(folderPath, FileName);
			Directory.CreateDirectory(folderPath);
			return File.Create(filePath);
		}

	}
}
