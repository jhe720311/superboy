using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

	Home myHome;
	[SerializeField]
	Text motherCaption;
	[SerializeField]
	Text fatherCaption;
	[SerializeField]
	Text childCaption;

	[SerializeField]
	Text diamodCap;

	[SerializeField]
	Text goldCap;

	// Use this for initialization
	void Start () {
		myHome = HomeManager.Instance ().GetMyHome ();
		motherCaption.text = myHome.Mother;
		fatherCaption.text = myHome.Father;
		childCaption.text = myHome.Child;
		diamodCap.text = ""+HomeManager.Instance ().GetDiamondCount ();
		goldCap.text = ""+HomeManager.Instance ().GetGoldCount ();

	}


	public void goAdopt()
	{
		SceneManager.LoadScene ("adopt");

	}

	public void goConfirm()
	{
		SceneManager.LoadScene ("childReward");
	}

	public void goReward()
	{
		empty.loadScene ("child");
	}

	public void goParentMain()
	{
		empty.loadScene ("ParentMain");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
