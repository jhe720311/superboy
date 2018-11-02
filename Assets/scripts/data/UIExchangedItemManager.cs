using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIExchangedItemManager : MonoBehaviour {


	[SerializeField]
	Transform itemParent;

	[SerializeField]
	UIExchangedItem uiExchangedPrefab;










	List<RewardData> rewards;

	List<UIExchangedItem> uiExchangedItems;

	List<UIExchangedItem> freeUiExchangedItems = new List<UIExchangedItem>();
	// Use this for initialization
	void Start () {

		Home myHome =  HomeManager.Instance ().GetMyHome ();	
		rewards = myHome.Rewards;
		refresh ();
	}

	public void refresh()
	{
		if (uiExchangedItems == null) {
			uiExchangedItems = new List<UIExchangedItem> ();
		}
		duqiUIExchangedItem ();
		int count = rewards.Count;
		for (int i = 0; i < count; i++) {

			RewardData rd = rewards [i];
			UIExchangedItem uiitem = uiExchangedItems[i];
			uiitem.RewardData = rd;



		}


	}


	void duqiUIExchangedItem(){
		int dataCount = rewards.Count;
		int uiCount = uiExchangedItems.Count;

		if (uiCount > dataCount) {
			int cha = uiCount - dataCount;
			for(int i = 0; i < cha;i++)
			{
				UIExchangedItem ui = uiExchangedItems[uiCount - i - 1];
				uiExchangedItems.RemoveAt (uiCount - i - 1);
				ui.gameObject.SetActive (false);
				ui.gameObject.transform.SetParent (null);
				freeUiExchangedItems.Add (ui);
			}
		}

		if (uiCount < dataCount) {
			int cha = dataCount - uiCount;
			for(int i = 0; i < cha;i++)
			{
				UIExchangedItem uiItem = getAUIExchangedItem ();
				uiItem.Manager = this;
				uiExchangedItems.Add (uiItem);

			}
		}

	}




	UIExchangedItem getAUIExchangedItem()
	{
		UIExchangedItem uiitem = null;
		if (freeUiExchangedItems.Count > 0) {
			uiitem = freeUiExchangedItems [freeUiExchangedItems.Count - 1];
			freeUiExchangedItems.RemoveAt (freeUiExchangedItems.Count - 1);

		} else {
			uiitem = GameObject.Instantiate<UIExchangedItem> (uiExchangedPrefab);
		}
		uiitem.transform.SetParent (itemParent);
		uiitem.gameObject.SetActive (true);
		return uiitem;

	}




}
