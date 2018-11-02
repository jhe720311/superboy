using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemManager : MonoBehaviour {

	[SerializeField]
	Transform itemParent;

	[SerializeField]
	UIItem uiItemPrefab;

	[SerializeField]
	InputField newItemName;

	[SerializeField]
	Text addResult;

	[SerializeField]
	InputField resetGold;

	[SerializeField]
	InputField resetDiamond;

	[SerializeField]
	Text goldCount;

	[SerializeField]
	Text diamondCount;

	[SerializeField]
	GameObject dialog;

	[SerializeField]
	ConfirmDialog confirmDialog;



//	int curGold =0;
//	int curDiamond = 0;



	void refreshMoney()
	{
		goldCount.text = ""+HomeManager.Instance().GetGoldCount();
		diamondCount.text = "" + HomeManager.Instance ().GetDiamondCount ();

	}


	void loadMoneyAndDiamond()
	{
		//curGold = PlayerPrefs.GetInt (Table.GOLD_KEY,0);
	//	curDiamond = PlayerPrefs.GetInt (Table.DIAMOND_KEY, 0);

		refreshMoney ();

	}



	List<ItemData> items;

	List<UIItem> uiItems;

	List<UIItem> freeUiItems = new List<UIItem>();
	// Use this for initialization
	void Start () {
		loadMoneyAndDiamond ();
		Home myHome =  HomeManager.Instance ().GetMyHome ();	
		items = myHome.Items;
		refresh ();
	}

	void refresh()
	{
		if (uiItems == null) {
			uiItems = new List<UIItem> ();
		}
		duqiUIItem ();
		int count = items.Count;
		for (int i = 0; i < count; i++) {

			ItemData id = items [i];
			UIItem uiitem = uiItems [i];
			uiitem.ItemData = id;



		}


	}


	void duqiUIItem(){
		int dataCount = items.Count;
		int uiCount = uiItems.Count;

		if (uiCount > dataCount) {
			int cha = uiCount - dataCount;
			for(int i = 0; i < cha;i++)
			{
				UIItem ui = uiItems[uiCount - i - 1];
				uiItems.RemoveAt (uiCount - i - 1);
				ui.gameObject.SetActive (false);
				ui.gameObject.transform.SetParent (null);
				freeUiItems.Add (ui);
			}
		}

		if (uiCount < dataCount) {
			int cha = dataCount - uiCount;
			for(int i = 0; i < cha;i++)
			{
				UIItem uiItem = getAUIItem ();
				uiItem.Manager = this;
				uiItems.Add (uiItem);

			}
		}

	}


	public void deleteItem(UIItem uiItem)
	{
		ItemData id = uiItem.ItemData;
		items.Remove (id);
		refresh ();
		HomeManager.Instance ().Save ();
	} 


	public void showConfirmDialog(UIItem uiItem)
	{
		confirmDialog.show (() => {
			deleteItem(uiItem);
		});
	}


	UIItem getAUIItem()
	{
		UIItem uiitem = null;
		if (freeUiItems.Count > 0) {
			uiitem = freeUiItems [freeUiItems.Count - 1];
			freeUiItems.RemoveAt (freeUiItems.Count - 1);

		} else {
			uiitem = GameObject.Instantiate<UIItem> (uiItemPrefab);
		}
		uiitem.transform.SetParent (itemParent);
		uiitem.gameObject.SetActive (true);
		return uiitem;

	}


	public void  showDialog(){
		resetDiamond.text =""+ HomeManager.Instance().GetDiamondCount();
		resetGold.text = "" + HomeManager.Instance ().GetGoldCount ();

		dialog.SetActive (true);
	}

	public void sureResetValue()
	{
		HomeManager.Instance ().SetGoldAndDiamond (int.Parse (resetGold.text), int.Parse (resetDiamond.text));

		//curGold = int.Parse( resetGold.text);
		//curDiamond = int.Parse (resetDiamond.text);
		saveAndReset ();
		dialog.SetActive (false);

	}

	public void cancelResetValue()
	{
		dialog.SetActive (false);
	}

	public void saveAndReset()
	{

		//PlayerPrefs.SetInt (Table.GOLD_KEY, curGold);
		//PlayerPrefs.SetInt (Table.DIAMOND_KEY, curDiamond);
		HomeManager.Instance().saveGoldAndDiamond();
		refreshMoney ();


	}




	public void addItem()
	{
		string itemName = this.newItemName.text;
		string err = HomeManager.Instance ().AddANewItemByName (itemName);
		if (err == null) {
			HomeManager.Instance ().Save ();
			err = "增加成功";
			refresh ();
		}

		addResult.text = err;


	}

	public void  goBack(){
		empty.loadScene ("ParentMain");
	}


}
