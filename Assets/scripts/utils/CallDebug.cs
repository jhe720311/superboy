using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CallDebug : MonoBehaviour,IPointerClickHandler {

	float _lastClickTime = 0;

	public void OnPointerClick (PointerEventData eventData)
	{
		if (eventData.pointerId == -1 && eventData.clickCount ==2 ) {
			Startup.Instance ().ChangeOutlogStatus ();
			return;
		}
		if (eventData.pointerId == 0) {

			//GAStats.Instance ().SendEvent (StatisticsKey.C_DEBUG, StatisticsKey.E_OPEN_OUTLOG);
			float curTime = Time.realtimeSinceStartup;
			if (curTime - _lastClickTime < 0.2f) {

				Startup.Instance ().ChangeOutlogStatus ();
			}
			_lastClickTime = curTime;
			return;
		}
	}
}
