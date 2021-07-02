﻿namespace Blaze.Utils
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

            // store as a Vector3
            Vector3 result = new Vector3(
                float.Parse(sArray[0]),
                float.Parse(sArray[1]),
                float.Parse(sArray[2]));

            return result;
        }

        public static Color HexToColor(string Hex)
        {
            ColorUtility.TryParseHtmlString(Hex, out Color output);
            return output;
        }
    }
}
