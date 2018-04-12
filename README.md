## Visual Studio Rich Presence
Now you can share with your friends what you are programming.

## About Visual Studio Rich Presence
This project allows you to customize your rich presence according to what you want in real visual studio.

## Features:

- You can use a custom application id.
- You can change the extension types and texts to be displayed.
- You can change the initial rich presence texts.
- You can use 79 file types by default (I've worked hard on that part).
- You can change the behavior of rich presence as:
    - Show / Hide Code Time
    - Show / Hide the project you are working on.
    - Show / Hide the name of the file you are working on.
    - Enable / Disable restart code time.

 >Any kind of question or problem use the issues in this repository.
<br/><br/>
>REMEMBER: This project is in the initial phase, at the moment it works correctly, however if you want to contribute with the project feel free, as long as it does not compromise the code or the repository.

## Configuration.
By default configuration is located in `%USERPROFILE%\Documents\My Games\Visual Studio Rich Presence`.<br>
You can customize all in configuration, see below:<br>
```xml
<VisualStudioRichPresenceConfig xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <ApplicationId>421688819868237824</ApplicationId>
  <ShowTimestamp>true</ShowTimestamp>
  <AutoResetTimestamp>false</AutoResetTimestamp>
  <ShowFileName>true</ShowFileName>
  <ShowProjectName>true</ShowProjectName>
  <DefaultFile Extension="" LargeImageKey="default_file" SmallImageKey="" /> <- This is an extension too like in <Extensions>
  <DefaultFolder Extension="" LargeImageKey="default_folder" SmallImageKey="" /> <- This is an extension too like in <Extensions>
  <Extensions>
    <Extension Extension="asp" LargeImageKey="file_type_asp" SmallImageKey="" SmallImageText="" LargeImageText="" />
    <Extension Extension="aspx" LargeImageKey="file_type_aspx" SmallImageKey="" SmallImageText="" LargeImageText="" />
    <Extension Extension="bat" LargeImageKey="file_type_bat" SmallImageKey="" SmallImageText="" LargeImageText="" />
    <Extension Extension="cmd" LargeImageKey="file_type_bat" SmallImageKey="" SmallImageText="" LargeImageText="" />
    <Extension Extension="sh" LargeImageKey="file_type_bat" SmallImageKey="" SmallImageText="" LargeImageText="" />
    <Extension Extension="c" LargeImageKey="file_type_c" SmallImageKey="" SmallImageText="" LargeImageText="" />
    <Extension Extension="cc" LargeImageKey="file_type_cpp" SmallImageKey="" SmallImageText="" LargeImageText="" />
    <Extension Extension="cpp" LargeImageKey="file_type_cpp" SmallImageKey="" SmallImageText="" LargeImageText="" />
    <Extension Extension="cxx" LargeImageKey="file_type_cpp" SmallImageKey="" SmallImageText="" LargeImageText="" />
    <Extension Extension="h" LargeImageKey="file_type_cppheader" SmallImageKey="" SmallImageText="" LargeImageText="" />
    <Extension Extension="hpp" LargeImageKey="file_type_cppheader" SmallImageKey="" SmallImageText="" LargeImageText="" />
    <Extension Extension="hh" LargeImageKey="file_type_cppheader" SmallImageKey="" SmallImageText="" LargeImageText="" />
    <Extension Extension="hxx" LargeImageKey="file_type_cppheader" SmallImageKey="" SmallImageText="" LargeImageText="" />
    <Extension Extension="cs" LargeImageKey="file_type_csharp" SmallImageKey="" SmallImageText="" LargeImageText="" />
    
    ... more extensions here...
    
  </Extensions>
  <Strings>
    <String Key="VS_WORKING_ON_PROJECT" Value="Working On: " />
    <String Key="VS_EDITING_FILE" Value="Editing: " />
  </Strings>
</VisualStudioRichPresenceConfig>
```
<br/>
<b>All default large image key that i have is:</b>
```txt
default_file
default_folder
file_type_asp
file_type_aspx
file_type_bat
file_type_c
file_type_cpp
file_type_cppheader
file_type_csharp
file_type_csproj
file_type_fsharp2
file_type_html
file_type_js
file_type_json_official
file_type_light_config
file_type_njsproj
file_type_php3
file_type_python
file_type_sln
file_type_sql
file_type_text
file_type_typescript
file_type_vb
file_type_vbhtml
file_type_vbproj
file_type_vcxproj
file_type_xml
file_type_yaml
```

## Example

<img src="https://i.imgur.com/2lZ9E1f.png" alt="Discord Rich Example"></img>

## Support

Join in our official guild <a href="https://discord.gg/N8Nuugb">clicking here</a>.
