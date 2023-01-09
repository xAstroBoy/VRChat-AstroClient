using Il2CppSystem.Runtime.CompilerServices;
using System;
using VRC.Udon.Common.Exceptions;

namespace VRC.Udon.Common
{
    internal static class Original_UdonHeapTools
    {
        internal static T GetHeapVariableInternal<T>(this UdonHeap instance, uint address)
        {
            var strongBox = instance._heap[(int)address];
            if (strongBox == null)
            {
                throw new NullReferenceException("Tried to access heap address that doesn't exist!");
            }
            var strongBox2 = strongBox as StrongBox<T>;
            if (strongBox2 == null)
            {
                object value = strongBox.Value;
                T t2;
                if (value != null)
                {
                    if (!(value is T))
                    {
                        throw new HeapTypeMismatchException(string.Concat(new string[]
                        {
                            "Cannot retrieve heap variable of type '",
                            value.GetType().Name,
                            "' as type '",
                            typeof(T).Name,
                            "'"
                        }));
                    }
                    T t = (T)((object)value);
                    t2 = t;
                }
                else
                {
                    t2 = default(T);
                }
                return t2;
            }
            return strongBox2.Value;
        }

        internal static bool TryGetHeapVariable<T>(this UdonHeap instance, uint address, out T value)
        {
            if (!instance.IsAddressWithinBounds(address))
            {
                value = default(T);
                return false;
            }
            IStrongBox strongBox = instance._heap[(int)address];
            if (strongBox == null)
            {
                value = default(T);
                return false;
            }
            IStrongBox<T> strongBox2 = strongBox as IStrongBox<T>;
            if (strongBox2 != null)
            {
                value = strongBox2.Value;
                return true;
            }
            object value2 = strongBox.Value;
            if (value2 == null)
            {
                value = default(T);
                return false;
            }
            if (value2 is T)
            {
                T t = (T)((object)value2);
                value = t;
                return true;
            }
            value = default(T);
            return false;
        }

        internal static void SetHeapVariableInternal<T>(this UdonHeap instance, uint address, T value)
        {
            var strongbox = instance._heap[(int)address];
            if (strongbox != null)
            {
                strongbox.Value = value;
                return;
            }
            instance._heap[(int)address] = strongBox;
        }

        internal static void SetHeapVariableInternal(this UdonHeap instance, uint address, Il2CppSystem.Type value, Il2CppSystem.Type type)
        {
            Il2CppSystem.Type type2;
            if (!instance._strongBoxOfTypeCache.TryGetValue(type, out type2))
            {
                type2 = typeof(StrongBox<>).MakeGenericType(type);
                instance._strongBoxOfTypeCache.Add(type, type2);
            }
            instance._heap[(int)address] = (IStrongBox)Activator.CreateInstance(type2);
            if (value == null)
            {
                return;
            }
            instance._heap[(int)address].Value = value;
        }

        internal static void SetHeapVariableInternal(this UdonHeap instance, uint address, object value, Type type)
        {
            Type type2;
            if (!instance._strongBoxOfTypeCache.TryGetValue(type, out type2))
            {
                type2 = typeof(StrongBox<>).MakeGenericType(new Type[] { type });
                instance._strongBoxOfTypeCache.Add(type, type2);
            }
            instance._heap[(int)address] = (IStrongBox)Activator.CreateInstance(type2);
            if (value == null)
            {
                return;
            }
            instance._heap[(int)address].Value = value;
        }
    }
}