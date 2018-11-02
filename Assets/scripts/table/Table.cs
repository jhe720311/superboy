using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Table : MonoBehaviour {


	public const string GOLD_KEY = "gold";
	public const string DIAMOND_KEY = "diamond";



	const int SPEED = 1;
	const int TIME_SPEED = 1;
	const int ADD_GOLD_SPEED = 10;
	const int ADD_DIAMOND = 1;


	long recordStartTime = 0;

	float startTime;
	float curTime;

	[SerializeField]
	Image tableIcon;

	[SerializeField]
	Text timeTxt;

	[SerializeField]
	InputField input;

	[SerializeField]
	Button btnStart;

	[SerializeField]
	Button btnStop;

	[SerializeField]
	Button btnPass;

	[SerializeField]
	Button btnReject;

	[SerializeField]
	Button btnPassOver;

	[SerializeField]
	Button btnRejectOver;


	[SerializeField]
	Text goldCount;

	[SerializeField]
	Text diamondCount;

	[SerializeField]
	Animator animator;


	[SerializeField]
	AudioSource _audio;





	bool startMark = false;
	bool stopMark = false;
	bool overMark = false;
	float curProcess = 0;
	bool pmark = true;


//	int addGoldCount = 0;
//	int addDiamond = 0;



//	int curGold =0;
//	int curDiamond = 0;

	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		loadMoneyAndDiamond ();
	}

	void loadMoneyAndDiamond()
	{
		
		//curGold = PlayerPrefs.GetInt (GOLD_KEY,0);
		//curDiamond = PlayerPrefs.GetInt (DIAMOND_KEY, 0);

//		curGold = HomeManager.Instance ().GetGoldCount ();
//		curGold = HomeManager.Instance ().GetDiamondCount ();
	
		refresh ();

	}


	void refresh()
	{
		goldCount.text = "" + HomeManager.Instance ().GetGoldCount();
		diamondCount.text = "" + HomeManager.Instance ().GetDiamondCount ();

	}
		
	// Update is called once per frame
	void Update () {



		if (!startMark) {
			return ;
		}
		if(stopMark)
		{
			return;
		}

		double curRecordTime = ((double)(System.DateTime.Now.Ticks - recordStartTime))*0.0001*0.001;

		curTime = (startTime - (float)curRecordTime);


		if (curTime <= 0) {
			curTime = 0;
			stopMark = true;
			overtime ();

		}

		int sec =(int)(curTime / 60);
		float  seconds =curTime - sec *60;
		curProcess = (60 - seconds);
		if (curProcess > 60) {
			curProcess = 0;
			pmark = !pmark;
		}
		if(pmark)
			tableIcon.fillAmount = curProcess/60f;
		else
			tableIcon.fillAmount =1- curProcess/60f;

	}

	public void passOver()
	{
		animator.SetTrigger ("drop");
		HomeManager.Instance ().AddGold (80);
		HomeManager.Instance ().AddDiamond (1);
		//curGold += 80;
		//curDiamond += 1;
		saveAndReset ();
		_audio.Stop ();
	}

	public void rejectOver()
	{
		saveAndReset ();
		_audio.Stop ();
	}


	void overtime()
	{
		overMark = true;
		btnStop.gameObject.SetActive (false);
		btnPassOver.gameObject.SetActive (true);
		btnRejectOver.gameObject.SetActive (true);
		_audio.Play ();

	}

	void OnGUI(){
		timeTxt.text = getCurTimeStr ();

	}

	void moveToGlod(){

	}

	public void StopCountDown()
	{

		stopMark = true;


		//addGoldCount= 100
		HomeManager.Instance().AddGold(100);
		//curGold += 100;
		refresh ();

		animator.SetTrigger ("drop");
		btnStop.gameObject.SetActive (false);
		btnPass.gameObject.SetActive (true);
		btnReject.gameObject.SetActive (true);
	}


	public void Pass()
	{
		HomeManager.Instance ().AddDiamond (1);
		//curDiamond += 1;

		saveAndReset ();
	

	}

	public void Reject(){
		animator.SetTrigger ("drop");
		HomeManager.Instance ().UseGold (100);
		//curGold -= 100;
		saveAndReset ();
	}



	public void saveAndReset()
	{
		
		//PlayerPrefs.SetInt (GOLD_KEY, curGold);
		//PlayerPrefs.SetInt (DIAMOND_KEY, curDiamond);
		HomeManager.Instance().saveGoldAndDiamond();
		refresh ();
		reset ();

	}




	void reset()
	{
		startMark = false;
		stopMark = false;
		curProcess = 0;
		btnStart.gameObject.SetActive (true);
		btnStop.gameObject.SetActive (false);
		btnPass.gameObject.SetActive (false);
		btnReject.gameObject.SetActive (false);
		btnPassOver.gameObject.SetActive (false);
		btnRejectOver.gameObject.SetActive (false);
		input.gameObject.SetActive (true);
		input.text = "";

	}
	public void startCountDown()
	{

	
		recordStartTime = System.DateTime.Now.Ticks;

		string stime = input.text;
		if (stime == "") {
			return;
		}
		int time = int.Parse (stime);
		if (time < 1) {
			return;

		}



		startTime = time*60;
		curTime = startTime;
		startMark = true;

		input.gameObject.SetActive (false);
		btnStart.gameObject.SetActive (false);
		btnStop.gameObject.SetActive (true);
	

	}


	public void gotoItems()
	{
		empty.loadScene ("items");
	}



	string getCurTimeStr()
	{
		string tstr = "";
		int mintue = (int)(curTime / 60);
		int second = (int)curTime % 60;

		tstr = (mintue < 10 ? ("0" + mintue) : "" + mintue) +" : "+ (second < 10 ? ("0" + second) : "" + second) ;
		return tstr;

	}



	public void goBack()
	{
		empty.loadScene ("main");
	}
}
