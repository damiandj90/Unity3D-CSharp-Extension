// Damian Bernardi (c) Somniumsoft
// You are free to use this file in your project

using UnityEngine;

namespace UnityEngine
{

	static public class Points
	{
		
		//Return uniform sphere of points
		static public List<Vector3> Sphere (float numbers, float size){
			
			List<Vector3> Points = new List<Vector3>();
			
			float i = Mathf.PI * ( 3 - Mathf.Sqrt(5) );
			float o = 2 / numbers;
			
			for ( int n = 0; n < numbers; n++ ){
				
				float y = n * o - 1 + ( o / 2 );
				float r = Mathf.Sqrt(1 - y * y);
				float phi = n * i;
				
				Points.Add(new Vector3(Mathf.Cos(phi) * r, y, Mathf.Sin(phi) * r) * size);
			}
			
			return Points;
		}

		//Return uniform plane of points
		static public List<Vector3> Plane (float numbers, float size){

			return new List<Vector3>();
		}

		//Return uniform Cube of points
		static public List<Vector3> Cube (float numbers, float size){

			return new List<Vector3>();
		}
	}
}