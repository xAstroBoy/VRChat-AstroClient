namespace AstroClient.Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class TaskHandler : GameEvents
    {

        internal override void OnUpdate()
        {
            TaskUtilities.ourMainThreadQueue.Flush();
        }

        internal override void OnGUI()
        {
            TaskUtilities.ourFrameEndQueue.Flush();
        }

    }
}
