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
	
	//distance in float
	public static float DistanceFloat (Vector3 v1, Vector3 v2){

		return ( float ) Mathf.Sqrt(( v1.x - v2.x ) * ( v1.x - v2.x ) + ( v1.y - v2.y ) * ( v1.y - v2.y ) + ( v1.z - v2.z ) * ( v1.z - v2.z ));
	}
	
	//distance round to int
	public static int DistanceInt (Vector3 v1, Vector3 v2){

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
}