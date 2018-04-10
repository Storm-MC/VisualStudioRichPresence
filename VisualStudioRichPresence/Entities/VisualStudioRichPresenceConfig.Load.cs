using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace VisualStudioRichPresence.Entities
{
	public partial class VisualStudioRichPresenceConfig
	{

		public static VisualStudioRichPresenceConfig Instance {
			get;
			private set;
		}

		public static void Load()
		{
			Log.Info("Loading Configuration...");

			var file = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\Visual Studio Rich Presence\Config.xml");
			var xs = new XmlSerializer(typeof(VisualStudioRichPresenceConfig));

			if (!file.Directory.Exists)
			{
				file.Directory.Create();
			}

			if (file.Exists)
			{
				Log.Info("Loaded Cached Configuration");

				var fs = file.OpenRead();
				var obj = xs.Deserialize(fs);
				fs.Dispose();
				Instance = (VisualStudioRichPresenceConfig)obj;

				Log.Info("Extensions Loaded: " + Instance.Extensions.Count);
			}
			else
			{
				Log.Info("Saved Cached Configuration");

				var fs = file.OpenWrite();
				var obj = new VisualStudioRichPresenceConfig
				{
					ApplicationId = "421688819868237824",
					ShowTimestamp = true,
					ShowFileName = true,
					ShowProjectName = true,
					ToggleTimestampReset = false,

					DefaultFile = new VisualStudioRichPresenceExtension("", "default_file"),
					DefaultFolder = new VisualStudioRichPresenceExtension("", "default_folder"),

					Extensions = new List<VisualStudioRichPresenceExtension> {
						new VisualStudioRichPresenceExtension("asp", "", "file_type_asp"),
						new VisualStudioRichPresenceExtension("aspx", "", "file_type_aspx"),

						new VisualStudioRichPresenceExtension("bat", "", "file_type_bat"),
						new VisualStudioRichPresenceExtension("cmd", "", "file_type_bat"),
						new VisualStudioRichPresenceExtension("sh", "", "file_type_bat"),

						new VisualStudioRichPresenceExtension("c", "", "file_type_c"),

						new VisualStudioRichPresenceExtension("cc", "", "file_type_cpp"),
						new VisualStudioRichPresenceExtension("cpp", "", "file_type_cpp"),
						new VisualStudioRichPresenceExtension("cxx", "", "file_type_cpp"),
						new VisualStudioRichPresenceExtension("h", "", "file_type_cppheader"),
						new VisualStudioRichPresenceExtension("hpp", "", "file_type_cppheader"),
						new VisualStudioRichPresenceExtension("hh", "", "file_type_cppheader"),
						new VisualStudioRichPresenceExtension("hxx", "", "file_type_cppheader"),

						new VisualStudioRichPresenceExtension("cs", "", "file_type_csharp"),
						new VisualStudioRichPresenceExtension("csx", "", "file_type_csharp"),
						new VisualStudioRichPresenceExtension("cake", "", "file_type_csharp"),
						new VisualStudioRichPresenceExtension("csproj", "", "file_type_csproj"),

						new VisualStudioRichPresenceExtension("fs", "", "file_type_fsharp2"),
						new VisualStudioRichPresenceExtension("fsi", "", "file_type_fsharp2"),
						new VisualStudioRichPresenceExtension("fsx", "", "file_type_fsharp2"),
						new VisualStudioRichPresenceExtension("fsscript", "", "file_type_fsharp2"),

						new VisualStudioRichPresenceExtension("htm", "", "file_type_html"),
						new VisualStudioRichPresenceExtension("html", "", "file_type_html"),
						new VisualStudioRichPresenceExtension("shtm", "", "file_type_html"),
						new VisualStudioRichPresenceExtension("xhtml", "", "file_type_html"),
						new VisualStudioRichPresenceExtension("xht", "", "file_type_html"),
						new VisualStudioRichPresenceExtension("hta", "", "file_type_html"),

						new VisualStudioRichPresenceExtension("js", "", "file_type_js"),
						new VisualStudioRichPresenceExtension("jsx", "", "file_type_js"),
						new VisualStudioRichPresenceExtension("es6", "", "file_type_js"),
						new VisualStudioRichPresenceExtension("mjs", "", "file_type_js"),
						new VisualStudioRichPresenceExtension("pac", "", "file_type_js"),

						new VisualStudioRichPresenceExtension("json", "", "file_type_json_official"),

						new VisualStudioRichPresenceExtension("config", "", "file_type_light_config"),
						new VisualStudioRichPresenceExtension("ini", "", "file_type_light_config"),
						new VisualStudioRichPresenceExtension("inf", "", "file_type_light_config"),
						new VisualStudioRichPresenceExtension("settings", "", "file_type_light_config"),

						new VisualStudioRichPresenceExtension("njsproj", "", "file_type_njsproj"),

						new VisualStudioRichPresenceExtension("php", "", "file_type_php3"),
						new VisualStudioRichPresenceExtension("php4", "", "file_type_php3"),
						new VisualStudioRichPresenceExtension("php5", "", "file_type_php3"),
						new VisualStudioRichPresenceExtension("phtml", "", "file_type_php3"),
						new VisualStudioRichPresenceExtension("ctp", "", "file_type_php3"),

						new VisualStudioRichPresenceExtension("py", "", "file_type_python"),
						new VisualStudioRichPresenceExtension("rpy", "", "file_type_python"),
						new VisualStudioRichPresenceExtension("pyw", "", "file_type_python"),
						new VisualStudioRichPresenceExtension("cpy", "", "file_type_python"),
						new VisualStudioRichPresenceExtension("gyp", "", "file_type_python"),
						new VisualStudioRichPresenceExtension("gypi", "", "file_type_python"),

						new VisualStudioRichPresenceExtension("sln", "", "file_type_sln"),

						new VisualStudioRichPresenceExtension("sql", "", "file_type_sql"),
						new VisualStudioRichPresenceExtension("dsql", "", "file_type_sql"),

						new VisualStudioRichPresenceExtension("txt", "", "file_type_text"),
						new VisualStudioRichPresenceExtension("log", "", "file_type_text"),
						new VisualStudioRichPresenceExtension("plain", "", "file_type_text"),
						new VisualStudioRichPresenceExtension("text", "", "file_type_text"),

						new VisualStudioRichPresenceExtension("ts", "", "file_type_typescript"),
						new VisualStudioRichPresenceExtension("tsx", "", "file_type_typescript"),


						new VisualStudioRichPresenceExtension("vb", "", "file_type_vb"),
						new VisualStudioRichPresenceExtension("vbs", "", "file_type_vb"),
						new VisualStudioRichPresenceExtension("brs", "", "file_type_vb"),
						new VisualStudioRichPresenceExtension("bas", "", "file_type_vb"),

						new VisualStudioRichPresenceExtension("vbhtml", "", "file_type_vbhtml"),
						new VisualStudioRichPresenceExtension("vbproj", "", "file_type_vbproj"),
						new VisualStudioRichPresenceExtension("vcxproj", "", "file_type_vcxproj"),

						new VisualStudioRichPresenceExtension("xml", "", "file_type_xml"),
						new VisualStudioRichPresenceExtension("xsd", "", "file_type_xml"),
						new VisualStudioRichPresenceExtension("ascx", "", "file_type_xml"),
						new VisualStudioRichPresenceExtension("atom", "", "file_type_xml"),
						new VisualStudioRichPresenceExtension("axml", "", "file_type_xml"),
						new VisualStudioRichPresenceExtension("bpmn", "", "file_type_xml"),
						new VisualStudioRichPresenceExtension("cpt", "", "file_type_xml"),
						new VisualStudioRichPresenceExtension("csl", "", "file_type_xml"),
						new VisualStudioRichPresenceExtension("xsl", "", "file_type_xml"),
						new VisualStudioRichPresenceExtension("xslt", "", "file_type_xml"),

						new VisualStudioRichPresenceExtension("eyaml", "", "file_type_yaml"),
						new VisualStudioRichPresenceExtension("eyml", "", "file_type_yaml"),
						new VisualStudioRichPresenceExtension("yaml", "", "file_type_yaml"),
						new VisualStudioRichPresenceExtension("yml", "", "file_type_yaml")
					}
				};

				Log.Info("Extensions Added: " + obj.Extensions.Count);

				xs.Serialize(fs, obj);
				fs.Close();
				Instance = obj;
			}
		}
	}
}