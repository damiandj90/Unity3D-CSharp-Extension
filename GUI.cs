// Damian Bernardi (c) Somniumsoft

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GUI : UnityEngine.GUI
{

	public static bool Button(int x, int y, int width, int height, string text){
	
		return GUI.Button(new Rect(x, y, width, height), text);
	}

	public static void Texture(int x, int y, int width, int height, Texture2D texture){

		GUI.DrawTexture(new Rect(x, y, width, height), texture);
	}

	public static void Label(int x, int y, int width, int height, string text){

		GUI.Label(new Rect(x, y, width, height), text);
	}
}