using AstroClient.AstroMonos.Components.Custom.Random;
using AstroClient.AstroMonos.Components.Tools;

namespace AstroClient.ClientActions
{
    using System;
    using UnityEngine;

    // Put all actions here .

    // There goes all Hooks and other "global" actions.

    internal static class TweakerEventActions
    {
        internal static Action<GameObject> Event_On_New_GameObject_Selected { get; set; }

        internal static Action<GameObject> Event_On_Old_GameObject_Removed { get; set; }

        internal static Action<RocketBehaviour> Event_OnRocketBehaviourPropertyChanged { get; set; }

        internal static Action<CrazyBehaviour> Event_OnCrazyBehaviourPropertyChanged { get; set; }

        internal static Action<InflaterBehaviour> Event_OnInflaterBehaviourPropertyChanged { get; set; }
        internal static Action<InflaterBehaviour> Event_OnInflaterBehaviourUpdate { get; set; }

        internal static Action<PickupController> Event_OnPickupControllerSelected { get; set; }
        internal static Action<PickupController> Event_OnPickupControllerPropertyChanged { get; set; }
        internal static Action<PickupController> Event_OnPickupController_OnUpdate { get; set; }


        internal static Action<SpinnerBehaviour> Event_OnSpinnerBehaviourPropertyChanged { get; set; }



        internal static Action Event_OnSelectedObject_Enabled { get; set; }
        internal static Action Event_OnSelectedObject_Disabled { get; set; }
        internal static Action Event_OnSelectedObject_Destroyed { get; set; }

        internal static Action<RigidBodyController> Event_OnRigidBodyControllerSelected { get; set; }
        internal static Action<RigidBodyController> Event_OnRigidBodyControllerPropertyChanged { get; set; }
        internal static Action<RigidBodyController> Event_OnRigidBodyController_OnUpdate { get; set; }
    }
}