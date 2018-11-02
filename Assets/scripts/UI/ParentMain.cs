using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ParentMain : MonoBehaviour {

	Home myHome;
	[SerializeField]
	Text motherCaption;
	[SerializeField]
	Text fatherCaption;
	[SerializeField]
	Text childCaption;

	[SerializeField]
	Text goldCap;

	[SerializeField]
	Text diamondCap;

	// Use this for initialization
	void Start () {
		myHome = HomeManager.Instance ().GetMyHome ();
		motherCaption.text = myHome.Mother;
		fatherCaption.text = myHome.Father;
		childCaption.text = myHome.Child;
		goldCap.text = ""+HomeManager.Instance ().GetGoldCount ();
		diamondCap.text = ""+HomeManager.Instance ().GetDiamondCount ();

	}


	public void goDelvery()
	{
		SceneManager.LoadScene ("DelveryReward");

	}

	public void goItems()
	{
		SceneManager.LoadScene ("items");
	}


	public void goBack()
	{
		empty.loadScene ("main");
	}


	// Update is called once per frame
	void Update () {

	}
}
