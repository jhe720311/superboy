using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIConfirmManager : MonoBehaviour {


	[SerializeField]
	Transform itemParent;

	[SerializeField]
	UIReadyConfirmItem uiReadyConfirmPrefab;





	[SerializeField]
	ConfirmDialog confirmDialog;


	[SerializeField]
	Text confirmResult;

	[SerializeField]
	UIConfirmRewardManager delveryRewardManager;








	List<RewardData> rewards;

	List<UIReadyConfirmItem> uiReadyConfirmItems;

	List<UIReadyConfirmItem> freeUiReadyConfirmItems = new List<UIReadyConfirmItem>();
	// Use this for initialization
	void Start () {
		Home myHome =  HomeManager.Instance ().GetMyHome ();	
		rewards = myHome.DeliveryRewords;
		refresh ();
	}

	void refresh()
	{
		if (uiReadyConfirmItems == null) {
			uiReadyConfirmItems = new List<UIReadyConfirmItem> ();
		}
		duqiUIConfirmItem ();
		int count = rewards.Count;
		for (int i = 0; i < count; i++) {

			RewardData rd = rewards [i];
			UIReadyConfirmItem uiitem = uiReadyConfirmItems [i];
			uiitem.RewardData = rd;



		}


	}


	void duqiUIConfirmItem(){
		int dataCount = rewards.Count;
		int uiCount = uiReadyConfirmItems.Count;

		if (uiCount > dataCount) {
			int cha = uiCount - dataCount;
			for(int i = 0; i < cha;i++)
			{
				UIReadyConfirmItem ui = uiReadyConfirmItems[uiCount - i - 1];
				uiReadyConfirmItems.RemoveAt (uiCount - i - 1);
				ui.gameObject.SetActive (false);
				ui.gameObject.transform.SetParent (null);
				freeUiReadyConfirmItems.Add (ui);
			}
		}

		if (uiCount < dataCount) {
			int cha = dataCount - uiCount;
			for(int i = 0; i < cha;i++)
			{
				UIReadyConfirmItem uiItem = getAUIReadyConfirmItem ();
				uiItem.Manager = this;
				uiReadyConfirmItems.Add (uiItem);

			}
		}

	}


	public string confirmReward(UIReadyConfirmItem uiItem)
	{
		RewardData rd = uiItem.RewardData;
		string err = HomeManager.Instance ().confirmAReward (rd);

		if (err == null) {
			HomeManager.Instance ().Save ();
			refresh();
			delveryRewardManager.refresh ();
			return null;


		} else {

			return err;
		}


	} 


	public void showConfirmDialog(UIReadyConfirmItem uiItem)
	{
		confirmDialog.show (() => {
			string result = confirmReward(uiItem);
			if(result == null)
			{
				result = "发送成功";
			}
			confirmResult.text = result;
		});
	}


	UIReadyConfirmItem getAUIReadyConfirmItem()
	{
		UIReadyConfirmItem uiitem = null;
		if (freeUiReadyConfirmItems.Count > 0) {
			uiitem = freeUiReadyConfirmItems [freeUiReadyConfirmItems.Count - 1];
			freeUiReadyConfirmItems.RemoveAt (freeUiReadyConfirmItems.Count - 1);

		} else {
			uiitem = GameObject.Instantiate<UIReadyConfirmItem> (uiReadyConfirmPrefab);
		}
		uiitem.transform.SetParent (itemParent);
		uiitem.gameObject.SetActive (true);
		return uiitem;

	}




	public void goBack()
	{
		empty.loadScene ("main");
	}

}
