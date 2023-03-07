namespace AstroClient.ClientResources.Loaders
{
    using System.Reflection;
    using CheetoLibrary.Utility;
    using ClientAttributes;
    using Helpers;
    using Paths;
    using UnhollowerRuntimeLib;
    using UnityEngine;

    internal static class Shaders
    {
        //private static Shader _testShader;

        ///// <summary>
        ///// Loads TestShader bundle in resources as Shader
        ///// </summary>
        //internal static Shader testShader
        //{
        //    get
        //    {
        //        if (_testShader == null)
        //        {
        //            _testShader = Bundles.waffle.LoadAsset_Internal("assets/Shaders/TestShader.shader", Il2CppType.Of<Shader>()).Cast<Shader>();
        //            _testShader.hideFlags |= HideFlags.DontUnloadUnusedAsset;
        //            return _testShader;
        //        }

        //        return _testShader;
        //    }
        //}


        private static Shader _highlightadddepth;



     internal static Shader highlightadddepth
	{
		get
		{
			if (_highlightadddepth == null)
			{
				_highlightadddepth = Bundles.highlightfx.LoadAsset_Internal("assets/highlightplus/resources/highlightplus/highlightadddepth.shader", Il2CppType.Of<Shader>()).Cast<Shader>();
				_highlightadddepth.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			}

			return _highlightadddepth;
		}
	}
        private static Shader _highlightadddepthclip;

        internal static Shader highlightadddepthclip
	{
		get
		{
			if (_highlightadddepthclip == null)
			{
				_highlightadddepthclip = Bundles.highlightfx.LoadAsset_Internal("assets/highlightplus/resources/highlightplus/highlightadddepthclip.shader", Il2CppType.Of<Shader>()).Cast<Shader>();
				_highlightadddepthclip.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			}

			return _highlightadddepthclip;
		}
	}
        private static Shader _highlightblurglow;

        internal static Shader highlightblurglow
	{
		get
		{
			if (_highlightblurglow == null)
			{
				_highlightblurglow = Bundles.highlightfx.LoadAsset_Internal("assets/highlightplus/resources/highlightplus/highlightblurglow.shader", Il2CppType.Of<Shader>()).Cast<Shader>();
				_highlightblurglow.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			}

			return _highlightblurglow;
		}
	}
        private static Shader _highlightbluroutline;

        internal static Shader highlightbluroutline
	{
		get
		{
			if (_highlightbluroutline == null)
			{
				_highlightbluroutline = Bundles.highlightfx.LoadAsset_Internal("assets/highlightplus/resources/highlightplus/highlightbluroutline.shader", Il2CppType.Of<Shader>()).Cast<Shader>();
				_highlightbluroutline.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			}

			return _highlightbluroutline;
		}
	}
        private static Shader _highlightclearstencil;

        internal static Shader highlightclearstencil
	{
		get
		{
			if (_highlightclearstencil == null)
			{
				_highlightclearstencil = Bundles.highlightfx.LoadAsset_Internal("assets/highlightplus/resources/highlightplus/highlightclearstencil.shader", Il2CppType.Of<Shader>()).Cast<Shader>();
				_highlightclearstencil.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			}

			return _highlightclearstencil;
		}
	}
        private static Shader _highlightcomposeglow;

        internal static Shader highlightcomposeglow
	{
		get
		{
			if (_highlightcomposeglow == null)
			{
				_highlightcomposeglow = Bundles.highlightfx.LoadAsset_Internal("assets/highlightplus/resources/highlightplus/highlightcomposeglow.shader", Il2CppType.Of<Shader>()).Cast<Shader>();
				_highlightcomposeglow.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			}

			return _highlightcomposeglow;
		}
	}
        private static Shader _highlightcomposeoutline;

        internal static Shader highlightcomposeoutline
	{
		get
		{
			if (_highlightcomposeoutline == null)
			{
				_highlightcomposeoutline = Bundles.highlightfx.LoadAsset_Internal("assets/highlightplus/resources/highlightplus/highlightcomposeoutline.shader", Il2CppType.Of<Shader>()).Cast<Shader>();
				_highlightcomposeoutline.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			}

			return _highlightcomposeoutline;
		}
	}
        private static Shader _highlightglow;

        internal static Shader highlightglow
	{
		get
		{
			if (_highlightglow == null)
			{
				_highlightglow = Bundles.highlightfx.LoadAsset_Internal("assets/highlightplus/resources/highlightplus/highlightglow.shader", Il2CppType.Of<Shader>()).Cast<Shader>();
				_highlightglow.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			}

			return _highlightglow;
		}
	}
        private static Shader _highlightinnerglow;

        internal static Shader highlightinnerglow
	{
		get
		{
			if (_highlightinnerglow == null)
			{
				_highlightinnerglow = Bundles.highlightfx.LoadAsset_Internal("assets/highlightplus/resources/highlightplus/highlightinnerglow.shader", Il2CppType.Of<Shader>()).Cast<Shader>();
				_highlightinnerglow.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			}

			return _highlightinnerglow;
		}
	}
        private static Shader _highlightmask;

        internal static Shader highlightmask
	{
		get
		{
			if (_highlightmask == null)
			{
				_highlightmask = Bundles.highlightfx.LoadAsset_Internal("assets/highlightplus/resources/highlightplus/highlightmask.shader", Il2CppType.Of<Shader>()).Cast<Shader>();
				_highlightmask.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			}

			return _highlightmask;
		}
	}
        private static Shader _highlightoccluder;

        internal static Shader highlightoccluder
	{
		get
		{
			if (_highlightoccluder == null)
			{
				_highlightoccluder = Bundles.highlightfx.LoadAsset_Internal("assets/highlightplus/resources/highlightplus/highlightoccluder.shader", Il2CppType.Of<Shader>()).Cast<Shader>();
				_highlightoccluder.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			}

			return _highlightoccluder;
		}
	}
        private static Shader _highlightoutline;

        internal static Shader highlightoutline
	{
		get
		{
			if (_highlightoutline == null)
			{
				_highlightoutline = Bundles.highlightfx.LoadAsset_Internal("assets/highlightplus/resources/highlightplus/highlightoutline.shader", Il2CppType.Of<Shader>()).Cast<Shader>();
				_highlightoutline.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			}

			return _highlightoutline;
		}
	}
        private static Shader _highlightoverlay;

        internal static Shader highlightoverlay
	{
		get
		{
			if (_highlightoverlay == null)
			{
				_highlightoverlay = Bundles.highlightfx.LoadAsset_Internal("assets/highlightplus/resources/highlightplus/highlightoverlay.shader", Il2CppType.Of<Shader>()).Cast<Shader>();
				_highlightoverlay.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			}

			return _highlightoverlay;
		}
	}
        private static Shader _highlightseethroughborder;

        internal static Shader highlightseethroughborder
	{
		get
		{
			if (_highlightseethroughborder == null)
			{
				_highlightseethroughborder = Bundles.highlightfx.LoadAsset_Internal("assets/highlightplus/resources/highlightplus/highlightseethroughborder.shader", Il2CppType.Of<Shader>()).Cast<Shader>();
				_highlightseethroughborder.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			}

			return _highlightseethroughborder;
		}
	}
        private static Shader _highlightseethroughinner;

        internal static Shader highlightseethroughinner
	{
		get
		{
			if (_highlightseethroughinner == null)
			{
				_highlightseethroughinner = Bundles.highlightfx.LoadAsset_Internal("assets/highlightplus/resources/highlightplus/highlightseethroughinner.shader", Il2CppType.Of<Shader>()).Cast<Shader>();
				_highlightseethroughinner.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			}

			return _highlightseethroughinner;
		}
	}
        private static Shader _highlightseethroughmask;

        internal static Shader highlightseethroughmask
	{
		get
		{
			if (_highlightseethroughmask == null)
			{
				_highlightseethroughmask = Bundles.highlightfx.LoadAsset_Internal("assets/highlightplus/resources/highlightplus/highlightseethroughmask.shader", Il2CppType.Of<Shader>()).Cast<Shader>();
				_highlightseethroughmask.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			}

			return _highlightseethroughmask;
		}
	}
        private static Shader _highlightsolidcolor;

        internal static Shader highlightsolidcolor
	{
		get
		{
			if (_highlightsolidcolor == null)
			{
				_highlightsolidcolor = Bundles.highlightfx.LoadAsset_Internal("assets/highlightplus/resources/highlightplus/highlightsolidcolor.shader", Il2CppType.Of<Shader>()).Cast<Shader>();
				_highlightsolidcolor.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			}

			return _highlightsolidcolor;
		}
	}
        private static Shader _highlighttarget;

        internal static Shader highlighttarget
	{
		get
		{
			if (_highlighttarget == null)
			{
				_highlighttarget = Bundles.highlightfx.LoadAsset_Internal("assets/highlightplus/resources/highlightplus/highlighttarget.shader", Il2CppType.Of<Shader>()).Cast<Shader>();
				_highlighttarget.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			}

			return _highlighttarget;
		}
	}
        private static Shader _highlightuimask;

        internal static Shader highlightuimask
	{
		get
		{
			if (_highlightuimask == null)
			{
				_highlightuimask = Bundles.highlightfx.LoadAsset_Internal("assets/highlightplus/resources/highlightplus/highlightuimask.shader", Il2CppType.Of<Shader>()).Cast<Shader>();
				_highlightuimask.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			}

			return _highlightuimask;
		}
	}



    }
}