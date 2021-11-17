namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Selector
{
    using Tools.Player;
    using UnityEngine;
    using xAstroBoy;

    internal class Tweaker_Object
    {
        internal static GameObject SetObjectToEditWithPath(string objpath)
        {
            var obj = GameObjectFinder.Find(objpath);
            if (obj != null)
            {
                ModConsole.Log("Path is valid, Found Gameobject obj : " + obj.name + "Using path " + objpath);
                Tweaker_Selector.SelectedObject = obj;
                return obj;
            }
            else
            {
                return null;
            }
        }

        internal static void SetObjectToEdit(GameObject obj)
        {
            if (LockItem)
            {
                return;
            }
            Tweaker_Selector.SelectedObject = obj;
        }

        internal static GameObject GetGameObjectToEdit()
        {
            try
            {
                if (!LockItem)
                {
                    var item = PlayerHands.GetHoldTransform();
                    if (item != null)
                    {
                        Tweaker_Selector.SelectedObject = item;
                    }
                    return Tweaker_Selector.SelectedObject;
                }
                else
                {
                    return Tweaker_Selector.SelectedObject;
                }
            }
            catch
            {
                return Tweaker_Selector.SelectedObject;
            }
        }

        private static bool _LockItem;

        internal static bool LockItem
        {
            get
            {
                return _LockItem;
            }
            set
            {
                if (Tweaker_Selector.SelectedObject == null)
                {
                    value = false;
                }
                _LockItem = value;
                if (TweakerV2Main.LockHoldItem != null)
                {
                    TweakerV2Main.LockHoldItem.SetToggleState(value);
                }
            }
        }

        internal static GameObject CurrentObjectToEdit
        {
            get
            {
                return Tweaker_Selector.SelectedObject;
            }
        }

        internal static string GetObjectToEditName
        {
            get
            {
                return Tweaker_Selector.SelectedObject.name;
            }
        }
    }
}