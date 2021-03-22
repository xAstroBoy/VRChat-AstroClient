namespace AstroClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Instrumentation;
    using System.Text;
    using System.Threading.Tasks;

    public class CheetoComponent
    {
        public static CheetoComponent Instance;

        public CheetoComponent()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            Main.Start += OnStart;
            Main.Update += OnUpdate;
            Main.LateUpdate += OnLateUpdate;
        }

        private void OnStart(object sender, EventArgs e)
        {
            Start();
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            Update();
        }

        private void OnLateUpdate(object sender, EventArgs e)
        {
            LateUpdate();
        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void LateUpdate()
        {

        }
    }

    public class CheetoEvents : CheetoComponent
    {
        public CheetoEvents() : base()
        {

        }

        private void OnLevelLoad(object sender, EventArgs e)
        {
            LevelLoaded(e);
        }

        private void OnPlayerLeft(object sender, PlayerEventArgs e)
        {
            PlayerLeft(e);
        }

        private void OnPlayerJoined(object sender, PlayerEventArgs e)
        {
            PlayerJoined(e);
        }

        public virtual void PlayerLeft(PlayerEventArgs e)
        {

        }

        public virtual void PlayerJoined(PlayerEventArgs e)
        {

        }

        public virtual void LevelLoaded(EventArgs e)
        {

        }
    }

    public class CheetoHooks : CheetoComponent
    {
        public CheetoHooks() : base()
        {

        }
    }
}
