using System;
using UnityEngine;
using UnityEngine.UI;

namespace AstroClient._1245.WorldAPI.ButtonAPI.QM.Buttons.Groups;

internal class DuoButtons 
{
    internal VRCButton btn1, btn2;
    internal GameObject gameObject;
    internal Transform transform;

    internal DuoButtons(GameObject menu, string buttonOne, string buttonOneTooltip, Action btnAction, string buttonTwo, string buttonTwoTooltip, Action buttonTwoAction) {
        gameObject = new GameObject();
        transform = gameObject.transform;
        gameObject.name = $"DuoToggles";
        gameObject.transform.parent = menu.transform;
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.AddComponent<LayoutElement>();
        GameObject Sub = new GameObject(); // this has a reason! ;3
        Sub.name = $"DuoButtons_[WorldClient]";
        Sub.transform.parent = gameObject.transform;
        Sub.transform.localRotation = Quaternion.Euler(0, 0, 0);
        Sub.transform.localScale = new Vector3(1f, 1f, 1f);
        Sub.transform.localPosition = new Vector3(0f, -3f, 0f);

        btn1 = new(Sub.transform, buttonOne, buttonOneTooltip, btnAction, true);
        btn2 = new(Sub.transform, buttonTwo, buttonTwoTooltip, buttonTwoAction, true);
        btn1.transform.localPosition = new Vector3(0f, 50f, 0f);
        btn2.transform.localPosition = new Vector3(0f, -51f, 0f);
    }

    internal DuoButtons(CollapsibleButtonGroup grp, string buttonOne, string buttonOneTooltip, Action btnAction, string buttonTwo, string buttonTwoTooltip, Action buttonTwoAction) :
        this(grp.gameObject, buttonOne, buttonOneTooltip, btnAction,
            buttonTwo, buttonTwoTooltip, buttonTwoAction)
    { }

    internal DuoButtons(ButtonGroup grp, string buttonOne, string buttonOneTooltip, Action btnAction, string buttonTwo, string buttonTwoTooltip, Action buttonTwoAction) :
    this(grp.gameObject, buttonOne, buttonOneTooltip, btnAction,
        buttonTwo, buttonTwoTooltip, buttonTwoAction)
    { }
}

