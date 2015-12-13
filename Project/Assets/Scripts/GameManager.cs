using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public Button restartButton;

	void Awake()
	{
		if (instance != null) {

			Destroy(gameObject);

		}

		instance = this;


		DontDestroyOnLoad (gameObject);
		



	}

	void Update()
	{
		
	}

	void OnLevelWasLoaded(int level)
	{
		if (level == 3) 
		{
			restartButton = GameObject.FindGameObjectWithTag ("RestartButton").GetComponent<Button> ();
			restartButton.onClick.AddListener (() => {Restart();});
		}
	}

	public void ChangeLevel(string level, int scene)
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

		case "Dead":
			EditorSceneManager.LoadScene ("Dead");
			break;

		}
	
	}

	public void Restart()
	{
		EditorSceneManager.LoadScene ("Kid");
	}

}
