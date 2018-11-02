using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AtlasMap : MonoBehaviour {

	[System.Serializable]
	public class AtlasEntry
	{
		public string spriteName;
		public Sprite sprite;
	}

	public List<AtlasEntry> atlasEntries = new List<AtlasEntry>();


	Dictionary<string,Sprite> spriteMap = new Dictionary<string, Sprite>();

	void Awake()
	{
		int count = atlasEntries.Count;
		for (int i = 0; i < count; i++) {
			AtlasEntry entry = atlasEntries[i];
			spriteMap.Add(entry.spriteName,entry.sprite);
		}
	}


	public Sprite GetSprite(string spriteName)
	{
		Sprite sprite = null;
		spriteMap.TryGetValue (spriteName, out sprite);
		return sprite;
	}


	public void AddSprite(Sprite sprite)
	{
		AtlasEntry entry = new AtlasEntry ();
		entry.spriteName = sprite.name;
		entry.sprite = sprite;
		atlasEntries.Add (entry);
	}


}
