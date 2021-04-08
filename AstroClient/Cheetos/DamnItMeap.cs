namespace AstroClient
{
    using AstroClient.ConsoleUtils;
    using System;
    using static AstroClient.variables.InstanceBuilder;
    using Color = System.Drawing.Color;

    class DamnItMeap : GenericOverridables
    {
        public override void SpawnEmojiRPC(VRCPlayer player, int emoji)
        {
            ModConsole.CheetoLog($"Emoji Spawned: {player.name} - {emoji}");
        }

        public DamnItMeap(IntPtr obj0) : base(obj0)
        {
        }

        private static DamnItMeap Instance;

        public void Start()
        {
            Instance = this;
        }

        public static void MakeInstance()
        {
            if (Instance == null)
            {
                string name = "DamnItMeap";
                var gameobj = GetInstanceHolder(name);
                Instance = gameobj.AddComponent<DamnItMeap>();
                UnityEngine.Object.DontDestroyOnLoad(gameobj);
                if (Instance != null)
                {
                    ModConsole.Log("[ " + name.ToUpper() + " STATUS ] : READY", Color.LawnGreen);
                }
                else
                {
                    ModConsole.Log("[ " + name.ToUpper() + " STATUS ] : ERROR", Color.OrangeRed);
                }
            }
        }

    }
}