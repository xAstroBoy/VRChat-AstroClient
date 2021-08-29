using MelonLoader;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle(AstroInjector.BuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(AstroInjector.BuildInfo.Company)]
[assembly: AssemblyProduct(AstroInjector.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + AstroInjector.BuildInfo.Author)]
[assembly: AssemblyTrademark(AstroInjector.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(AstroInjector.BuildInfo.Version)]
[assembly: AssemblyFileVersion(AstroInjector.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonInfo(typeof(AstroInjector.AstroInjector), AstroInjector.BuildInfo.Name, AstroInjector.BuildInfo.Version, AstroInjector.BuildInfo.Author, AstroInjector.BuildInfo.DownloadLink)]
[assembly: InternalsVisibleTo("UnityExplorer.ML.IL2CPP")]
// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]