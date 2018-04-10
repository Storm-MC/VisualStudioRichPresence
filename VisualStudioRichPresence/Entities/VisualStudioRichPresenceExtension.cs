using System.Xml.Serialization;

namespace VisualStudioRichPresence.Entities
{
	public class VisualStudioRichPresenceExtension
	{
		public VisualStudioRichPresenceExtension()
		{
			Extension = "";
			LargeImageKey = "";
			SmallImageKey = "";
		}

		public VisualStudioRichPresenceExtension(string ext)
		{
			Extension = ext;
		}

		public VisualStudioRichPresenceExtension(string ext, string smallKey) : this(ext)
		{
			SmallImageKey = smallKey;
		}

		public VisualStudioRichPresenceExtension(string ext, string smallKey, string largeKey) : this(ext, smallKey)
		{
			LargeImageKey = LargeImageKey;
		}

		public VisualStudioRichPresenceExtension(string ext, string smallKey, string smallText, string largeKey, string largeText) : this(ext, smallKey, largeKey)
		{
			SmallImageText = smallText;
			LargeImageText = largeText;
		}

		[XmlIgnore]
		public bool HasExtension => !string.IsNullOrWhiteSpace(Extension);

		[XmlIgnore]
		public bool HasLargeImageKey => !string.IsNullOrWhiteSpace(LargeImageKey);

		[XmlIgnore]
		public bool HasSmallImageKey => !string.IsNullOrWhiteSpace(SmallImageKey);

		[XmlIgnore]
		public bool HasLargeImageText => !string.IsNullOrWhiteSpace(LargeImageText);

		[XmlIgnore]
		public bool HasSmallImageText => !string.IsNullOrWhiteSpace(SmallImageText);

		[XmlAttribute]
		public string Extension { get; set; }

		[XmlAttribute]
		public string LargeImageKey { get; set; }

		[XmlAttribute]
		public string SmallImageKey { get; set; }

		[XmlAttribute]
		public string SmallImageText { get; set; }

		[XmlAttribute]
		public string LargeImageText { get; set; }
	}
}