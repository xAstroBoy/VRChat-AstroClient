using System;
using AstroClient._1245.WorldAPI.ButtonAPI.MM;
using AstroClient._1245.WorldAPI.ButtonAPI.QM.Buttons;
using AstroClient._1245.WorldAPI.ButtonAPI.QM.Buttons.Groups;
using TMPro;
using UnityEngine;

namespace AstroClient._1245.WorldAPI.ButtonAPI.QM.Controls
{
    internal class Root
    {
        internal GameObject gameObject { get; set; }
        internal TextMeshProUGUI TMProCompnt { get; set; }


        internal string Text;

        internal void SetActive(bool Active) =>
            gameObject.SetActive(Active);

        internal void SetTextColor(Color color) =>
            TMProCompnt.color = color;

        internal void SetTextColor(string Hex) =>
            TMProCompnt.text = $"<color={Hex}>{Text}</color>";

        internal void SetRotation(Vector3 Poz) =>
            gameObject.transform.localRotation = Quaternion.Euler(Poz);

        internal void SetPostion(Vector3 Poz) =>
            gameObject.transform.localPosition = Poz;

        internal GameObject GetGameObject() =>
            gameObject;

        internal Transform GetTransform() =>
            gameObject.transform;

        internal Transform ChangeParent(GameObject newParent) =>
            gameObject.transform.parent = newParent.transform;

        internal Transform AlsoAddToMM(MMPage pg) =>
            GameObject.Instantiate(gameObject.transform, pg.menuContents);

        internal VRCButton AddButton(string text, string tooltip, Action listener, bool Half = false, bool SubMenuIcon = false, Sprite Icon = null) =>
            new VRCButton(gameObject.transform, text, tooltip, listener, Half, SubMenuIcon, Icon);

        internal VRCToggle AddToggle(string Ontext, Action<bool> listener, bool DefaultState = false, string OffTooltip = null, string OnToolTip = null,
            Sprite onSprite = null, Sprite offSprite = null, bool Half = false) =>
            new VRCToggle(gameObject.transform, Ontext, listener, DefaultState, OffTooltip, OnToolTip, onSprite, offSprite, Half);

        internal VRCLable AddLable(string text, string LowerText, Action onClick = null, bool Bg = true) =>
            new VRCLable(gameObject.transform, text, LowerText, onClick, Bg);

        internal GrpButtons AddGrpOfButtons(string FirstName, string FirstTooltip, Action action,
                                            string SecondName = null, string SecondTooltip = null, Action Secondaction = null,
                                            string thirdName = null, string thirdTooltip = null, Action thirdaction = null) => 
                new GrpButtons(gameObject, FirstName, FirstTooltip, action,
                    SecondName, SecondTooltip, Secondaction,
                    thirdName, thirdTooltip, thirdaction);

        internal GrpToggles AddGrpToggles(string text, string Ontooltip, string OffTooltip, Action<bool> BoolStateChange,
            string text2, string Ontooltip2, string OffTooltip2, Action<bool> BoolStateChange2,
            Vector3 TogglePoz, Sprite OnImageSprite = null, Sprite OffImageSprite = null,
            float FirstFontSize = 24f, float SecondFontSize = 24f, bool FirstState = false, bool SecondState = false) =>
            new GrpToggles(gameObject, text, Ontooltip, OffTooltip, BoolStateChange,
                text2, Ontooltip2, OffTooltip2, BoolStateChange2,
                TogglePoz, OnImageSprite, OffImageSprite, FirstFontSize, SecondFontSize, FirstState, SecondState);

        internal DuoButtons AddDuoButtons(string buttonOne, string buttonOneTooltip, Action btnAction, string buttonTwo, string buttonTwoTooltip, Action buttonTwoAction) =>
            new DuoButtons(gameObject, buttonOne, buttonOneTooltip, btnAction,
                buttonTwo, buttonTwoTooltip, buttonTwoAction);
        
    }
}
