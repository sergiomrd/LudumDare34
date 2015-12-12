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

	public void ChangeLevel(string level)
	{
		switch (level) {

		case "Kid":
			EditorSceneManager.LoadScene ("Kid");
			break;

		case "Adult":
			EditorSceneManager.LoadScene ("Adult");
			break;

		case "Elder":
			EditorSceneManager.LoadScene ("Elder");
			break;

		}

	}

}
