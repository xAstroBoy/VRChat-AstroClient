namespace AstroClient.Tools.Player
{
    using UnityEngine;
    using xAstroBoy.Utility;

    internal class PlayerCloner
    {
        // CREDITS : Unreal (Day's one is broken and refused to stay in place)



        internal static GameObject CloneLocalPlayerAvatar()
        {
            if (PlayerUtils.GetVRCPlayer() != null)
            {
                var original = PlayerUtils.GetPlayer().GetAvatarObject();
                if (original != null)
                {
                    var Capsule = UnityEngine.Object.Instantiate(original, null, true);
                    Animator animator = Capsule.GetComponent<Animator>();
                    if (animator != null && animator.isHuman)
                    {
                        Transform boneTransform = animator.GetBoneTransform(HumanBodyBones.Head);
                        if (boneTransform != null)
                        {
                            boneTransform.localScale = Vector3.one;
                        }
                    }
                    Capsule.name = "Serialize Capsule";
                    UnhollowerBaseLib.Il2CppArrayBase<Component> list = Capsule.GetComponents<Component>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        Component comp = list[i];
                        if (!(comp is Transform) || !(comp is Renderer) || !(comp is MeshRenderer) || !(comp is Rigidbody))
                        {
                            UnityEngine.Object.Destroy(comp);
                        }
                    }
                    Capsule.transform.position = original.transform.position;
                    Capsule.transform.rotation = original.transform.rotation;
                    return Capsule;
                }
            }
            else
            {
                ModConsole.Error("Unable to Instantiate a Avatar Capsule due to VRCPlayer being null.");
            }
            return null;
        }
    }
}