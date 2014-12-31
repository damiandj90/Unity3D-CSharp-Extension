// Damian Bernardi (c) Somniumsoft
// You are free to use this file in your project

using UnityEngine;
using System.Linq;
using System.Collections.Generic;

#region List
public class List<T> :  System.Collections.Generic.List<T>
{
	
	public List (params IEnumerable<T>[] a){
		
		this.AddRange(a);
	}
	
	public List (params T[] a){
		
		this.AddRange(a);
	}
}
#endregion

#region IntVector3
public struct IntVector3
{
	public int x, y, z;
	
	public IntVector3 (int x, int z){
		
		this.x = x;
		this.y = 0;
		this.z = z;
	}
	
	public IntVector3 (int x, int y, int z){
		
		this.x = x;
		this.y = y;
		this.z = z;
	}
	
	int sqrMagnitude {
		get { return x * x + y * y + z * z; }
	}
}
#endregion

#region Matrix 1x2
public struct Matrix1x2
{
	public int x, y;
	public Matrix1x2 (int X, int Y){
		
		x = X;
		y = Y;
	}
	
	public void Set (int X, int Y){
		
		x = X;
		y = Y;
	}
	
	public static Matrix1x2 Zero = new Matrix1x2(0, 0);
}
#endregion

#region CString
public class CString
{
	
	private string value;
	
	public CString (){
	}
	
	public CString (string a){
		
		value = a;
	}
	
	public static implicit operator CString (string a){
		
		if ( a == null ){
			
			return null;
		}
		
		return new CString(a);
	}
}
#endregion

public static class VariablesExtensions
{

	#region Bool
	public static bool And (this bool a, params bool[] b){

		if ( !a ){

			return false;
		}

		for ( int n = 0; n < b.Length; n++ ){
			
			if ( b[n] == false ){
				
				return false;
			}
		}

		return true;
	}

	public static bool Or (this bool a, params bool[] b){

		if ( a ){

			return true;
		}

		for ( int n = 0; n < b.Length; n++ ){
			
			if ( b[n] == true ){
				
				return true;
			}
		}
		
		return false;
	}
	#endregion

	#region Int
	public static int Index (this string a, string[] b){
		
		for ( int n = 1; n < b.Length; n++ ){

			if ( a == b[n] ){

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

	#region String

	public static string ToString (this float v, string f, bool showInteger){

		if ( showInteger ){

			if ( float.Parse(v.ToString(f)) % 1 == 0 ){

				return v.ToString("F0");
			}
		}

		return v.ToString(f);
	}

	//replace with chars
	public static string ReplaceChars (this string text, string chars, string replace){
		
		for ( int n = 0; n < chars.Length; n++ ){
			
			text = text.Replace(chars.Substring(n, 1), replace);
		}
		
		return text;
	}
	#endregion

	#region Vector3
	public static Vector3 Add (this Vector3 v, float a){
		
		return new Vector3(v.x + a, v.y + a, v.z + a);
	}
	#endregion

	#region InVector3
	public static IntVector3 ToIntVector3 (this Vector3 v){

		return new IntVector3(( int ) v.x, ( int ) v.y, ( int ) v.z);
	}

	#endregion

	#region Hit
	public static T GetComponent<T> (this RaycastHit h) where T : class{

		return h.collider.GetComponent(typeof( T )) != null ? 
			( T ) System.Convert.ChangeType(h.collider.GetComponent(typeof( T )), h.collider.GetComponent(typeof( T )).GetType()) : default(T);
	}

	public static T GetComponentInParent<T> (this RaycastHit h){
		
		return h.collider.transform.parent.GetComponent(typeof( T )) != null ? 
			( T ) System.Convert.ChangeType(h.collider.transform.parent.GetComponent(typeof( T )), h.collider.transform.parent.GetComponent(typeof( T )).GetType()) : default(T);
	}

	public static T GetComponentInParent<T> (this RaycastHit h, int a){
		
		return h.collider.transform.GetParent(a).GetComponent(typeof( T )) != null ? 
			( T ) System.Convert.ChangeType(h.collider.transform.GetParent(a).GetComponent(typeof( T )), h.collider.transform.GetParent(a).GetComponent(typeof( T )).GetType()) : default(T);
	}

	public static T GetComponentInRoot<T> (this RaycastHit h){

		return h.collider.transform.root.GetComponent(typeof( T )) != null ? 
			( T ) System.Convert.ChangeType(h.collider.transform.root.GetComponent(typeof( T )), h.collider.transform.root.GetComponent(typeof( T )).GetType()) : default(T);
	}

	public static int Layer (this RaycastHit h){

		return h.transform.gameObject.layer;
	}
	#endregion

	#region Camera
	public static Vector3 ScreenPointToRay (this Camera camera, Vector2 p, float d){

		return camera.ScreenPointToRay(p).GetPoint(d);
	}
	#endregion

	#region List

	//Add list to list if there are elements
	public static void AddSafe <T> (this List<List<T>> a, List<T> b){

		if ( b.Count > 0 ){

			a.Add(b);
		}
	}

	public static void AddRange <T> (this List<T> a, params IEnumerable<T>[] b){

		for ( int n = 0; n < b.Length; n++ ){
				
			a.AddRange(b[n]);
		}
	}

	public static void Add (this List<int> a, params int[] b){
		
		a.AddRange(b);
	}
	#endregion

	#region GameObject
	public static void AddComponents (this GameObject o, params System.Type[] types){
		
		if ( types != null ){
			
			foreach ( System.Type type in types ){
				
				o.AddComponent(type);
			}
		}
	}
	#endregion

	#region Transform
	public static Transform GetParent (this Transform t, int a){
		
		for ( int n = 0; n < a; n++ ){
			
			if ( t.parent ){
				
				t = t.parent;
			}
		}
		
		return t.parent;
	}

	public static void SetActive (this Transform t, bool b){

		t.gameObject.SetActive(b);
	}
	#endregion

	#region MonoBehaviour
	public static T AddComponent<T> (this MonoBehaviour mono){
		
		return ( T ) System.Convert.ChangeType(mono.gameObject.AddComponent(typeof( T )), typeof( T ));
	}
	
	public static void AddComponents<T1, T2> (this MonoBehaviour mono, params System.Type[] types){
		
		foreach ( System.Type type in types ){
			
			mono.gameObject.AddComponent(type);
		}
	}
	#endregion

	#region AnimationCurve
	public static float Unit (this AnimationCurve anim, float a){

		return Mathf.Clamp(anim.Evaluate(a), 0, 1);
	}
	#endregion
}

#region Quaternion
public static class QUATERNION
{
	
	public static Quaternion LookPlayer (Vector3 right, Vector3 normal, float rotation){
		
		return Quaternion.LookRotation(right - ( Vector3.Dot(right, normal) ) * normal, normal) * Quaternion.Euler(0, rotation, 0);
	}
}
#endregion