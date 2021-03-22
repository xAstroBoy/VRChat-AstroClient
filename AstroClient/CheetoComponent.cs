namespace AstroClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CheetoComponent
    {
        public CheetoComponent()
        {
            Main.Start += OnStart;
            Main.Update += OnUpdate;
        }

        private void OnStart(object sender, EventArgs e)
        {
            Start();
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            Update();
        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }
    }
}
