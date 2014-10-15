// Damian Bernardi (c) Somniumsoft

using UnityEngine;

public class MonoBehaviour : UnityEngine.MonoBehaviour
{

    #region Instantiate
    internal static GameObject Instantiate(string name){

        return Instantiate(name, null, null, Vector3.zero, Quaternion.identity, Vector3.one);
    }

    internal static GameObject Instantiate(string name, Transform parent){
        
        return Instantiate(name, null, parent, Vector3.zero, Quaternion.identity, Vector3.one);
    }

    internal static GameObject Instantiate(string name, GameObject gameObject){
        
        return Instantiate(name, gameObject, null, Vector3.zero, Quaternion.identity, Vector3.one);
    }

    internal static GameObject Instantiate(string name, GameObject gameObject, Vector3 position){
        
        return Instantiate(name, gameObject, null, position, Quaternion.identity, Vector3.one);
    }

    internal static GameObject Instantiate(string name, GameObject gameObject, Transform parent){

        return Instantiate(name, gameObject, parent, Vector3.zero, Quaternion.identity, Vector3.one);
    }

    internal static GameObject Instantiate(string name, GameObject gameObject, Transform parent, Vector3 position){
        
        return Instantiate(name, gameObject, parent, position, Quaternion.identity, Vector3.one);
    }

    internal static GameObject Instantiate(string name, GameObject gameObject, Transform parent, Vector3 position, Quaternion rotation, Vector3 scale){

        gameObject = gameObject ? GameObject.Instantiate(gameObject, position, rotation) as GameObject : new GameObject();
        gameObject.name = name;

        if(parent){

            gameObject.transform.parent = parent;
        }

        gameObject.transform.localScale = scale;
        return gameObject;
    }
    #endregion

    #region GameObject
    internal static GameObject Create(){
        
        return Create("", null, 0, null);
    }

    internal static GameObject Create(string name){
        
        return Create(name, null, 0, null);
    }

    internal static GameObject Create(int layer){
        
        return Create("", null, layer, null);
    }

    internal static GameObject Create(string name, Transform parent, int layer){

        return Create(name, parent, layer, null);
    }

    internal static GameObject Create(string name, Transform parent, params System.Type[] types){
        
        return Create(name, parent, 0, types);
    }

    internal static GameObject Create(string name, Transform parent, int layer, params System.Type[] types){

        GameObject o = types != null ? new GameObject(name, types) : new GameObject(name);
        o.transform.parent = parent;
        o.layer = layer;
        return o;
    }

	internal static T Create<T>(string name){
		
		return Create<T>(name, null, 0);
	}

	internal static T Create<T>(string name, Transform parent){
		
		return Create<T>(name, parent, 0);
	}

	internal static T Create<T>(string name, Transform parent, int layer){

		GameObject o = new GameObject(name, typeof(T));
		o.transform.parent = parent;
		o.layer = layer;

		return (T) System.Convert.ChangeType(o.GetComponent(typeof(T)), typeof(T));
	}
    #endregion
}
