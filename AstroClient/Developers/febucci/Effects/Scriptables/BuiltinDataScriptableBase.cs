using UnityEngine;

namespace AstroClient.febucci.Effects.Scriptables
{
    public class BuiltinDataScriptableBase<T> : ScriptableObject where T : new()
    {
         public T effectValues = new T();
    }
}