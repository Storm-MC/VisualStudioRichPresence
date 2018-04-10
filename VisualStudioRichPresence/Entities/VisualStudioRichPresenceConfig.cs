using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace VisualStudioRichPresence.Entities
{
	[XmlRoot]
	public partial class VisualStudioRichPresenceConfig
	{
		[XmlElement]
		public string ApplicationId { get; set; }

		[XmlElement]
		public bool ShowTimestamp { get; set; }

		[XmlElement]
		public bool ToggleTimestampReset { get; set; }

		[XmlElement]
		public bool ShowFileName { get; set; }
		
		[XmlElement]
		public bool ShowProjectName { get; set; }

		[XmlElement]
		public VisualStudioRichPresenceExtension DefaultFile { get; set; }

		[XmlElement]
		public VisualStudioRichPresenceExtension DefaultFolder { get; set; }

		[XmlArray ("Extensions")]
		[XmlArrayItem ("Extension")]
		public List<VisualStudioRichPresenceExtension> Extensions { get; set; }
	}
}