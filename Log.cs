// Damian Bernardi (c) Somniumsoft

using UnityEngine;
using System.Diagnostics;

static public class Log
{

    private static int counter = 0;

    //simple game messages
    static public void GAME(params object[] objects){
        
        Write(0, Insert(objects, "GAME"));
    }

    //simple system messages
    static public void SYSTEM(params object[] objects){

        Write(0, Insert(objects, "SYSTEM"));
    }

    //network messages
    static public void NETWORK(params object[] objects){

        Write(0, Insert(objects, "NETWORK"));
    }

    //important engine messages
    static public void ENGINE(params object[] objects){

        Write(0, Insert(objects, "ENGINE"));
    }

    //error messages
    static public void ERROR(params object[] objects){

        Write(2, Insert(objects, "ERROR"));
    }

    //warning messages
    static public void WARNING(params object[] objects){
        
        Write(1, Insert(objects, "WARNING"));
    }

    //editor scripts messages
    static public void EDITOR(params object[] objects){

        Write(0, Insert(objects, "EDITOR"));
    }

    //launcher messages
    static public void LAUNCHER(params object[] objects){

        Write(0, Insert(objects, "LAUNCHER"));
    }

    //to test during coding
    static public void TEST(params object[] objects){

        Write(1, Insert(objects, "TEST"));
    }

    static public void COUNTER(params object[] objects){

        Write(1, Insert(objects, "COUNTER", ++counter));
    }

    static public void A(params object[] objects){ Write(1, Insert(objects, "A")); }
    static public void B(params object[] objects){ Write(1, Insert(objects, "B")); }
    static public void C(params object[] objects){ Write(1, Insert(objects, "C")); }
    static public void D(params object[] objects){ Write(1, Insert(objects, "D")); }
    static public void E(params object[] objects){ Write(1, Insert(objects, "E")); }
    static public void F(params object[] objects){ Write(1, Insert(objects, "F")); }
    static public void G(params object[] objects){ Write(1, Insert(objects, "G")); }

	#region Chronometer
	static Stopwatch stopWatch = new Stopwatch();
	
	public static void Start(){
		
		Reset();
		stopWatch.Start();
	}
	
	public static void Continue(){
		
		stopWatch.Start();
	}
	
	public static void Stop(){
		
		stopWatch.Stop();
		Log.SYSTEM("" + stopWatch.Elapsed.TotalSeconds);
	}
	
	public static void Stop(string text){
		
		stopWatch.Stop();
		Log.SYSTEM(text + ": " + stopWatch.Elapsed.TotalSeconds);
	}
	
	public static void Reset(){
		
		stopWatch.Reset();
	}
	#endregion

	#region Insert
    static private object[] Insert(object[] objects, params object[] moreObjects){

        object[] newObjects = null;

        if(objects != null){

            newObjects = new object[objects.Length + moreObjects.Length];
            
            int n1 = 0;
            int n2 = 0;
            
            for(n1 = 0; n1 < moreObjects.Length; n1++){
                
                newObjects[n1] = moreObjects[n1];
            }
            
            for(n2 = 0; n2 < objects.Length; n2++){
                
                newObjects[n1 + n2] = objects[n2];
            }
        }
        else {

            newObjects = moreObjects;
        }

        return newObjects;
    }
	#endregion

	#region Write
    static private void Write(int type, params object[] objects){

        string text = "";

        for(int n = 0; n < objects.Length; n++){
            
            if(objects.Length > n + 1){

                if(objects[n] != null){

                    text += objects[n] + " | ";
                }
                else {

                    text += "Null |";
                }
            }
            else {

                if(objects[n] != null){

                    text += objects[n].ToString();
                }
                else {

                    text += "Null";
                }
            }
        }

        switch(type){

            case 0:
            default:

                UnityEngine.Debug.Log(text);
                break;

            case 1:

				UnityEngine.Debug.LogWarning(text);
                break;

            case 2:

				UnityEngine.Debug.LogError(text);
                break;
        }
    }
	#endregion
}