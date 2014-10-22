// Damian Bernardi (c) Somniumsoft
// You are free to use this file in your project

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GUI : UnityEngine.GUI
{

	#region Label
	public static void Label (int x, int y, int width, int height, string text){
		
		GUI.Label(new Rect(x, y, width, height), text);
	}
	#endregion

	#region Button
	public static bool Button (int x, int y, int width, int height, GUIContent content){
		
		return GUI.Button(new Rect(x, y, width, height), content);
	}
	#endregion

	#region Texture
	public static void Texture (int x, int y, int width, int height, Texture  texture){

		GUI.DrawTexture(new Rect(x, y, width, height), texture);
	}
	#endregion
}