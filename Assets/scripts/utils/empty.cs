using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using framework.Utils;
using UnityEngine.SceneManagement;

public class empty : MonoBehaviour  {

	private static string nextSceneName ;
	public static void  loadScene(string sceneName)
	{
		nextSceneName = sceneName;
		SceneManager.LoadScene("empty");

	}

	void Start()
	{

		SceneManager.LoadSceneAsync (nextSceneName);
	}




}
