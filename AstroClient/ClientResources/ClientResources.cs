namespace AstroClient.ClientResources
{
    using System.Reflection;
    using CheetoLibrary.Utility;
    using UnityEngine;

    internal static class ClientResources
    {


        #region 1.png
        private static Texture2D _one;
        private static Sprite _one_sprite;

        /// <summary>
        ///     Loads 1.png in resources as Texture2D
        /// </summary>
        internal static Texture2D one
        {
            get
            {
                if (_one == null)
                {
                    _one = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.1.png"));
                    _one.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _one;
                }

                return _one;
            }
        }


        /// <summary>
        ///     Loads 1.png in resources as sprite
        /// </summary>
        internal static Sprite one_sprite
        {
            get
            {
                if (_one_sprite == null)
                {
                    _one_sprite = one.ToSprite();
                    _one_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _one_sprite;
                }

                return _one_sprite;
            }
        }


        #endregion
        #region 2.png
        private static Texture2D _two;
        private static Sprite _two_sprite;

        /// <summary>
        ///     Loads 2.png in resources as Texture2D
        /// </summary>
        internal static Texture2D two
        {
            get
            {
                if (_two == null)
                {
                    _two = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.2.png"));
                    _two.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _two;
                }

                return _two;
            }
        }


        /// <summary>
        ///     Loads 2.png in resources as sprite
        /// </summary>
        internal static Sprite two_sprite
        {
            get
            {
                if (_two_sprite == null)
                {
                    _two_sprite = two.ToSprite();
                    _two_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _two_sprite;
                }

                return _two_sprite;
            }
        }


        #endregion
        #region 3.png
        private static Texture2D _three;
        private static Sprite _three_sprite;

        /// <summary>
        ///     Loads 3.png in resources as Texture3D
        /// </summary>
        internal static Texture2D three
        {
            get
            {
                if (_three == null)
                {
                    _three = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.3.png"));
                    _three.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _three;
                }

                return _three;
            }
        }


        /// <summary>
        ///     Loads 3.png in resources as sprite
        /// </summary>
        internal static Sprite three_sprite
        {
            get
            {
                if (_three_sprite == null)
                {
                    _three_sprite = three.ToSprite();
                    _three_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _three_sprite;
                }

                return _three_sprite;
            }
        }


        #endregion
        #region 4.png
        private static Texture2D _four;
        private static Sprite _four_sprite;

        /// <summary>
        ///     Loads 4.png in resources as Texture2D
        /// </summary>
        internal static Texture2D four
        {
            get
            {
                if (_four == null)
                {
                    _four = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.4.png"));
                    _four.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _four;
                }

                return _four;
            }
        }


        /// <summary>
        ///     Loads 4.png in resources as sprite
        /// </summary>
        internal static Sprite four_sprite
        {
            get
            {
                if (_four_sprite == null)
                {
                    _four_sprite = four.ToSprite();
                    _four_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _four_sprite;
                }

                return _four_sprite;
            }
        }


        #endregion
        #region 5.png
        private static Texture2D _five;
        private static Sprite _five_sprite;

        /// <summary>
        ///     Loads 5.png in resources as Texture2D
        /// </summary>
        internal static Texture2D five
        {
            get
            {
                if (_five == null)
                {
                    _five = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.5.png"));
                    _five.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _five;
                }

                return _five;
            }
        }


        /// <summary>
        ///     Loads 5.png in resources as sprite
        /// </summary>
        internal static Sprite five_sprite
        {
            get
            {
                if (_five_sprite == null)
                {
                    _five_sprite = five.ToSprite();
                    _five_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _five_sprite;
                }

                return _five_sprite;
            }
        }


        #endregion
        #region 6.png
        private static Texture2D _six;
        private static Sprite _six_sprite;

        /// <summary>
        ///     Loads 6.png in resources as Texture2D
        /// </summary>
        internal static Texture2D six
        {
            get
            {
                if (_six == null)
                {
                    _six = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.6.png"));
                    _six.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _six;
                }

                return _six;
            }
        }


        /// <summary>
        ///     Loads 6.png in resources as sprite
        /// </summary>
        internal static Sprite six_sprite
        {
            get
            {
                if (_six_sprite == null)
                {
                    _six_sprite = six.ToSprite();
                    _six_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _six_sprite;
                }

                return _six_sprite;
            }
        }


        #endregion
        #region 7.png
        private static Texture2D _seven;
        private static Sprite _seven_sprite;

        /// <summary>
        ///     Loads 7.png in resources as Texture2D
        /// </summary>
        internal static Texture2D seven
        {
            get
            {
                if (_seven == null)
                {
                    _seven = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.7.png"));
                    _seven.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _seven;
                }

                return _seven;
            }
        }


        /// <summary>
        ///     Loads 7.png in resources as sprite
        /// </summary>
        internal static Sprite seven_sprite
        {
            get
            {
                if (_seven_sprite == null)
                {
                    _seven_sprite = seven.ToSprite();
                    _seven_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _seven_sprite;
                }

                return _seven_sprite;
            }
        }


        #endregion
        #region badge.png
        private static Texture2D _badge;
        private static Sprite _badge_sprite;

        /// <summary>
        ///     Loads badge.png in resources as Texture2D
        /// </summary>
        internal static Texture2D badge
        {
            get
            {
                if (_badge == null)
                {
                    _badge = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.badge.png"));
                    _badge.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _badge;
                }

                return _badge;
            }
        }


        /// <summary>
        ///     Loads badge.png in resources as sprite
        /// </summary>
        internal static Sprite badge_sprite
        {
            get
            {
                if (_badge_sprite == null)
                {
                    _badge_sprite = badge.ToSprite();
                    _badge_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _badge_sprite;
                }

                return _badge_sprite;
            }
        }


        #endregion
        #region blank.png
        private static Texture2D _blank;
        private static Sprite _blank_sprite;

        /// <summary>
        ///     Loads blank.png in resources as Texture2D
        /// </summary>
        internal static Texture2D blank
        {
            get
            {
                if (_blank == null)
                {
                    _blank = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.blank.png"));
                    _blank.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _blank;
                }

                return _blank;
            }
        }


        /// <summary>
        ///     Loads blank.png in resources as sprite
        /// </summary>
        internal static Sprite blank_sprite
        {
            get
            {
                if (_blank_sprite == null)
                {
                    _blank_sprite = blank.ToSprite();
                    _blank_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _blank_sprite;
                }

                return _blank_sprite;
            }
        }


        #endregion
        #region box.png
        private static Texture2D _box;
        private static Sprite _box_sprite;

        /// <summary>
        ///     Loads box.png in resources as Texture2D
        /// </summary>
        internal static Texture2D box
        {
            get
            {
                if (_box == null)
                {
                    _box = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.box.png"));
                    _box.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _box;
                }

                return _box;
            }
        }


        /// <summary>
        ///     Loads box.png in resources as sprite
        /// </summary>
        internal static Sprite box_sprite
        {
            get
            {
                if (_box_sprite == null)
                {
                    _box_sprite = box.ToSprite();
                    _box_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _box_sprite;
                }

                return _box_sprite;
            }
        }


        #endregion        /// <summary>
        #region button.png
        private static Texture2D _button;
        private static Sprite _button_sprite;

        /// <summary>
        ///     Loads button.png in resources as Texture2D
        /// </summary>
        internal static Texture2D button
        {
            get
            {
                if (_button == null)
                {
                    _button = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.button.png"));
                    _button.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _button;
                }

                return _button;
            }
        }


        /// <summary>
        ///     Loads button.png in resources as sprite
        /// </summary>
        internal static Sprite button_sprite
        {
            get
            {
                if (_button_sprite == null)
                {
                    _button_sprite = button.ToSprite();
                    _button_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _button_sprite;
                }

                return _button_sprite;
            }
        }


        #endregion
        #region cancel.png
        private static Texture2D _cancel;
        private static Sprite _cancel_sprite;

        /// <summary>
        ///     Loads cancel.png in resources as Texture2D
        /// </summary>
        internal static Texture2D cancel
        {
            get
            {
                if (_cancel == null)
                {
                    _cancel = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.cancel.png"));
                    _cancel.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _cancel;
                }

                return _cancel;
            }
        }


        /// <summary>
        ///     Loads cancel.png in resources as sprite
        /// </summary>
        internal static Sprite cancel_sprite
        {
            get
            {
                if (_cancel_sprite == null)
                {
                    _cancel_sprite = cancel.ToSprite();
                    _cancel_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _cancel_sprite;
                }

                return _cancel_sprite;
            }
        }


        #endregion
        #region check.png
        private static Texture2D _check;
        private static Sprite _check_sprite;

        /// <summary>
        ///     Loads check.png in resources as Texture2D
        /// </summary>
        internal static Texture2D check
        {
            get
            {
                if (_check == null)
                {
                    _check = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.check.png"));
                    _check.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _check;
                }

                return _check;
            }
        }


        /// <summary>
        ///     Loads check.png in resources as sprite
        /// </summary>
        internal static Sprite check_sprite
        {
            get
            {
                if (_check_sprite == null)
                {
                    _check_sprite = check.ToSprite();
                    _check_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _check_sprite;
                }

                return _check_sprite;
            }
        }


        #endregion        /// <summary>
        #region history.png
        private static Texture2D _history;
        private static Sprite _history_sprite;

        /// <summary>
        ///     Loads history.png in resources as Texture2D
        /// </summary>
        internal static Texture2D history
        {
            get
            {
                if (_history == null)
                {
                    _history = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.history.png"));
                    _history.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _history;
                }

                return _history;
            }
        }


        /// <summary>
        ///     Loads history.png in resources as sprite
        /// </summary>
        internal static Sprite history_sprite
        {
            get
            {
                if (_history_sprite == null)
                {
                    _history_sprite = history.ToSprite();
                    _history_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _history_sprite;
                }

                return _history_sprite;
            }
        }


        #endregion
        #region planet.png
        private static Texture2D _planet;
        private static Sprite _planet_sprite;

        /// <summary>
        ///     Loads planet.png in resources as Texture2D
        /// </summary>
        internal static Texture2D planet
        {
            get
            {
                if (_planet == null)
                {
                    _planet = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.planet.png"));
                    _planet.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _planet;
                }

                return _planet;
            }
        }


        /// <summary>
        ///     Loads planet.png in resources as sprite
        /// </summary>
        internal static Sprite planet_sprite
        {
            get
            {
                if (_planet_sprite == null)
                {
                    _planet_sprite = planet.ToSprite();
                    _planet_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _planet_sprite;
                }

                return _planet_sprite;
            }
        }


        #endregion
        #region repair.png
        private static Texture2D _repair;
        private static Sprite _repair_sprite;

        /// <summary>
        ///     Loads repair.png in resources as Texture2D
        /// </summary>
        internal static Texture2D repair
        {
            get
            {
                if (_repair == null)
                {
                    _repair = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.repair.png"));
                    _repair.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _repair;
                }

                return _repair;
            }
        }


        /// <summary>
        ///     Loads repair.png in resources as sprite
        /// </summary>
        internal static Sprite repair_sprite
        {
            get
            {
                if (_repair_sprite == null)
                {
                    _repair_sprite = repair.ToSprite();
                    _repair_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _repair_sprite;
                }

                return _repair_sprite;
            }
        }


        #endregion
        #region thief.png
        private static Texture2D _thief;
        private static Sprite _thief_sprite;

        /// <summary>
        ///     Loads thief.png in resources as Texture2D
        /// </summary>
        internal static Texture2D thief
        {
            get
            {
                if (_thief == null)
                {
                    _thief = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.thief.png"));
                    _thief.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _thief;
                }

                return _thief;
            }
        }


        /// <summary>
        ///     Loads thief.png in resources as sprite
        /// </summary>
        internal static Sprite thief_sprite
        {
            get
            {
                if (_thief_sprite == null)
                {
                    _thief_sprite = thief.ToSprite();
                    _thief_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _thief_sprite;
                }

                return _thief_sprite;
            }
        }


        #endregion        /// <summary>
        #region shuttle.png
        private static Texture2D _shuttle;
        private static Sprite _shuttle_sprite;

        /// <summary>
        ///     Loads shuttle.png in resources as Texture2D
        /// </summary>
        internal static Texture2D shuttle
        {
            get
            {
                if (_shuttle == null)
                {
                    _shuttle = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.shuttle.png"));
                    _shuttle.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _shuttle;
                }

                return _shuttle;
            }
        }


        /// <summary>
        ///     Loads shuttle.png in resources as sprite
        /// </summary>
        internal static Sprite shuttle_sprite
        {
            get
            {
                if (_shuttle_sprite == null)
                {
                    _shuttle_sprite = shuttle.ToSprite();
                    _shuttle_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _shuttle_sprite;
                }

                return _shuttle_sprite;
            }
        }


        #endregion
        #region save.png
        private static Texture2D _save;
        private static Sprite _save_sprite;

        /// <summary>
        ///     Loads save.png in resources as Texture2D
        /// </summary>
        internal static Texture2D save
        {
            get
            {
                if (_save == null)
                {
                    _save = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.save.png"));
                    _save.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _save;
                }

                return _save;
            }
        }


        /// <summary>
        ///     Loads save.png in resources as sprite
        /// </summary>
        internal static Sprite save_sprite
        {
            get
            {
                if (_save_sprite == null)
                {
                    _save_sprite = save.ToSprite();
                    _save_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _save_sprite;
                }

                return _save_sprite;
            }
        }


        #endregion
        #region locked.png
        private static Texture2D _locked;
        private static Sprite _locked_sprite;

        /// <summary>
        ///     Loads locked.png in resources as Texture2D
        /// </summary>
        internal static Texture2D locked
        {
            get
            {
                if (_locked == null)
                {
                    _locked = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.locked.png"));
                    _locked.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _locked;
                }

                return _locked;
            }
        }


        /// <summary>
        ///     Loads locked.png in resources as sprite
        /// </summary>
        internal static Sprite locked_sprite
        {
            get
            {
                if (_locked_sprite == null)
                {
                    _locked_sprite = locked.ToSprite();
                    _locked_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _locked_sprite;
                }

                return _locked_sprite;
            }
        }


        #endregion
        #region unlocked.png
        private static Texture2D _unlocked;
        private static Sprite _unlocked_sprite;

        /// <summary>
        ///     Loads unlocked.png in resources as Texture2D
        /// </summary>
        internal static Texture2D unlocked
        {
            get
            {
                if (_unlocked == null)
                {
                    _unlocked = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.unlocked.png"));
                    _unlocked.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _unlocked;
                }

                return _unlocked;
            }
        }


        /// <summary>
        ///     Loads unlocked.png in resources as sprite
        /// </summary>
        internal static Sprite unlocked_sprite
        {
            get
            {
                if (_unlocked_sprite == null)
                {
                    _unlocked_sprite = unlocked.ToSprite();
                    _unlocked_sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    return _unlocked_sprite;
                }

                return _unlocked_sprite;
            }
        }


        #endregion

    }
}
