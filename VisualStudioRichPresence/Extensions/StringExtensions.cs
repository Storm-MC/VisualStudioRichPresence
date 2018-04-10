namespace VisualStudioRichPresence.Extensions
{
	public static class StringExtensions
	{
		public static string Formatted(this string format, params object[] args) {
			return string.Format (format, args);
		}
	}
}
