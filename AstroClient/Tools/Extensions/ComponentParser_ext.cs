﻿using AstroClient.Tools.UdonEditor;

namespace AstroClient.Tools.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using VRC.SDK3.Components;
    using VRC.SDKBase;
    using VRC.Udon;

    internal static class ComponentParser_ext
    {
        internal static List<GameObject> Get_VRCInteractables(this GameObject obj)
        {
            if (obj != null)
            {
                try
                {
                    var list1 = obj.GetComponentsInChildren<VRC_Interactable>(true).Select(i => i.gameObject).Where(x => x != null).ToList();
                    if (list1.Count() != 0 && list1 != null)
                    {
                        return list1;
                    }

                    var list2 = obj.GetComponentsInChildren<VRCSDK2.VRC_Interactable>(true).Select(i => i.gameObject).Where(x => x != null).ToList();
                    if (list2.Count() != 0 && list2 != null)
                    {
                        return list2;
                    }

                    var list3 = obj.GetComponentsInChildren<VRCInteractable>(true).Select(i => i.gameObject).Where(x => x != null).ToList();
                    if (list3.Count() != 0 && list3 != null)
                    {
                        return list3;
                    }
                }
                catch (Exception e)
                {
                    Log.Error("Error parsing Pickup VRC Interactables");
                    Log.Exception(e);
                    return new List<GameObject>();
                }
            }

            return new List<GameObject>();
        }

        internal static List<GameObject> Get_Triggers(this GameObject obj)
        {
            if (obj != null)
            {
                try
                {
                    var list1 = obj.GetComponentsInChildren<VRC_Trigger>(true).Select(i => i.gameObject).Where(x => x != null).ToList();
                    if (list1.Count() != 0 && list1 != null)
                    {
                        return list1;
                    }

                    var list2 = obj.GetComponentsInChildren<VRCSDK2.VRC_Trigger>(true).Select(i => i.gameObject).Where(x => x != null).ToList();
                    if (list2.Count() != 0 && list2 != null)
                    {
                        return list2;
                    }
                }
                catch (Exception e)
                {
                    Log.Error("Error parsing World Triggers");
                    Log.Exception(e);
                    return new List<GameObject>();
                }
            }

            return new List<GameObject>();
        }

        internal static List<UdonBehaviour> Get_UdonBehaviours(this GameObject obj)
        {
            var UdonBehaviourObjects = new List<UdonBehaviour>();
            var list = obj.GetComponentsInChildren<UdonBehaviour>(true);
            if (list.Count() != 0)
            {

                foreach (var item in list)
                {
                    var keys = item.Get_EventKeys();
                    if (keys == null) continue;

                    UdonBehaviourObjects.Add(item);
                }

                return UdonBehaviourObjects;
            }

            return UdonBehaviourObjects;
        }


        internal static void Set_UdonBehaviour_DisableInteractive(this GameObject obj, bool DisableInteractive)
        {
            var list = obj.GetComponentsInChildren<UdonBehaviour>(true);
            if (list.Count() != 0)
            {
                foreach (var item in list)
                {
                    item.DisableInteractive = DisableInteractive;
                }
            }
        }

        internal static void Set_UdonBehaviour_DisableInteractive(this Transform obj, bool DisableInteractive)
        {
            obj.gameObject.Set_UdonBehaviour_DisableInteractive(DisableInteractive);
        }

        
        internal static List<UdonBehaviour> Get_UdonBehaviours(this Transform obj)
        {
            return obj.gameObject.Get_UdonBehaviours();
        }

        internal static List<GameObject> Get_Triggers(this Transform obj)
        {
            return obj.gameObject.Get_Triggers();
        }

        internal static List<GameObject> Get_VRCInteractables(this Transform obj)
        {
            return obj.gameObject.Get_VRCInteractables();
        }
    }
}