using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour {

	public static OptionManager Instance { get; private set; }
	public GameObject character, background;
	public Button option1, option2;
	private int scene = 0;
	public List<GameObject> listCharacters = new List<GameObject> ();
	public List<GameObject> listBackgrounds = new List<GameObject> ();
	public List<GameObject> listFurniture = new List<GameObject> ();
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

		GettingReferences ();
		SettingNewScene(Scene);

	}

	void OnLevelWasLoaded(int level)
	{
		if (level == 1)
		{	
			Scene = 0;
			GettingReferences ();
			SettingNewScene (Scene);
		}


		if (level > 1 && level < 4) 
		{
			GettingReferences ();
			SettingNewScene (Scene);
		}

		if (level == 4)
		{
			SettingDeadScenes (Scene);
		}


	}
		
	private void GettingReferences()
	{
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
			character = Instantiate (listCharacters [0], listCharacters [0].transform.position, Quaternion.identity) as GameObject;
			background = Instantiate (listBackgrounds [2], listBackgrounds [2].transform.position, Quaternion.identity) as GameObject;

			//Colliders
			Instantiate (listFurniture [0], listFurniture [0].transform.position, Quaternion.identity);
			Instantiate (listFurniture [1], listFurniture [1].transform.position, Quaternion.identity);
			Instantiate (listFurniture [2], listFurniture [2].transform.position, Quaternion.identity);


			option1.image.overrideSprite = arrayButtons [8];
			option2.image.overrideSprite = arrayButtons [9];
			ButtonScenes ("Adult", 1, 2);
			break;

		//Fat gamer
		case 1: 
			character = Instantiate(listCharacters[1],listCharacters[1].transform.position,Quaternion.identity) as GameObject;
			background = Instantiate(listBackgrounds[0],listBackgrounds[0].transform.position,Quaternion.identity) as GameObject;

			//Colliders
			Instantiate (listFurniture [3], listFurniture [3].transform.position, Quaternion.identity);
			Instantiate (listFurniture [4], listFurniture [4].transform.position, Quaternion.identity);
			Instantiate (listFurniture [5], listFurniture [5].transform.position, Quaternion.identity);
			Instantiate (listFurniture [6], listFurniture [6].transform.position, Quaternion.identity);

			option1.image.overrideSprite = arrayButtons [6];
			option2.image.overrideSprite = arrayButtons [5];
			ButtonScenes ("Elder", 3, 4);
			break;

		//Rich Guy
		case 2:
			character = Instantiate(listCharacters[4],listCharacters[4].transform.position,Quaternion.identity) as GameObject;
			background = Instantiate(listBackgrounds[4],listBackgrounds[4].transform.position,Quaternion.identity) as GameObject;


			Instantiate (listFurniture [11], listFurniture [11].transform.position, Quaternion.identity);
			Instantiate (listFurniture [12], listFurniture [12].transform.position, Quaternion.identity);
			Instantiate (listFurniture [10], listFurniture [10].transform.position, Quaternion.identity);

			option1.image.overrideSprite = arrayButtons [10];
			option2.image.overrideSprite = arrayButtons [3];
			ButtonScenes ("Elder", 5, 6);
			break;
		
		//Young Developer
		case 3:
			character = Instantiate(listCharacters[2],listCharacters[2].transform.position,Quaternion.identity) as GameObject;
			background = Instantiate(listBackgrounds[1],listBackgrounds[1].transform.position,Quaternion.identity) as GameObject;


			Instantiate (listFurniture [13], listFurniture [13].transform.position, Quaternion.identity);
			Instantiate (listFurniture [14], listFurniture [14].transform.position, Quaternion.identity);

			option1.image.overrideSprite = arrayButtons [12];
			option2.image.overrideSprite = arrayButtons [2];
			ButtonScenes ("Dead", 7, 8);
			break;

		//Old Gamer
		case 4:
			character = Instantiate(listCharacters[5],listCharacters[5].transform.position,Quaternion.identity) as GameObject;
			background = Instantiate(listBackgrounds[5],listBackgrounds[5].transform.position,Quaternion.identity) as GameObject;

			Instantiate (listFurniture [7], listFurniture [7].transform.position, Quaternion.identity);
			Instantiate (listFurniture [8], listFurniture [8].transform.position, Quaternion.identity);
			Instantiate (listFurniture [9], listFurniture [9].transform.position, Quaternion.identity);

			option1.image.overrideSprite = arrayButtons [7];
			option2.image.overrideSprite = arrayButtons [4];
			ButtonScenes ("Dead", 9, 10);
			break;
		//Familiar
		case 5:
			character = Instantiate(listCharacters[3],listCharacters[3].transform.position,Quaternion.identity) as GameObject;
			background = Instantiate(listBackgrounds[3],listBackgrounds[3].transform.position,Quaternion.identity) as GameObject;
			option1.image.overrideSprite = arrayButtons [13];
			option2.image.overrideSprite = arrayButtons [1];
			ButtonScenes ("Dead", 11, 12);
			break;
		//Lonely
		case 6:
			character = Instantiate(listCharacters[6],listCharacters[6].transform.position,Quaternion.identity) as GameObject;
			background = Instantiate(listBackgrounds[6],listBackgrounds[6].transform.position,Quaternion.identity) as GameObject;
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
