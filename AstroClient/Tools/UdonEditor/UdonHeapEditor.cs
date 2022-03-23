namespace AstroClient.Tools.UdonEditor
{
    using System;
    using Extensions;
    using VRC.Udon.Common.Interfaces;


    [Obsolete("Switch to AstroUdonVariable System Or enchance RawUdonBehaviour as well to support it!")]
    internal static class UdonHeapEditor
    {
        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, bool value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, float value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, string value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.Error("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, string[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, uint value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, int value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, long value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, char value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, char[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, byte value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, byte[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }
        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Color value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Material value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.MeshRenderer value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.MeshRenderer[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Component value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Component[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.BoxCollider value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.BoxCollider[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Sprite value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Sprite[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }
        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Rigidbody value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Rigidbody[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.ParticleSystem value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Transform value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.GameObject value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.GameObject[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Vector3 value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Quaternion value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.AudioSource value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.AudioClip[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.UI.Text value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.HumanBodyBones value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.SDKBase.VRCPlayerApi value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.SDKBase.VRCPlayerApi[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.Udon.UdonBehaviour value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.Udon.Common.Interfaces.NetworkEventTarget value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, TMPro.TextMeshPro value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, TMPro.TextMeshProUGUI value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }
        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.CapsuleCollider value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.CapsuleCollider[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.SphereCollider value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.SphereCollider[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.MeshCollider value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.MeshCollider[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Collider value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Collider[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Bounds value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Bounds[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Animator value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Animator[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.LayerMask value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.LayerMask[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.LineRenderer value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.LineRenderer[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.RaycastHit value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.RaycastHit[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.RectTransform value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.RectTransform[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Camera value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Camera[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.KeyCode value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.KeyCode[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Rect value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Rect[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Texture2D value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Texture2D[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.AI.NavMeshAgent value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.AI.NavMeshAgent[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.AI.NavMeshHit value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.AI.NavMeshHit[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.UI.Toggle value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.UI.Toggle[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }
        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.UI.Image value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.UI.Image[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.UI.Button value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.UI.Button[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.UI.RawImage value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.UI.RawImage[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }
        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.SDK3.Components.VRCAvatarPedestal value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.SDK3.Components.VRCAvatarPedestal[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.SDK3.Components.VRCPickup value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.SDK3.Components.VRCPickup[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, double value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, double[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, System.TimeSpan value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, System.TimeSpan[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Mesh value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Mesh[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Texture value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Texture[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.ReflectionProbe value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.ReflectionProbe[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.RenderTexture value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.RenderTexture[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.TextAsset value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.TextAsset[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.UI.Slider value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.UI.Slider[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }
        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.UI.ScrollRect value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.UI.ScrollRect[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.UI.InputField value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.UI.InputField[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.Udon.Common.SerializationResult value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.Udon.Common.SerializationResult[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.SDKBase.VRCUrl value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.SDKBase.VRCUrl[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.SDK3.Components.Video.VideoError value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.SDK3.Components.Video.VideoError[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.SDK3.Components.VRCUrlInputField value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.SDK3.Components.VRCUrlInputField[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.SDK3.Video.Components.VRCUnityVideoPlayer value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.SDK3.Video.Components.VRCUnityVideoPlayer[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }
        internal static void PatchHeap(IUdonHeap heap, uint address, VRC.SDK3.Video.Components.VRCUnityVideoPlayer value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_VRC_SDK3_Video_Components_VRCUnityVideoPlayer();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, VRC.SDK3.Video.Components.VRCUnityVideoPlayer[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_VRC_SDK3_Video_Components_VRCUnityVideoPlayer();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, VRC.SDK3.Components.VRCUrlInputField value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_VRC_SDK3_Components_VRCUrlInputField();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, VRC.SDK3.Components.VRCUrlInputField[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_VRC_SDK3_Components_VRCUrlInputField();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, VRC.SDK3.Components.Video.VideoError value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_VRC_SDK3_Components_Video_VideoError();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, VRC.SDK3.Components.Video.VideoError[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_VRC_SDK3_Components_Video_VideoError();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, VRC.SDKBase.VRCUrl value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_VRC_SDKBase_VRCUrl();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, VRC.SDKBase.VRCUrl[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_VRC_SDKBase_VRCUrl();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, VRC.Udon.Common.SerializationResult value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_VRC_Udon_Common_SerializationResult();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, VRC.Udon.Common.SerializationResult[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_VRC_Udon_Common_SerializationResult();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.UI.InputField value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_UnityEngine_UI_InputField();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.UI.InputField[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_UnityEngine_UI_InputField();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.UI.ScrollRect value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_UnityEngine_UI_ScrollRect();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.UI.ScrollRect[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_UnityEngine_UI_ScrollRect();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }
        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.UI.Slider value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_UnityEngine_UI_Slider();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.UI.Slider[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_UnityEngine_UI_Slider();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.TextAsset value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_TextAsset();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.TextAsset[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_TextAsset();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.RenderTexture value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_RenderTexture();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.RenderTexture[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_RenderTexture();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.ReflectionProbe value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_ReflectionProbe();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.ReflectionProbe[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_ReflectionProbe();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Texture value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Texture();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Texture[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_Texture();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Mesh value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Mesh();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Mesh[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_Mesh();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, System.TimeSpan value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_TimeSpan();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, System.TimeSpan[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_TimeSpan();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }
        internal static void PatchHeap(IUdonHeap heap, uint address, double value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Double();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, double[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_Double();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, VRC.SDK3.Components.VRCPickup value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_VRC_SDK3_Components_VRCPickup();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, VRC.SDK3.Components.VRCPickup[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_VRC_SDK3_Components_VRCPickup();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, VRC.SDK3.Components.VRCAvatarPedestal value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_VRC_SDK3_Components_VRCAvatarPedestal();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, VRC.SDK3.Components.VRCAvatarPedestal[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_VRC_SDK3_Components_VRCAvatarPedestal();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, ushort value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, ushort[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, ushort value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_UInt16();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, ushort[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_UInt16();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }
        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.UI.Button value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_UnityEngine_UI_Button();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.UI.Button[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_UnityEngine_UI_Button();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.UI.RawImage value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_UnityEngine_UI_RawImage();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.UI.RawImage[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_UnityEngine_UI_RawImage();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.UI.Image value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_UnityEngine_UI_Image();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.UI.Image[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_UnityEngine_UI_Image();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.UI.Toggle value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_UnityEngine_UI_Toggle();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.UI.Toggle[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_UnityEngine_UI_Toggle();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.AI.NavMeshHit value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_UnityEngine_AI_NavMeshHit();
                    if (result.Value.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.AI.NavMeshHit[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_UnityEngine_AI_NavMeshHit();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.AI.NavMeshAgent value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_UnityEngine_AI_NavMeshAgent();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.AI.NavMeshAgent[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_UnityEngine_AI_NavMeshAgent();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Texture2D value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Texture2D();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Texture2D[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_Texture2D();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Rect value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Rect();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Rect[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_Rect();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.KeyCode value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_KeyCode();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.KeyCode[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_KeyCode();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Camera value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Camera();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Camera[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_Camera();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.RectTransform value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_RectTransform();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.RectTransform[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_RectTransform();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.RaycastHit value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_RaycastHit();
                    if (result.Value.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.RaycastHit[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_RaycastHit();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.LineRenderer value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_LineRenderer();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.LineRenderer[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_LineRenderer();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.LayerMask value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_LayerMask();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.LayerMask[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_LayerMask();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Animator value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Animator();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Animator[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_Animator();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Bounds value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Bounds();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Bounds[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_Bounds();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.MeshCollider value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_MeshCollider();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.MeshCollider[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_MeshCollider();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.SphereCollider value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_SphereCollider();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.SphereCollider[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_SphereCollider();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.CapsuleCollider value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_CapsuleCollider();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.CapsuleCollider[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_CapsuleCollider();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, TMPro.TextMeshProUGUI value, bool verify = false)
        {
            if (heap != null && address != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_TextMeshProUGUI();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, bool value, bool verify = false)
        {
            if (heap != null && address != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Boolean();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, float value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Single();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, string value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_String();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.Error($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.Error("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, string[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_String();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, uint value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_UInt32();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, int value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Int32();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }
        internal static void PatchHeap(IUdonHeap heap, uint address, byte value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Byte();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, byte[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_Byte();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, long value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Int64();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, char value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Char();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, char[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_Char();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Color value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Color();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Material value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Material();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.MeshRenderer value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_MeshRenderer();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.MeshRenderer[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_MeshRenderer();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Component value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Component();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Component[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_Component();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }
        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.BoxCollider value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_BoxCollider();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.BoxCollider[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_BoxCollider();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Collider value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Collider();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Collider[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_Collider();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.ParticleSystem value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_ParticleSystem();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Transform value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Transform();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.GameObject value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_GameObject();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.GameObject[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_GameObject();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Vector3 value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Vector3();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Quaternion value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Quaternion();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.AudioSource value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_AudioSource();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.AudioClip[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_AudioClip();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.UI.Text value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_UnityEngine_UI_Text();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.HumanBodyBones value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_HumanBodyBones();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, VRC.SDKBase.VRCPlayerApi value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_VRCPlayerApi();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, VRC.SDKBase.VRCPlayerApi[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_VRCPlayerApi();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, VRC.Udon.UdonBehaviour value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_UdonBehaviour();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, VRC.Udon.Common.Interfaces.NetworkEventTarget value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_NetworkEventTarget();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, TMPro.TextMeshPro value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_TextMeshPro();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Sprite value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Sprite();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Sprite[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_Sprite();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Rigidbody value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Rigidbody();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        internal static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Rigidbody[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = Il2CppConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_Rigidbody();
                    if (result.Equals(value))
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

    }
}