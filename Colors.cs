// Damian Bernardi (c) Somniumsoft

using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class ColorSettings
{

	public static string ColorToHex(Color32 color){
		
		return color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
	}
	
	public static Color Hex(string hex){
		
		return new Color32(byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber),
		                   byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber),
		                   byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber), 255);
	}
}