using System.Drawing;
using AstroClient.ClientActions;
using AstroClient.Config;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using AstroClient.xAstroBoy.AstroButtonAPI.WingsAPI;
using VRC.UI.Elements;

namespace AstroClient.ClientUI.QuickMenuGUI.RandomSubmenus
{
    internal class ESPColorSelector : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnQuickMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuOpen += OnCloseMenu;
        }

        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;


        private static bool _PublicESPSettings;
        private static bool _FriendESPSetting;
        private static bool _BlockedESPSetting;


        private static QMWingToggleButton PublicESPSettingsToggle;
        private static QMWingToggleButton FriendESPSettingToggle;
        private static QMWingToggleButton BlockedESPSettingToggle;
        private static bool isOpen { get; set; }

        private static bool SetPublicESP
        {
            get => _PublicESPSettings;
            set
            {
                _PublicESPSettings = value;
                if (PublicESPSettingsToggle != null) PublicESPSettingsToggle.SetToggleState(value);
                if (value)
                {
                    SetFriendESP = false;
                    SetBlockedESP = false;
                }
            }
        }

        private static bool SetFriendESP
        {
            get => _FriendESPSetting;
            set
            {
                _FriendESPSetting = value;
                if (FriendESPSettingToggle != null) FriendESPSettingToggle.SetToggleState(value);
                if (value)
                {
                    SetBlockedESP = false;
                    SetPublicESP = false;
                }
            }
        }

        private static bool SetBlockedESP
        {
            get => _BlockedESPSetting;
            set
            {
                _BlockedESPSetting = value;
                if (BlockedESPSettingToggle != null) BlockedESPSettingToggle.SetToggleState(value);
                if (value)
                {
                    SetFriendESP = false;
                    SetPublicESP = false;
                }
            }
        }

        private static bool _IsUIPageListenerActive = false;
        private static bool IsUIPageListenerActive
        {
            get => _IsUIPageListenerActive;
            set
            {
                if (_IsUIPageListenerActive != value)
                {
                    if (value)
                    {
                        ClientEventActions.OnUiPageToggled += OnUiPageToggled;

                    }
                    else
                    {
                        ClientEventActions.OnUiPageToggled -= OnUiPageToggled;

                    }

                }
                _IsUIPageListenerActive = value;
            }
        }
        internal static void InitButtons(QMNestedGridMenu menu)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, "ESP Color Selection", "Edit Current ESPs Colors ");
            CurrentScrollMenu.OnOpenAction += OnOpenMenu;
            CurrentScrollMenu.OnCloseAction += OnCloseMenu;
            FillMenu();
            InitWingPage();
        }

        private static void FillMenu()
        {
            new QMSingleButton(CurrentScrollMenu, Color.AliceBlue.Name, () => { SetESPColor(Color.AliceBlue); }, Color.AliceBlue.Name, Color.AliceBlue);
            new QMSingleButton(CurrentScrollMenu, Color.AntiqueWhite.Name, () => { SetESPColor(Color.AntiqueWhite); }, Color.AntiqueWhite.Name, Color.AntiqueWhite);
            new QMSingleButton(CurrentScrollMenu, Color.Aqua.Name, () => { SetESPColor(Color.Aqua); }, Color.Aqua.Name, Color.Aqua);
            new QMSingleButton(CurrentScrollMenu, Color.Aquamarine.Name, () => { SetESPColor(Color.Aquamarine); }, Color.Aquamarine.Name, Color.Aquamarine);
            new QMSingleButton(CurrentScrollMenu, Color.Azure.Name, () => { SetESPColor(Color.Azure); }, Color.Azure.Name, Color.Azure);
            new QMSingleButton(CurrentScrollMenu, Color.Beige.Name, () => { SetESPColor(Color.Beige); }, Color.Beige.Name, Color.Beige);
            new QMSingleButton(CurrentScrollMenu, Color.Bisque.Name, () => { SetESPColor(Color.Bisque); }, Color.Bisque.Name, Color.Bisque);
            new QMSingleButton(CurrentScrollMenu, Color.Black.Name, () => { SetESPColor(Color.Black); }, Color.Black.Name, Color.Black);
            new QMSingleButton(CurrentScrollMenu, Color.BlanchedAlmond.Name, () => { SetESPColor(Color.BlanchedAlmond); }, Color.BlanchedAlmond.Name, Color.BlanchedAlmond);
            new QMSingleButton(CurrentScrollMenu, Color.Blue.Name, () => { SetESPColor(Color.Blue); }, Color.Blue.Name, Color.Blue);
            new QMSingleButton(CurrentScrollMenu, Color.BlueViolet.Name, () => { SetESPColor(Color.BlueViolet); }, Color.BlueViolet.Name, Color.BlueViolet);
            new QMSingleButton(CurrentScrollMenu, Color.Brown.Name, () => { SetESPColor(Color.Brown); }, Color.Brown.Name, Color.Brown);
            new QMSingleButton(CurrentScrollMenu, Color.BurlyWood.Name, () => { SetESPColor(Color.BurlyWood); }, Color.BurlyWood.Name, Color.BurlyWood);
            new QMSingleButton(CurrentScrollMenu, Color.CadetBlue.Name, () => { SetESPColor(Color.CadetBlue); }, Color.CadetBlue.Name, Color.CadetBlue);
            new QMSingleButton(CurrentScrollMenu, Color.Chartreuse.Name, () => { SetESPColor(Color.Chartreuse); }, Color.Chartreuse.Name, Color.Chartreuse);
            new QMSingleButton(CurrentScrollMenu, Color.Chocolate.Name, () => { SetESPColor(Color.Chocolate); }, Color.Chocolate.Name, Color.Chocolate);
            new QMSingleButton(CurrentScrollMenu, Color.Coral.Name, () => { SetESPColor(Color.Coral); }, Color.Coral.Name, Color.Coral);
            new QMSingleButton(CurrentScrollMenu, Color.CornflowerBlue.Name, () => { SetESPColor(Color.CornflowerBlue); }, Color.CornflowerBlue.Name, Color.CornflowerBlue);
            new QMSingleButton(CurrentScrollMenu, Color.Cornsilk.Name, () => { SetESPColor(Color.Cornsilk); }, Color.Cornsilk.Name, Color.Cornsilk);
            new QMSingleButton(CurrentScrollMenu, Color.Crimson.Name, () => { SetESPColor(Color.Crimson); }, Color.Crimson.Name, Color.Crimson);
            new QMSingleButton(CurrentScrollMenu, Color.Cyan.Name, () => { SetESPColor(Color.Cyan); }, Color.Cyan.Name, Color.Cyan);
            new QMSingleButton(CurrentScrollMenu, Color.DarkBlue.Name, () => { SetESPColor(Color.DarkBlue); }, Color.DarkBlue.Name, Color.DarkBlue);
            new QMSingleButton(CurrentScrollMenu, Color.DarkCyan.Name, () => { SetESPColor(Color.DarkCyan); }, Color.DarkCyan.Name, Color.DarkCyan);
            new QMSingleButton(CurrentScrollMenu, Color.DarkGoldenrod.Name, () => { SetESPColor(Color.DarkGoldenrod); }, Color.DarkGoldenrod.Name, Color.DarkGoldenrod);
            new QMSingleButton(CurrentScrollMenu, Color.DarkGray.Name, () => { SetESPColor(Color.DarkGray); }, Color.DarkGray.Name, Color.DarkGray);
            new QMSingleButton(CurrentScrollMenu, Color.DarkGreen.Name, () => { SetESPColor(Color.DarkGreen); }, Color.DarkGreen.Name, Color.DarkGreen);
            new QMSingleButton(CurrentScrollMenu, Color.DarkKhaki.Name, () => { SetESPColor(Color.DarkKhaki); }, Color.DarkKhaki.Name, Color.DarkKhaki);
            new QMSingleButton(CurrentScrollMenu, Color.DarkMagenta.Name, () => { SetESPColor(Color.DarkMagenta); }, Color.DarkMagenta.Name, Color.DarkMagenta);
            new QMSingleButton(CurrentScrollMenu, Color.DarkOliveGreen.Name, () => { SetESPColor(Color.DarkOliveGreen); }, Color.DarkOliveGreen.Name, Color.DarkOliveGreen);
            new QMSingleButton(CurrentScrollMenu, Color.DarkOrange.Name, () => { SetESPColor(Color.DarkOrange); }, Color.DarkOrange.Name, Color.DarkOrange);
            new QMSingleButton(CurrentScrollMenu, Color.DarkOrchid.Name, () => { SetESPColor(Color.DarkOrchid); }, Color.DarkOrchid.Name, Color.DarkOrchid);
            new QMSingleButton(CurrentScrollMenu, Color.DarkRed.Name, () => { SetESPColor(Color.DarkRed); }, Color.DarkRed.Name, Color.DarkRed);
            new QMSingleButton(CurrentScrollMenu, Color.DarkSalmon.Name, () => { SetESPColor(Color.DarkSalmon); }, Color.DarkSalmon.Name, Color.DarkSalmon);
            new QMSingleButton(CurrentScrollMenu, Color.DarkSeaGreen.Name, () => { SetESPColor(Color.DarkSeaGreen); }, Color.DarkSeaGreen.Name, Color.DarkSeaGreen);
            new QMSingleButton(CurrentScrollMenu, Color.DarkSlateBlue.Name, () => { SetESPColor(Color.DarkSlateBlue); }, Color.DarkSlateBlue.Name, Color.DarkSlateBlue);
            new QMSingleButton(CurrentScrollMenu, Color.DarkSlateGray.Name, () => { SetESPColor(Color.DarkSlateGray); }, Color.DarkSlateGray.Name, Color.DarkSlateGray);
            new QMSingleButton(CurrentScrollMenu, Color.DarkTurquoise.Name, () => { SetESPColor(Color.DarkTurquoise); }, Color.DarkTurquoise.Name, Color.DarkTurquoise);
            new QMSingleButton(CurrentScrollMenu, Color.DarkViolet.Name, () => { SetESPColor(Color.DarkViolet); }, Color.DarkViolet.Name, Color.DarkViolet);
            new QMSingleButton(CurrentScrollMenu, Color.DeepPink.Name, () => { SetESPColor(Color.DeepPink); }, Color.DeepPink.Name, Color.DeepPink);
            new QMSingleButton(CurrentScrollMenu, Color.DeepSkyBlue.Name, () => { SetESPColor(Color.DeepSkyBlue); }, Color.DeepSkyBlue.Name, Color.DeepSkyBlue);
            new QMSingleButton(CurrentScrollMenu, Color.DimGray.Name, () => { SetESPColor(Color.DimGray); }, Color.DimGray.Name, Color.DimGray);
            new QMSingleButton(CurrentScrollMenu, Color.DodgerBlue.Name, () => { SetESPColor(Color.DodgerBlue); }, Color.DodgerBlue.Name, Color.DodgerBlue);
            new QMSingleButton(CurrentScrollMenu, Color.Firebrick.Name, () => { SetESPColor(Color.Firebrick); }, Color.Firebrick.Name, Color.Firebrick);
            new QMSingleButton(CurrentScrollMenu, Color.FloralWhite.Name, () => { SetESPColor(Color.FloralWhite); }, Color.FloralWhite.Name, Color.FloralWhite);
            new QMSingleButton(CurrentScrollMenu, Color.ForestGreen.Name, () => { SetESPColor(Color.ForestGreen); }, Color.ForestGreen.Name, Color.ForestGreen);
            new QMSingleButton(CurrentScrollMenu, Color.Fuchsia.Name, () => { SetESPColor(Color.Fuchsia); }, Color.Fuchsia.Name, Color.Fuchsia);
            new QMSingleButton(CurrentScrollMenu, Color.Gainsboro.Name, () => { SetESPColor(Color.Gainsboro); }, Color.Gainsboro.Name, Color.Gainsboro);
            new QMSingleButton(CurrentScrollMenu, Color.GhostWhite.Name, () => { SetESPColor(Color.GhostWhite); }, Color.GhostWhite.Name, Color.GhostWhite);
            new QMSingleButton(CurrentScrollMenu, Color.Gold.Name, () => { SetESPColor(Color.Gold); }, Color.Gold.Name, Color.Gold);
            new QMSingleButton(CurrentScrollMenu, Color.Goldenrod.Name, () => { SetESPColor(Color.Goldenrod); }, Color.Goldenrod.Name, Color.Goldenrod);
            new QMSingleButton(CurrentScrollMenu, Color.Gray.Name, () => { SetESPColor(Color.Gray); }, Color.Gray.Name, Color.Gray);
            new QMSingleButton(CurrentScrollMenu, Color.Green.Name, () => { SetESPColor(Color.Green); }, Color.Green.Name, Color.Green);
            new QMSingleButton(CurrentScrollMenu, Color.GreenYellow.Name, () => { SetESPColor(Color.GreenYellow); }, Color.GreenYellow.Name, Color.GreenYellow);
            new QMSingleButton(CurrentScrollMenu, Color.Honeydew.Name, () => { SetESPColor(Color.Honeydew); }, Color.Honeydew.Name, Color.Honeydew);
            new QMSingleButton(CurrentScrollMenu, Color.HotPink.Name, () => { SetESPColor(Color.HotPink); }, Color.HotPink.Name, Color.HotPink);
            new QMSingleButton(CurrentScrollMenu, Color.IndianRed.Name, () => { SetESPColor(Color.IndianRed); }, Color.IndianRed.Name, Color.IndianRed);
            new QMSingleButton(CurrentScrollMenu, Color.Indigo.Name, () => { SetESPColor(Color.Indigo); }, Color.Indigo.Name, Color.Indigo);
            new QMSingleButton(CurrentScrollMenu, Color.Ivory.Name, () => { SetESPColor(Color.Ivory); }, Color.Ivory.Name, Color.Ivory);
            new QMSingleButton(CurrentScrollMenu, Color.Khaki.Name, () => { SetESPColor(Color.Khaki); }, Color.Khaki.Name, Color.Khaki);
            new QMSingleButton(CurrentScrollMenu, Color.Lavender.Name, () => { SetESPColor(Color.Lavender); }, Color.Lavender.Name, Color.Lavender);
            new QMSingleButton(CurrentScrollMenu, Color.LavenderBlush.Name, () => { SetESPColor(Color.LavenderBlush); }, Color.LavenderBlush.Name, Color.LavenderBlush);
            new QMSingleButton(CurrentScrollMenu, Color.LawnGreen.Name, () => { SetESPColor(Color.LawnGreen); }, Color.LawnGreen.Name, Color.LawnGreen);
            new QMSingleButton(CurrentScrollMenu, Color.LemonChiffon.Name, () => { SetESPColor(Color.LemonChiffon); }, Color.LemonChiffon.Name, Color.LemonChiffon);
            new QMSingleButton(CurrentScrollMenu, Color.LightBlue.Name, () => { SetESPColor(Color.LightBlue); }, Color.LightBlue.Name, Color.LightBlue);
            new QMSingleButton(CurrentScrollMenu, Color.LightCoral.Name, () => { SetESPColor(Color.LightCoral); }, Color.LightCoral.Name, Color.LightCoral);
            new QMSingleButton(CurrentScrollMenu, Color.LightCyan.Name, () => { SetESPColor(Color.LightCyan); }, Color.LightCyan.Name, Color.LightCyan);
            new QMSingleButton(CurrentScrollMenu, Color.LightGoldenrodYellow.Name, () => { SetESPColor(Color.LightGoldenrodYellow); }, Color.LightGoldenrodYellow.Name, Color.LightGoldenrodYellow);
            new QMSingleButton(CurrentScrollMenu, Color.LightGreen.Name, () => { SetESPColor(Color.LightGreen); }, Color.LightGreen.Name, Color.LightGreen);
            new QMSingleButton(CurrentScrollMenu, Color.LightGray.Name, () => { SetESPColor(Color.LightGray); }, Color.LightGray.Name, Color.LightGray);
            new QMSingleButton(CurrentScrollMenu, Color.LightPink.Name, () => { SetESPColor(Color.LightPink); }, Color.LightPink.Name, Color.LightPink);
            new QMSingleButton(CurrentScrollMenu, Color.LightSalmon.Name, () => { SetESPColor(Color.LightSalmon); }, Color.LightSalmon.Name, Color.LightSalmon);
            new QMSingleButton(CurrentScrollMenu, Color.LightSeaGreen.Name, () => { SetESPColor(Color.LightSeaGreen); }, Color.LightSeaGreen.Name, Color.LightSeaGreen);
            new QMSingleButton(CurrentScrollMenu, Color.LightSkyBlue.Name, () => { SetESPColor(Color.LightSkyBlue); }, Color.LightSkyBlue.Name, Color.LightSkyBlue);
            new QMSingleButton(CurrentScrollMenu, Color.LightSlateGray.Name, () => { SetESPColor(Color.LightSlateGray); }, Color.LightSlateGray.Name, Color.LightSlateGray);
            new QMSingleButton(CurrentScrollMenu, Color.LightSteelBlue.Name, () => { SetESPColor(Color.LightSteelBlue); }, Color.LightSteelBlue.Name, Color.LightSteelBlue);
            new QMSingleButton(CurrentScrollMenu, Color.LightYellow.Name, () => { SetESPColor(Color.LightYellow); }, Color.LightYellow.Name, Color.LightYellow);
            new QMSingleButton(CurrentScrollMenu, Color.Lime.Name, () => { SetESPColor(Color.Lime); }, Color.Lime.Name, Color.Lime);
            new QMSingleButton(CurrentScrollMenu, Color.LimeGreen.Name, () => { SetESPColor(Color.LimeGreen); }, Color.LimeGreen.Name, Color.LimeGreen);
            new QMSingleButton(CurrentScrollMenu, Color.Linen.Name, () => { SetESPColor(Color.Linen); }, Color.Linen.Name, Color.Linen);
            new QMSingleButton(CurrentScrollMenu, Color.Magenta.Name, () => { SetESPColor(Color.Magenta); }, Color.Magenta.Name, Color.Magenta);
            new QMSingleButton(CurrentScrollMenu, Color.Maroon.Name, () => { SetESPColor(Color.Maroon); }, Color.Maroon.Name, Color.Maroon);
            new QMSingleButton(CurrentScrollMenu, Color.MediumAquamarine.Name, () => { SetESPColor(Color.MediumAquamarine); }, Color.MediumAquamarine.Name, Color.MediumAquamarine);
            new QMSingleButton(CurrentScrollMenu, Color.MediumBlue.Name, () => { SetESPColor(Color.MediumBlue); }, Color.MediumBlue.Name, Color.MediumBlue);
            new QMSingleButton(CurrentScrollMenu, Color.MediumOrchid.Name, () => { SetESPColor(Color.MediumOrchid); }, Color.MediumOrchid.Name, Color.MediumOrchid);
            new QMSingleButton(CurrentScrollMenu, Color.MediumPurple.Name, () => { SetESPColor(Color.MediumPurple); }, Color.MediumPurple.Name, Color.MediumPurple);
            new QMSingleButton(CurrentScrollMenu, Color.MediumSeaGreen.Name, () => { SetESPColor(Color.MediumSeaGreen); }, Color.MediumSeaGreen.Name, Color.MediumSeaGreen);
            new QMSingleButton(CurrentScrollMenu, Color.MediumSlateBlue.Name, () => { SetESPColor(Color.MediumSlateBlue); }, Color.MediumSlateBlue.Name, Color.MediumSlateBlue);
            new QMSingleButton(CurrentScrollMenu, Color.MediumSpringGreen.Name, () => { SetESPColor(Color.MediumSpringGreen); }, Color.MediumSpringGreen.Name, Color.MediumSpringGreen);
            new QMSingleButton(CurrentScrollMenu, Color.MediumTurquoise.Name, () => { SetESPColor(Color.MediumTurquoise); }, Color.MediumTurquoise.Name, Color.MediumTurquoise);
            new QMSingleButton(CurrentScrollMenu, Color.MediumVioletRed.Name, () => { SetESPColor(Color.MediumVioletRed); }, Color.MediumVioletRed.Name, Color.MediumVioletRed);
            new QMSingleButton(CurrentScrollMenu, Color.MidnightBlue.Name, () => { SetESPColor(Color.MidnightBlue); }, Color.MidnightBlue.Name, Color.MidnightBlue);
            new QMSingleButton(CurrentScrollMenu, Color.MintCream.Name, () => { SetESPColor(Color.MintCream); }, Color.MintCream.Name, Color.MintCream);
            new QMSingleButton(CurrentScrollMenu, Color.MistyRose.Name, () => { SetESPColor(Color.MistyRose); }, Color.MistyRose.Name, Color.MistyRose);
            new QMSingleButton(CurrentScrollMenu, Color.Moccasin.Name, () => { SetESPColor(Color.Moccasin); }, Color.Moccasin.Name, Color.Moccasin);
            new QMSingleButton(CurrentScrollMenu, Color.NavajoWhite.Name, () => { SetESPColor(Color.NavajoWhite); }, Color.NavajoWhite.Name, Color.NavajoWhite);
            new QMSingleButton(CurrentScrollMenu, Color.Navy.Name, () => { SetESPColor(Color.Navy); }, Color.Navy.Name, Color.Navy);
            new QMSingleButton(CurrentScrollMenu, Color.OldLace.Name, () => { SetESPColor(Color.OldLace); }, Color.OldLace.Name, Color.OldLace);
            new QMSingleButton(CurrentScrollMenu, Color.Olive.Name, () => { SetESPColor(Color.Olive); }, Color.Olive.Name, Color.Olive);
            new QMSingleButton(CurrentScrollMenu, Color.OliveDrab.Name, () => { SetESPColor(Color.OliveDrab); }, Color.OliveDrab.Name, Color.OliveDrab);
            new QMSingleButton(CurrentScrollMenu, Color.Orange.Name, () => { SetESPColor(Color.Orange); }, Color.Orange.Name, Color.Orange);
            new QMSingleButton(CurrentScrollMenu, Color.OrangeRed.Name, () => { SetESPColor(Color.OrangeRed); }, Color.OrangeRed.Name, Color.OrangeRed);
            new QMSingleButton(CurrentScrollMenu, Color.Orchid.Name, () => { SetESPColor(Color.Orchid); }, Color.Orchid.Name, Color.Orchid);
            new QMSingleButton(CurrentScrollMenu, Color.PaleGoldenrod.Name, () => { SetESPColor(Color.PaleGoldenrod); }, Color.PaleGoldenrod.Name, Color.PaleGoldenrod);
            new QMSingleButton(CurrentScrollMenu, Color.PaleGreen.Name, () => { SetESPColor(Color.PaleGreen); }, Color.PaleGreen.Name, Color.PaleGreen);
            new QMSingleButton(CurrentScrollMenu, Color.PaleTurquoise.Name, () => { SetESPColor(Color.PaleTurquoise); }, Color.PaleTurquoise.Name, Color.PaleTurquoise);
            new QMSingleButton(CurrentScrollMenu, Color.PaleVioletRed.Name, () => { SetESPColor(Color.PaleVioletRed); }, Color.PaleVioletRed.Name, Color.PaleVioletRed);
            new QMSingleButton(CurrentScrollMenu, Color.PapayaWhip.Name, () => { SetESPColor(Color.PapayaWhip); }, Color.PapayaWhip.Name, Color.PapayaWhip);
            new QMSingleButton(CurrentScrollMenu, Color.PeachPuff.Name, () => { SetESPColor(Color.PeachPuff); }, Color.PeachPuff.Name, Color.PeachPuff);
            new QMSingleButton(CurrentScrollMenu, Color.Peru.Name, () => { SetESPColor(Color.Peru); }, Color.Peru.Name, Color.Peru);
            new QMSingleButton(CurrentScrollMenu, Color.Pink.Name, () => { SetESPColor(Color.Pink); }, Color.Pink.Name, Color.Pink);
            new QMSingleButton(CurrentScrollMenu, Color.Plum.Name, () => { SetESPColor(Color.Plum); }, Color.Plum.Name, Color.Plum);
            new QMSingleButton(CurrentScrollMenu, Color.PowderBlue.Name, () => { SetESPColor(Color.PowderBlue); }, Color.PowderBlue.Name, Color.PowderBlue);
            new QMSingleButton(CurrentScrollMenu, Color.Purple.Name, () => { SetESPColor(Color.Purple); }, Color.Purple.Name, Color.Purple);
            new QMSingleButton(CurrentScrollMenu, Color.Red.Name, () => { SetESPColor(Color.Red); }, Color.Red.Name, Color.Red);
            new QMSingleButton(CurrentScrollMenu, Color.RosyBrown.Name, () => { SetESPColor(Color.RosyBrown); }, Color.RosyBrown.Name, Color.RosyBrown);
            new QMSingleButton(CurrentScrollMenu, Color.RoyalBlue.Name, () => { SetESPColor(Color.RoyalBlue); }, Color.RoyalBlue.Name, Color.RoyalBlue);
            new QMSingleButton(CurrentScrollMenu, Color.SaddleBrown.Name, () => { SetESPColor(Color.SaddleBrown); }, Color.SaddleBrown.Name, Color.SaddleBrown);
            new QMSingleButton(CurrentScrollMenu, Color.Salmon.Name, () => { SetESPColor(Color.Salmon); }, Color.Salmon.Name, Color.Salmon);
            new QMSingleButton(CurrentScrollMenu, Color.SandyBrown.Name, () => { SetESPColor(Color.SandyBrown); }, Color.SandyBrown.Name, Color.SandyBrown);
            new QMSingleButton(CurrentScrollMenu, Color.SeaGreen.Name, () => { SetESPColor(Color.SeaGreen); }, Color.SeaGreen.Name, Color.SeaGreen);
            new QMSingleButton(CurrentScrollMenu, Color.SeaShell.Name, () => { SetESPColor(Color.SeaShell); }, Color.SeaShell.Name, Color.SeaShell);
            new QMSingleButton(CurrentScrollMenu, Color.Sienna.Name, () => { SetESPColor(Color.Sienna); }, Color.Sienna.Name, Color.Sienna);
            new QMSingleButton(CurrentScrollMenu, Color.Silver.Name, () => { SetESPColor(Color.Silver); }, Color.Silver.Name, Color.Silver);
            new QMSingleButton(CurrentScrollMenu, Color.SkyBlue.Name, () => { SetESPColor(Color.SkyBlue); }, Color.SkyBlue.Name, Color.SkyBlue);
            new QMSingleButton(CurrentScrollMenu, Color.SlateBlue.Name, () => { SetESPColor(Color.SlateBlue); }, Color.SlateBlue.Name, Color.SlateBlue);
            new QMSingleButton(CurrentScrollMenu, Color.SlateGray.Name, () => { SetESPColor(Color.SlateGray); }, Color.SlateGray.Name, Color.SlateGray);
            new QMSingleButton(CurrentScrollMenu, Color.Snow.Name, () => { SetESPColor(Color.Snow); }, Color.Snow.Name, Color.Snow);
            new QMSingleButton(CurrentScrollMenu, Color.SpringGreen.Name, () => { SetESPColor(Color.SpringGreen); }, Color.SpringGreen.Name, Color.SpringGreen);
            new QMSingleButton(CurrentScrollMenu, Color.SteelBlue.Name, () => { SetESPColor(Color.SteelBlue); }, Color.SteelBlue.Name, Color.SteelBlue);
            new QMSingleButton(CurrentScrollMenu, Color.Tan.Name, () => { SetESPColor(Color.Tan); }, Color.Tan.Name, Color.Tan);
            new QMSingleButton(CurrentScrollMenu, Color.Teal.Name, () => { SetESPColor(Color.Teal); }, Color.Teal.Name, Color.Teal);
            new QMSingleButton(CurrentScrollMenu, Color.Thistle.Name, () => { SetESPColor(Color.Thistle); }, Color.Thistle.Name, Color.Thistle);
            new QMSingleButton(CurrentScrollMenu, Color.Tomato.Name, () => { SetESPColor(Color.Tomato); }, Color.Tomato.Name, Color.Tomato);
            new QMSingleButton(CurrentScrollMenu, Color.Turquoise.Name, () => { SetESPColor(Color.Turquoise); }, Color.Turquoise.Name, Color.Turquoise);
            new QMSingleButton(CurrentScrollMenu, Color.Violet.Name, () => { SetESPColor(Color.Violet); }, Color.Violet.Name, Color.Violet);
            new QMSingleButton(CurrentScrollMenu, Color.Wheat.Name, () => { SetESPColor(Color.Wheat); }, Color.Wheat.Name, Color.Wheat);
            new QMSingleButton(CurrentScrollMenu, Color.White.Name, () => { SetESPColor(Color.White); }, Color.White.Name, Color.White);
            new QMSingleButton(CurrentScrollMenu, Color.WhiteSmoke.Name, () => { SetESPColor(Color.WhiteSmoke); }, Color.WhiteSmoke.Name, Color.WhiteSmoke);
            new QMSingleButton(CurrentScrollMenu, Color.Yellow.Name, () => { SetESPColor(Color.Yellow); }, Color.Yellow.Name, Color.Yellow);
            new QMSingleButton(CurrentScrollMenu, Color.YellowGreen.Name, () => { SetESPColor(Color.YellowGreen); }, Color.YellowGreen.Name, Color.YellowGreen);
        }


        private static void SetESPColor(Color color)
        {
            if (SetPublicESP) ConfigManager.PublicESPColor = color.ToUnityEngineColor();
            if (SetFriendESP) ConfigManager.ESPFriendColor = color.ToUnityEngineColor();
            if (SetBlockedESP) ConfigManager.ESPBlockedColor = color.ToUnityEngineColor();
        }


        private void OnQuickMenuClose()
        {
            OnCloseMenu();
        }

        private static void OnCloseMenu()
        {
            IsUIPageListenerActive = false;
            isOpen = false;
            if (WingMenu != null)
            {
                
                WingMenu.SetActive(false);
            }
        }

        private static void OnOpenMenu()
        {
            isOpen = true;
            if (WingMenu != null)
            {
                WingMenu.SetActive(true);
                WingMenu.ShowWingsPage();
            }
            IsUIPageListenerActive = true;
        }

        private static void OnUiPageToggled(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType, bool Toggle2)
        {
            if (!isOpen) return;

            if (Page != null)
                if (!Page.isPage(CurrentScrollMenu.GetPage()) )
                    OnCloseMenu();
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(1021, true, "Color Selection ESP", "Edit ESP Colors");
            PublicESPSettingsToggle = new QMWingToggleButton(WingMenu, "Public ESP", () => { SetPublicESP = true; }, () => { SetPublicESP = false; }, "Set Public ESP Color.");
            FriendESPSettingToggle = new QMWingToggleButton(WingMenu, "Friend ESP", () => { SetFriendESP = true; }, () => { SetFriendESP = false; }, "Set Friend ESP Color.");
            BlockedESPSettingToggle = new QMWingToggleButton(WingMenu, "Blocked ESP", () => { SetBlockedESP = true; }, () => { SetBlockedESP = false; }, "Set Blocked ESP Color.");
            WingMenu.SetActive(false);
        }
    }
}