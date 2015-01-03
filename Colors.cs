// Made by Damian Bernardi (c) Somniumsoft
// You are free to use this C# file in your project

using UnityEngine;

public static class ColorExtensions
{

	#region Color To Hex String
	public static string ToHex (this Color color){

		return color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
	}
	#endregion

	#region String To Color
	public static Color ToColor (this string a){
		
		return ToColor32(a);
	}

	public static Color32 ToColor32 (this string a){

		return new Color32(byte.Parse(a.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
		                   byte.Parse(a.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
		                   byte.Parse(a.Substring(4, 2), System.Globalization.NumberStyles.HexNumber), 255);
	}
	#endregion
}