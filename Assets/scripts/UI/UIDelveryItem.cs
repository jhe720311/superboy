using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDelveryItem : MonoBehaviour {
	[SerializeField]
	Text nameTxt;

	[SerializeField]
	Text countTxt;







	UIDelveryRewardManager manager;
	public UIDelveryRewardManager Manager {
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
