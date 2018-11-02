using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;


public class MakeAudio {
	[MenuItem("Assets/Audios/MakeAudioPrefab")] 
	static private void makeAudios ( ) 
	{ 
		
		string spriteDir = Application . dataPath + "/Resources/Audio" ; 
		
		
		if ( ! Directory . Exists ( spriteDir ) ) { 
			
			Directory . CreateDirectory ( spriteDir ) ; 
			
		} 
		
		string path = AssetDatabase.GetAssetPath(Selection.activeObject);
		
		DirectoryInfo dirInfo = new DirectoryInfo ( path ) ;
		GameObject newGo = null;
		AudioMap audioMap = null;
		FileInfo[] mp3s = dirInfo .GetFiles ("*.mp3", SearchOption .TopDirectoryOnly);
		FileInfo[] oggs = dirInfo.GetFiles ("*.ogg", SearchOption .TopDirectoryOnly);
		FileInfo[] wavs = dirInfo.GetFiles ("*.wav", SearchOption .TopDirectoryOnly);
		if (mp3s.Length > 0 || oggs.Length > 0 || wavs.Length > 0) {
			newGo = new GameObject(dirInfo.Name);
			audioMap = newGo.AddComponent<AudioMap>();
		} else {
			return;
		}
		
		loopAddAudio (dirInfo, audioMap, "*.mp3");
		loopAddAudio (dirInfo, audioMap, "*.ogg");
		loopAddAudio (dirInfo, audioMap, "*.wav");
		
		
		string allPath = spriteDir + "/" + dirInfo.Name + ".prefab" ; 
		
		if (File.Exists (allPath)) {
			File.Delete(allPath);
		}
		
		string prefabPath = allPath . Substring ( allPath . IndexOf ( "Assets" ) ) ; 
		
		PrefabUtility . CreatePrefab ( prefabPath , newGo ) ; 
		
		GameObject . DestroyImmediate ( newGo ) ; 
		
		
		
	} 
	
	
	
	static void loopAddAudio(DirectoryInfo dirInfo,AudioMap audioMap,string fileExt)
	{
		foreach ( FileInfo pngFile in dirInfo . GetFiles ( fileExt , SearchOption .TopDirectoryOnly ) ) { 
			
			string allPath = pngFile . FullName ; 
			
			string assetPath = allPath . Substring ( allPath . IndexOf ( "Assets" ) ) ; 
			
			AudioClip clip = AssetDatabase.LoadAssetAtPath( assetPath ,typeof(AudioClip)) as AudioClip ; 
			if(clip == null)
			{
				continue;
			}
			audioMap.AddAudioClip(clip);
			
			
			
		}
		
	}
	
}
