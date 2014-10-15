// Damian Bernardi (c) Somniumsoft

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class Physics : UnityEngine.Physics
{

    //raycast based on layer mask order from below
    public static bool RaycastMask(Ray ray, out RaycastHit hit, float distance, params LayerMask[] masks){

        for(int n = 0; n < masks.Length; n++){

            if (Physics.Raycast(ray, out hit, distance, masks[n])){

                return true;
            }
        }

        hit = new RaycastHit();
        return false;
    }

    //overlap sphere with specific raidus on layer mask
    public static List<Collider[]> OverlapSphereMask(Vector3 position, float[] radius, params LayerMask[] masks){

        List<Collider[]> List = new List<Collider[]>();
        
        if(radius.Length != masks.Length){
            
            Log.ERROR("No correct use of raycast");
            return default(List<Collider[]>);
        }

        for(int n = 0; n < radius.Length; n++){

            List.Add(Physics.OverlapSphere(position, radius[n], masks[masks.Length > n ? n : 0]));
        }

        return List; 
    }

    public static bool Raycast(Ray ray, out RaycastHit hit, float[] distances, params LayerMask[] masks){

        if(distances.Length != masks.Length){

            Log.ERROR("No corrent use of raycast");
            hit = default(RaycastHit);
            return false;
        }

        for(int n = 0; n < masks.Length; n++){


        }

        hit = default(RaycastHit);
        return false;
    }
}