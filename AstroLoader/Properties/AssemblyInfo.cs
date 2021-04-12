using MelonLoader;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle(AstroLoader.BuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(AstroLoader.BuildInfo.Company)]
[assembly: AssemblyProduct(AstroLoader.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + AstroLoader.BuildInfo.Author)]
[assembly: AssemblyTrademark(AstroLoader.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(AstroLoader.BuildInfo.Version)]
[assembly: AssemblyFileVersion(AstroLoader.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonInfo(typeof(AstroLoader.AstroLoader), AstroLoader.BuildInfo.Name, AstroLoader.BuildInfo.Version, AstroLoader.BuildInfo.Author, AstroLoader.BuildInfo.DownloadLink)]
[assembly: InternalsVisibleTo("UnityExplorer.ML.IL2CPP")]
// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]