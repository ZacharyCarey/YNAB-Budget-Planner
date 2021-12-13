using JsonSerializable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common.Saving {
	public abstract class IAppData {

		public readonly AppData Settings = new AppData();

		protected IAppData() {

		}

		public void Save(bool minimal = false) {
			using (Stream stream = SaveStream()) {
				Json.Write(Settings, stream, minimal);
				stream.Flush();
			}
		}

		public void Load() {
			using (Stream stream = LoadStream()) {
				if (stream != null) {
					Json.Read(stream, Settings);
				} else {
					Console.Out.WriteLine("Could not read file.");
				}
			}
		}

		protected abstract Stream SaveStream();

		protected abstract Stream LoadStream();

	}
}
