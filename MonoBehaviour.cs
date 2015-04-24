// Made by Damian Bernardi (c) Somniumsoft
// You are free to use this C# file in your project

using UnityEngine;

public class  MonoBehaviour : UnityEngine.MonoBehaviour
{

	#region Instantiate <T>

	public static T Instantiate<T> (GameObject go) where T : MonoBehaviour{
		
		return Instantiate<T> ("", go, null, Vector3.zero, null);
	}

	public static T Instantiate<T> (GameObject go, Transform parent)where T : MonoBehaviour{
		
		return Instantiate<T> ("", go, parent, Vector3.zero, null);
	}

	public static T Instantiate<T> (string name, GameObject go)where T : MonoBehaviour{
		
		return Instantiate<T> (name, go, null, Vector3.zero, null);
	}

	public static T Instantiate<T> (string name, GameObject go, Transform parent)where T : MonoBehaviour{
		
		return Instantiate<T> (name, go, parent, Vector3.zero, null);
	}

	public static T Instantiate<T> (string name, GameObject go, Vector3 position) where T : MonoBehaviour{
		
		return Instantiate<T> (name, go, null, position, null);
	}

	public static T Instantiate<T> (string name, GameObject go, Transform parent, Vector3 position) where T : MonoBehaviour{
		
		return Instantiate<T> (name, go, parent, Vector3.zero, null);
	}

	public static T Instantiate<T> (string name, GameObject o, Transform parent, Vector3 pos, params System.Type[] types) where T : MonoBehaviour{

		o = Instantiate (o) as GameObject;
		o.name = name;
		o.AddComponents (types);
		o.transform.parent = parent;
		o.transform.position = pos;

		if (o.GetComponent (typeof(T))) {

			return o.GetComponent (typeof(T)) as T;
		}
		else {

			return o.AddComponent (typeof(T)) as T;
		}
	}
	#endregion

	#region New <T>
	public static T New<T> (GameObject go){
		
		return New<T> ("", go, null, Vector3.zero, null);
	}
	
	public static T New<T> (GameObject go, Transform parent){
		
		return New<T> ("", go, parent, Vector3.zero, null);
	}
	
	public static T New<T> (string name, GameObject go){
		
		return New<T> (name, go, null, Vector3.zero, null);
	}
	
	public static T New<T> (string name, GameObject go, Transform parent){
		
		return New<T> (name, go, parent, Vector3.zero, null);
	}
	
	public static T New<T> (string name, GameObject go, Vector3 position){
		
		return New<T> (name, go, null, position, null);
	}
	
	public static T New<T> (string name, GameObject go, Transform parent, Vector3 position){
		
		return New<T> (name, go, parent, Vector3.zero, null);
	}

	public static T New<T> (string name, GameObject o, Transform parent, Vector3 pos, params System.Type[] types){

		o = Instantiate (o) as GameObject;
		o.name = name;
		o.AddComponents (types);
		o.transform.parent = parent;
		o.transform.position = pos;

		if (typeof(T) == typeof(GameObject)) {
			
			return (T)System.Convert.ChangeType (o, typeof(T));
		}
		else {
			
			if (typeof(T) == typeof(Transform)) {
				
				return (T)System.Convert.ChangeType (o.transform, typeof(T));
			}
			else {

				if (o.GetComponent (typeof(T))) {
					
					return (T)System.Convert.ChangeType (o.GetComponent (typeof(T)), typeof(T));
				}
				else {
					
					return (T)System.Convert.ChangeType (o.AddComponent (typeof(T)), typeof(T));
				}
			}
		}
	}
	#endregion

    #region Create
	public static T Create<T> (){
		
		return Create<T> ("", null, 0, null);
	}

	public static T Create<T> (string name){
		
		return Create<T> (name, null, 0, null);
	}

	public static T Create<T> (int layer){
		
		return Create<T> ("", null, layer, null);
	}

	public static T Create<T> (string name, Transform parent){
		
		return Create<T> (name, parent, 0, null);
	}

	public static T Create<T> (string name, Transform parent, params System.Type[] types){

		return Create<T> (name, parent, 0, types);
	}

	public static T Create<T> (string name, Transform parent, int layer, params System.Type[] types){
		
		GameObject go = types != null ? new GameObject (name, types) : new GameObject (name);
		go.transform.parent = parent;
		go.layer = layer;

		if (typeof(T) == typeof(GameObject)) {

			return (T)System.Convert.ChangeType (go, typeof(T));
		}
		else {

			if (typeof(T) == typeof(Transform)) {

				return (T)System.Convert.ChangeType (go.transform, typeof(T));
			}
			else {

				if (go.GetComponent (typeof(T))) {
					
					return (T)System.Convert.ChangeType (go.GetComponent (typeof(T)), typeof(T));
				}
				else {
					
					return (T)System.Convert.ChangeType (go.AddComponent (typeof(T)), typeof(T));
				}
			}
		}
	}
    #endregion

	#region Comparison
	public static bool Same <T> (T a, T b){

		return Equals (a, b) ? true : false;
	}
	#endregion

	#region Properties
	public static B GetProperty<A, B> (string name){
		
		return (B)default(A).GetType ().GetProperty (name).GetValue (default(A), null);
	}
	#endregion
}