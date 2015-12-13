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
	public List<Sprite> arrayFurniture = new List<Sprite> ();
	public List<Sprite> arrayButtons = new List<Sprite> ();

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

		//Fat gamer
		case 1: 
			character.sprite = arrayCharacters [2];
			option1.image.overrideSprite = arrayButtons [2];
			option2.image.overrideSprite = arrayButtons [3];
			ButtonScenes ("Elder", 3, 4);
			break;

		//Rich Guy
		case 2:
			character.sprite = arrayCharacters [5];
			option1.image.overrideSprite = arrayButtons [6];
			option2.image.overrideSprite = arrayButtons [5];
			ButtonScenes ("Elder", 5, 6);
			break;
		
		//Young Developer
		case 3:
			character.sprite = arrayCharacters [3];
			option1.image.overrideSprite = arrayButtons [7];
			option2.image.overrideSprite = arrayButtons [4];
			ButtonScenes ("Elder", 7, 8);
			break;

		//Old Gamer
		case 4:
			character.sprite = arrayCharacters [4];
			option1.image.overrideSprite = arrayButtons [9];
			option2.image.overrideSprite = arrayButtons [8];
			ButtonScenes ("Elder", 8, 9);
			break;
		//Familiar
		case 5:
			character.sprite = arrayCharacters [0];
			option1.image.overrideSprite = arrayButtons [10];
			option2.image.overrideSprite = arrayButtons [12];
			ButtonScenes ("Elder", 9, 10);
			break;
		//Lonely
		case 6:
			character.sprite = arrayCharacters [1];
			option1.image.overrideSprite = arrayButtons [11];
			option2.image.overrideSprite = arrayButtons [13];
			ButtonScenes ("Elder", 10, 11);
			break;
		}
	}

	private void ButtonScenes(string nextSceneName, int nextScene1, int nextScene2)
	{
		option1.onClick.AddListener(() => GameManager.instance.ChangeLevel (nextSceneName, nextScene1));
		option2.onClick.AddListener(() => GameManager.instance.ChangeLevel (nextSceneName, nextScene2));
	}
	
}
