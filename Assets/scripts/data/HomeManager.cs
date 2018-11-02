using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using framework.Utils;
using System;

public class HomeManager : Singleton<HomeManager> {

	const string HOME_KEY = "HOME_KEY";


	public const string GOLD_KEY = "gold";
	public const string DIAMOND_KEY = "diamond";

	Home myHome = null;
	int goldCount = 0;
	int diamondCount = 0;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		Load ();
	}



	void Load()
	{
		Home dh = Home.GetADefaultHome ();
		string defaultString = JsonUtility.ToJson (dh);
		string value = PlayerPrefs.GetString (HOME_KEY, defaultString);
		goldCount = PlayerPrefs.GetInt (GOLD_KEY,0);
		diamondCount = PlayerPrefs.GetInt (DIAMOND_KEY, 0);
		//OutLog.Log ("读取:"+value);

		try{
			//myHome= JsonReader.Deserialize<Home> (value);
			myHome = JsonUtility.FromJson<Home>(value);
			if(myHome.BoxDatas == null)
			{
				myHome.BoxDatas = new List<BoxData>();
			}

		}catch(Exception e) {
			//OutLog.Log ("错误："+e.Message);
			PlayerPrefs.DeleteKey (HOME_KEY);
			value = PlayerPrefs.GetString (HOME_KEY, defaultString);
			myHome= JsonUtility.FromJson<Home> (value);


		}

	}

	public int GetGoldCount()
	{
		return goldCount;
	}

	public int GetDiamondCount(){
		return diamondCount;
	}

	public void saveGoldAndDiamond()
	{
		PlayerPrefs.SetInt (GOLD_KEY, goldCount);
		PlayerPrefs.SetInt (DIAMOND_KEY, diamondCount);

	}


	public void SetGoldAndDiamond(int goldCount,int diamondCount)
	{
		this.goldCount = goldCount;
		this.diamondCount = diamondCount;


	}
	public void AddGold(int count)
	{
		goldCount += count;
	}

	public void AddDiamond(int count)
	{
		diamondCount += count;
	}

	public void UseGold(int count)
	{
		goldCount -= count;
	}

	public void UseDiamond(int count)
	{
		diamondCount -= count;
	}

	public void Save()
	{
		string value = JsonUtility.ToJson (myHome);
		PlayerPrefs.SetString (HOME_KEY, value);

	}


	public Home GetMyHome()
	{
		return myHome;
	}



	public string AddANewItemByName(string newName)
	{

		if (newName == null || newName.Trim () == "") {
			return "名字不能为空";
		}
		else if (myHome == null) {
			return "没有家庭信息";
		} else if (isThisNameExit (newName)) {
			return "这个名字已经存在";
		}


		ItemData newItem = new ItemData ();
		newItem.Name = newName;
		newItem.Count = 1;

		newItem.MoneyType = ItemData.MONEY_TYPE_GOLD;
		newItem.Price = 10;
		myHome.Items.Add (newItem);
		return null;

	}

	public string buyAItem(ItemData id){
		

		if (id.Count > 0) {

			id.Count -= 1;
			AddANewReward (id.Name);
			return null;
		} else {
			return "库存不足";
		}
	}

	public string delveryAReward(RewardData rd){


		if (rd.Count > 0) {

			rd.Count -= 1;
			AddADelveryReward (rd.Name);
			if(rd.Count == 0)
			{
				GetMyHome().Rewards.Remove(rd);
			}
			return null;
		} else {
			GetMyHome().Rewards.Remove(rd);
			return "没有可发送货物不足";
		}


	}

	public string confirmAReward(RewardData rd){


		if (rd.Count > 0) {

			rd.Count -= 1;
			AddAConfirmedReward (rd.Name);
			if(rd.Count == 0)
			{
				GetMyHome().DeliveryRewords.Remove(rd);
			}
			return null;
		} else {
			GetMyHome().DeliveryRewords.Remove(rd);
			return "没有可以确认的货物";
		}


	}

	public void AddAConfirmedReward(string name)
	{
		if (myHome.ConfirmRewards == null) {
			myHome.ConfirmRewards = new List<RewardData> ();
		}
		int count = myHome.ConfirmRewards.Count;
		RewardData rd = null;
		if (count > 0) {
			for (int i = 0; i < count; i++) {
				RewardData lrd = myHome.ConfirmRewards [i];
				if (lrd.Name == name) {
					rd = lrd;
					break;
				}
			}
		}
		if (rd == null) {
			rd = new RewardData();
			rd.Name = name;
			rd.Count = 0;	
			myHome.ConfirmRewards.Add (rd);
		}
		rd.Count += 1;

	}


	public void AddADelveryReward(string name)
	{
		if (myHome.DeliveryRewords == null) {
			myHome.DeliveryRewords = new List<RewardData> ();
		}
		int count = myHome.DeliveryRewords.Count;
		RewardData rd = null;
		if (count > 0) {
			for (int i = 0; i < count; i++) {
				RewardData lrd = myHome.DeliveryRewords [i];
				if (lrd.Name == name) {
					rd = lrd;
					break;
				}
			}
		}
		if (rd == null) {
			rd = new RewardData();
			rd.Name = name;
			rd.Count = 0;	
			myHome.DeliveryRewords.Add (rd);
		}
		rd.Count += 1;

	}

	public void AddANewReward(string itemName)
	{
		if (myHome.Rewards == null) {
			myHome.Rewards = new List<RewardData> ();
		}
		int count = myHome.Rewards.Count;
		RewardData rd = null;
		if (count > 0) {
			for (int i = 0; i < count; i++) {
				RewardData lrd = myHome.Rewards [i];
				if (lrd.Name == itemName) {
					rd = lrd;
					break;
				}
			}
		}
		if (rd == null) {
			rd = new RewardData();
			rd.Name = itemName;
			rd.Count = 0;	
			myHome.Rewards.Add (rd);
		}
		rd.Count += 1;

	}

	public bool isThisNameExit(string name)
	{

		int count = myHome.Items.Count;
		for (int i = 0; i < count; i++) {
			ItemData item = myHome.Items [i];
			if (item.Name == name) {
				return true;
			}
		}


		return false;
	}


}
