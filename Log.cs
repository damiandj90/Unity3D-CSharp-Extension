// Made by Damian Bernardi (c) Somniumsoft
// You are free to use this C# file in your project

using UnityEngine;
using System.Diagnostics;
using System.Linq;

static public class Log
{
	
	private static int counter = 0;
	private static Transform LogDirectory;
	public static string[] LogData = Enumerable.Repeat ("", 10).ToArray ();
	
	#region Debug
	//simple game messages
	static public void GAME (params object[] objects){
		
		Write (LogType.NONE, Insert (objects, "GAME"));
	}
	
	//simple system messages
	static public void SYSTEM (params object[] objects){
		
		Write (LogType.NONE, Insert (objects, "SYSTEM"));
	}
	
	//network messages
	static public void NETWORK (params object[] objects){
		
		Write (LogType.NONE, Insert (objects, "NETWORK"));
	}
	
	//important engine messages
	static public void ENGINE (params object[] objects){
		
		Write (LogType.NONE, Insert (objects, "ENGINE"));
	}
	
	//error messages
	static public void ERROR (params object[] objects){
		
		Write (LogType.ERROR, Insert (objects, "ERROR"));
	}
	
	//warning messages
	static public void WARNING (params object[] objects){
		
		Write (LogType.WARNING, Insert (objects, "WARNING"));
	}
	
	//editor scripts messages
	static public void EDITOR (params object[] objects){
		
		Write (LogType.NONE, Insert (objects, "EDITOR"));
	}
	
	//launcher messages
	static public void LAUNCHER (params object[] objects){
		
		Write (LogType.NONE, Insert (objects, "LAUNCHER"));
	}
	
	//to test during coding
	static public void TEST (params object[] objects){
		
		Write (LogType.WARNING, Insert (objects, "TEST"));
	}
	
	static public void COUNTER (params object[] objects){
		
		Write (LogType.WARNING, Insert (objects, "COUNTER", ++counter));
	}
	
	static public void A (params object[] objects){
		Write (LogType.WARNING, Insert (objects, "A"));
	}
	static public void B (params object[] objects){
		Write (LogType.WARNING, Insert (objects, "B"));
	}
	static public void C (params object[] objects){
		Write (LogType.WARNING, Insert (objects, "C"));
	}
	static public void D (params object[] objects){
		Write (LogType.WARNING, Insert (objects, "D"));
	}
	static public void E (params object[] objects){
		Write (LogType.WARNING, Insert (objects, "E"));
	}
	static public void F (params object[] objects){
		Write (LogType.WARNING, Insert (objects, "F"));
	}
	static public void G (params object[] objects){
		Write (LogType.WARNING, Insert (objects, "G"));
	}
	#endregion
	
	#region Draw
	static public void DRAW (float x, float y, float width, float height){
		
		DRAW (x, y, width, height, new Texture2D (10, 10, TextureFormat.Alpha8, false));
	}
	
	static public void DRAW (float x, float y, float width, float height, Texture2D texture){
		
		GUI.DrawTexture (new Rect (x, y, width, height), texture);
		
		Write (0, Insert (new object[]{x, y, width, height}, "DRAW"));
	}
	#endregion
	
	#region Point
	static public void POINT (Vector3 pos){

		//create log directory if needed
		if (!LogDirectory) {
			
			LogDirectory = MonoBehaviour.Create<Transform> ("_Log");
		}
		
		GameObject go = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		go.name = "Point (" + pos + ")";
		go.transform.parent = LogDirectory;
		go.transform.position = pos;
		go.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
	}
	#endregion

	#region Ray
	static public void RAY (Vector3 pos1, Vector3 pos2){

		//create log directory if needed
		if (!LogDirectory) {
			
			LogDirectory = MonoBehaviour.Create<Transform> ("_Log");
		}
		
		GameObject go = GameObject.CreatePrimitive (PrimitiveType.Cube);
		go.name = "Ray (" + pos1 + "," + pos2 + ")";
		go.transform.parent = LogDirectory;
		go.transform.position = pos1 + (pos2 - pos1).magnitude / 2 * (pos2 - pos1).normalized;
		go.transform.localScale = new Vector3 (0.05f, 0.05f, (pos2 - pos1).magnitude);
		go.transform.LookAt (pos2);
	}
	#endregion
	
	#region Timer
	static Stopwatch timerWatch = new Stopwatch ();
	
	public static void START (){
		
		timerWatch.Reset ();
		timerWatch.Start ();
	}
	
	public static void CONTINUE (){
		
		timerWatch.Start ();
	}
	
	public static void PAUSE (){
		
		timerWatch.Stop ();
	}
	
	public static void STOP (){
		
		timerWatch.Stop ();
		Log.TIME ("" + timerWatch.Elapsed.TotalSeconds);
	}
	
	public static void STOP (string text){
		
		timerWatch.Stop ();
		Log.TIME (text + ": " + timerWatch.Elapsed.TotalSeconds);
	}
	
	private static void TIME (params object[] objects){
		
		Write (0, Insert (objects, "TIMER"));
	}
	#endregion
	
	#region Measure
	static Stopwatch measureWatch = new Stopwatch ();
	static List<double> measures = new List<double> ();
	
	public static void BEGIN (){
		
		measureWatch.Reset ();
		measureWatch.Start ();
	}
	
	public static void CHECK (){
		
		if (measureWatch.IsRunning) {
			
			measureWatch.Stop ();
			measures.Add (measureWatch.Elapsed.TotalMilliseconds);
			measureWatch.Start ();
		}
		else {
			
			Log.ERROR ("No log measure begin");
		}
	}
	
	public static void END (){
		
		if (measureWatch.IsRunning) {
			
			measureWatch.Stop ();
			measures.Add (measureWatch.Elapsed.TotalMilliseconds);
			measureWatch.Reset ();
			
			string[] values = new string[measures.Count];
			
			for (int n = 0; n < values.Length; n++) {
				
				if (n > 0) {
					
					values [n] = "+" + (measures [n] - measures [n - 1]).ToString ("F4");
				}
				else {
					
					values [n] = "+" + measures [n].ToString ("F4");
				}
			}
			
			Log.MEASURE (values);
			measures.Clear ();
		}
		else {
			
			Log.ERROR ("No log measure begin");
		}
	}
	
	private static void MEASURE (params object[] objects){
		
		Write (0, Insert (objects, "MEASURE"));
	}
	#endregion
	
	#region Insert
	static private object[] Insert (object[] objects, params object[] moreObjects){
		
		object[] newObjects = null;
		
		if (objects != null) {
			
			newObjects = new object[objects.Length + moreObjects.Length];
			
			int n1 = 0;
			int n2 = 0;
			
			for (n1 = 0; n1 < moreObjects.Length; n1++) {
				
				newObjects [n1] = moreObjects [n1];
			}
			
			for (n2 = 0; n2 < objects.Length; n2++) {
				
				newObjects [n1 + n2] = objects [n2];
			}
		}
		else {
			
			newObjects = moreObjects;
		}
		
		return newObjects;
	}
	#endregion
	
	#region Write
	static private void Write (LogType type, params object[] objects){
		
		string text = "";
		
		for (int n = 0; n < objects.Length; n++) {
			
			if (objects.Length > n + 1) {
				
				if (objects [n] != null) {
					
					text += objects [n] + " | ";
				}
				else {
					
					text += "Null |";
				}
			}
			else {
				
				if (objects [n] != null) {
					
					text += objects [n].ToString ();
				}
				else {
					
					text += "Null";
				}
			}
		}
		
		switch (type) {
			
			case LogType.NONE:
			default:
				
				UnityEngine.Debug.Log (text);
				break;
				
			case LogType.WARNING:
				
				UnityEngine.Debug.LogWarning (text);
				break;
				
			case LogType.ERROR:
				
				UnityEngine.Debug.LogError (text);
				break;
		}
		
		//shift current temp log saved
		for (int n = LogData.Length - 1; n > 0; n--) {
			
			LogData [n] = LogData [n - 1];
		}
		
		LogData [0] = text;
	}
	#endregion
	
	private enum LogType
	{
		NONE,
		WARNING,
		ERROR
	}
}