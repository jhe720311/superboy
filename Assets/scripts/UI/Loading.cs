using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

	const float SPEED = 0.5f;
	[SerializeField]
	private Slider slider = null;

	float process = 0f;

	bool endMark = false;

	// Use this for initialization
	void Start () {
		StartCoroutine( LoadResource ());
		
	}
	
	// Update is called once per frame
	void Update () {
		if (endMark) {
			return;
		}

		if (slider.value < process) {
			slider.value += Time.deltaTime * SPEED;
		} else {
			slider.value = process;
		}

		if (slider.value >= slider.maxValue) {
			endMark = true;
			gotoAdopt ();
		}
	}

	void gotoAdopt()
	{
		empty.loadScene ("main");
	}

	IEnumerator LoadResource(){
		while (true) {
			
			process += 0.1f * SPEED;
			if (process >= 1f) {
				process =1f;
				break;
			}
			yield return new WaitForSeconds (0.1f);

		}
	}
}
