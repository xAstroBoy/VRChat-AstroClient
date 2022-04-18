namespace AstroClient.PlayerList.Config 
{
    using System;
    using MelonLoader;

    public class EntryWrapper
    {
        public event Action OnValueChangedUntyped;

        protected void RunOnValueChangedUntyped() => OnValueChangedUntyped?.SafetyRaise();
    }
    public class EntryWrapper<T> : EntryWrapper
    {
        public MelonPreferences_Entry<T> pref;

        public T Value
        {
            get { return pref.Value; }
            set 
            {
                if (!value.Equals(Value))
                {
                    OnValueChanged?.SafetyRaiseWithParams(pref.Value, value);
                    pref.Value = value;
                    RunOnValueChangedUntyped();
                }
            }
        }

        public event Action<T, T> OnValueChanged;
    }
}
