using AstroClient.ClientActions;

namespace AstroClient.Tools.ObjectEditor.Editor.Scale
{
    using System.Linq;
    using AstroMonos.Components.Custom.Random;
    using Extensions;
    using UnityEngine;
    using VRC.Udon;
    using static ClientUI.Menu.ItemTweakerV2.Submenus.Scale.ScaleSubmenu;
    using static Constants.CustomLists;

    internal class ScaleEditor : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
        }

        private static float ModifiedVectorX() => EditVectorX ? ScaleValueToUse : 0;

        private static float ModifiedVectorY() => EditVectorY ? ScaleValueToUse : 0;

        private static float ModifiedVectorZ() => EditVectorZ ? ScaleValueToUse : 0;

        internal static void EditScaleSize(GameObject obj, bool increase)
        {
            if (obj != null)
            {
                if (!HasOriginalScaleStored(obj))
                {
                    StoreOriginalScale(obj, obj.transform.localScale);
                }
                var inflater = obj.GetComponent<InflaterBehaviour>();
                if (!InflaterScaleMode)
                {
                    if (increase)
                    {
                        obj.transform.localScale = obj.transform.localScale + new Vector3(ModifiedVectorX(), ModifiedVectorY(), ModifiedVectorZ());
                        if (inflater != null)
                        {
                            if (inflater.enabled)
                            {
                                inflater.enabled = false;
                            }
                            inflater.NewSize = obj.transform.localScale;
                        }
                        EditUdon(obj, obj.transform.localScale);
                    }
                    else
                    {
                        obj.transform.localScale = obj.transform.localScale - new Vector3(ModifiedVectorX(), ModifiedVectorY(), ModifiedVectorZ());
                        if (inflater != null)
                        {
                            if (inflater.enabled)
                            {
                                inflater.enabled = false;
                            }
                            inflater.NewSize = obj.transform.localScale;
                        }
                        EditUdon(obj, obj.transform.localScale);
                    }
                }
                else
                {
                    if (inflater!= null)
                    {
                        if (!inflater.enabled)
                        {
                            inflater.enabled = true;
                        }
                        if (increase)
                        {
                            inflater.NewSize = inflater.NewSize + new Vector3(ModifiedVectorX(), ModifiedVectorY(), ModifiedVectorZ());
                            EditUdon(obj, obj.transform.localScale);
                        }
                        else
                        {
                            inflater.NewSize = inflater.NewSize - new Vector3(ModifiedVectorX(), ModifiedVectorY(), ModifiedVectorZ());
                            EditUdon(obj, obj.transform.localScale);
                        }
                    }
                    else
                    {
                        inflater = obj.AddComponent<InflaterBehaviour>();
                        if (inflater != null)
                        {
                            if (!inflater.enabled)
                            {
                                inflater.enabled = true;
                            }
                            if (increase)
                            {
                                inflater.NewSize = inflater.NewSize + new Vector3(ModifiedVectorX(), ModifiedVectorY(), ModifiedVectorZ());
                                EditUdon(obj, obj.transform.localScale);
                            }
                            else
                            {
                                inflater.NewSize = inflater.NewSize - new Vector3(ModifiedVectorX(), ModifiedVectorY(), ModifiedVectorZ());
                                EditUdon(obj, obj.transform.localScale);
                            }
                        }
                    }
                }

                if(inflater != null)
                {
                    inflater.FocusOnTweaker();
                }
            }
        }

        internal static bool HasOriginalScaleStored(GameObject obj)
        {
            return ScaleCheck.Where(x => x.TargetObj == obj).Select(x => x.HasBeenStored).DefaultIfEmpty(false).First();
        }

        internal static Vector3 GetOriginalScale(GameObject obj)
        {
            return ScaleCheck.Where(x => x.TargetObj == obj).Select(x => x.OriginalScale).DefaultIfEmpty(new Vector3(0, 0, 0)).First();
        }

        internal static void StoreOriginalScale(GameObject obj, Vector3 OriginalScale)
        {
            if (obj != null)
            {
                var item = new GameObjScales(obj, OriginalScale, true);
                if (!ScaleCheck.Contains(item))
                {
                    ScaleCheck.Add(item);
                }
            }
        }

        private void OnRoomLeft()
        {
            ScaleCheck.Clear();
        }

        internal static void EditUdon(GameObject obj, Vector3 scale)
        {
            //TODO: FIND A SOLUTION IN UDON WORLD ITEM EDITS WITHOUT DESTROYING COMPONENT
            // DESTROYING COMPONENT CAUSES OBJECT LOSE SCRIPT AND INTERACTIVITY WITH OTHER WORLD COMPONENTS
            var udon = obj.GetComponent<UdonBehaviour>();
            if (udon != null)
            {
                // ATTEMPT TO MAKE THE UDONSYNC COMPONENT TO EDIT SCALE
                udon.gameObject.transform.localScale = scale;
                udon.enabled = true;
            }
        }

        internal static void RestoreOriginalScale(GameObject obj)
        {
            if (HasOriginalScaleStored(obj))
            {
                obj.transform.localScale = GetOriginalScale(obj);
                var inflater = obj.GetComponent<InflaterBehaviour>();
                if (inflater != null)
                {
                    inflater.enabled = false;
                    if (!inflater.enabled)
                    {
                        inflater.NewSize = GetOriginalScale(obj);
                        inflater.enabled = true;
                    }
                }
            }
            else
            {
                Log.Write($"I Dont have the original Scale stored for Object {obj.gameObject.name}");
            }
        }
    }
}