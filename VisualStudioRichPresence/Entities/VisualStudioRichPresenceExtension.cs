using System.Xml.Serialization;

namespace VisualStudioRichPresence.Entities
{
	public class VisualStudioRichPresenceExtension
	{
		public VisualStudioRichPresenceExtension() {
			Extension = "";
			LargeImageKey = "";
			SmallImageKey = "";
		}

		public VisualStudioRichPresenceExtension(string ext) {
			Extension = ext;
		}

		public VisualStudioRichPresenceExtension(string ext, string large) {
			Extension = ext;
			LargeImageKey = large;
		}

		public VisualStudioRichPresenceExtension(string ext, string large, string small) {
			Extension = ext;
			LargeImageKey = large;
			SmallImageKey = small;
		}

		[XmlIgnore]
		public bool HasExtension => string.IsNullOrWhiteSpace (Extension);

		[XmlIgnore]
		public bool HasLargeImageKey => string.IsNullOrWhiteSpace (LargeImageKey);

		[XmlIgnore]
		public bool HasSmallImageKey => string.IsNullOrWhiteSpace (SmallImageKey);

		[XmlAttribute]
		public string Extension { get; set; }

		[XmlAttribute]
		public string LargeImageKey { get; set; }

		[XmlAttribute]
		public string SmallImageKey { get; set; }
	}
}