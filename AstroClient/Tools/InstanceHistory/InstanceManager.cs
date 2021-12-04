namespace AstroClient.Tools.InstanceHistory
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using AstroClient;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using VRC.Core;
    using xAstroBoy.Utility;
    using ConfigManager = Config.ConfigManager;

    internal class InstanceManager : AstroEvents
    {
        public static List<WorldInstance> instances = new List<WorldInstance>();
        private static string instanceDatabasePath { get; } = ConfigManager.AstroInstances;


        internal override void OnApplicationStart()
        {
            ModConsole.DebugLog("Loading Instances...");

            if (!File.Exists(instanceDatabasePath))
            {
                File.WriteAllText(instanceDatabasePath, "[]");
                ModConsole.DebugLog("AstroInstances.json not found. Creating new one...");
            }
            else
            {
                string text = File.ReadAllText(instanceDatabasePath);
                if (string.IsNullOrWhiteSpace(text))
                {
                    File.WriteAllText(instanceDatabasePath, "[]");
                    text = "[]";
                    ModConsole.DebugLog("AstroInstances.json is empty. Creating new one...");
                }

                try
                {
                    JArray array = JArray.Parse(text);
                    foreach (JToken token in array)
                        instances.Add(JObject.Parse(token.ToString()).ToObject<WorldInstance>());
                }
                catch (Exception ex)
                {
                    ModConsole.Error($"Something went wrong while parsing the json file.\nIt is likely that your AstroInstances.json file is corrupted and will need to be manually deleted. Find it in the {instanceDatabasePath} folder.\nFor debug purposes in case this is not the case, here is the error:");
                    ModConsole.ErrorExc(ex);
                    return;
                }
            }

            ModConsole.DebugLog("Instances Loaded!");
        }

        internal override void OnEnterWorld(ApiWorld world, ApiWorldInstance instance)
        {
            instances.Insert(0, new WorldInstance(world.name, world.id, instance.instanceId));
            File.WriteAllText(instanceDatabasePath, JsonConvert.SerializeObject(instances, Formatting.Indented));

        }

        public struct WorldInstance
        {
            internal string worldName;
            internal string worldId;
            internal string instanceId;

            internal WorldInstance(string worldName, string worldId, string instanceId)
            {
                this.worldName = worldName;
                this.worldId = worldId;
                this.instanceId = instanceId;
            }
        }
    }
}
