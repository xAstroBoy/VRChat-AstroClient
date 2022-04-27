using System.Collections.Generic;
using AstroClient.ClientActions;

namespace AstroClient.PlayerList.Entries
{
    using System;
    using ClientAttributes;
    using UnhollowerBaseLib.Attributes;

    [RegisterComponent]
    public class RiskyFuncAllowedEntry : EntryBase
    {
        public RiskyFuncAllowedEntry(IntPtr obj0) : base(obj0) { }

        [HideFromIl2Cpp]
        public override string Name => "Risky Functions Allowed";
        [HideFromIl2Cpp]
        public override void Init(object[] parameters = null)
        {
            ClientEventActions.Event_OnWorldReveal += OnWorldReveal;
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            OnEmmWorldCheckCompleted(true);
        }


        [HideFromIl2Cpp]
        public void OnEmmWorldCheckCompleted(bool areRiskyFuncsAllowed)
        {
            textComponent.text = OriginalText.Replace("{riskyfuncallowed}", areRiskyFuncsAllowed.ToString());
        }
    }
}
