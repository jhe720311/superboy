// Warning: Some assembly references could not be resolved automatically. This might lead to incorrect decompilation of some parts,
// for ex. property getter/setter access. To get optimal decompilation results, please manually add the missing references to the list of loaded assemblies.
// UIBuyManager
using framework.Utils;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuyManager : MonoBehaviour
{
    [SerializeField]
    private Transform itemParent;

    [SerializeField]
    private UIBuyItem uiBuyPrefab;

    [SerializeField]
    private Text goldCount;

    [SerializeField]
    private Text diamondCount;

    [SerializeField]
    private ConfirmDialog confirmDialog;

    [SerializeField]
    private Text exchangeResult;

    [SerializeField]
    private UIExchangedItemManager exchangeManager;

    private int curGold;

    private int curDiamond;

    private List<ItemData> items;

    private List<UIBuyItem> uiItems;

    private List<UIBuyItem> freeUiItems = new List<UIBuyItem>();

    public UIBuyManager()
    {
    }

    private void refreshMoney()
    {
        goldCount.text = "" + curGold;
        diamondCount.text="" + curDiamond;
    }

    private void loadMoneyAndDiamond()
    {
        curGold = PlayerPrefs.GetInt("gold", 0);
        curDiamond = PlayerPrefs.GetInt("diamond", 0);
        refreshMoney();
    }

    private void Start()
    {
        loadMoneyAndDiamond();
        Home myHome = Singleton<HomeManager>.Instance().GetMyHome();
        items = myHome.Items;
        refresh();
    }

    private void refresh()
    {
        if (uiItems == null)
        {
            uiItems = new List<UIBuyItem>();
        }
        duqiUIBuyItem();
        int count = items.Count;
        for (int i = 0; i < count; i++)
        {
            ItemData itemData = items[i];
            UIBuyItem uIBuyItem = uiItems[i];
            uIBuyItem.ItemData = itemData;
        }
    }

    private void duqiUIBuyItem()
    {
        int count = items.Count;
        int count2 = uiItems.Count;
        if (count2 > count)
        {
            int num = count2 - count;
            for (int i = 0; i < num; i++)
            {
                UIBuyItem uIBuyItem = uiItems[count2 - i - 1];
                uiItems.RemoveAt(count2 - i - 1);
                uIBuyItem.gameObject.SetActive(false);
                uIBuyItem.transform.SetParent(null);
                freeUiItems.Add(uIBuyItem);
            }
        }
        if (count2 < count)
        {
            int num2 = count - count2;
            for (int j = 0; j < num2; j++)
            {
                UIBuyItem aUIBuyItem = getAUIBuyItem();
                aUIBuyItem.Manager = this;
                uiItems.Add(aUIBuyItem);
            }
        }
    }

    public string buyItem(UIBuyItem uiItem)
    {
        ItemData itemData = uiItem.ItemData;
        int price = itemData.Price;
        if (itemData.MoneyType == 0)
        {
            if (price > curGold)
            {
                return "金币不足";
            }
        }
        else if (price > curDiamond)
        {
            return "钻石不足";
        }
        string text = Singleton<HomeManager>.Instance().buyAItem(itemData);
        if (text == null)
        {
            if (itemData.MoneyType == 0)
            {
                curGold -= price;
            }
            else
            {
                curDiamond -= price;
            }
            saveAndReset();
            Singleton<HomeManager>.Instance().Save();
            refresh();
            exchangeManager.refresh();
            return null;
        }
        return text;
    }

    public void showConfirmDialog(UIBuyItem uiItem)
    {
        confirmDialog.show(delegate
        {
            string text = buyItem(uiItem);
            if (text == null)
            {
                text = "兑换成功";
            }
            exchangeResult.text =text;
        });
    }

    private UIBuyItem getAUIBuyItem()
    {
        UIBuyItem uIBuyItem = null;
        if (freeUiItems.Count > 0)
        {
            uIBuyItem = freeUiItems[freeUiItems.Count - 1];
            freeUiItems.RemoveAt(freeUiItems.Count - 1);
        }
        else
        {
            uIBuyItem = Object.Instantiate<UIBuyItem>(uiBuyPrefab);
        }
        uIBuyItem.transform.SetParent(itemParent);
        uIBuyItem.gameObject.SetActive(true);
        return uIBuyItem;
    }

    public void saveAndReset()
    {
        PlayerPrefs.SetInt("gold", curGold);
        PlayerPrefs.SetInt("diamond", curDiamond);
        refreshMoney();
    }

    private void Update()
    {
    }

    public void goBack()
    {
        empty.loadScene("main");
    }
}
