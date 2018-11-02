using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BoxItemData {

    public enum BoxItemType
    {
        NONE= 0,
        GOLD = 1,
        DIAMOND=2,
        ITEM=3,
         VIRTUAL=4,
        
    }


    public BoxItemType itemType  = BoxItemType.NONE;
    
	public string boxName;

    public int count;

    public int weight;


}
