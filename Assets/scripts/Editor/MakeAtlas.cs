using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;


public class MakeAtlas {
	[MenuItem("Assets/Atlas/MakeSpritePrefab")] 
	static private void makeAtlas ( ) 
	{ 
		
		string spriteDir = Application . dataPath + "/Resources/Sprite" ; 
		

		if ( ! Directory . Exists ( spriteDir ) ) { 
			
			Directory . CreateDirectory ( spriteDir ) ; 
			
		} 

		string path = AssetDatabase.GetAssetPath(Selection.activeObject);

		DirectoryInfo dirInfo = new DirectoryInfo ( path ) ;
		GameObject newGo = null;
		AtlasMap atlasMap = null;
		FileInfo[] pngs = dirInfo .GetFiles ("*.png", SearchOption .TopDirectoryOnly);
		FileInfo[] jpgs = dirInfo.GetFiles ("*.jpg", SearchOption .TopDirectoryOnly);
		if (pngs.Length > 0 || jpgs.Length > 0) {
			newGo = new GameObject(dirInfo.Name);
			atlasMap = newGo.AddComponent<AtlasMap>();
		} else {
			return;
		}
			
		loopAddSprite (dirInfo, atlasMap, "*.png");
		loopAddSprite (dirInfo, atlasMap, "*.jpg");


		string allPath = spriteDir + "/" + dirInfo.Name + ".prefab" ; 

		if (File.Exists (allPath)) {
			File.Delete(allPath);
		}
		
		string prefabPath = allPath . Substring ( allPath . IndexOf ( "Assets" ) ) ; 
		
		PrefabUtility . CreatePrefab ( prefabPath , newGo ) ; 
		
		GameObject . DestroyImmediate ( newGo ) ; 


		
	} 



	static void loopAddSprite(DirectoryInfo dirInfo,AtlasMap atlasMap,string fileExt)
	{
		foreach ( FileInfo pngFile in dirInfo . GetFiles ( fileExt , SearchOption .TopDirectoryOnly ) ) { 
			
			string allPath = pngFile . FullName ; 
			
			string assetPath = allPath . Substring ( allPath . IndexOf ( "Assets" ) ) ; 
			
			Sprite sprite = AssetDatabase.LoadAssetAtPath ( assetPath,typeof(Sprite) ) as Sprite; 
			if(sprite == null)
			{
				continue;
			}
			atlasMap.AddSprite(sprite);


			
		}

	}

}
