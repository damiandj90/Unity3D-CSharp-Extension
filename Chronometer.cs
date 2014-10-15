// Damian Bernardi (c) Somniumsoft

using UnityEngine;
using System.Diagnostics;

public class Chrono
{

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
}