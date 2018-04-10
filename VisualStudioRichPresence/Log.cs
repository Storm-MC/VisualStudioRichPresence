using System;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace VisualStudioRichPresence
{
	public sealed class Log
	{
		/// <summary>
		/// Output Panel Guid
		/// </summary>
		static Guid guid = new Guid("EC5C9F2B-E659-428B-979D-AA0D9B186975");

		/// <summary>
		/// Output Panel Type
		/// </summary>
		static string LogTitle = "Visual Studio Rich Presence";

		static IVsOutputWindow vsOutputWindow;
		static IVsOutputWindowPane vsOutputWindowPane;

		/// <summary>
		/// Configure <see cref="IVsOutputWindow"/> and <see cref="IVsOutputWindowPane"/>
		/// </summary>
		public static void Configure()
		{
			vsOutputWindow = Package.GetGlobalService(typeof(IVsOutputWindow)) as IVsOutputWindow;
			vsOutputWindow.CreatePane(ref guid, LogTitle, 1, 0);
			vsOutputWindow.GetPane(ref guid, out vsOutputWindowPane);
			vsOutputWindowPane.Activate();
		}

		/// <summary>
		/// Internal: Add Info to log message
		/// </summary>
		/// <param name="message">Base message</param>
		/// <returns></returns>
		static string AddInfo(string message)
		{
			return DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ffffff") + " " + message + Environment.NewLine;
		}

		/// <summary>
		/// Information
		/// </summary>
		/// <param name="message">Message</param>
		public static void Info(string message) => vsOutputWindowPane.OutputString(AddInfo("Information " + message));

		/// <summary>
		/// Information
		/// </summary>
		/// <param name="format">Information Format</param>
		/// <param name="args">Arguments</param>
		public static void Info(string format, params object[] args) => Info(string.Format(format, args));

		/// <summary>
		/// Warning
		/// </summary>
		/// <param name="message">Message</param>
		public static void Warn(string message) => vsOutputWindowPane.OutputString(AddInfo("Warning " + message));

		/// <summary>
		/// Warning
		/// </summary>
		/// <param name="format">Warning Format</param>
		/// <param name="args">Arguments</param>
		public static void Warn(string format, params object[] args) => Warn(string.Format(format, args));
		
		/// <summary>
		/// Warning an Exception
		/// </summary>
		/// <param name="ex">Exception</param>
		/// <param name="message">Additional Message</param>
		public static void Warn(Exception ex, string message) => Warn("{0}\r\n{1}", message, ex.ToString());

		/// <summary>
		/// Error
		/// </summary>
		/// <param name="message"></param>
		public static void Error(string message) => vsOutputWindowPane.OutputString(AddInfo("Error " + message));

		/// <summary>
		/// Error
		/// </summary>
		/// <param name="format">Error Format</param>
		/// <param name="args">Arguments</param>
		public static void Error(string format, params object[] args) => Error(string.Format(format, args));
		
		/// <summary>
		/// Error Exception
		/// </summary>
		/// <param name="ex">Exception</param>
		/// <param name="message">Additional Message</param>
		public static void Error(Exception ex, string message) => Error("{0}\r\n{1}", message, ex.ToString());

		/// <summary>
		/// Debug (Not Important)
		/// </summary>
		/// <param name="message"></param>
		public static void Debug(string message)
		{
#if DEBUG
			vsOutputWindowPane.OutputString(AddInfo("Debug " + message));
#else
			return;
#endif
		}

		/// <summary>
		/// Debug (Not Important)
		/// </summary>
		/// <param name="message"></param>
		public static void Debug(string format, params object[] args) => Debug(string.Format(format, args));
	}
}
