using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Plan : MonoBehaviour {

	DateTime date = new DateTime();
	string dateString;


	List<PlanItem> planItems = new List <PlanItem>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string Date{
		get{
			return dateString;
		}
	}

	public List<PlanItem> PlanItems{
		get{
			return planItems;
		}
	}


}
