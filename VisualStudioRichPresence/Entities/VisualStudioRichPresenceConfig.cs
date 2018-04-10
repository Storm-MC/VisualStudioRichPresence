using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace VisualStudioRichPresence.Entities
{
	[XmlRoot]
	public partial class VisualStudioRichPresenceConfig
	{
		public VisualStudioRichPresenceConfig()
		{
			Extensions = new List<VisualStudioRichPresenceExtension>();
			Strings = new List<VisualStudioRichPresenceString>();
		}

		[XmlElement]
		public string ApplicationId { get; set; }

		[XmlElement]
		public bool ShowTimestamp { get; set; }

		[XmlElement]
		public bool AutoResetTimestamp { get; set; }

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

		[XmlArray("Strings")]
		[XmlArrayItem("String")]
		public List<VisualStudioRichPresenceString> Strings { get; set; }

		public (bool exists, string text) GetString(string key)
		{
			var m = Strings.Find(f => f.Key == key);
			if(m != null)
			{
				return (true, m.Value);
			}
			return (false, "");
		}
	}
}