using UnityEngine;
using System.Collections;
using Constants;
using framework.Utils;

public class CheckConnectInternet : Singleton<CheckConnectInternet> {

	const string CHECK_URL = "http://s3-us-west-2.amazonaws.com/adsimagefiles/chess/test.txt";

	bool _isAlreadyCheck = false;
	bool _connectToInternet = false;

	public bool AlreadyCheck{
		get{
			return  _isAlreadyCheck;
		}
		set{
			_isAlreadyCheck = value;
		}
	}


	public bool ConnectToInternet{
		get{
			return _connectToInternet;
		}
		set{
			_connectToInternet = value;
		}
	}

	// Use this for initialization
	void Start () {
	
		StartCoroutine (_loopCheckConnect ());
	}
	

	IEnumerator _loopCheckConnect()
	{
		while(true){
			WWW www = new WWW (CHECK_URL);
			yield return www;	
			if(!_isAlreadyCheck)
			{
				_isAlreadyCheck = true;
				//Application.LoadLevel ("ChessPlay");
			}
			if (string.IsNullOrEmpty(www.error)) {  
				_connectToInternet = true;
				www.Dispose();
				break;
			}else
			{
				//UIChessBoard.Instance().ConnectInternet = false;
				_connectToInternet = false;
			}
			www.Dispose();
			yield return WaitSeconds.wait20s;
		}
	}
}
