namespace AstroClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Instrumentation;
    using System.Text;
    using System.Threading.Tasks;


    // thanks TO Cheeto aka Craig on discord, he's been really helpful!
    public class Overridables // TODO: GET A BETTER NAME
    {
        public static Overridables Instance;

        public Overridables()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            Main.Event_OnApplicationStart += Internal_OnApplicationStart;
            Main.Event_OnUpdate += Internal_OnUpdate;
            Main.Event_LateUpdate += Internal_OnLateUpdate;
        }

        private void Internal_OnApplicationStart(object sender, EventArgs e)
        {
            OnApplicationStart();
        }

        private void Internal_OnUpdate(object sender, EventArgs e)
        {
            OnUpdate();
        }

        private void Internal_OnLateUpdate(object sender, EventArgs e)
        {
            OnLateUpdate();
        }

        private void internal_OnLevelLoaded(object sender, EventArgs e)
        {
            OnLevelLoaded(e);
        }


        public virtual void OnApplicationStart()
        {

        }

        public virtual void OnUpdate()
        {

        }

        public virtual void OnLateUpdate()
        {

        }

        public virtual void OnLevelLoaded(EventArgs e)
        {

        }

    }

    public class GameEvents : Overridables
    {
        public GameEvents() : base()
        {

        }

        private void Internal_OnPlayerLeft(object sender, PlayerEventArgs e)
        {
            OnPlayerLeft(e);
        }

        private void Internal_OnPlayerJoined(object sender, PlayerEventArgs e)
        {
            OnPlayerJoined(e);
        }

        private void Internal_OnWorldReveal(object sender, EventArgs e)
        {
            OnWorldReveal(e);
        }


        public virtual void OnPlayerLeft(PlayerEventArgs e)
        {

        }

        public virtual void OnPlayerJoined(PlayerEventArgs e)
        {

        }

        public virtual void OnWorldReveal(EventArgs e)
        {

        }
    }

    public class GameHooks : Overridables
    {
        public GameHooks() : base()
        {

        }
    }

    public class GamePatches : Overridables
    {
        public GamePatches() : base()
        {

        }
    }


}
