using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIReadyDelveryItem : MonoBehaviour {

	[SerializeField]
	Text nameTxt;


	[SerializeField]
	Text countTxt;




	[SerializeField]
	Button btnConfirm;



	UIDelveryManager manager;
	public UIDelveryManager Manager {
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




	public void delvery(){
		manager.showConfirmDialog (this);
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
