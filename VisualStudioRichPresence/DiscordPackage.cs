using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using VisualStudioRichPresence.Entities;
using VisualStudioRichPresence.Extensions;
using Config = VisualStudioRichPresence.Entities.VisualStudioRichPresenceConfig;

namespace VisualStudioRichPresence
{
	[ProvideAutoLoad (UIContextGuids80.SolutionExists, flags: PackageAutoLoadFlags.BackgroundLoad | PackageAutoLoadFlags.SkipWhenUIContextRulesActive)]
	[ProvideAutoLoad (UIContextGuids80.EmptySolution, flags: PackageAutoLoadFlags.BackgroundLoad | PackageAutoLoadFlags.SkipWhenUIContextRulesActive)]

	[PackageRegistration (UseManagedResourcesOnly = true)]
	[InstalledProductRegistration ("#110", "#112", "1.0", IconResourceID = 400)]
	[Guid ("3aa63f34-c1f0-42ea-95d1-5d2f07c3c7ec")]
	[SuppressMessage ("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
	public sealed partial class DiscordPackage : Package
	{
		DTE dte;
		Events events;

		RichPresence rp;
		EventHandlers eh;
		bool ready = false;

		public DiscordPackage() {
			Config.Load ();

			rp = new RichPresence ();
			eh = new EventHandlers () {
				readyCallback = () => {
					Trace.TraceInformation ("[DiscordRpc]: Ready");
					ready = true;
				},

				disconnectedCallback = (int c, string s) => {
					Trace.TraceWarning ("[DiscordRpc]: Disconnected. [{0}]: {1}", c, s);
					ready = false;
				},

				errorCallback = (int c, string s) => {
					Trace.TraceError ("[DiscordRpc]: Error. [{0}]: {1}", c, s);
					ready = false;
				}
			};
		}

		protected override void Initialize() {
			DiscordRpc.Initialize (
				Config.Instance.ApplicationId,
				ref eh,
				true,
				null
			);

			dte = (DTE)GetService (typeof (SDTE));
			events = dte.Events;

			events.DTEEvents.OnStartupComplete += () => {
				rp.smallImageKey = "visualstudio";
				rp.smallImageText = "Visual Studio";
				rp.startTimestamp = DiscordRpc.GetTimestamp (DateTime.UtcNow);
			};

			if(ready) {
				Trace.TraceInformation ("[DiscordRpc] Clearing Presence.");
				DiscordRpc.ClearPresence ();

				Trace.TraceInformation ("[DiscordRpc] Updating Presence.");
				DiscordRpc.UpdatePresence (rp);
				DiscordRpc.RunCallbacks ();
			}
			else {
				Trace.TraceError ("[DiscordRpc] Failed To Connect Discord.");
			}

			base.Initialize ();

			events.SolutionEvents.Opened += SolutionEvents_Opened;
		}

		private void SolutionEvents_Opened() {
			if(Config.Instance.ShowTimestamp) {
				if(Config.Instance.ToggleTimestampReset)
					rp.startTimestamp = DiscordRpc.GetTimestamp (DateTime.UtcNow);
			}
			else {
				rp.startTimestamp = -1;
			}

			if(Config.Instance.ShowProjectName)
				rp.details = "Working on {0}".Formatted (dte.Solution.FileName);

			DiscordRpc.UpdatePresence (rp);
			DiscordRpc.RunCallbacks ();
		}

		protected override int QueryClose(out bool canClose) {
			DiscordRpc.Shutdown ();
			return base.QueryClose (out canClose);
		}
	}
}