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

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="ext">File Extension</param>
		public VisualStudioRichPresenceExtension(string ext)
		{
			Extension = ext;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="ext">File Extension</param>
		/// <param name="smallKey">Small Image Key</param>
		public VisualStudioRichPresenceExtension(string ext, string smallKey) : this(ext)
		{
			SmallImageKey = smallKey;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="ext">File Extension</param>
		/// <param name="smallKey">Small Image Key</param>
		/// <param name="largeKey">Large Image Key</param>
		public VisualStudioRichPresenceExtension(string ext, string smallKey, string largeKey) : this(ext, smallKey)
		{
			LargeImageKey = largeKey;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="ext">File Extension</param>
		/// <param name="smallKey">Small Image Key</param>
		/// <param name="largeKey">Large Image Key</param>
		/// <param name="smallText">Small Image Text</param>
		/// <param name="largeText">Large Image Text</param>
		public VisualStudioRichPresenceExtension(string ext, string smallKey, string largeKey, string smallText, string largeText) : this(ext, smallKey, largeKey)
		{
			SmallImageText = smallText;
			LargeImageText = largeText;
		}

		/// <summary>
		/// Has File Extension?
		/// </summary>
		[XmlIgnore]
		public bool HasExtension => !string.IsNullOrWhiteSpace(Extension);

		/// <summary>
		/// Has Large Image Key?
		/// </summary>
		[XmlIgnore]
		public bool HasLargeImageKey => !string.IsNullOrWhiteSpace(LargeImageKey);

		/// <summary>
		/// Has Small Image Key?
		/// </summary>
		[XmlIgnore]
		public bool HasSmallImageKey => !string.IsNullOrWhiteSpace(SmallImageKey);

		/// <summary>
		/// Has Large Image Text?
		/// </summary>
		[XmlIgnore]
		public bool HasLargeImageText => !string.IsNullOrWhiteSpace(LargeImageText);

		/// <summary>
		/// Has Small Image Text?
		/// </summary>
		[XmlIgnore]
		public bool HasSmallImageText => !string.IsNullOrWhiteSpace(SmallImageText);

		/// <summary>
		/// File Extension
		/// </summary>
		[XmlAttribute]
		public string Extension { get; set; }

		/// <summary>
		/// Discord Large Image Key
		/// </summary>
		[XmlAttribute]
		public string LargeImageKey { get; set; }

		/// <summary>
		/// Discord Small Image Key
		/// </summary>
		[XmlAttribute]
		public string SmallImageKey { get; set; }

		/// <summary>
		/// Discord Small Image Text
		/// </summary>
		[XmlAttribute]
		public string SmallImageText { get; set; }

		/// <summary>
		/// Discord Large Image Text
		/// </summary>
		[XmlAttribute]
		public string LargeImageText { get; set; }
	}
}