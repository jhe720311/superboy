using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour {

	[SerializeField]
	Text nameTxt;

	[SerializeField]
	InputField priceInput;

	[SerializeField]
	Dropdown countDrop;

	[SerializeField]
	Toggle mtToggle;


	[SerializeField]
	Button btnConfirm;



	UIItemManager manager;
	public UIItemManager Manager {
		get {
			return this.manager;
		}
		set {
			manager = value;
		}
	}

	ItemData _itemData;

	public ItemData ItemData {
		get {
			return this._itemData;
		}
		set {
			_itemData = value;
			refresh ();
		}
	}

	void refresh()
	{
		if (_itemData != null) {
			nameTxt.text = _itemData.Name;
			countDrop.value = _itemData.Count;
			priceInput.text = ""+_itemData.Price;
			if (_itemData.MoneyType == ItemData.MONEY_TYPE_DIAMOND) {
				mtToggle.isOn = true;
			} else {
				mtToggle.isOn = false;
			}
			btnConfirm.gameObject.SetActive (false);

		}

	}

	public void onContentChange()
	{
		btnConfirm.gameObject.SetActive (true);
	}

	public void confirmModify()
	{
		readUserChange ();
		HomeManager.Instance ().Save ();
		btnConfirm.gameObject.SetActive (false);
	}

	void readUserChange()
	{

		_itemData.Count = countDrop.value;
		_itemData.Price = int.Parse(priceInput.text);
		_itemData.MoneyType = mtToggle.isOn ? 1 : 0;


	}


	public void delete(){
		manager.showConfirmDialog (this);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
