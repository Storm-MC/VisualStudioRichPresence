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

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="key">String Key</param>
		/// <param name="value">String Value</param>
		public VisualStudioRichPresenceString(string key, string value) : this()
		{
			Key = key;
			Value = value;
		}

		/// <summary>
		/// Localization Key
		/// </summary>
		[XmlAttribute]
		public string Key { get; set; }

		/// <summary>
		/// Localization Text
		/// </summary>
		[XmlAttribute]
		public string Value { get; set; }
	}
}
