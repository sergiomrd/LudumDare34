using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager Instance { get; private set; }
	public Button restartButton;
	private DialogManager dialog;

	void Awake()
	{
		if (Instance != null && Instance != this) {

			Destroy (gameObject);

		} else 
		{
			Instance = this;


			DontDestroyOnLoad (gameObject);
		}

	}
		

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
			{
			Application.Quit ();
			}
	}

	void OnLevelWasLoaded(int level)
	{
		if (level == 4) 
		{
			restartButton = GameObject.FindGameObjectWithTag ("RestartButton").GetComponent<Button> ();
			restartButton.onClick.AddListener (() => {Restart();});
		}
	}

	public void ChangeLevel(string level, int scene)
	{
		switch (level) {

		case "Kid":

			OptionManager.Instance.Scene = scene;
			SceneManager.LoadScene ("Kid");
			break;

		case "Adult":

			OptionManager.Instance.Scene = scene;
			SceneManager.LoadScene ("Adult");
			break;

		case "Elder":
			OptionManager.Instance.Scene = scene;
			SceneManager.LoadScene ("Elder");
			break;

		case "Dead":
			OptionManager.Instance.Scene = scene;
			SceneManager.LoadScene ("Dead");
			break;

		}
	
	}

	public void Restart()
	{
		ChangeLevel("Kid",0);
		AudioManager.Instance.GetRandomSong ();
	}

}
