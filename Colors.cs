// Damian Bernardi (c) Somniumsoft
// You are free to use this file in your project

using UnityEngine;

public static class ColorExtensions
{

	//convert color to hex
	public static string ToHex (this Color color){

		return color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
	}

	//convert string to color
	public static Color ToColor (this string hex){
		
		return ToColor32(hex);
	}

	public static Color32 ToColor32 (this string hex){
		
		return new Color32(byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
		                   byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
		                   byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber), 255);
	}
}