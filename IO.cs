// Made by Damian Bernardi (c) Somniumsoft
// You are free to use this C# file in your project

using UnityEngine;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

#region Serialization
public sealed class VersionDeserializationBinder : SerializationBinder
{
	
	public override System.Type BindToType (string assemblyName, string typeName){
		
		if ( !string.IsNullOrEmpty(assemblyName) && !string.IsNullOrEmpty(typeName) ){
			
			System.Type typeToDeserialize = null; 
			assemblyName = Assembly.GetExecutingAssembly().FullName; 
			
			// The following line of code returns the type.
			typeToDeserialize = System.Type.GetType(string.Format("{0}, {1}", typeName, assemblyName)); 
			return typeToDeserialize; 
		}
		
		return null;
	}
}
#endregion

public static class IO
{

	#region Save
	public static bool Save <T> (T data, string path, string name, string ext) where T : new(){

		Stream stream = File.OpenWrite(path + name + ext);
		BinaryFormatter bf = new BinaryFormatter();
		bf.Binder = new VersionDeserializationBinder();
		bf.Serialize(stream, typeof( T ));
		stream.Close();
		return data != null ? true : false;
	}
	#endregion

	#region Load
	public static bool Load <T> (string path, string name, string ext){
		
		Stream stream = File.Open(path + name + ext, FileMode.Open);
		BinaryFormatter bformatter = new BinaryFormatter();
		bformatter.Binder = new VersionDeserializationBinder(); 
		T Data = ( T ) bformatter.Deserialize(stream);
		stream.Close();
		return Data != null ? true : false;
	}
	#endregion

	#region Upload
	public static byte[] Upload <T> (T data, string path){
		
		Stream stream = File.Open(path, FileMode.Create);
		
		BinaryFormatter bformatter = new BinaryFormatter();
		bformatter.Binder = new VersionDeserializationBinder(); 
		bformatter.Serialize(stream, data);
		stream.Close();
		
		byte[] bytes = System.IO.File.ReadAllBytes(path);
		System.IO.File.Delete(path);
		
		return bytes;
	}
	#endregion

	#region Download
	public static void Download<T> (byte[] bytes, T data){
		
	}
	#endregion

	#region Move
	public static void Move <T> (string path, T data){
		
		Stream stream = File.Open(path, FileMode.Create);
		BinaryFormatter bformatter = new BinaryFormatter();
		bformatter.Binder = new VersionDeserializationBinder(); 
		bformatter.Serialize(stream, data);
		stream.Close();
	}
	#endregion

	#region FTP Upload
	public static void FTPUpload (){


	}
	#endregion

	#region FTP Download
	public static void FTPDownload (){


	}
	#endregion
}