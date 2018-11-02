using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using framework.Utils;

public class PlanManager : Singleton<PlanManager> {


	Dictionary<string,Plan> plans = new Dictionary<string,Plan>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}




	public Plan GetTodayPlan()
	{
		return null;

	}


	public Plan GetTommoryPlan()
	{
		return null;
	}

}
