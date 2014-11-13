// Damian Bernardi (c) Somniumsoft
// You are free to use this file in your project

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

	public static float Round (float a, int decimals){

		return float.Parse(a.ToString("F" + decimals));
	}
    #endregion
	
    #region Distance

	public static int Distance (int a1, int a2){
		
		return Absolute(a1 - a2);
	}
	
	public static float Distance (float a1, int a2){
		
		return Absolute(a1 - a2);
	}

	//Fastest way to calculate distance from point to point
	public static double Distance (Vector3 v1, Vector3 v2){
	
		return Mathf.Sqrt(( v1.x - v2.x ) * ( v1.x - v2.x ) + ( v1.y - v2.y ) * ( v1.y - v2.y ) + ( v1.z - v2.z ) * ( v1.z - v2.z ));
	}
	
	//Fast distance in float
	public static float DistanceFLOAT (Vector3 v1, Vector3 v2){

		return ( float ) Mathf.Sqrt(( v1.x - v2.x ) * ( v1.x - v2.x ) + ( v1.y - v2.y ) * ( v1.y - v2.y ) + ( v1.z - v2.z ) * ( v1.z - v2.z ));
	}
	
	//Fast distance round to int
	public static int DistanceINT (Vector3 v1, Vector3 v2){

		return ( int ) Mathf.Sqrt(( v1.x - v2.x ) * ( v1.x - v2.x ) + ( v1.y - v2.y ) * ( v1.y - v2.y ) + ( v1.z - v2.z ) * ( v1.z - v2.z ));
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
	public static object Random (this object[] objects){
		
		return objects.Length > 0 ? objects[UnityEngine.Random.Range(0, objects.Length)] : default(object);
	}
	
	public static T Random<T> (this T[] objects){
		
		return objects.Length > 0 ? objects[UnityEngine.Random.Range(0, objects.Length)] : default(T);
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