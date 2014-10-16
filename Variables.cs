// Damian Bernardi (c) Somniumsoft

using UnityEngine;

public static class VariablesExtensions
{

	#region Index
	public static int Index (this string value, string[] values){
		
		for ( int n = 1; n < values.Length; n++ ){

			if ( value == values[n] ){

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
	#endregion

	#region Nearest
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
}