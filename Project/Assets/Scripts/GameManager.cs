using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance { get; private set; }

	void Awake()
	{
		if (Instance != null && Instance != this) {

			DestroyImmediate (gameObject);

		}

		Instance = this;

		DontDestroyOnLoad (gameObject);

	}

	public void ChangeLevel(string level, int scene)
	{
		switch (level) {

		case "Kid":
			OptionManager.Instance.Scene = scene;
			EditorSceneManager.LoadScene ("Kid");
			break;

		case "Adult":

			OptionManager.Instance.Scene = scene;
			EditorSceneManager.LoadScene ("Adult");
			break;

		case "Elder":
			OptionManager.Instance.Scene = scene;
			EditorSceneManager.LoadScene ("Elder");
			break;

		case "Dead":
			OptionManager.Instance.Scene = scene;
			EditorSceneManager.LoadScene ("Dead");
			break;

		}
	
	}

	public void Restart()
	{
		EditorSceneManager.LoadScene ("Kid");
	}

}
