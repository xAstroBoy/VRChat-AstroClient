

namespace AstroClient.Tools.Skybox.SkyboxClasses
{
    using System;
    using System.Text;
    using CheetoLibrary.Utility;
    using MaterialBuilders;
    using AstroClient.xAstroBoy.Extensions;
    using UnityEngine;
    using System.Collections;

    /// <summary>
    /// This will Convert any Skybox To 6 Sided and clamp their textures, to make life easier.
    /// </summary>
    internal class GeneratedSkyboxes
    {
        internal Texture2D Up { get; set; }

        internal Texture2D Down { get; set; }

        internal Texture2D Back { get; set; }

        internal Texture2D Front { get; set; }

        internal Texture2D Left { get; set; }

        internal Texture2D Right { get; set; }

        internal string Texture_Path_Up { get; set; }
                 
        internal string Texture_Path_Down { get; set; }
                 
        internal string Texture_Path_Back { get; set; }
                 
        internal string Texture_Path_Front { get; set; }
                 
        internal string Texture_Path_Left { get; set; }
                 
        internal string Texture_Path_Right { get; set; }


        /// <summary>
        /// To Make life easier, convert Any skybox to 6 sided, and then apply it back.
        /// </summary>
        /// <param name="Up"></param>
        /// <param name="Texture_Path_Up"></param>
        /// <param name="Down"></param>
        /// <param name="Texture_Path_Down"></param>
        /// <param name="Back"></param>
        /// <param name="Texture_Path_Back"></param>
        /// <param name="Front"></param>
        /// <param name="Texture_Path_Front"></param>
        /// <param name="Left"></param>
        /// <param name="Texture_Path_Left"></param>
        /// <param name="Right"></param>
        /// <param name="Texture_Path_Right"></param>
        /// <param name="Name"></param>
        internal GeneratedSkyboxes(Texture2D Up, string Texture_Path_Up, Texture2D Down, string Texture_Path_Down, Texture2D Back, string Texture_Path_Back, Texture2D Front, string Texture_Path_Front,  Texture2D Left,  string Texture_Path_Left, Texture2D Right, string Texture_Path_Right, string Name)
        {
            var reason = new StringBuilder();
            if (Up == null) reason.AppendLine("Up Texture is missing!");
            if (Down == null) reason.AppendLine("Down Texture is missing!");
            if (Back == null) reason.AppendLine("Back Texture is missing!");
            if (Front == null) reason.AppendLine("Front Texture is missing!");
            if (Left == null) reason.AppendLine("Left Texture is missing!");
            if (Right == null) reason.AppendLine("Right Texture is missing!");
            if (Up == null || Down == null || Back == null || Front == null || Left == null || Right == null)
            {
                throw new Exception("Failed Material Generation " + reason.ToString());
            }

            this.Up = Up;
            this.Texture_Path_Up = Texture_Path_Up;
            this.Down = Down;
            this.Texture_Path_Down = Texture_Path_Down;
            this.Back = Back;
            this.Texture_Path_Back = Texture_Path_Back;
            this.Front = Front;
            this.Texture_Path_Front = Texture_Path_Front;
            this.Left = Left;
            this.Texture_Path_Left = Texture_Path_Left;
            this.Right = Right;
            this.Texture_Path_Right = Texture_Path_Right;
            this.Name = Name;
        }

        internal IEnumerator UpdateTextures()
        {
            if(GeneratedMat != null)
            {
                UnityEngine.Object.DestroyImmediate(GeneratedMat);
            }
            if (Texture_Path_Up.IsNotNullOrEmptyOrWhiteSpace())
            {
                if (Up != null)
                {
                    UnityEngine.Object.DestroyImmediate(Up);
                }
                
                var loaded = CheetoUtils.LoadPNGFromDir(Texture_Path_Up);
                if (loaded != null)
                {
                    loaded.wrapMode = TextureWrapMode.Clamp;
                    loaded.Apply();
                    loaded.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    Up = loaded;
                }
            }
            if (Texture_Path_Down.IsNotNullOrEmptyOrWhiteSpace())
            {
                if (Down != null)
                {
                    UnityEngine.Object.DestroyImmediate(Down);
                }
                var loaded = CheetoUtils.LoadPNGFromDir(Texture_Path_Down);
                if (loaded != null)
                {
                    loaded.wrapMode = TextureWrapMode.Clamp;
                    loaded.Apply();
                    loaded.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    Down = loaded;
                }
            }
            if (Texture_Path_Back.IsNotNullOrEmptyOrWhiteSpace())
            {
                if (Back != null)
                {
                    UnityEngine.Object.DestroyImmediate(Back);
                }
                var loaded = CheetoUtils.LoadPNGFromDir(Texture_Path_Back);
                if (loaded != null)
                {
                    loaded.wrapMode = TextureWrapMode.Clamp;
                    loaded.Apply();
                    loaded.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    Back = loaded;
                }
            }
            if (Texture_Path_Front.IsNotNullOrEmptyOrWhiteSpace())
            {
                if (Front != null)
                {
                    UnityEngine.Object.DestroyImmediate(Front);
                }
                var loaded = CheetoUtils.LoadPNGFromDir(Texture_Path_Front);
                if (loaded != null)
                {
                    loaded.wrapMode = TextureWrapMode.Clamp;
                    loaded.Apply();
                    loaded.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    Front = loaded;
                }
            }
            if (Texture_Path_Left.IsNotNullOrEmptyOrWhiteSpace())
            {
                if (Left != null)
                {
                    UnityEngine.Object.DestroyImmediate(Left);
                }
                var loaded = CheetoUtils.LoadPNGFromDir(Texture_Path_Left);
                if (loaded != null)
                {
                    loaded.wrapMode = TextureWrapMode.Clamp;
                    loaded.Apply();
                    loaded.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    Left = loaded;
                }
            }
            if (Texture_Path_Right.IsNotNullOrEmptyOrWhiteSpace())
            {
                if (Right != null)
                {
                    UnityEngine.Object.DestroyImmediate(Right);
                }
                var loaded = CheetoUtils.LoadPNGFromDir(Texture_Path_Right);
                if (loaded != null)
                {
                    loaded.wrapMode = TextureWrapMode.Clamp;
                    loaded.Apply();
                    loaded.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    Right = loaded;
                }
            }
            if(SkyboxEditor.SelectedSkybox == this)
            {
                SkyboxEditor.SetRenderSettingSkybox(this);
            }

            yield return null;
        }



        internal Material Material
        {
            get
            {
                if(GeneratedMat != null)
                {
                    UnityEngine.Object.DestroyImmediate(GeneratedMat);
                }

                GeneratedMat = MaterialBuilder.BuildSixSidedMaterial(Up, Down, Back, Front, Left, Right);
                if (GeneratedMat != null)
                {
                    GeneratedMat.name = Name;
                    return GeneratedMat;
                }
                return null;

            }
        }
        private Material GeneratedMat  { get; set; }
        internal string Name { get; set; }

    }
}
