using UnityEngine;
using System.Collections;
using Constants;
using framework.Utils;
//using I2.Loc;
using UnityEngine.SceneManagement;

public class Startup : Singleton<Startup> {

	[SerializeField]
	OutLog _outLog;


	int scaleWidth,scaleHeight;

	void Start () {
		setDesignContentScale ();
		DontDestroyOnLoad (gameObject);

//		string lan = LocalizationManager.CurrentLanguage;
		StartCoroutine (delayLoad ());



//		if (UIGame.AlreadyEnterMark > 0) {
//			GAStats.Instance ().SendEvent (StatisticsKey.C_OLD_USER, ""+UIGame.AlreadyEnterMark);
//			UIGame.AlreadyEnterMark = UIGame.AlreadyEnterMark+1;
//
//
//		} else {
//			GAStats.Instance ().SendEvent (StatisticsKey.C_NEW_USER, "SHOW");
//			UIGame.AlreadyEnterMark = 1;
//
//		}
//		AdSdk.Instance ().getAdsState ();
	}


	public void ChangeOutlogStatus()
	{
		if (_outLog.enabled) {
			_outLog.enabled = false;
		} else {
			_outLog.enabled = true;
			OutLog.Log ("enable outlog");

		}
	}
	IEnumerator delayLoad()
	{
		while(true){
//			if(RemoteConfig.Instance() == null)
//			{
//				yield return null;
//				continue;
//			}
//
//			if (!RemoteConfig.Instance ().IsStart ()) {
//				yield return null;
//				continue;
//			}

//			if (AdSdk.Instance () == null) {
//				yield return null;
//				continue;
//			}
			break;
		}
//		AdSdk.Instance ().BindInAppPurchaseService ();
//		NativeAdUI.Instance ().ShowNativeAd (20);
		yield return WaitSeconds.wait2s;
//		NativeAdUI.Instance ().HideNativeAd ();
		SceneManager.LoadScene("loading");



	}


	public void setDesignContentScale()
	{
		#if UNITY_ANDROID
		if(scaleWidth ==0 && scaleHeight ==0)
		{
			int width = Screen.currentResolution.width;
			int height = Screen.currentResolution.height;
			int designWidth = 720;
			int designHeight = 1280;
			float s1 = (float)designWidth / (float)designHeight;
			float s2 = (float)width / (float)height;
			if(s1 < s2) {
				designWidth = (int)Mathf.FloorToInt(designHeight * s2);
			} else if(s1 > s2) {
				designHeight = (int)Mathf.FloorToInt(designWidth / s2);
			}
			float contentScale = (float)designWidth/(float)width;
			if(contentScale < 1.0f) { 
				scaleWidth = designWidth;
				scaleHeight = designHeight;
			}
		}
		if(scaleWidth >0 && scaleHeight >0)
		{
			if(scaleWidth % 2 == 0) {
				scaleWidth += 1;
			} else {
				scaleWidth -= 1;					
			}
			Screen.SetResolution(scaleWidth,scaleHeight,true);
		}
		#endif
	}



}
