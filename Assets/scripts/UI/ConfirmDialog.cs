using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConfirmDialog : MonoBehaviour {

	[SerializeField]
	GameObject obj;



	Action sureAction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void show(Action sure)
	{
		sureAction = sure;
		obj.SetActive (true);

	}


	public void hide()
	{
		sureAction = null;
		obj.SetActive (false);

	}

	public void sure()
	{
		if (sureAction != null) {
			sureAction ();
		}
		hide ();
	}

}
