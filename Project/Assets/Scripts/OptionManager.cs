using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class OptionManager : MonoBehaviour {

	public static OptionManager instance = null;
	public SpriteRenderer character, background;
	public Button option1, option2;
	private int scene;
	public List<Sprite> arrayCharacters = new List<Sprite>();
	public List<Sprite> arrayBackgrounds = new List<Sprite> ();

	public int Scene {
		get {
			return scene;
		}
		set {
			scene = value;
		}
	}
		
	void Awake()
	{
		if (instance != null) {

			DestroyImmediate (gameObject);

		}

		instance = this;

		DontDestroyOnLoad (gameObject);

		character = GameObject.FindGameObjectWithTag ("Character").GetComponent<SpriteRenderer>();
		background = GameObject.FindGameObjectWithTag ("bg").GetComponent<SpriteRenderer>();
		option1 = GameObject.FindGameObjectWithTag ("Option1").GetComponent<Button> ();
		option2 = GameObject.FindGameObjectWithTag ("Option2").GetComponent<Button> ();

	}

	void OnLevelWasLoaded(int level)
	{
		GettingReferences ();
		SettingNewScene (scene);

	}

	private void GettingReferences()
	{
		character = GameObject.FindGameObjectWithTag ("Character").GetComponent<SpriteRenderer>();
		background = GameObject.FindGameObjectWithTag ("bg").GetComponent<SpriteRenderer>();
		option1 = GameObject.FindGameObjectWithTag ("Option1").GetComponent<Button> ();
		option2 = GameObject.FindGameObjectWithTag ("Option2").GetComponent<Button> ();
	}

	void Start()
	{
		//nexSceneName, Button1NextScene, Button2NextScene, lastScene
		ButtonScenes ("Adult", 1, 2);
	}

	public void SettingNewScene(int scene)
	{

		switch (scene) {
		case 1:
			character.sprite = arrayCharacters [0];
			ButtonScenes ("Elder", 3, 4);
			break;
		case 2:
			ButtonScenes ("Elder", 5, 6);
			break;
		}
	}

	private void ButtonScenes(string nextSceneName, int nextScene1, int nextScene2)
	{
		option1.onClick.AddListener(() => GameManager.instance.ChangeLevel (nextSceneName, nextScene1));
		option2.onClick.AddListener(() => GameManager.instance.ChangeLevel (nextSceneName, nextScene2));
	}
	
}
