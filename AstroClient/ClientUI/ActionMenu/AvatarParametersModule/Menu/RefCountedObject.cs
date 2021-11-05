
namespace AstroClient.ClientUI.ActionMenuButtons.AvatarParametersModule.Menu
{
    using UnityEngine;

    internal class RefCountedObject<T> where T : Object
    {
        private int m_Count;
        private T m_Value;

        internal RefCountedObject(T value)
        {
            m_Count = 1;
            m_Value = value;
        }

        internal T Get()
        {
            return m_Value;
        }

        internal void Increment()
        {
            ++m_Count;
        }

        internal bool Decrement()
        {
            if (--m_Count == 0)
            {
                Object.DestroyImmediate(m_Value);
                m_Value = null;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}