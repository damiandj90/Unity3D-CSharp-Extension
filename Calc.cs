// (c) Damian Bernardi | SomniumSoft

using UnityEngine;

public static class Calc
{

    #region Even
	public static bool Even(int value){

        return value%2 == 0 ? true : false;
	}

    public static bool Uneven(int value){
        
        return value%2 == 1 ? true : false;
    }
    #endregion

    #region Round
    public static int Round(float value){
        
        return int.Parse(value.ToString("F0"));
    }

    public static float Round(float value, int number){

        return float.Parse(value.ToString("F" + number));
    }
    #endregion
	
    #region Distance

    //Fastest way to calculate distance from point to point
	public static double Distance(Vector3 v1, Vector3 v2){
	
		return Mathf.Sqrt((v1.x - v2.x)*(v1.x - v2.x) + (v1.y - v2.y)*(v1.y - v2.y) + (v1.z - v2.z)*(v1.z - v2.z));
	}
	
    //distance in float
	public static float DistanceFloat(Vector3 v1, Vector3 v2){

		return (float) Mathf.Sqrt((v1.x - v2.x)*(v1.x - v2.x) + (v1.y - v2.y)*(v1.y - v2.y) + (v1.z - v2.z)*(v1.z - v2.z));
	}
	
    //distance round to int
	public static int DistanceInt(Vector3 v1, Vector3 v2){

	    return (int) Mathf.Sqrt((v1.x - v2.x)*(v1.x - v2.x) + (v1.y - v2.y)*(v1.y - v2.y) + (v1.z - v2.z)*(v1.z - v2.z));
    }
    #endregion
}