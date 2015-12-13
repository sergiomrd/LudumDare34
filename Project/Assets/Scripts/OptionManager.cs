using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour {

	public static OptionManager Instance { get; private set; }
	public SpriteRenderer character, background;
	public Button option1, option2;
	private int scene = 0;
	public List<Sprite> arrayCharacters = new List<Sprite>();
	public List<Sprite> arrayBackgrounds = new List<Sprite> ();
	public List<Sprite> arrayFurniture = new List<Sprite> ();
	public List<Sprite> arrayButtons = new List<Sprite> ();
	public List<GameObject> arrayDeads = new List<GameObject> ();

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
		if (Instance != null && Instance != this) {

			Destroy(gameObject);

		}else 
		{
			Instance = this;


			DontDestroyOnLoad (gameObject);
		}
		

		//scene = 0;
		GettingReferences ();
		SettingNewScene (Scene);

	}

	void OnLevelWasLoaded(int level)
	{
		if (level == 0)
		{	
			Scene = 0;
			GettingReferences ();
			SettingNewScene (Scene);
		}


		if (level > 0 && level < 3) 
		{
			GettingReferences ();
			SettingNewScene (Scene);
		}

		if (level == 3)
		{
			SettingDeadScenes (Scene);
		}


	}
		
	private void GettingReferences()
	{

		character = GameObject.FindGameObjectWithTag ("Character").GetComponent<SpriteRenderer>();
		background = GameObject.FindGameObjectWithTag ("bg").GetComponent<SpriteRenderer>();
		option1 = GameObject.FindGameObjectWithTag ("Option1").GetComponent<Button> ();
		option2 = GameObject.FindGameObjectWithTag ("Option2").GetComponent<Button> ();
	}
		
	#region Dead Scenes
	public void SettingDeadScenes(int scene)
	{


		switch (scene) {

		//Minecraft
		case 7:
			
			Instantiate (arrayDeads [3], arrayDeads [3].transform.position, Quaternion.identity);
			break;
		//LD
		case 8: 
			Instantiate (arrayDeads [5], arrayDeads [5].transform.position, Quaternion.identity);
			break;
		//Pixel
		case 9: 
			Instantiate (arrayDeads [2], arrayDeads [2].transform.position, Quaternion.identity);
			break;
		//Ovni
		case 10: 
			Instantiate (arrayDeads [7], arrayDeads [7].transform.position, Quaternion.identity);
			break;
		//Corrupto
		case 11: 
			Instantiate (arrayDeads [6], arrayDeads [6].transform.position, Quaternion.identity);
			break;
		//Normal
		case 12: 
			Instantiate (arrayDeads [4], arrayDeads [4].transform.position, Quaternion.identity);
			break;
		//Rockero
		case 13: 
			Instantiate (arrayDeads [1], arrayDeads [1].transform.position, Quaternion.identity);
			break;
		//Diogenes
		case 14: 
			Instantiate (arrayDeads [0], arrayDeads [0].transform.position, Quaternion.identity);
			break;
		}
	}
	#endregion
	 
	#region Normal Scenes
	public void SettingNewScene(int Scene)
	{



		switch (scene) {

		//Kid
		case 0:
			character.sprite = arrayCharacters [6];
			option1.image.overrideSprite = arrayButtons [8];
			option2.image.overrideSprite = arrayButtons [9];
			ButtonScenes ("Adult", 1, 2);
			break;

		//Fat gamer
		case 1: 
			character.sprite = arrayCharacters [2];
			option1.image.overrideSprite = arrayButtons [6];
			option2.image.overrideSprite = arrayButtons [5];
			ButtonScenes ("Elder", 3, 4);
			break;

		//Rich Guy
		case 2:
			character.sprite = arrayCharacters [5];
			option1.image.overrideSprite = arrayButtons [10];
			option2.image.overrideSprite = arrayButtons [3];
			ButtonScenes ("Elder", 5, 6);
			break;
		
		//Young Developer
		case 3:
			character.sprite = arrayCharacters [3];
			option1.image.overrideSprite = arrayButtons [12];
			option2.image.overrideSprite = arrayButtons [2];
			ButtonScenes ("Dead", 7, 8);
			break;

		//Old Gamer
		case 4:
			character.sprite = arrayCharacters [4];
			option1.image.overrideSprite = arrayButtons [7];
			option2.image.overrideSprite = arrayButtons [4];
			ButtonScenes ("Dead", 9, 10);
			break;
		//Familiar
		case 5:
			character.sprite = arrayCharacters [0];
			option1.image.overrideSprite = arrayButtons [13];
			option2.image.overrideSprite = arrayButtons [1];
			ButtonScenes ("Dead", 11, 12);
			break;
		//Lonely
		case 6:
			character.sprite = arrayCharacters [1];
			option1.image.overrideSprite = arrayButtons [0];
			option2.image.overrideSprite = arrayButtons [11];
			ButtonScenes ("Dead", 13, 14);
			break;
		}
	}
	#endregion

	private void ButtonScenes(string nextSceneName, int nextScene1, int nextScene2)
	{
		option1.onClick.AddListener(() => {GameManager.Instance.ChangeLevel (nextSceneName, nextScene1); Scene = nextScene1;});
		option2.onClick.AddListener(() => {GameManager.Instance.ChangeLevel (nextSceneName, nextScene2); Scene = nextScene2;});
	}
	
}
