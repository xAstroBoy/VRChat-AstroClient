namespace AstroLibrary.Extensions
{
    #region Imports

    using UnityEngine;
    using VRC.SDKBase;

    #endregion Imports

    internal static  class VRC_UiShape_ext
    {
        internal static void AddUiShapeWithTriggerCollider(this GameObject obj)
        {
            obj.AddComponent<VRC_UiShape>().Awake(); // Awake is not called on disabled object, so call it manually; calling it twice doesn't cause issues
            obj.GetComponent<BoxCollider>().isTrigger = true;
        }
    }
}