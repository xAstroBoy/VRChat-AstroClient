namespace AstroClient
{
    using AstroLibrary.Console;
    using System.Threading;

    public class AssemblySpy : GameEvents
    {
        public static void Scan(string query)
        {
            ModConsole.Log("Scanning Assemblies...");

            var assemblies = Thread.GetDomain().GetAssemblies();

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type != null && type.Name.Contains(query))
                    {
                        ModConsole.Log($"Found: {type.FullName}");
                        foreach (var method in type.GetMethods())
                        {
                            ModConsole.Log($"{method.Name}");
                        }
                    }
                }
            }
        }
    }
}