// Damian Bernardi (c) Somniumsoft

using UnityEngine;

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

	#region Hit
	public static T GetComponent<T> (this RaycastHit hit) where T : class{

		return hit.collider.GetComponent(typeof( T )) != null ? 
			( T ) System.Convert.ChangeType(hit.collider.GetComponent(typeof( T )), hit.collider.GetComponent(typeof( T )).GetType()) : default(T);
	}

	public static T GetComponentInParent<T> (this RaycastHit hit){
		
		return ( T ) System.Convert.ChangeType(hit.collider.transform.parent.GetComponent(typeof( T )), typeof( T ));
	}
	#endregion

	#region Camera
	public static Vector3 ScreenPointToRay (this Camera camera, Vector2 position, float distance){

		return camera.ScreenPointToRay(position).GetPoint(distance);
	}
	#endregion
}