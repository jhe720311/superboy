using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioMap : MonoBehaviour {
	
	[System.Serializable]
	public class AudioEntry
	{
		public string audioName;
		public AudioClip clip;
	}
	
	public List<AudioEntry> audioEntries = new List<AudioEntry>();
	
	
	Dictionary<string,AudioClip> clipMap = new Dictionary<string, AudioClip>();
	
	void Awake()
	{
		int count = audioEntries.Count;
		for (int i = 0; i < count; i++) {
			AudioEntry entry = audioEntries[i];
			clipMap.Add(entry.audioName,entry.clip);
		}
	}
	
	
	public AudioClip GetAudioClip(string audioName)
	{
		AudioClip clip = null;
		clipMap.TryGetValue (audioName, out clip);
		return clip;
	}
	
	
	public void AddAudioClip(AudioClip clip)
	{
		AudioEntry entry = new AudioEntry ();
		entry.audioName = clip.name;
		entry.clip = clip;
		audioEntries.Add (entry);
	}
	
	
}
