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

	#region Switch
	public static int Switch (float value, params float[] values){

		for ( int n = 0; n < values.Length; n++ ){

			if ( n + 1 < values.Length ){

				if ( value >= values[n] && value < values[n + 1] ){

					return n;
				}
			}
			else{

				if ( value > values[n] ){

					return n;
				}
			}
		}

		return -1;
	}
	#endregion

	#region Plus
	public static void Plus (ref int value, int i, int max){

		if ( value + i <= max ){
			
			value += i;
		}
		else{
			
			value = max;
		}
	}
	#endregion

	#region Minus
	public static void Minus (ref int value, int i, int min){
		
		if ( value - i >= min ){
			
			value -= i;
		}
		else{
			
			value = min;
		}
	}
	#endregion
}