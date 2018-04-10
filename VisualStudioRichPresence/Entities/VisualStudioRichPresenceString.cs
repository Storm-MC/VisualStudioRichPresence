using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VisualStudioRichPresence.Entities
{
	public class VisualStudioRichPresenceString
	{
		public VisualStudioRichPresenceString()
		{
			Key = "";
			Value = "";
		}

		public VisualStudioRichPresenceString(string key, string value) : this()
		{
			Key = key;
			Value = value;
		}

		[XmlAttribute]
		public string Key { get; set; }

		[XmlAttribute]
		public string Value { get; set; }
	}
}
