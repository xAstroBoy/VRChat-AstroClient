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
        internal static Action<GameObject> On_New_GameObject_Selected { get; set; }

        internal static Action<GameObject> On_Old_GameObject_Removed { get; set; }

        internal static Action<RocketBehaviour> OnRocketBehaviourPropertyChanged { get; set; }

        internal static Action<CrazyBehaviour> OnCrazyBehaviourPropertyChanged { get; set; }

        internal static Action<InflaterBehaviour> OnInflaterBehaviourPropertyChanged { get; set; }
        internal static Action<InflaterBehaviour> OnInflaterBehaviourUpdate { get; set; }

        internal static Action<PickupController> OnPickupControllerSelected { get; set; }
        internal static Action<PickupController> OnPickupControllerPropertyChanged { get; set; }
        internal static Action<PickupController> OnPickupController_OnUpdate { get; set; }


        internal static Action<SpinnerBehaviour> OnSpinnerBehaviourPropertyChanged { get; set; }



        internal static Action OnSelectedObject_Enabled { get; set; }
        internal static Action OnSelectedObject_Disabled { get; set; }
        internal static Action OnSelectedObject_Destroyed { get; set; }

        internal static Action<RigidBodyController> OnRigidBodyControllerSelected { get; set; }
        internal static Action<RigidBodyController> OnRigidBodyControllerPropertyChanged { get; set; }
        internal static Action<RigidBodyController> OnRigidBodyController_OnUpdate { get; set; }
    }
}