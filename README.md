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
You can customize all in configuration, see below:<br><br>

```xml
<VisualStudioRichPresenceConfig xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <ApplicationId>421688819868237824</ApplicationId>
  <ShowTimestamp>true</ShowTimestamp>
  <AutoResetTimestamp>false</AutoResetTimestamp>
  <ShowFileName>true</ShowFileName>
  <ShowProjectName>true</ShowProjectName>
  <DefaultFile Extension="" LargeImageKey="default_file" SmallImageKey="" /> <!-- Is an extension too like in &lt;Extensions&gt; -->
  <DefaultFolder Extension="" LargeImageKey="default_folder" SmallImageKey="" />
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

## Example

<img src="https://i.imgur.com/2lZ9E1f.png" alt="Discord Rich Example"></img>

## Support

Join in our official guild <a href="https://discord.gg/N8Nuugb">clicking here</a>.
