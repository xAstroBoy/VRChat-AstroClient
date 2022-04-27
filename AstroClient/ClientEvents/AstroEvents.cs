
namespace AstroClient
{


    // Removed all spammy and unneeded events to enchance performance,
    // subscribe on the classes manually and unsubscribe when no longer required to avoid hitting performance
    // All events left are one time only.
    
    internal class AstroEvents
    {

        /// <summary>
        /// This will be invoked For preloading resources.
        /// </summary>
        internal virtual void StartPreloadResources()
        {

        }


        /// <summary>
        /// This will be invoked after PriorityPatches (REGISTER EVENTS HERE)
        /// </summary>
        internal virtual void RegisterToEvents()
        {

        }

        /// <summary>
        /// This is needed to start all the harmony hooks
        /// </summary>
        internal virtual void ExecutePriorityPatches()
        {
        }

    }
}