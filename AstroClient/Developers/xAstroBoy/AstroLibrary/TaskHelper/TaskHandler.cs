namespace AstroClient.xAstroBoy.TaskHelper
{
    internal class TaskHandler : AstroEvents
    {

        internal override void OnUpdate()
        {
            TaskUtilities.ourMainThreadQueue?.Flush();
        }

        internal override void OnGUI()
        {
            TaskUtilities.ourFrameEndQueue.Flush();
        }

    }
}
