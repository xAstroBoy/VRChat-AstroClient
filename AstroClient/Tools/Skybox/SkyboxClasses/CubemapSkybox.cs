using System.Windows.Forms.VisualStyles;
using AstroClient.Tools.Skybox.MaterialBuilders;
using UnityEngine;

namespace AstroClient.Tools.Skybox.SkyboxClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class CubemapSkybox
    {
        internal CubemapSkybox(Texture2D PositiveX, Texture2D NegativeX, Texture2D PositiveY, Texture2D NegativeY, Texture2D PositiveZ, Texture2D NegativeZ, string Name)
        {
            this.PositiveX = PositiveX;
            this.NegativeX = NegativeX;
            this.PositiveY = PositiveY;
            this.NegativeY = NegativeY;
            this.PositiveZ = PositiveZ;
            this.NegativeZ = NegativeZ;
            this.Name = Name;
            Material = MaterialBuilder.BuildCubemap(PositiveX, NegativeX, PositiveY, NegativeY, PositiveZ, NegativeZ);
            if (Material != null)
            {
                Material.name = Name;
            }

        }




        internal Texture2D PositiveX { get; set; }

        internal Texture2D NegativeX { get; set; }

        internal Texture2D PositiveY { get; set; }

        internal Texture2D NegativeY { get; set; }

        internal Texture2D PositiveZ { get; set; }

        internal Texture2D NegativeZ { get; set; }

        internal Material Material { get; set; }
        internal string Name { get; set; }
        internal void Destroy()
        {
            UnityEngine.Object.Destroy(PositiveX);
            UnityEngine.Object.Destroy(NegativeX);
            UnityEngine.Object.Destroy(PositiveY);
            UnityEngine.Object.Destroy(NegativeY);
            UnityEngine.Object.Destroy(PositiveZ);
            UnityEngine.Object.Destroy(NegativeZ);
            UnityEngine.Object.Destroy(Material);
        }
    }
}
