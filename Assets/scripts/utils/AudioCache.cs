using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using framework.Utils;

public class AudioCache : Singleton<AudioCache> {
	
	
	public const string AudioName = "Audios";

	public GameObject[] prefabs;
	public List<string> audioCache = new List<string>();
	
	
	Dictionary<GameObject, AudioMap> cache = new Dictionary<GameObject, AudioMap>();
	Dictionary<string,AudioMap> scache = new Dictionary<string, AudioMap> ();
	
	
	void Start()
	{
		int count = prefabs.Length;
		for(int i = 0; i < count; i++)
		{
			_LoadAudio(prefabs[i]);
		}
		count = audioCache.Count;
		for (int i = 0; i < count; i++)
		{
			GameObject prefab = Resources.Load(audioCache[i]) as GameObject;
			if (prefab == null)
				continue;
			_LoadAudio(prefab);
		}
		startMark =  true;
	}
	
	protected void _LoadAudio(GameObject prefab)
	{
		if (scache.ContainsKey(prefab.name))
			return;
		
		GameObject ao = GameObject.Instantiate(prefab) as GameObject;
		ao.transform.parent = transform;
		AudioMap am = ao.GetComponent<AudioMap>();
		cache.Add(prefab, am);
		scache.Add(prefab.name, am);
	}
	AudioMap GetAudioMap(GameObject prefab)
	{
		AudioMap am = null;
		if (cache.TryGetValue (prefab, out am)) {
			return am;
		}
		
		GameObject ao = GameObject.Instantiate (prefab) as GameObject;
		ao.transform.parent = transform;
		am = ao.GetComponent<AudioMap> ();
		if (am == null) {
			Debug.LogError("can not get atlias map from prefab");
			return null;
		}
		cache.Add (prefab, am);
		return am;
		
	}
	
	
	public AudioMap GetAudioMapByName(string name)
	{
		AudioMap am = null;
		scache.TryGetValue (name, out am);
		return am;
	}
	
	public AudioMap GetAudioMap()
	{
		return GetAudioMapByName (AudioName);
		
	}
	

}
