// Damian Bernardi (c) Somniumsoft
// You are free to use this file in your project

using UnityEngine;

public class MonoBehaviour : UnityEngine.MonoBehaviour
{

    #region Instantiate

	public static T Instantiate<T> (GameObject go){
		
		return Instantiate<T>("", go, null, Vector3.zero, null);
	}

	public static T Instantiate<T> (GameObject go, Transform parent){
		
		return Instantiate<T>("", go, parent, Vector3.zero, null);
	}

	public static T Instantiate<T> (string name, GameObject go){
		
		return Instantiate<T>(name, go, null, Vector3.zero, null);
	}

	public static T Instantiate<T> (string name, GameObject go, Transform parent){
		
		return Instantiate<T>(name, go, parent, Vector3.zero, null);
	}

	public static T Instantiate<T> (string name, GameObject go, Vector3 position){
		
		return Instantiate<T>(name, go, null, position, null);
	}

	public static T Instantiate<T> (string name, GameObject go, Transform parent, Vector3 position){
		
		return Instantiate<T>(name, go, parent, Vector3.zero, null);
	}

	public static T Instantiate<T> (string name, GameObject go, Transform parent, Vector3 position, params System.Type[] types){

		go = Instantiate(go) as GameObject;
		go.name = name;
		go.AddComponents(types);
		go.transform.parent = parent;
		go.transform.position = position;

		if ( typeof( T ) == typeof( GameObject ) ){
			
			return ( T ) System.Convert.ChangeType(go, typeof( T ));
		}
		else{

			if ( typeof( T ) == typeof( Transform ) ){
				
				return ( T ) System.Convert.ChangeType(go.transform, typeof( T ));
			}
			else{
			
				if ( go.GetComponent(typeof( T )) ){
					
					return ( T ) System.Convert.ChangeType(go.GetComponent(typeof( T )), typeof( T ));
				}
				else{
					
					return ( T ) System.Convert.ChangeType(go.AddComponent(typeof( T )), typeof( T ));
				}
			}
		}
	}
    #endregion

    #region Create

	public static T Create<T> (){
		
		return Create<T>("", null, 0, null);
	}

	public static T Create<T> (string name){
		
		return Create<T>(name, null, 0, null);
	}

	public static T Create<T> (int layer){
		
		return Create<T>("", null, layer, null);
	}

	public static T Create<T> (string name, Transform parent){
		
		return Create<T>(name, parent, 0, null);
	}

	public static T Create<T> (string name, Transform parent, params System.Type[] types){

		return Create<T>(name, parent, 0, types);
	}

	public static T Create<T> (string name, Transform parent, int layer, params System.Type[] types){
		
		GameObject go = types != null ? new GameObject(name, types) : new GameObject(name);
		go.transform.parent = parent;
		go.layer = layer;

		if ( typeof( T ) == typeof( GameObject ) ){

			return ( T ) System.Convert.ChangeType(go, typeof( T ));
		}
		else{

			if ( typeof( T ) == typeof( Transform ) ){

				return ( T ) System.Convert.ChangeType(go.transform, typeof( T ));
			}
			else{

				if ( go.GetComponent(typeof( T )) ){
					
					return ( T ) System.Convert.ChangeType(go.GetComponent(typeof( T )), typeof( T ));
				}
				else{
					
					return ( T ) System.Convert.ChangeType(go.AddComponent(typeof( T )), typeof( T ));
				}
			}
		}
	}
    #endregion

	#region Comparison
	public static bool Same <T> (T a, T b){

		return Equals(a, b) ? true : false;
	}
	#endregion

	#region Properties
	public static B GetProperty<A, B> (string name){
		
		return ( B ) default(A).GetType().GetProperty(name).GetValue(default(A), null);
	}
	#endregion
}