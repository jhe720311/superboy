using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDelveryRewardManager : MonoBehaviour {


	[SerializeField]
	Transform itemParent;

	[SerializeField]
	UIDelveryItem uiDelveryPrefab;










	List<RewardData> rewards;

	List<UIDelveryItem> uiDelveryItems;

	List<UIDelveryItem> freeUiDelveyItems = new List<UIDelveryItem>();
	// Use this for initialization
	void Start () {

		Home myHome =  HomeManager.Instance ().GetMyHome ();	
		rewards = myHome.DeliveryRewords;
		refresh ();
	}

	public void refresh()
	{
		if (uiDelveryItems == null) {
			uiDelveryItems = new List<UIDelveryItem> ();
		}
		duqiUIDelveryItem ();
		int count = rewards.Count;
		for (int i = 0; i < count; i++) {

			RewardData rd = rewards [i];
			UIDelveryItem uiitem = uiDelveryItems[i];
			uiitem.RewardData = rd;



		}


	}


	void duqiUIDelveryItem(){
		int dataCount = rewards.Count;
		int uiCount = uiDelveryItems.Count;

		if (uiCount > dataCount) {
			int cha = uiCount - dataCount;
			for(int i = 0; i < cha;i++)
			{
				UIDelveryItem ui = uiDelveryItems[uiCount - i - 1];
				uiDelveryItems.RemoveAt (uiCount - i - 1);
				ui.gameObject.SetActive (false);
				ui.gameObject.transform.SetParent (null);
				freeUiDelveyItems.Add (ui);
			}
		}

		if (uiCount < dataCount) {
			int cha = dataCount - uiCount;
			for(int i = 0; i < cha;i++)
			{
				UIDelveryItem uiItem = getAUIDelveryItem ();
				uiItem.Manager = this;
				uiDelveryItems.Add (uiItem);

			}
		}

	}




	UIDelveryItem getAUIDelveryItem()
	{
		UIDelveryItem uiitem = null;
		if (freeUiDelveyItems.Count > 0) {
			uiitem = freeUiDelveyItems [freeUiDelveyItems.Count - 1];
			freeUiDelveyItems.RemoveAt (freeUiDelveyItems.Count - 1);

		} else {
			uiitem = GameObject.Instantiate<UIDelveryItem> (uiDelveryPrefab);
		}
		uiitem.transform.SetParent (itemParent);
		uiitem.gameObject.SetActive (true);
		return uiitem;

	}

}
