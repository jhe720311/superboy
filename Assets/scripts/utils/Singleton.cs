using UnityEngine;
using System.Collections;
namespace framework.Utils{
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour{
		static T _instance;
		public static T Instance()
		{

			//if(_instance == null)
			//{
			//	_instance = GameObject.FindObjectOfType<T> ();
			//}

			return _instance;
		}


		void Awake()
		{
			_instance = this as T;
			onAwake ();
		}
		protected virtual void onAwake()
		{

		}


		protected bool startMark = false;

		public bool IsStart()
		{
			return startMark;

		}
	}
}