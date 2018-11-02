using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIConfirmItem : MonoBehaviour {
	[SerializeField]
	Text nameTxt;

	[SerializeField]
	Text countTxt;







	UIConfirmRewardManager manager;
	public UIConfirmRewardManager Manager {
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

		}

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
