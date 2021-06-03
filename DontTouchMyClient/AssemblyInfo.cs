using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(DontTouchMyClient.BuildInfo.Description)]
[assembly: AssemblyDescription(DontTouchMyClient.BuildInfo.Description)]
[assembly: AssemblyCompany(DontTouchMyClient.BuildInfo.Company)]
[assembly: AssemblyProduct(DontTouchMyClient.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + DontTouchMyClient.BuildInfo.Author)]
[assembly: AssemblyTrademark(DontTouchMyClient.BuildInfo.Company)]
[assembly: AssemblyVersion(DontTouchMyClient.BuildInfo.Version)]
[assembly: AssemblyFileVersion(DontTouchMyClient.BuildInfo.Version)]
[assembly: MelonInfo(typeof(DontTouchMyClient.DontTouchMyClient), DontTouchMyClient.BuildInfo.Name, DontTouchMyClient.BuildInfo.Version, DontTouchMyClient.BuildInfo.Author, DontTouchMyClient.BuildInfo.DownloadLink)]


// Create and Setup a MelonPluginGame to mark a Plugin as Universal or Compatible with specific Games.
// If no MelonPluginGameAttribute is found or any of the Values for any MelonPluginGame on the Mod is null or empty it will be assumed the Plugin is Universal.
// Values for MelonPluginGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]