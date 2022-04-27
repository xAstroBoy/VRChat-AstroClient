namespace AstroClient.AstroMonos.Components.Cheats.PatronUnlocker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal static class PatronEventsLists
    {

        internal static System.Collections.Generic.List<string> GetPatronSkinEventNames {  get; } = new()
        {
            "PatronSkin",
            "Patron",
            "EnablePatronEffects",
        };

        internal static System.Collections.Generic.List<string> GetNonPatronSkinEventNames { get; } = new()
        {
            "NonPatronSkin",
            "NonPatron",
            "DisablePatronEffects",
        };


    }
}
