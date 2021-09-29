namespace AstroLibrary.Extensions
{
    using AstroLibrary.Console;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using VRC.SDK3.Components;
    using VRC.SDKBase;
    using VRC.Udon;

    internal static  class ComponentParser_ext
    {
        internal static  List<GameObject> Get_VRCInteractables(this GameObject obj)
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
                    else
                    {
                        var list2 = obj.GetComponentsInChildren<VRCSDK2.VRC_Interactable>(true).Select(i => i.gameObject).Where(x => x != null).ToList();
                        if (list2.Count() != 0 && list2 != null)
                        {
                            return list2;
                        }
                        else
                        {
                            var list3 = obj.GetComponentsInChildren<VRCInteractable>(true).Select(i => i.gameObject).Where(x => x != null).ToList();
                            if (list3.Count() != 0 && list3 != null)
                            {
                                return list3;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    ModConsole.Error("Error parsing Pickup VRC Interactables");
                    ModConsole.ErrorExc(e);
                    return new List<GameObject>();
                }
            }
            return new List<GameObject>();
        }

        internal static  List<GameObject> Get_Triggers(this GameObject obj)
        {
            if (obj != null)
            {
                try
                {
                    var list1 = obj.GetComponentsInChildren<VRC.SDKBase.VRC_Trigger>(true).Select(i => i.gameObject).Where(x => x != null).ToList();
                    if (list1.Count() != 0 && list1 != null)
                    {
                        return list1;
                    }
                    else
                    {
                        var list2 = obj.GetComponentsInChildren<VRCSDK2.VRC_Trigger>(true).Select(i => i.gameObject).Where(x => x != null).ToList();
                        if (list2.Count() != 0 && list2 != null)
                        {
                            return list2;
                        }
                    }
                }
                catch (Exception e)
                {
                    ModConsole.Error("Error parsing World Triggers");
                    ModConsole.ErrorExc(e);
                    return new List<GameObject>();
                }
            }
            return new List<GameObject>();
        }

        internal static  List<UdonBehaviour> Get_UdonBehaviours(this GameObject obj)
        {
            var UdonBehaviourObjects = new List<UdonBehaviour>();
            var list = obj.GetComponentsInChildren<UdonBehaviour>(true);
            if (list.Count() != 0)
            {
                foreach (var item in list)
                {
                    if (item._eventTable.Keys.Count != 0)
                    {
                        if (!UdonBehaviourObjects.Contains(item))
                        {
                            UdonBehaviourObjects.Add(item);
                        }
                    }
                }
                return UdonBehaviourObjects;
            }
            return UdonBehaviourObjects;
        }

        internal static  List<UdonBehaviour> Get_UdonBehaviours(this Transform obj)
        {
            return obj.gameObject.Get_UdonBehaviours();
        }

        internal static  List<GameObject> Get_Triggers(this Transform obj)
        {
            return obj.gameObject.Get_Triggers();
        }

        internal static  List<GameObject> Get_VRCInteractables(this Transform obj)
        {
            return obj.gameObject.Get_VRCInteractables();
        }
    }
}