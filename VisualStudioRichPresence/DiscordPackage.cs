using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using VisualStudioRichPresence.Entities;

namespace VisualStudioRichPresence
{
	[ProvideAutoLoad (UIContextGuids80.EmptySolution)]
	[ProvideAutoLoad (UIContextGuids80.SolutionExists)]

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
		bool ready;

		public DiscordPackage() {
			VisualStudioRichPresenceConfig.Load ();

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
				VisualStudioRichPresenceConfig.Instance.ApplicationId.ToString (),
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

			DiscordRpc.ClearPresence ();
			DiscordRpc.UpdatePresence (rp);
			DiscordRpc.RunCallbacks ();

			base.Initialize ();
		}

		protected override int QueryClose(out bool canClose) {
			DiscordRpc.Shutdown ();
			return base.QueryClose (out canClose);
		}
	}
}