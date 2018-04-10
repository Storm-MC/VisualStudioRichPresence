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

		long timestamp;
		
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

			timestamp = DiscordRpc.GetTimestamp();

			rp.startTimestamp = null;
			rp.endTimestamp = null;

			rp.largeImageKey = "visualstudio";
			rp.largeImageText = "Visual Studio";

			DiscordRpc.UpdatePresence(rp);
			DiscordRpc.RunCallbacks();

			events.SolutionEvents.Opened += SolutionEvents_Opened;
			events.SolutionEvents.AfterClosing += SolutionEvents_Closed;
			events.WindowEvents.WindowActivated += WindowEvents_WindowActivated;

			base.Initialize();
			Log.Info("Initialized.");
		}

		void CheckTimestamp()
		{
			if (Config.Instance.ShowTimestamp)
			{
				if (Config.Instance.AutoResetTimestamp)
					rp.startTimestamp = DiscordRpc.GetTimestamp();
				else
					rp.startTimestamp = timestamp;
			}
			else
			{
				rp.startTimestamp = null;
				rp.endTimestamp = null;
			}
		}

		void SolutionEvents_Opened()
		{
			CheckTimestamp();

			if (Config.Instance.ShowProjectName)
			{
				var name = Path.GetFileNameWithoutExtension(dte.Solution.FileName);
				var str = Config.Instance.GetString("VS_WORKING_ON_PROJECT");
				rp.state = str.exists ? str.text + name : name;
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

			rp.state = null;
			rp.details = null;
			rp.largeImageKey = "visualstudio";
			rp.largeImageText = "Visual Studio";

			rp.smallImageKey = null;
			rp.smallImageText = null;

			rp.startTimestamp = null;
			rp.endTimestamp = null;

			DiscordRpc.UpdatePresence(rp);
			DiscordRpc.RunCallbacks();
		}

		void WindowEvents_WindowActivated(Window GotFocus, Window LostFocus)
		{
			CheckTimestamp();

			if (Config.Instance.ShowProjectName && dte.Solution != null && File.Exists(dte.Solution.FullName))
			{
				var name = Path.GetFileNameWithoutExtension(new FileInfo(dte.Solution.FullName).FullName);
				var str = Config.Instance.GetString("VS_WORKING_ON_PROJECT");
				rp.state = str.exists ? str.text + name : name;
			}

			if (GotFocus != null && GotFocus.Document != null && File.Exists(GotFocus.Document.FullName))
			{
				rp.largeImageKey = null;
				rp.largeImageText = null;
				rp.smallImageKey = null;
				rp.smallImageText = null;
				
				var filename = new FileInfo(GotFocus.Document.FullName).FullName;
				var extension = Path.GetExtension(filename).Substring(1);

				var name = Path.GetFileName(filename);
				var str = Config.Instance.GetString("VS_EDITING_FILE");
				rp.details = str.exists ? str.text + name : name;

				var ext = Config.Instance.Extensions.Find(e => e.Extension == extension);
				if(ext != null)
				{
					if (ext.HasLargeImageKey)
						rp.largeImageKey = ext.LargeImageKey;

					if (ext.HasLargeImageText)
						rp.largeImageText = ext.LargeImageText;

					if (ext.HasSmallImageKey)
						rp.smallImageKey = ext.SmallImageKey;

					if (ext.HasSmallImageText)
						rp.smallImageText = ext.SmallImageText;
				}
			}

			DiscordRpc.UpdatePresence(rp);
			DiscordRpc.RunCallbacks();
		}
	}
}