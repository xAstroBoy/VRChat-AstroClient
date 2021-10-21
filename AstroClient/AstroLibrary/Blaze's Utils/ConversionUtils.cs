namespace Blaze.Utils
{
    using UnityEngine;

    public class ConversionUtils
    {
        public static Vector3 StringToVector3(string sVector)
        {
            // Remove the parentheses
            if (sVector.StartsWith("(") && sVector.EndsWith(")"))
            {
                sVector = sVector.Substring(1, sVector.Length - 2);
            }

            // split the items
            string[] sArray = sVector.Split(',');

            // return as a Vector3
            return new Vector3(
                float.Parse(sArray[0]),
                float.Parse(sArray[1]),
                float.Parse(sArray[2]));
        }

        public static Color HexToColor(string Hex)
        {
            ColorUtility.TryParseHtmlString(Hex, out Color output);
            return output;
        }
    }
}
