using YNAB_Budget_Planner.Backend.Saving;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNAB_Budget_Planner.Backend {
	public class AppDataWeb : IAppData {

		private static AppDataWeb appData = new AppDataWeb();
		public static AppData AppData { get => appData.Settings; }
		private IJSRuntime javascript;
		private MemoryStream readStream;

		public static async Task UploadAppData(IJSRuntime js, IBrowserFile file) {
			appData.javascript = js;
			// Microsoft said this is bad, but it's ok... for now...
			MemoryStream stream = new MemoryStream();
			appData.readStream = stream;
			using (var reader = file.OpenReadStream()) {
				await reader.CopyToAsync(stream);
			}

			stream.Position = 0;
			appData.Load();
		}

		public static void DownloadAppData(IJSRuntime js) {
			appData.javascript = js;
			appData.Save(true);
		}

		private AppDataWeb() { }
		
		protected override Stream LoadStream() {
			return readStream;
		}

		protected override Stream SaveStream() {
			return new DownloadStream(this.javascript, "Budget Planner.json");
		}

		#region Streams
		private class DownloadStream : Stream {
			public override bool CanRead => false;

			public override bool CanSeek => false;

			public override bool CanWrite => true;

			public override long Length => throw new NotImplementedException();

			public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

			private readonly StringBuilder data = new StringBuilder();
			private readonly IJSRuntime javascript;
			private readonly string filename;

			public DownloadStream(IJSRuntime js, string fileName) {
				this.javascript = js;
				this.filename = fileName;
			}

			~DownloadStream() {
				Flush();
			}

			public override void Flush() {
				if (data.Length > 0) {
					javascript.InvokeVoidAsync("saveAsFile", filename, data.ToString());
					data.Clear();
				}
			}

			public override int Read(byte[] buffer, int offset, int count) {
				throw new NotImplementedException();
			}

			public override long Seek(long offset, SeekOrigin origin) {
				throw new NotImplementedException();
			}

			public override void SetLength(long value) {
				throw new NotImplementedException();
			}

			public override void Write(byte[] buffer, int offset, int count) {
				data.Append(System.Text.Encoding.ASCII.GetString(buffer, offset, count));
			}
		}
		#endregion

	}
}
