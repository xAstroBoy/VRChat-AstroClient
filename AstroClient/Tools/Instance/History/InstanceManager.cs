namespace AstroClient.Tools.Instance.History
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using AstroClient;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using VRC.Core;
    using ConfigManager = Config.ConfigManager;

    internal class InstanceManager : AstroEvents
    {
        internal static List<WorldInstance> instances = new List<WorldInstance>();

        internal override void OnApplicationStart()
        {
            Log.Debug("Loading Instances...");

            if (!File.Exists(ConfigManager.AstroInstances))
            {
                File.Create(ConfigManager.AstroInstances);
                Log.Debug("AstroInstances.json not found. Creating new one...");
            }
            else
            {
                string text = File.ReadAllText(ConfigManager.AstroInstances);
                if (string.IsNullOrWhiteSpace(text))
                {
                    return;
                }

                try
                {
                    JArray array = JArray.Parse(text);
                    foreach (JToken token in array)
                        instances.Add(JObject.Parse(token.ToString()).ToObject<WorldInstance>());
                }
                catch (Exception ex)
                {
                    Log.Error($"Something went wrong while parsing the json file.\nIt is likely that your AstroInstances.json file is corrupted and will need to be manually deleted. Find it in the {ConfigManager.AstroInstances} folder.\nFor debug purposes in case this is not the case, here is the error:");
                    Log.Exception(ex);
                    return;
                }
            }

            Log.Debug($"{instances.Count} Instances Loaded!");
        }

        internal override void OnEnterWorld(ApiWorld world, ApiWorldInstance instance)
        {
            if (world == null) return;
            if (instance == null) return;

            var item = new WorldInstance(world.name, world.id, instance.instanceId);
            instances.Insert(0, item);

            var JsonConverted = JsonConvert.SerializeObject(instances, Formatting.Indented);
            File.WriteAllText(ConfigManager.AstroInstances, JsonConverted);
        }

        internal struct WorldInstance
        {
            [JsonProperty]
            internal string worldName;
            [JsonProperty]
            internal string worldId;
            [JsonProperty]
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
