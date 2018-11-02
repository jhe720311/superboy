using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Home  {

	public Home()
	{

	}


	public Home (string father, string mother, string child, List<ItemData> items, List<RewardData> rewards, List<RewardData> deliveryRewords, List<RewardData> confirmRewards,List<BoxData> boxDatas)
	{
		this.Father = father;
		this.Mother = mother;
		this.Child = child;
		this.Items = items;
		this.Rewards = rewards;
		this.DeliveryRewords = deliveryRewords;
		this.ConfirmRewards = confirmRewards;
		this.BoxDatas = boxDatas;
	}

	public string Father;
	public string Mother;
	public string Child;

	public List<ItemData> Items;
	//兑换的奖励
	public List<RewardData> Rewards;
	//发货的奖励
	public List<RewardData> DeliveryRewords;
	//确认的奖励
	public List<RewardData> ConfirmRewards;

	public List<BoxData> BoxDatas;

	static Home defaultHome;

	public static  Home GetADefaultHome()
	{
		if (defaultHome == null) {
			defaultHome = new Home ("贺炬", "罗晓", "贺若缺", new List<ItemData> (), new List<RewardData> (), new List<RewardData> (), new List<RewardData> (), new List<BoxData> ());
		}
		return defaultHome;
	}


}
