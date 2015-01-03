// Made by Damian Bernardi (c) Somniumsoft
// You are free to use this C# file in your project

using UnityEngine;
using System;
using System.IO;

namespace Deriva
{

	public class Ini
	{
		
		public List<string> keys = new List<string>();
		public List<string> values = new List<string>();  
		
		public string Get (string key){
			for ( int i = 0; i < keys.Count; i++ ){ 
				if ( keys[i] == key ){
					return( values[i] );
				}
			}
			return null;
		}

		public void Set (String key, String val){
			for ( var i = 0; i < keys.Count; i++ ){
				if ( keys[i] == key ){
					values[i] = val;
					return;
				}
			}
	   	
			keys.Add(key);
			values.Add(val);
		}
		
		public void Remove (String key){
			for ( var i = 0; i < keys.Count; i++ ){
				if ( keys[i] == key ){
					keys.RemoveAt(i);
					values.RemoveAt(i);
					return;
				}
			}
		}
		
		public void Save (string fileName, string path){
			
			StreamWriter sw = new StreamWriter(path + fileName);
			for ( var i = 0; i < keys.Count; i++ ){
				sw.WriteLine(keys[i] + " " + values[i]);
			}
			sw.Close();
		}
		
		public bool Exists (string key){
			
			for ( var i = 0; i < keys.Count; i++ ){
				if ( keys[i] == key ){
					
					return true;
				}
			}
			return false;
		}
		
		public void Load (String fileName, string path){
			
			keys = new List<string>();
			values = new List<string>();
			
			string line = "-";
			int offset;
			try{
				
				StreamReader sr = new StreamReader(path + fileName);
				line = sr.ReadLine();
				
				while ( line != null ){
						
					offset = line.IndexOf(" ");
					if ( offset > 0 ){
						Set(line.Substring(0, offset), line.Substring(offset + 1));
					}
					line = sr.ReadLine();
				}
				sr.Close();
			} catch{
				
				Log.ERROR("Load Ini failed: " + path + fileName);
			}
		}
	   	
		int Count (){
			return keys.Count;
		} 
	}
}
