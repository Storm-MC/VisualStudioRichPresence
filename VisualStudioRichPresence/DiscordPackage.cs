using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using VisualStudioRichPresence.Entities;
using Config = VisualStudioRichPresence.Entities.VisualStudioRichPresenceConfig;

namespace VisualStudioRichPresence
{
	[ProvideAutoLoad(UIContextGuids80.NoSolution)]
	[PackageRegistration(UseManagedResourcesOnly = true)]
	[InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
	[Guid("3aa63f34-c1f0-42ea-95d1-5d2f07c3c7ec")]
	[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
	public sealed partial class DiscordPackage : Package
	{
		DTE dte;
		Events events;

		RichPresence rp;
		EventHandlers eh;

		public static DiscordPackage Instance { get; private set; }

		public DiscordPackage()
		{
			Instance = this;

			Log.Configure();
			Config.Load();

			rp = new RichPresence();
			eh = new EventHandlers()
			{
				readyCallback = () =>
				{
					Log.Debug("Ready");
				},

				disconnectedCallback = (int c, string s) =>
				{
					Log.Warn("Disconnected: [{0}]: {1}", c, s);
				},

				errorCallback = (int c, string s) =>
				{
					Log.Error("Errored: [{0}]: {1}", c, s);
				}
			};
		}

		protected override void Initialize()
		{
			DiscordRpc.Initialize(
				Config.Instance.ApplicationId,
				ref eh,
				true,
				null
			);

			dte = (DTE)GetService(typeof(SDTE));
			events = dte.Events;


			rp.largeImageKey = "visualstudio";
			rp.largeImageText = "Visual Studio";
			rp.startTimestamp = DiscordRpc.GetTimestamp(DateTime.UtcNow);

			rp.state = "No File";
			rp.details = "No Project";

			DiscordRpc.UpdatePresence(rp);
			DiscordRpc.RunCallbacks();

			events.SolutionEvents.Opened += SolutionEvents_Opened;
			events.WindowEvents.WindowActivated += WindowEvents_WindowActivated;

			base.Initialize();
			Log.Info("Initialized.");
		}

		void CheckTimestamp()
		{
			Log.Debug("CheckTimestamp(): Show Timestamp? " + (Config.Instance.ShowTimestamp ? "Yes" : "No"));
			if (Config.Instance.ShowTimestamp)
			{
				Log.Debug("CheckTimestamp(): Toggle Timestamp Reset? " + (Config.Instance.ToggleTimestampReset ? "Yes" : "No"));

				if (Config.Instance.ToggleTimestampReset)
				{
					var ts = DiscordRpc.GetTimestamp(DateTime.UtcNow);
					Log.Debug("CheckTimestamp(): Old Timestamp: " + rp.startTimestamp + ", New Timestamp: " + ts);
					rp.startTimestamp = ts;
				}
			}
			else
			{
				rp.startTimestamp = null;
			}
		}

		void SolutionEvents_Opened()
		{
			CheckTimestamp();

			if (Config.Instance.ShowProjectName)
			{
				rp.details = string.Format("Working On {0}", Path.GetFileNameWithoutExtension(dte.Solution.FileName));
			}
			else
			{
				rp.details = null;
			}

			DiscordRpc.UpdatePresence(rp);
			DiscordRpc.RunCallbacks();
		}

		void SolutionEvents_Closed()
		{
			CheckTimestamp();

			rp.state = "No File";
			rp.details = "No Project";

			DiscordRpc.UpdatePresence(rp);
			DiscordRpc.RunCallbacks();
		}

		void WindowEvents_WindowActivated(Window GotFocus, Window LostFocus)
		{
			CheckTimestamp();

			if (GotFocus != null && GotFocus.Document != null && File.Exists(GotFocus.Document.Path))
			{

			}
		}

		protected override int QueryClose(out bool canClose)
		{
			Log.Info("Shutdown.");
			DiscordRpc.Shutdown();
			return base.QueryClose(out canClose);
		}
	}
}