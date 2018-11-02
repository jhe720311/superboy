using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetManager : MonoBehaviour {
	[SerializeField]
	Animator animator;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void OpenBox()
	{
		animator.SetTrigger ("open");
	}

	public void CloseBox(){
		animator.SetTrigger ("close");
	}
}
