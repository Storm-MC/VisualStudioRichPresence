using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace VisualStudioRichPresence.Entities
{
	[XmlRoot]
	public partial class VisualStudioRichPresenceConfig
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public VisualStudioRichPresenceConfig()
		{
			Extensions = new List<VisualStudioRichPresenceExtension>();
			Strings = new List<VisualStudioRichPresenceString>();
		}

		/// <summary>
		/// Application Id
		/// </summary>
		[XmlElement]
		public string ApplicationId { get; set; }

		/// <summary>
		/// Show Timestamp?
		/// </summary>
		[XmlElement]
		public bool ShowTimestamp { get; set; }

		/// <summary>
		/// Auto Reset Timestamp?
		/// </summary>
		[XmlElement]
		public bool AutoResetTimestamp { get; set; }

		/// <summary>
		/// Show Editing File Name?
		/// </summary>
		[XmlElement]
		public bool ShowFileName { get; set; }
		
		/// <summary>
		/// Show Working On Project?
		/// </summary>
		[XmlElement]
		public bool ShowProjectName { get; set; }

		/// <summary>
		/// Default File Extension
		/// </summary>
		[XmlElement]
		public VisualStudioRichPresenceExtension DefaultFile { get; set; }

		/// <summary>
		/// Default Folder Extension
		/// </summary>
		[XmlElement]
		public VisualStudioRichPresenceExtension DefaultFolder { get; set; }
		
		/// <summary>
		/// Extensions Assets
		/// </summary>
		[XmlArray ("Extensions")]
		[XmlArrayItem ("Extension")]
		public List<VisualStudioRichPresenceExtension> Extensions { get; set; }

		/// <summary>
		/// Localization Strings
		/// </summary>
		[XmlArray("Strings")]
		[XmlArrayItem("String")]
		public List<VisualStudioRichPresenceString> Strings { get; set; }

		/// <summary>
		/// Get String From <see cref="Strings"/>
		/// </summary>
		/// <param name="key">Key</param>
		/// <returns></returns>
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