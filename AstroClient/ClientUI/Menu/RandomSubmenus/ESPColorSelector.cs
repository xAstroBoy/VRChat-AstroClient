namespace AstroClient.ClientUI.Menu.RandomSubmenus
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Config;
    using Tools.Colors;
    using Tools.Extensions;
    using Tools.Skybox;
    using UnityEngine;
    using VRC.UI.Elements;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenu;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.AstroButtonAPI.Wings;

    internal class ESPColorSelector : AstroEvents
    {
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static bool isOpen { get; set; } = false;


        internal static void InitButtons(QMNestedGridMenu menu)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, "ESP Color Selection", "Edit Current ESPs Colors ");
            CurrentScrollMenu.SetBackButtonAction(menu, () =>
            {
                OnCloseMenu();
            });
            CurrentScrollMenu.AddOpenAction(() =>
            {
                OnOpenMenu();
            });
            FillMenu();
            InitWingPage();
        }

        private static void FillMenu()
        {
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.AliceBlue.Name, () => { SetESPColor(System.Drawing.Color.AliceBlue); }, System.Drawing.Color.AliceBlue.Name, System.Drawing.Color.AliceBlue);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.AntiqueWhite.Name, () => { SetESPColor(System.Drawing.Color.AntiqueWhite); }, System.Drawing.Color.AntiqueWhite.Name, System.Drawing.Color.AntiqueWhite);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Aqua.Name, () => { SetESPColor(System.Drawing.Color.Aqua); }, System.Drawing.Color.Aqua.Name, System.Drawing.Color.Aqua);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Aquamarine.Name, () => { SetESPColor(System.Drawing.Color.Aquamarine); }, System.Drawing.Color.Aquamarine.Name, System.Drawing.Color.Aquamarine);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Azure.Name, () => { SetESPColor(System.Drawing.Color.Azure); }, System.Drawing.Color.Azure.Name, System.Drawing.Color.Azure);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Beige.Name, () => { SetESPColor(System.Drawing.Color.Beige); }, System.Drawing.Color.Beige.Name, System.Drawing.Color.Beige);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Bisque.Name, () => { SetESPColor(System.Drawing.Color.Bisque); }, System.Drawing.Color.Bisque.Name, System.Drawing.Color.Bisque);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Black.Name, () => { SetESPColor(System.Drawing.Color.Black); }, System.Drawing.Color.Black.Name, System.Drawing.Color.Black);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.BlanchedAlmond.Name, () => { SetESPColor(System.Drawing.Color.BlanchedAlmond); }, System.Drawing.Color.BlanchedAlmond.Name, System.Drawing.Color.BlanchedAlmond);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Blue.Name, () => { SetESPColor(System.Drawing.Color.Blue); }, System.Drawing.Color.Blue.Name, System.Drawing.Color.Blue);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.BlueViolet.Name, () => { SetESPColor(System.Drawing.Color.BlueViolet); }, System.Drawing.Color.BlueViolet.Name, System.Drawing.Color.BlueViolet);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Brown.Name, () => { SetESPColor(System.Drawing.Color.Brown); }, System.Drawing.Color.Brown.Name, System.Drawing.Color.Brown);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.BurlyWood.Name, () => { SetESPColor(System.Drawing.Color.BurlyWood); }, System.Drawing.Color.BurlyWood.Name, System.Drawing.Color.BurlyWood);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.CadetBlue.Name, () => { SetESPColor(System.Drawing.Color.CadetBlue); }, System.Drawing.Color.CadetBlue.Name, System.Drawing.Color.CadetBlue);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Chartreuse.Name, () => { SetESPColor(System.Drawing.Color.Chartreuse); }, System.Drawing.Color.Chartreuse.Name, System.Drawing.Color.Chartreuse);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Chocolate.Name, () => { SetESPColor(System.Drawing.Color.Chocolate); }, System.Drawing.Color.Chocolate.Name, System.Drawing.Color.Chocolate);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Coral.Name, () => { SetESPColor(System.Drawing.Color.Coral); }, System.Drawing.Color.Coral.Name, System.Drawing.Color.Coral);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.CornflowerBlue.Name, () => { SetESPColor(System.Drawing.Color.CornflowerBlue); }, System.Drawing.Color.CornflowerBlue.Name, System.Drawing.Color.CornflowerBlue);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Cornsilk.Name, () => { SetESPColor(System.Drawing.Color.Cornsilk); }, System.Drawing.Color.Cornsilk.Name, System.Drawing.Color.Cornsilk);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Crimson.Name, () => { SetESPColor(System.Drawing.Color.Crimson); }, System.Drawing.Color.Crimson.Name, System.Drawing.Color.Crimson);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Cyan.Name, () => { SetESPColor(System.Drawing.Color.Cyan); }, System.Drawing.Color.Cyan.Name, System.Drawing.Color.Cyan);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DarkBlue.Name, () => { SetESPColor(System.Drawing.Color.DarkBlue); }, System.Drawing.Color.DarkBlue.Name, System.Drawing.Color.DarkBlue);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DarkCyan.Name, () => { SetESPColor(System.Drawing.Color.DarkCyan); }, System.Drawing.Color.DarkCyan.Name, System.Drawing.Color.DarkCyan);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DarkGoldenrod.Name, () => { SetESPColor(System.Drawing.Color.DarkGoldenrod); }, System.Drawing.Color.DarkGoldenrod.Name, System.Drawing.Color.DarkGoldenrod);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DarkGray.Name, () => { SetESPColor(System.Drawing.Color.DarkGray); }, System.Drawing.Color.DarkGray.Name, System.Drawing.Color.DarkGray);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DarkGreen.Name, () => { SetESPColor(System.Drawing.Color.DarkGreen); }, System.Drawing.Color.DarkGreen.Name, System.Drawing.Color.DarkGreen);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DarkKhaki.Name, () => { SetESPColor(System.Drawing.Color.DarkKhaki); }, System.Drawing.Color.DarkKhaki.Name, System.Drawing.Color.DarkKhaki);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DarkMagenta.Name, () => { SetESPColor(System.Drawing.Color.DarkMagenta); }, System.Drawing.Color.DarkMagenta.Name, System.Drawing.Color.DarkMagenta);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DarkOliveGreen.Name, () => { SetESPColor(System.Drawing.Color.DarkOliveGreen); }, System.Drawing.Color.DarkOliveGreen.Name, System.Drawing.Color.DarkOliveGreen);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DarkOrange.Name, () => { SetESPColor(System.Drawing.Color.DarkOrange); }, System.Drawing.Color.DarkOrange.Name, System.Drawing.Color.DarkOrange);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DarkOrchid.Name, () => { SetESPColor(System.Drawing.Color.DarkOrchid); }, System.Drawing.Color.DarkOrchid.Name, System.Drawing.Color.DarkOrchid);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DarkRed.Name, () => { SetESPColor(System.Drawing.Color.DarkRed); }, System.Drawing.Color.DarkRed.Name, System.Drawing.Color.DarkRed);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DarkSalmon.Name, () => { SetESPColor(System.Drawing.Color.DarkSalmon); }, System.Drawing.Color.DarkSalmon.Name, System.Drawing.Color.DarkSalmon);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DarkSeaGreen.Name, () => { SetESPColor(System.Drawing.Color.DarkSeaGreen); }, System.Drawing.Color.DarkSeaGreen.Name, System.Drawing.Color.DarkSeaGreen);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DarkSlateBlue.Name, () => { SetESPColor(System.Drawing.Color.DarkSlateBlue); }, System.Drawing.Color.DarkSlateBlue.Name, System.Drawing.Color.DarkSlateBlue);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DarkSlateGray.Name, () => { SetESPColor(System.Drawing.Color.DarkSlateGray); }, System.Drawing.Color.DarkSlateGray.Name, System.Drawing.Color.DarkSlateGray);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DarkTurquoise.Name, () => { SetESPColor(System.Drawing.Color.DarkTurquoise); }, System.Drawing.Color.DarkTurquoise.Name, System.Drawing.Color.DarkTurquoise);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DarkViolet.Name, () => { SetESPColor(System.Drawing.Color.DarkViolet); }, System.Drawing.Color.DarkViolet.Name, System.Drawing.Color.DarkViolet);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DeepPink.Name, () => { SetESPColor(System.Drawing.Color.DeepPink); }, System.Drawing.Color.DeepPink.Name, System.Drawing.Color.DeepPink);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DeepSkyBlue.Name, () => { SetESPColor(System.Drawing.Color.DeepSkyBlue); }, System.Drawing.Color.DeepSkyBlue.Name, System.Drawing.Color.DeepSkyBlue);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DimGray.Name, () => { SetESPColor(System.Drawing.Color.DimGray); }, System.Drawing.Color.DimGray.Name, System.Drawing.Color.DimGray);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.DodgerBlue.Name, () => { SetESPColor(System.Drawing.Color.DodgerBlue); }, System.Drawing.Color.DodgerBlue.Name, System.Drawing.Color.DodgerBlue);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Firebrick.Name, () => { SetESPColor(System.Drawing.Color.Firebrick); }, System.Drawing.Color.Firebrick.Name, System.Drawing.Color.Firebrick);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.FloralWhite.Name, () => { SetESPColor(System.Drawing.Color.FloralWhite); }, System.Drawing.Color.FloralWhite.Name, System.Drawing.Color.FloralWhite);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.ForestGreen.Name, () => { SetESPColor(System.Drawing.Color.ForestGreen); }, System.Drawing.Color.ForestGreen.Name, System.Drawing.Color.ForestGreen);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Fuchsia.Name, () => { SetESPColor(System.Drawing.Color.Fuchsia); }, System.Drawing.Color.Fuchsia.Name, System.Drawing.Color.Fuchsia);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Gainsboro.Name, () => { SetESPColor(System.Drawing.Color.Gainsboro); }, System.Drawing.Color.Gainsboro.Name, System.Drawing.Color.Gainsboro);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.GhostWhite.Name, () => { SetESPColor(System.Drawing.Color.GhostWhite); }, System.Drawing.Color.GhostWhite.Name, System.Drawing.Color.GhostWhite);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Gold.Name, () => { SetESPColor(System.Drawing.Color.Gold); }, System.Drawing.Color.Gold.Name, System.Drawing.Color.Gold);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Goldenrod.Name, () => { SetESPColor(System.Drawing.Color.Goldenrod); }, System.Drawing.Color.Goldenrod.Name, System.Drawing.Color.Goldenrod);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Gray.Name, () => { SetESPColor(System.Drawing.Color.Gray); }, System.Drawing.Color.Gray.Name, System.Drawing.Color.Gray);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Green.Name, () => { SetESPColor(System.Drawing.Color.Green); }, System.Drawing.Color.Green.Name, System.Drawing.Color.Green);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.GreenYellow.Name, () => { SetESPColor(System.Drawing.Color.GreenYellow); }, System.Drawing.Color.GreenYellow.Name, System.Drawing.Color.GreenYellow);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Honeydew.Name, () => { SetESPColor(System.Drawing.Color.Honeydew); }, System.Drawing.Color.Honeydew.Name, System.Drawing.Color.Honeydew);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.HotPink.Name, () => { SetESPColor(System.Drawing.Color.HotPink); }, System.Drawing.Color.HotPink.Name, System.Drawing.Color.HotPink);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.IndianRed.Name, () => { SetESPColor(System.Drawing.Color.IndianRed); }, System.Drawing.Color.IndianRed.Name, System.Drawing.Color.IndianRed);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Indigo.Name, () => { SetESPColor(System.Drawing.Color.Indigo); }, System.Drawing.Color.Indigo.Name, System.Drawing.Color.Indigo);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Ivory.Name, () => { SetESPColor(System.Drawing.Color.Ivory); }, System.Drawing.Color.Ivory.Name, System.Drawing.Color.Ivory);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Khaki.Name, () => { SetESPColor(System.Drawing.Color.Khaki); }, System.Drawing.Color.Khaki.Name, System.Drawing.Color.Khaki);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Lavender.Name, () => { SetESPColor(System.Drawing.Color.Lavender); }, System.Drawing.Color.Lavender.Name, System.Drawing.Color.Lavender);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.LavenderBlush.Name, () => { SetESPColor(System.Drawing.Color.LavenderBlush); }, System.Drawing.Color.LavenderBlush.Name, System.Drawing.Color.LavenderBlush);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.LawnGreen.Name, () => { SetESPColor(System.Drawing.Color.LawnGreen); }, System.Drawing.Color.LawnGreen.Name, System.Drawing.Color.LawnGreen);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.LemonChiffon.Name, () => { SetESPColor(System.Drawing.Color.LemonChiffon); }, System.Drawing.Color.LemonChiffon.Name, System.Drawing.Color.LemonChiffon);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.LightBlue.Name, () => { SetESPColor(System.Drawing.Color.LightBlue); }, System.Drawing.Color.LightBlue.Name, System.Drawing.Color.LightBlue);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.LightCoral.Name, () => { SetESPColor(System.Drawing.Color.LightCoral); }, System.Drawing.Color.LightCoral.Name, System.Drawing.Color.LightCoral);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.LightCyan.Name, () => { SetESPColor(System.Drawing.Color.LightCyan); }, System.Drawing.Color.LightCyan.Name, System.Drawing.Color.LightCyan);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.LightGoldenrodYellow.Name, () => { SetESPColor(System.Drawing.Color.LightGoldenrodYellow); }, System.Drawing.Color.LightGoldenrodYellow.Name, System.Drawing.Color.LightGoldenrodYellow);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.LightGreen.Name, () => { SetESPColor(System.Drawing.Color.LightGreen); }, System.Drawing.Color.LightGreen.Name, System.Drawing.Color.LightGreen);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.LightGray.Name, () => { SetESPColor(System.Drawing.Color.LightGray); }, System.Drawing.Color.LightGray.Name, System.Drawing.Color.LightGray);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.LightPink.Name, () => { SetESPColor(System.Drawing.Color.LightPink); }, System.Drawing.Color.LightPink.Name, System.Drawing.Color.LightPink);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.LightSalmon.Name, () => { SetESPColor(System.Drawing.Color.LightSalmon); }, System.Drawing.Color.LightSalmon.Name, System.Drawing.Color.LightSalmon);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.LightSeaGreen.Name, () => { SetESPColor(System.Drawing.Color.LightSeaGreen); }, System.Drawing.Color.LightSeaGreen.Name, System.Drawing.Color.LightSeaGreen);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.LightSkyBlue.Name, () => { SetESPColor(System.Drawing.Color.LightSkyBlue); }, System.Drawing.Color.LightSkyBlue.Name, System.Drawing.Color.LightSkyBlue);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.LightSlateGray.Name, () => { SetESPColor(System.Drawing.Color.LightSlateGray); }, System.Drawing.Color.LightSlateGray.Name, System.Drawing.Color.LightSlateGray);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.LightSteelBlue.Name, () => { SetESPColor(System.Drawing.Color.LightSteelBlue); }, System.Drawing.Color.LightSteelBlue.Name, System.Drawing.Color.LightSteelBlue);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.LightYellow.Name, () => { SetESPColor(System.Drawing.Color.LightYellow); }, System.Drawing.Color.LightYellow.Name, System.Drawing.Color.LightYellow);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Lime.Name, () => { SetESPColor(System.Drawing.Color.Lime); }, System.Drawing.Color.Lime.Name, System.Drawing.Color.Lime);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.LimeGreen.Name, () => { SetESPColor(System.Drawing.Color.LimeGreen); }, System.Drawing.Color.LimeGreen.Name, System.Drawing.Color.LimeGreen);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Linen.Name, () => { SetESPColor(System.Drawing.Color.Linen); }, System.Drawing.Color.Linen.Name, System.Drawing.Color.Linen);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Magenta.Name, () => { SetESPColor(System.Drawing.Color.Magenta); }, System.Drawing.Color.Magenta.Name, System.Drawing.Color.Magenta);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Maroon.Name, () => { SetESPColor(System.Drawing.Color.Maroon); }, System.Drawing.Color.Maroon.Name, System.Drawing.Color.Maroon);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.MediumAquamarine.Name, () => { SetESPColor(System.Drawing.Color.MediumAquamarine); }, System.Drawing.Color.MediumAquamarine.Name, System.Drawing.Color.MediumAquamarine);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.MediumBlue.Name, () => { SetESPColor(System.Drawing.Color.MediumBlue); }, System.Drawing.Color.MediumBlue.Name, System.Drawing.Color.MediumBlue);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.MediumOrchid.Name, () => { SetESPColor(System.Drawing.Color.MediumOrchid); }, System.Drawing.Color.MediumOrchid.Name, System.Drawing.Color.MediumOrchid);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.MediumPurple.Name, () => { SetESPColor(System.Drawing.Color.MediumPurple); }, System.Drawing.Color.MediumPurple.Name, System.Drawing.Color.MediumPurple);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.MediumSeaGreen.Name, () => { SetESPColor(System.Drawing.Color.MediumSeaGreen); }, System.Drawing.Color.MediumSeaGreen.Name, System.Drawing.Color.MediumSeaGreen);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.MediumSlateBlue.Name, () => { SetESPColor(System.Drawing.Color.MediumSlateBlue); }, System.Drawing.Color.MediumSlateBlue.Name, System.Drawing.Color.MediumSlateBlue);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.MediumSpringGreen.Name, () => { SetESPColor(System.Drawing.Color.MediumSpringGreen); }, System.Drawing.Color.MediumSpringGreen.Name, System.Drawing.Color.MediumSpringGreen);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.MediumTurquoise.Name, () => { SetESPColor(System.Drawing.Color.MediumTurquoise); }, System.Drawing.Color.MediumTurquoise.Name, System.Drawing.Color.MediumTurquoise);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.MediumVioletRed.Name, () => { SetESPColor(System.Drawing.Color.MediumVioletRed); }, System.Drawing.Color.MediumVioletRed.Name, System.Drawing.Color.MediumVioletRed);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.MidnightBlue.Name, () => { SetESPColor(System.Drawing.Color.MidnightBlue); }, System.Drawing.Color.MidnightBlue.Name, System.Drawing.Color.MidnightBlue);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.MintCream.Name, () => { SetESPColor(System.Drawing.Color.MintCream); }, System.Drawing.Color.MintCream.Name, System.Drawing.Color.MintCream);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.MistyRose.Name, () => { SetESPColor(System.Drawing.Color.MistyRose); }, System.Drawing.Color.MistyRose.Name, System.Drawing.Color.MistyRose);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Moccasin.Name, () => { SetESPColor(System.Drawing.Color.Moccasin); }, System.Drawing.Color.Moccasin.Name, System.Drawing.Color.Moccasin);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.NavajoWhite.Name, () => { SetESPColor(System.Drawing.Color.NavajoWhite); }, System.Drawing.Color.NavajoWhite.Name, System.Drawing.Color.NavajoWhite);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Navy.Name, () => { SetESPColor(System.Drawing.Color.Navy); }, System.Drawing.Color.Navy.Name, System.Drawing.Color.Navy);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.OldLace.Name, () => { SetESPColor(System.Drawing.Color.OldLace); }, System.Drawing.Color.OldLace.Name, System.Drawing.Color.OldLace);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Olive.Name, () => { SetESPColor(System.Drawing.Color.Olive); }, System.Drawing.Color.Olive.Name, System.Drawing.Color.Olive);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.OliveDrab.Name, () => { SetESPColor(System.Drawing.Color.OliveDrab); }, System.Drawing.Color.OliveDrab.Name, System.Drawing.Color.OliveDrab);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Orange.Name, () => { SetESPColor(System.Drawing.Color.Orange); }, System.Drawing.Color.Orange.Name, System.Drawing.Color.Orange);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.OrangeRed.Name, () => { SetESPColor(System.Drawing.Color.OrangeRed); }, System.Drawing.Color.OrangeRed.Name, System.Drawing.Color.OrangeRed);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Orchid.Name, () => { SetESPColor(System.Drawing.Color.Orchid); }, System.Drawing.Color.Orchid.Name, System.Drawing.Color.Orchid);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.PaleGoldenrod.Name, () => { SetESPColor(System.Drawing.Color.PaleGoldenrod); }, System.Drawing.Color.PaleGoldenrod.Name, System.Drawing.Color.PaleGoldenrod);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.PaleGreen.Name, () => { SetESPColor(System.Drawing.Color.PaleGreen); }, System.Drawing.Color.PaleGreen.Name, System.Drawing.Color.PaleGreen);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.PaleTurquoise.Name, () => { SetESPColor(System.Drawing.Color.PaleTurquoise); }, System.Drawing.Color.PaleTurquoise.Name, System.Drawing.Color.PaleTurquoise);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.PaleVioletRed.Name, () => { SetESPColor(System.Drawing.Color.PaleVioletRed); }, System.Drawing.Color.PaleVioletRed.Name, System.Drawing.Color.PaleVioletRed);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.PapayaWhip.Name, () => { SetESPColor(System.Drawing.Color.PapayaWhip); }, System.Drawing.Color.PapayaWhip.Name, System.Drawing.Color.PapayaWhip);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.PeachPuff.Name, () => { SetESPColor(System.Drawing.Color.PeachPuff); }, System.Drawing.Color.PeachPuff.Name, System.Drawing.Color.PeachPuff);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Peru.Name, () => { SetESPColor(System.Drawing.Color.Peru); }, System.Drawing.Color.Peru.Name, System.Drawing.Color.Peru);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Pink.Name, () => { SetESPColor(System.Drawing.Color.Pink); }, System.Drawing.Color.Pink.Name, System.Drawing.Color.Pink);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Plum.Name, () => { SetESPColor(System.Drawing.Color.Plum); }, System.Drawing.Color.Plum.Name, System.Drawing.Color.Plum);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.PowderBlue.Name, () => { SetESPColor(System.Drawing.Color.PowderBlue); }, System.Drawing.Color.PowderBlue.Name, System.Drawing.Color.PowderBlue);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Purple.Name, () => { SetESPColor(System.Drawing.Color.Purple); }, System.Drawing.Color.Purple.Name, System.Drawing.Color.Purple);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Red.Name, () => { SetESPColor(System.Drawing.Color.Red); }, System.Drawing.Color.Red.Name, System.Drawing.Color.Red);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.RosyBrown.Name, () => { SetESPColor(System.Drawing.Color.RosyBrown); }, System.Drawing.Color.RosyBrown.Name, System.Drawing.Color.RosyBrown);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.RoyalBlue.Name, () => { SetESPColor(System.Drawing.Color.RoyalBlue); }, System.Drawing.Color.RoyalBlue.Name, System.Drawing.Color.RoyalBlue);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.SaddleBrown.Name, () => { SetESPColor(System.Drawing.Color.SaddleBrown); }, System.Drawing.Color.SaddleBrown.Name, System.Drawing.Color.SaddleBrown);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Salmon.Name, () => { SetESPColor(System.Drawing.Color.Salmon); }, System.Drawing.Color.Salmon.Name, System.Drawing.Color.Salmon);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.SandyBrown.Name, () => { SetESPColor(System.Drawing.Color.SandyBrown); }, System.Drawing.Color.SandyBrown.Name, System.Drawing.Color.SandyBrown);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.SeaGreen.Name, () => { SetESPColor(System.Drawing.Color.SeaGreen); }, System.Drawing.Color.SeaGreen.Name, System.Drawing.Color.SeaGreen);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.SeaShell.Name, () => { SetESPColor(System.Drawing.Color.SeaShell); }, System.Drawing.Color.SeaShell.Name, System.Drawing.Color.SeaShell);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Sienna.Name, () => { SetESPColor(System.Drawing.Color.Sienna); }, System.Drawing.Color.Sienna.Name, System.Drawing.Color.Sienna);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Silver.Name, () => { SetESPColor(System.Drawing.Color.Silver); }, System.Drawing.Color.Silver.Name, System.Drawing.Color.Silver);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.SkyBlue.Name, () => { SetESPColor(System.Drawing.Color.SkyBlue); }, System.Drawing.Color.SkyBlue.Name, System.Drawing.Color.SkyBlue);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.SlateBlue.Name, () => { SetESPColor(System.Drawing.Color.SlateBlue); }, System.Drawing.Color.SlateBlue.Name, System.Drawing.Color.SlateBlue);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.SlateGray.Name, () => { SetESPColor(System.Drawing.Color.SlateGray); }, System.Drawing.Color.SlateGray.Name, System.Drawing.Color.SlateGray);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Snow.Name, () => { SetESPColor(System.Drawing.Color.Snow); }, System.Drawing.Color.Snow.Name, System.Drawing.Color.Snow);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.SpringGreen.Name, () => { SetESPColor(System.Drawing.Color.SpringGreen); }, System.Drawing.Color.SpringGreen.Name, System.Drawing.Color.SpringGreen);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.SteelBlue.Name, () => { SetESPColor(System.Drawing.Color.SteelBlue); }, System.Drawing.Color.SteelBlue.Name, System.Drawing.Color.SteelBlue);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Tan.Name, () => { SetESPColor(System.Drawing.Color.Tan); }, System.Drawing.Color.Tan.Name, System.Drawing.Color.Tan);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Teal.Name, () => { SetESPColor(System.Drawing.Color.Teal); }, System.Drawing.Color.Teal.Name, System.Drawing.Color.Teal);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Thistle.Name, () => { SetESPColor(System.Drawing.Color.Thistle); }, System.Drawing.Color.Thistle.Name, System.Drawing.Color.Thistle);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Tomato.Name, () => { SetESPColor(System.Drawing.Color.Tomato); }, System.Drawing.Color.Tomato.Name, System.Drawing.Color.Tomato);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Turquoise.Name, () => { SetESPColor(System.Drawing.Color.Turquoise); }, System.Drawing.Color.Turquoise.Name, System.Drawing.Color.Turquoise);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Violet.Name, () => { SetESPColor(System.Drawing.Color.Violet); }, System.Drawing.Color.Violet.Name, System.Drawing.Color.Violet);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Wheat.Name, () => { SetESPColor(System.Drawing.Color.Wheat); }, System.Drawing.Color.Wheat.Name, System.Drawing.Color.Wheat);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.White.Name, () => { SetESPColor(System.Drawing.Color.White); }, System.Drawing.Color.White.Name, System.Drawing.Color.White);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.WhiteSmoke.Name, () => { SetESPColor(System.Drawing.Color.WhiteSmoke); }, System.Drawing.Color.WhiteSmoke.Name, System.Drawing.Color.WhiteSmoke);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.Yellow.Name, () => { SetESPColor(System.Drawing.Color.Yellow); }, System.Drawing.Color.Yellow.Name, System.Drawing.Color.Yellow);
            new QMSingleButton(CurrentScrollMenu, System.Drawing.Color.YellowGreen.Name, () => { SetESPColor(System.Drawing.Color.YellowGreen); }, System.Drawing.Color.YellowGreen.Name, System.Drawing.Color.YellowGreen);
        }


        private static void SetESPColor(System.Drawing.Color color)
        {
            if (SetPublicESP)
            {
                ConfigManager.PublicESPColor = color.ToUnityEngineColor();
            }
            if (SetFriendESP)
            {
                ConfigManager.ESPFriendColor = color.ToUnityEngineColor();
            }
            if (SetBlockedESP)
            {
                ConfigManager.ESPBlockedColor = color.ToUnityEngineColor();
            }

        }





        internal override void OnQuickMenuClose()
        {
            OnCloseMenu();
        }

        private static void OnCloseMenu()
        {
            if (WingMenu != null)
            {
                WingMenu.SetActive(false);
                WingMenu.ClickBackButton();
            }
            isOpen = false;

        }

        private static void OnOpenMenu()
        {
            isOpen = true;
            if (WingMenu != null)
            {
                WingMenu.SetActive(true);
                WingMenu.ShowWingsPage();
            }
        }

        internal override void OnUiPageToggled(UIPage Page, bool Toggle)
        {
            if (!isOpen) return;

            if (Page != null)
            {
                if (!Page.ContainsPage(CurrentScrollMenu.page) && !Page.ContainsPage(WingMenu.CurrentPage))
                {
                    OnCloseMenu();
                }
            }
        }


        private static bool _PublicESPSettings = false;
        private static bool _FriendESPSetting = false;
        private static bool _BlockedESPSetting = false;

        private static bool SetPublicESP
        {
            get
            {
                return _PublicESPSettings;
            }
            set
            {
                _PublicESPSettings = value;
                if (PublicESPSettingsToggle != null)
                {
                    PublicESPSettingsToggle.SetToggleState(value);
                }
                if (value)
                {
                    SetFriendESP = false;
                    SetBlockedESP = false;
                }

            }
        }
        private static bool SetFriendESP
        {
            get
            {
                return _FriendESPSetting;

            }
            set
            {
                _FriendESPSetting = value;
                if (FriendESPSettingToggle != null)
                {
                    FriendESPSettingToggle.SetToggleState(value);
                }
                if (value)
                {
                    SetBlockedESP = false;
                    SetPublicESP = false;
                }

            }
        }

        private static bool SetBlockedESP
        {
            get
            {
                return _BlockedESPSetting;
            }
            set
            {
                _BlockedESPSetting = value;
                if (BlockedESPSettingToggle != null)
                {
                    BlockedESPSettingToggle.SetToggleState(value);
                }
                if (value)
                {
                    SetFriendESP = false;
                    SetPublicESP = false;
                }

            }
        }



        private static QMWingToggleButton PublicESPSettingsToggle;
        private static QMWingToggleButton FriendESPSettingToggle;
        private static QMWingToggleButton BlockedESPSettingToggle;

        private static void InitWingPage()
        {
            WingMenu = new QMWings(1021, true, "Color Selection ESP", "Edit ESP Colors");
            PublicESPSettingsToggle = new QMWingToggleButton(WingMenu, "Public ESP", () => { SetPublicESP = true;}, () => { SetPublicESP = false;}, "Set Public ESP Color.");
            FriendESPSettingToggle = new QMWingToggleButton(WingMenu, "Friend ESP", () => { SetFriendESP = true; }, () => { SetFriendESP = false;}, "Set Friend ESP Color.");
            BlockedESPSettingToggle = new QMWingToggleButton(WingMenu, "Blocked ESP", () => { SetBlockedESP = true; }, () => { SetBlockedESP = false;}, "Set Blocked ESP Color.");
            WingMenu.SetActive(false);
        }
    }
}