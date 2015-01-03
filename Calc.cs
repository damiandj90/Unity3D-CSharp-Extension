// Made by Damian Bernardi (c) Somniumsoft
// You are free to use this C# file in your project

using UnityEngine;

public static class Calc
{

    #region Even
	public static bool Even (int a){

		return a % 2 == 0 ? true : false;
	}

	public static bool Uneven (int a){
        
		return a % 2 == 1 ? true : false;
	}
    #endregion

    #region Round
	public static int Round (float a){
        
		return int.Parse(a.ToString("F0"));
	}

	public static float Round (float a, int dec){

		return float.Parse(a.ToString("F" + dec));
	}
    #endregion
	
    #region Distance
	public static int Distance (int a, int b){
		
		return Absolute(a - b);
	}

	public static float Distance (float a, int b){
		
		return Absolute(a - b);
	}

	//fastest way to calculate vector2 distance
	public static float Distance (Vector2 a, Vector2 b){
		
		return Mathf.Sqrt(( a.x - b.x ) * ( a.x - b.x ) + ( a.y - b.y ) * ( a.y - b.y ));
	}
	
	//fastest way to calculate vector3 distance
	public static float Distance (Vector3 a, Vector3 b){

		return Mathf.Sqrt(( a.x - b.x ) * ( a.x - b.x ) + ( a.y - b.y ) * ( a.y - b.y ) + ( a.z - b.z ) * ( a.z - b.z ));
	}
	
	//fastest way to calculate vector3 distance to int
	public static int DistanceToInt (Vector3 a, Vector3 b){

		return ( int ) Mathf.Sqrt(( a.x - b.x ) * ( a.x - b.x ) + ( a.y - b.y ) * ( a.y - b.y ) + ( a.z - b.z ) * ( a.z - b.z ));
	}
    #endregion

	#region Absolute
	public static int Absolute (int a){

		return 0 > a ? -a : a;
	}

	public static float Absolute (float a){
		
		return 0 > a ? -a : a;
	}
	#endregion

	#region Random
	//get random element from array of objects
	public static object Random (this object[] a){
		
		return a.Length > 0 ? a[UnityEngine.Random.Range(0, a.Length)] : default(object);
	}
	
	public static T Random<T> (this T[] a){
		
		return a.Length > 0 ? a[UnityEngine.Random.Range(0, a.Length)] : default(T);
	}
	#endregion

	#region Linear
	public static float LC (float value, float range){

		return value <= range ? Absolute(( value - range )) / range : 0;
	}
	#endregion

	#region Limit
	public static float Limit (float a){
		
		return Limit(a, 0.1f);
	}

	public static float Limit (float a, float b){

		return a - b;
	}
	#endregion
}