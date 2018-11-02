using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class OutLog : MonoBehaviour
{
	static List<string> mLines = new List<string> ();
	static List<string> mWriteTxt = new List<string> ();
	private string outpath;
	GUIStyle bb;

	const string Str_Clear = "清理";


	static bool _logMark = false;

	void Start ()
	{
		//Application.persistentDataPath Unity中只有这个路径是既可以读也可以写的。
		outpath = Application.persistentDataPath + "/outLog.txt";
		//每次启动客户端删除之前保存的Log
		if (System.IO.File.Exists (outpath)) {
			File.Delete (outpath);
		}
		bb = new GUIStyle ();
		bb.normal.background = null;    //这是设置背景填充的
		bb.normal.textColor = new Color (1, 0, 0);   //设置字体颜色的
		bb.fontSize = 20;       //当然，这是字体颜色


		//一个输出
		//Debug.Log("xuanyusong");
	}


	void OnEnable()
	{
		_logMark = true;
		Application.RegisterLogCallback(HandleLog);
	}

	void OnDisable()
	{
		_logMark = false;
	}
	void Update ()
	{
		//因为写入文件的操作必须在主线程中完成，所以在Update中哦给你写入文件。
		if (mWriteTxt.Count > 0) {
			string[] temp = mWriteTxt.ToArray ();
			int count = temp.Length;
			for (int i = 0; i < count; i++) {
				string t = temp [i];
				using (StreamWriter writer = new StreamWriter(outpath, true, Encoding.UTF8)) {
					writer.WriteLine (t);
				}
				mWriteTxt.Remove (t);
			}
		}
	}
	
	void HandleLog (string logString, string stackTrace, LogType type)
	{

		if (type == LogType.Error || type == LogType.Exception) {
			mWriteTxt.Add (logString);
			Log (logString);
			Log (stackTrace);
		}
	}

	static public void Log (string info)
	{
		if (_logMark) {
			if (Application.isPlaying) {
				if (mLines.Count > 20) {
					mLines.RemoveAt (0);
				}
				mLines.Add (info);

			}
		}
	}

	static public void LogAll (string info)
	{
		if (_logMark) {
			mLines.Clear ();
			if (Application.isPlaying) {

				mLines.Add (info);
			
			}
		}
	}
	
	//这里我把错误的信息保存起来，用来输出在手机屏幕上
	static public void Log (params object[] objs)
	{
		if (_logMark) {
			string text = "";
			for (int i = 0; i < objs.Length; ++i) {
				if (i == 0) {
					text += objs [i].ToString ();
				} else {
					text += ", " + objs [i].ToString ();
				}
			}
			if (Application.isPlaying) {
				if (mLines.Count > 20) {
					mLines.RemoveAt (0);
				}
				mLines.Add (text);
			
			}
		}
	}

	public static void CleanLog ()
	{
		mLines.Clear ();
	}

	private Vector2 ChatScrollPosition = Vector2.zero;

	void OnGUI ()
	{


		GUI.color = Color.red;

		//for (int i = 0, imax = mLines.Count; i < imax; ++i)
		//{
		//    GUILayout.Label(mLines[i], bb);
		//}
		if (mLines.Count > 0) {
			GUILayout.BeginArea (new Rect (0, 30, 100, 20));
		
		
			GUILayout.BeginVertical ();

			if (GUILayout.Button (Str_Clear)) {
				mLines.Clear ();
			}
		
			GUILayout.EndVertical ();
			GUILayout.EndArea ();

			int chat = (int)(Screen.width * 0.75f);
			GUILayout.BeginArea (new Rect (0, 50, chat, Screen.height / 3));
			GUILayout.BeginVertical ();
			ChatScrollPosition = GUILayout.BeginScrollView (ChatScrollPosition);
			//StringBuilder builder = new StringBuilder();
			//for (int i = 0, imax = mLines.Count; i < imax; ++i)
			//{
			//    builder.Append(mLines[i] + "\n");
			//}
			////GUILayout.TextArea("sdfds\ngfdgfdf\nghdkfg\nhjkdfghkjdfhg\nkjdfhgk\nj\nd\nf\ng\nh\nk      \nj\nd   \nf\ng\nh\nk\nd\nf\nj\ng\nh\nd\nkj\nf\ng\nhdfjkghjdkfghfkdjghdfkj", GUILayout.ExpandHeight(true));
			//GUILayout.TextArea(builder.ToString(), GUILayout.ExpandHeight(true));
			for (int i = 0, imax = mLines.Count; i < imax; ++i) {
				GUILayout.Label (mLines [i], bb, GUILayout.ExpandHeight (true));
			}
        
			GUILayout.EndScrollView ();
			GUILayout.EndVertical ();
			GUILayout.EndArea ();
		}
		//print(ChatScrollPosition);

	}


	public void ServiceLog(string msg)
	{
		Log (msg);
	}



}