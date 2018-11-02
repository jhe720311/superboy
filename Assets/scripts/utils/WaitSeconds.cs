using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Constants{
	public class WaitSeconds  {
		public static Dictionary<float,WaitForSeconds> waits = new  Dictionary<float, WaitForSeconds> ();
		public static WaitForSeconds wait1s = new WaitForSeconds(1f);
		public static WaitForSeconds wait2s = new WaitForSeconds(2f);
		public static WaitForSeconds wait3s = new WaitForSeconds(3f);
		public static WaitForSeconds wait4s = new WaitForSeconds(4f);
		public static WaitForSeconds wait5s = new WaitForSeconds(5f);
		public static WaitForSeconds wait10s = new WaitForSeconds(10f);
		public static WaitForSeconds wait15s = new WaitForSeconds(15f);
		public static WaitForSeconds wait20s = new WaitForSeconds(20f);

		public static WaitForSeconds wait0_0_5s = new WaitForSeconds(0.05f);
		public static WaitForSeconds wait0_1s = new WaitForSeconds(0.1f);
		public static WaitForSeconds wait0_2s = new WaitForSeconds(0.2f);
		public static WaitForSeconds wait0_3s = new WaitForSeconds(0.3f);
		public static WaitForSeconds wait0_4s = new WaitForSeconds(0.4f);
		public static WaitForSeconds wait0_5s = new WaitForSeconds(0.5f);
		public static WaitForSeconds wait0_6s = new WaitForSeconds(0.6f);
		public static WaitForSeconds wait0_7s = new WaitForSeconds(0.7f);
		public static WaitForSeconds wait0_8s = new WaitForSeconds(0.8f);
		public static WaitForSeconds wait0_9s = new WaitForSeconds(0.9f);


		public static WaitForFixedUpdate waitFixedUpdate = new WaitForFixedUpdate();
		public static WaitForEndOfFrame waitForEndFrame = new WaitForEndOfFrame();	



		public static WaitForSeconds GetWaits(float seconds)
		{
			if (waits.ContainsKey (seconds)) {
				return waits[seconds];
			}

			WaitForSeconds ws = new WaitForSeconds (seconds);
			waits[seconds] = ws;
			return ws;

		}

	}
}