// Made by Damian Bernardi (c) Somniumsoft
// You are free to use this C# file in your project

using UnityEngine;


public class Physics : UnityEngine.Physics
{

	//raycast based on layer mask order from below
	public static bool RaycastMask (Ray ray, out RaycastHit hit, float distance, params LayerMask[] masks){

		for ( int n = 0; n < masks.Length; n++ ){

			if ( Physics.Raycast(ray, out hit, distance, masks[n]) ){

				return true;
			}
		}

		hit = new RaycastHit();
		return false;
	}

	//overlap sphere with specific raidus on layer mask
	public static List<Collider[]> OverlapSphereMask (Vector3 position, float[] radius, params LayerMask[] masks){

		List<Collider[]> List = new List<Collider[]>();
        
		if ( radius.Length != masks.Length ){
            
			Log.ERROR("Incorrect use of overlap sphere mask");
			return default(List<Collider[]>);
		}

		for ( int n = 0; n < radius.Length; n++ ){

			List.Add(Physics.OverlapSphere(position, radius[n], masks[masks.Length > n ? n : 0]));
		}

		return List; 
	}
}