// Made by Damian Bernardi (c) Somniumsoft
// You are free to use this C# file in your project

using UnityEngine;
using System;

public class XUI
{
	
	#region Label
	public static void Label (int x, int y, int width, int height, string text){
		
		GUI.Label(new Rect(x, y, width, height), text);
	}
	
	public static void Label (int x, int y, int width, int height, string text, string style){
		
		GUI.Label(new Rect(x, y, width, height), text, GUI.skin.GetStyle(style));
	}
	#endregion
	
	#region Button
	public static bool Button (float x, float y, float width, float height, string text){
		
		return GUI.Button(new Rect(x, y, width, height), text);
	}
	
	public static bool Button (float x, float y, float width, float height, string text, string style){
		
		return GUI.Button(new Rect(x, y, width, height), text, style);
	}
	
	public static bool Button (float x, float y, float width, float height, GUIContent content){
		
		return GUI.Button(new Rect(x, y, width, height), content);
	}
	
	public static bool Button (float x, float y, float width, float height, GUIContent content, string style){
		
		return GUI.Button(new Rect(x, y, width, height), content, style);
	}
	#endregion
	
	#region Texture
	public static void Texture (int x, int y, int width, int height, Texture texture){
		
		GUI.DrawTexture(new Rect(x, y, width, height), texture);
	}
	#endregion
	
	#region Popup
	public static void Popup (int x, int y, int width, int height, Enum e){
		
		Label(x, y, width, height, e.ToString());
		
		for ( int n = 0; n < Enum.GetValues(e.GetType()).Length; n++ ){
			
			if ( Button(x, y + n * 10, width, height, Enum.GetNames(e.GetType())[n]) ){
				
				
			}
		}
	}
	#endregion
}