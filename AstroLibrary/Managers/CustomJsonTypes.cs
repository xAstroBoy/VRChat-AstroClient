namespace AstroLibrary.Managers
{
	using UnityEngine;

	public class JsonColor
    {
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
        public float A { get; set; }

        public JsonColor(Color color)
        {
            R = color.r;
            G = color.g;
            B = color.b;
            A = color.a;
        }

        public Color GetColor()
        {
            return new Color(R, G, B, A);
        }
    }
}