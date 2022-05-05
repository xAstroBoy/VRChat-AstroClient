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
            this.Up = Up;
            this.Down = Down;
            this.Back = Back;
            this.Front = Front;
            this.Left = Left;
            this.Right = Right;
            this.Name = Name;
            Material = MaterialBuilder.BuildSixSidedMaterial(Up, Down, Back, Front, Left, Right);
            if(Material != null)
            {
                Material.name = Name;
            }

        }


        internal Texture2D Up { get; set; }

        internal Texture2D Down { get; set; }

        internal Texture2D Back { get; set; }

        internal Texture2D Front { get; set; }

        internal Texture2D Left { get; set; }

        internal Texture2D Right { get; set; }

        internal Material Material { get; set; }

        internal string Name { get; set; }

        internal void Destroy()
        {
            UnityEngine.Object.Destroy(Up);
            UnityEngine.Object.Destroy(Down);
            UnityEngine.Object.Destroy(Back);
            UnityEngine.Object.Destroy(Front);
            UnityEngine.Object.Destroy(Left);
            UnityEngine.Object.Destroy(Right);
            UnityEngine.Object.Destroy(Material);
        }
    }
}
