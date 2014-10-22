// Damian Bernardi (c) Somniumsoft

using UnityEngine;
using System;

#region IntVector3
public struct IntVector3
{
	public int x, y, z;
	
	public IntVector3 (int x, int z){
		
		this.x = x;
		this.y = 0;
		this.z = z;
	}
	
	public IntVector3 (int x, int y, int z){
		
		this.x = x;
		this.y = y;
		this.z = z;
	}
	
	int sqrMagnitude {
		get { return x * x + y * y + z * z; }
	}
}
#endregion

public static class VariablesExtensions
{

	#region Int
	public static int Index (this string value, string[] values){
		
		for ( int n = 1; n < values.Length; n++ ){

			if ( value == values[n] ){

				return n;
			}
		}

		return 0;
	}

	public static int Index (this int value, int[] values){
		
		for ( int n = 1; n < values.Length; n++ ){
			
			if ( value == values[n] ){
				
				return n;
			}
		}
		
		return 0;
	}

	public static int Nearest (this int value, int[] values){
		
		int range = Calc.Distance(value, values[0]);
		int position = 0;
		
		for ( int n = 1; n < values.Length; n++ ){
			
			if ( Calc.Distance(value, values[n]) < range ){
				
				range = Calc.Distance(value, values[n]);
				position = n;
			}
		}

		return values[position];
	}

	public static int NearestIndex (this int value, int[] values){
		
		int range = Calc.Distance(value, values[0]);
		int position = 0;
		
		for ( int n = 1; n < values.Length; n++ ){
			
			if ( Calc.Distance(value, values[n]) < range ){
				
				range = Calc.Distance(value, values[n]);
				position = n;
			}
		}
		
		return position;
	}
	#endregion

	#region String

	public static string ToString (this float value, string format, bool showInteger){

		if ( showInteger ){

			if ( float.Parse(value.ToString(format)) % 1 == 0 ){

				return value.ToString("F0");
			}
		}

		return value.ToString(format);
	}

	//replace with chars
	public static string ReplaceChars (this string text, string chars, string replace){
		
		for ( int n = 0; n < chars.Length; n++ ){
			
			text = text.Replace(chars.Substring(n, 1), replace);
		}
		
		return text;
	}
	#endregion

	#region Vector3
	public static IntVector3 ToIntVector3 (this Vector3 v){

		return new IntVector3(( int ) v.x, ( int ) v.y, ( int ) v.z);
	}
	#endregion

	#region Hit
	public static T GetComponent<T> (this RaycastHit hit) where T : class{

		return hit.collider.GetComponent(typeof( T )) != null ? 
			( T ) System.Convert.ChangeType(hit.collider.GetComponent(typeof( T )), hit.collider.GetComponent(typeof( T )).GetType()) : default(T);
	}

	public static T GetComponentInParent<T> (this RaycastHit hit){

		return hit.collider.transform.parent.GetComponent(typeof( T )) != null ? 
			( T ) System.Convert.ChangeType(hit.collider.transform.parent.GetComponent(typeof( T )), hit.collider.transform.parent.GetComponent(typeof( T )).GetType()) : default(T);
	}

	public static T GetComponentInRoot<T> (this RaycastHit hit){
		
		return hit.collider.transform.root.GetComponent(typeof( T )) != null ? 
			( T ) System.Convert.ChangeType(hit.collider.transform.root.GetComponent(typeof( T )), hit.collider.transform.root.GetComponent(typeof( T )).GetType()) : default(T);
	}
	#endregion

	#region Camera
	public static Vector3 ScreenPointToRay (this Camera camera, Vector2 position, float distance){

		return camera.ScreenPointToRay(position).GetPoint(distance);
	}
	#endregion
}