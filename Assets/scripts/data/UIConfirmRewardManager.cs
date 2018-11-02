using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIConfirmRewardManager : MonoBehaviour {

	[SerializeField]
	Transform itemParent;

	[SerializeField]
	UIConfirmItem uiConfirmPrefab;










	List<RewardData> rewards;

	List<UIConfirmItem> uiConfirmItems;

	List<UIConfirmItem> freeUiConfirmItems = new List<UIConfirmItem>();
	// Use this for initialization
	void Start () {

		Home myHome =  HomeManager.Instance ().GetMyHome ();	
		rewards = myHome.ConfirmRewards;
		refresh ();
	}

	public void refresh()
	{
		if (uiConfirmItems == null) {
			uiConfirmItems = new List<UIConfirmItem> ();
		}
		duqiUIConfirmItem ();
		int count = rewards.Count;
		for (int i = 0; i < count; i++) {

			RewardData rd = rewards [i];
			UIConfirmItem uiitem = uiConfirmItems[i];
			uiitem.RewardData = rd;



		}


	}


	void duqiUIConfirmItem(){
		int dataCount = rewards.Count;
		int uiCount = uiConfirmItems.Count;

		if (uiCount > dataCount) {
			int cha = uiCount - dataCount;
			for(int i = 0; i < cha;i++)
			{
				UIConfirmItem ui = uiConfirmItems[uiCount - i - 1];
				uiConfirmItems.RemoveAt (uiCount - i - 1);
				ui.gameObject.SetActive (false);
				ui.gameObject.transform.SetParent (null);
				freeUiConfirmItems.Add (ui);
			}
		}

		if (uiCount < dataCount) {
			int cha = dataCount - uiCount;
			for(int i = 0; i < cha;i++)
			{
				UIConfirmItem uiItem = getAUIConfirmItem ();
				uiItem.Manager = this;
				uiConfirmItems.Add (uiItem);

			}
		}

	}




	UIConfirmItem getAUIConfirmItem()
	{
		UIConfirmItem uiitem = null;
		if (freeUiConfirmItems.Count > 0) {
			uiitem = freeUiConfirmItems [freeUiConfirmItems.Count - 1];
			freeUiConfirmItems.RemoveAt (freeUiConfirmItems.Count - 1);

		} else {
			uiitem = GameObject.Instantiate<UIConfirmItem> (uiConfirmPrefab);
		}
		uiitem.transform.SetParent (itemParent);
		uiitem.gameObject.SetActive (true);
		return uiitem;

	}
}
