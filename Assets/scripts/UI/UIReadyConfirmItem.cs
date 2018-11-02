using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIReadyConfirmItem : MonoBehaviour {

	[SerializeField]
	Text nameTxt;


	[SerializeField]
	Text countTxt;




	[SerializeField]
	Button btnConfirm;



	UIConfirmManager manager;
	public UIConfirmManager Manager {
		get {
			return this.manager;
		}
		set {
			manager = value;
		}
	}

	RewardData _rewardData;

	public RewardData RewardData {
		get {
			return this._rewardData;
		}
		set {
			_rewardData = value;
			refresh ();
		}
	}

	void refresh()
	{
		if (_rewardData != null) {
			nameTxt.text = ""+_rewardData.Name;
			countTxt.text = ""+_rewardData.Count;

			//btnConfirm.gameObject.SetActive (false);

		}

	}




	public void confirm(){
		manager.showConfirmDialog (this);
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
