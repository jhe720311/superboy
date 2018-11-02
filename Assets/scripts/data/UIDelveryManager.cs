using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDelveryManager : MonoBehaviour {


	[SerializeField]
	Transform itemParent;

	[SerializeField]
	UIReadyDelveryItem uiReadyDelveryPrefab;





	[SerializeField]
	ConfirmDialog confirmDialog;


	[SerializeField]
	Text delveryResult;

	[SerializeField]
	UIDelveryRewardManager delveryRewardManager;








	List<RewardData> rewards;

	List<UIReadyDelveryItem> uiReadyDelveryItems;

	List<UIReadyDelveryItem> freeUiReadyDelveryItems = new List<UIReadyDelveryItem>();
	// Use this for initialization
	void Start () {
		Home myHome =  HomeManager.Instance ().GetMyHome ();	
		rewards = myHome.Rewards;
		refresh ();
	}

	void refresh()
	{
		if (uiReadyDelveryItems == null) {
			uiReadyDelveryItems = new List<UIReadyDelveryItem> ();
		}
		duqiUIRewardItem ();
		int count = rewards.Count;
		for (int i = 0; i < count; i++) {

			RewardData rd = rewards [i];
			UIReadyDelveryItem uiitem = uiReadyDelveryItems [i];
			uiitem.RewardData = rd;



		}


	}


	void duqiUIRewardItem(){
		int dataCount = rewards.Count;
		int uiCount = uiReadyDelveryItems.Count;

		if (uiCount > dataCount) {
			int cha = uiCount - dataCount;
			for(int i = 0; i < cha;i++)
			{
				UIReadyDelveryItem ui = uiReadyDelveryItems[uiCount - i - 1];
				uiReadyDelveryItems.RemoveAt (uiCount - i - 1);
				ui.gameObject.SetActive (false);
				ui.gameObject.transform.SetParent (null);
				freeUiReadyDelveryItems.Add (ui);
			}
		}

		if (uiCount < dataCount) {
			int cha = dataCount - uiCount;
			for(int i = 0; i < cha;i++)
			{
				UIReadyDelveryItem uiItem = getAUIReadyDelveryItem ();
				uiItem.Manager = this;
				uiReadyDelveryItems.Add (uiItem);

			}
		}

	}


	public string delveryReward(UIReadyDelveryItem uiItem)
	{
		RewardData rd = uiItem.RewardData;
		string err = HomeManager.Instance ().delveryAReward (rd);

		if (err == null) {
			HomeManager.Instance ().Save ();
			refresh();
			delveryRewardManager.refresh ();
			return null;


		} else {

			return err;
		}


	} 


	public void showConfirmDialog(UIReadyDelveryItem uiItem)
	{
		confirmDialog.show (() => {
			string result = delveryReward(uiItem);
			if(result == null)
			{
				result = "发送成功";
			}
			delveryResult.text = result;
		});
	}


	UIReadyDelveryItem getAUIReadyDelveryItem()
	{
		UIReadyDelveryItem uiitem = null;
		if (freeUiReadyDelveryItems.Count > 0) {
			uiitem = freeUiReadyDelveryItems [freeUiReadyDelveryItems.Count - 1];
			freeUiReadyDelveryItems.RemoveAt (freeUiReadyDelveryItems.Count - 1);

		} else {
			uiitem = GameObject.Instantiate<UIReadyDelveryItem> (uiReadyDelveryPrefab);
		}
		uiitem.transform.SetParent (itemParent);
		uiitem.gameObject.SetActive (true);
		return uiitem;

	}




	public void goBack()
	{
		empty.loadScene ("ParentMain");
	}

}
