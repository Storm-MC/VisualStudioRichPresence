using System;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace VisualStudioRichPresence
{
	public sealed class Log
	{
		static Guid guid = new Guid("EC5C9F2B-E659-428B-979D-AA0D9B186975");
		static string LogTitle = "DiscordRpc";

		static IVsOutputWindow vsOutputWindow;
		static IVsOutputWindowPane vsOutputWindowPane;

		public static void Configure()
		{
			vsOutputWindow = Package.GetGlobalService(typeof(IVsOutputWindow)) as IVsOutputWindow;
			vsOutputWindow.CreatePane(ref guid, LogTitle, 1, 0);
			vsOutputWindow.GetPane(ref guid, out vsOutputWindowPane);
			vsOutputWindowPane.Activate();
		}

		static string AddInfo(string message)
		{
			return DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ffffff") + " " + message + Environment.NewLine;
		}

		public static void Info(string message) => vsOutputWindowPane.OutputString(AddInfo("Information " + message));
		public static void Info(string format, params object[] args) => Info(string.Format(format, args));

		public static void Warn(string message) => vsOutputWindowPane.OutputString(AddInfo("Warning " + message));
		public static void Warn(string format, params object[] args) => Warn(string.Format(format, args));
		public static void Warn(Exception ex, string message) => Warn("{0}\r\n{1}", message, ex.ToString());

		public static void Error(string message) => vsOutputWindowPane.OutputString(AddInfo("Error " + message));
		public static void Error(string format, params object[] args) => Error(string.Format(format, args));
		public static void Error(Exception ex, string message) => Error("{0}\r\n{1}", message, ex.ToString());

		public static void Debug(string message)
		{
#if DEBUG
			vsOutputWindowPane.OutputString(AddInfo("Debug " + message));
#else
			return;
#endif
		}

		public static void Debug(string format, params object[] args) => Debug(string.Format(format, args));
	}
}
