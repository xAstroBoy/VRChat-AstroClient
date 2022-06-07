using AstroClient.Tools.Skybox.MaterialBuilders;
using UnityEngine;

namespace AstroClient.Tools.Skybox.SkyboxClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This will Convert any Skybox To 6 Sided and clamp their textures, to make life easier.
    /// </summary>
    internal class GeneratedSkyboxes
    {
        /// <summary>
        /// To Make life easier, convert Any skybox to 6 sided, and then apply it back.
        /// </summary>
        /// <param name="Up"></param>
        /// <param name="Down"></param>
        /// <param name="Back"></param>
        /// <param name="Front"></param>
        /// <param name="Left"></param>
        /// <param name="Right"></param>
        /// <param name="Name"></param>
        internal GeneratedSkyboxes(Texture2D Up, Texture2D Down, Texture2D Back, Texture2D Front, Texture2D Left, Texture2D Right, string Name)
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
            this.Down = Down;
            this.Back = Back;
            this.Front = Front;
            this.Left = Left;
            this.Right = Right;
            this.Name = Name;
        }


        internal Texture2D Up { get; set; }

        internal Texture2D Down { get; set; }

        internal Texture2D Back { get; set; }

        internal Texture2D Front { get; set; }

        internal Texture2D Left { get; set; }

        internal Texture2D Right { get; set; }

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

        internal void Destroy()
        {
            UnityEngine.Object.DestroyImmediate(Up);
            UnityEngine.Object.DestroyImmediate(Down);
            UnityEngine.Object.DestroyImmediate(Back);
            UnityEngine.Object.DestroyImmediate(Front);
            UnityEngine.Object.DestroyImmediate(Left);
            UnityEngine.Object.DestroyImmediate(Right);
            UnityEngine.Object.DestroyImmediate(GeneratedMat);
        }
    }
}
