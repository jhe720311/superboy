using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ItemData {
	public const int MONEY_TYPE_GOLD = 0;
	public const int MONEY_TYPE_DIAMOND = 1;
	public string Name;
	public int Count;
	public int Price;
	public int MoneyType;


}
