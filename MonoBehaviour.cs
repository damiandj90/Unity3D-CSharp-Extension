// Damian Bernardi (c) Somniumsoft

using UnityEngine;

public class MonoBehaviour : UnityEngine.MonoBehaviour
{

    #region Instantiate
	public static GameObject Instantiate (string name){

		return Instantiate(name, null, null, Vector3.zero, Quaternion.identity, Vector3.one);
	}

	public static GameObject Instantiate (string name, Transform parent){
        
		return Instantiate(name, null, parent, Vector3.zero, Quaternion.identity, Vector3.one);
	}

	public static GameObject Instantiate (string name, GameObject gameObject){
        
		return Instantiate(name, gameObject, null, Vector3.zero, Quaternion.identity, Vector3.one);
	}

	public static GameObject Instantiate (string name, GameObject gameObject, Vector3 position){
        
		return Instantiate(name, gameObject, null, position, Quaternion.identity, Vector3.one);
	}

	public static GameObject Instantiate (string name, GameObject gameObject, Transform parent){

		return Instantiate(name, gameObject, parent, Vector3.zero, Quaternion.identity, Vector3.one);
	}

	public static GameObject Instantiate (string name, GameObject gameObject, Transform parent, Vector3 position){
        
		return Instantiate(name, gameObject, parent, position, Quaternion.identity, Vector3.one);
	}

	public static GameObject Instantiate (string name, GameObject gameObject, Transform parent, Vector3 position, Quaternion rotation, Vector3 scale){

		gameObject = gameObject ? GameObject.Instantiate(gameObject, position, rotation) as GameObject : new GameObject();
		gameObject.name = name;

		if ( parent ){

			gameObject.transform.parent = parent;
		}

		gameObject.transform.localScale = scale;
		return gameObject;
	}
    #endregion

    #region GameObject
	public static GameObject Create (){
        
		return Create("", null, 0, null);
	}

	public static GameObject Create (string name){
        
		return Create(name, null, 0, null);
	}

	public static GameObject Create (int layer){
        
		return Create("", null, layer, null);
	}

	public static GameObject Create (string name, Transform parent, int layer){

		return Create(name, parent, layer, null);
	}

	public static GameObject Create (string name, Transform parent, params System.Type[] types){
        
		return Create(name, parent, 0, types);
	}

	public static GameObject Create (string name, Transform parent, int layer, params System.Type[] types){

		GameObject o = types != null ? new GameObject(name, types) : new GameObject(name);
		o.transform.parent = parent;
		o.layer = layer;
		return o;
	}

	public static T Create<T> (string name){
		
		return Create<T>(name, null, 0);
	}

	public static T Create<T> (string name, Transform parent){
		
		return Create<T>(name, parent, 0);
	}

	public static T Create<T> (string name, Transform parent, int layer){

		GameObject o = new GameObject(name, typeof( T ));
		o.transform.parent = parent;
		o.layer = layer;

		return ( T ) System.Convert.ChangeType(o.GetComponent(typeof( T )), typeof( T ));
	}
    #endregion

}

public static class MonoExtensions
{

	#region Components
	public static T AddComponent<T> (this MonoBehaviour mono){
		
		return ( T ) System.Convert.ChangeType(mono.gameObject.AddComponent(typeof( T )), typeof( T ));
	}

	public static void AddComponents<T1, T2> (this MonoBehaviour mono, params System.Type[] types){

		foreach ( System.Type type in types ){

			mono.gameObject.AddComponent(type);
		}
	}
	#endregion
}