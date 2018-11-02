using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour {

	[SerializeField]
	Animator animator;

	bool openMark = false;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}


	public void HandleBox()
	{
		if (openMark) {
			CloseBox ();
		} else {
			OpenBox ();

		}
	}
	void OpenBox()
	{
		animator.SetTrigger ("open");
		openMark = true;
	}

	void CloseBox(){
		animator.SetTrigger ("close");
		openMark = false;
	}
}
