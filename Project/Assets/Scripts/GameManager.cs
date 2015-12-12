using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	void Awake()
	{
		if (instance != null) {

			DestroyImmediate (gameObject);

		}

		instance = this;

		DontDestroyOnLoad (gameObject);

	}

	public void ChangeLevel(string level, int scene)
	{
		switch (level) {

		case "Kid":
			OptionManager.instance.Scene = scene;
			EditorSceneManager.LoadScene ("Kid");
			break;

		case "Adult":

			OptionManager.instance.Scene = scene;
			EditorSceneManager.LoadScene ("Adult");
			break;

		case "Elder":
			OptionManager.instance.Scene = scene;
			EditorSceneManager.LoadScene ("Elder");
			break;

		}

	}

}
