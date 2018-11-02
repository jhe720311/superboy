using UnityEngine;
using System.Collections;
using System;
using Constants;
using framework.Utils;

public class CommonYield : Singleton<CommonYield> {

	public void StartDelayAction(float seconds, Action action)
	{
		StartCoroutine (delayAction (seconds, action));
	}


	IEnumerator delayAction(float seconds,Action action)
	{
		yield return WaitSeconds.GetWaits(seconds);
		action ();
	}

}
