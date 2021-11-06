﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MelonLoader;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle(AstroClient.BuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(AstroClient.BuildInfo.Company)]
[assembly: AssemblyProduct(AstroClient.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + AstroClient.BuildInfo.Author)]
[assembly: AssemblyTrademark(AstroClient.BuildInfo.Company)]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]
[assembly: MelonInfo(typeof(AstroClient.Main), AstroClient.BuildInfo.Name, AstroClient.BuildInfo.Version, AstroClient.BuildInfo.Author, AstroClient.BuildInfo.DownloadLink)]
[assembly: InternalsVisibleTo("UnityExplorer.ML.IL2CPP")]
[assembly: InternalsVisibleTo(AstroClient.BuildInfo.Name)]
[assembly: MelonGame(null, null)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("6506F83F-9665-4EC9-9D7F-6F88E1652BBA")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]