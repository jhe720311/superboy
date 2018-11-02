using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using framework.Utils;

public class AtlasCache : Singleton<AtlasCache> {


	public const string UnitPieceName = "piece";

	public const string UISprite_Ui = "Ui";

	public GameObject[] prefabs;
    public List<string> atlasCache = new List<string>();


	Dictionary<GameObject, AtlasMap> cache = new Dictionary<GameObject, AtlasMap>();
	Dictionary<string,AtlasMap> scache = new Dictionary<string, AtlasMap> ();


	protected override void onAwake ()
	{
		base.onAwake ();

		int count = prefabs.Length;
		for(int i = 0; i < count; i++)
		{
            _LoadAtlas(prefabs[i]);
		}
        count = atlasCache.Count;
        for (int i = 0; i < count; i++)
        {
            GameObject prefab = Resources.Load(atlasCache[i]) as GameObject;
            if (prefab == null)
                continue;
            _LoadAtlas(prefab);
        }
		startMark =  true;
	}

    protected void _LoadAtlas(GameObject prefab)
    {
        if (scache.ContainsKey(prefab.name))
            return;

        GameObject ao = GameObject.Instantiate(prefab) as GameObject;
        ao.transform.parent = transform;
        AtlasMap am = ao.GetComponent<AtlasMap>();
        cache.Add(prefab, am);
        scache.Add(prefab.name, am);
    }
	AtlasMap GetAtlasMap(GameObject prefab)
	{
		AtlasMap am = null;
		if (cache.TryGetValue (prefab, out am)) {
			return am;
		}

		GameObject ao = GameObject.Instantiate (prefab) as GameObject;
		ao.transform.parent = transform;
		am = ao.GetComponent<AtlasMap> ();
		if (am == null) {
			Debug.LogError("can not get atlias map from prefab");
			return null;
		}
		cache.Add (prefab, am);
		return am;

	}


	public AtlasMap GetAtlasMapByName(string name)
	{
		AtlasMap am = null;
		scache.TryGetValue (name, out am);
		return am;
	}

	public AtlasMap GetPieceIconAtlasMap()
	{
		return GetAtlasMapByName (UnitPieceName);

	}


	public AtlasMap GetUiMap()
	{
		return GetAtlasMapByName(UISprite_Ui);
	}
}
