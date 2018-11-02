using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuyItem : MonoBehaviour {

	[SerializeField]
	Text nameTxt;

	[SerializeField]
	Text priceTxt;

	[SerializeField]
	Text countTxt;




	[SerializeField]
	Button btnConfirm;



	UIBuyManager manager;
	public UIBuyManager Manager {
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
			nameTxt.text = ""+_itemData.Name;
			countTxt.text = ""+_itemData.Count;

			if (_itemData.MoneyType == ItemData.MONEY_TYPE_DIAMOND) {
				priceTxt.text = ""+_itemData.Price+" 钻石";
			} else {
				priceTxt.text = ""+_itemData.Price+" 金币";
			}
			//btnConfirm.gameObject.SetActive (false);

		}

	}




	public void exChange(){
		manager.showConfirmDialog (this);
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
