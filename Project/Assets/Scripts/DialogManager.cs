using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEditor.SceneManagement;

public class DialogManager : MonoBehaviour {

	public Text dialog, endHistory;
	private List<string> listDialogs;
	private Dictionary<int,string> dialogues;
	private float timeLeft;
	private bool timeOut;
	private int scene;

	void Awake()
	{
		dialog = GameObject.Find ("DialogText").GetComponent<Text> ();
		listDialogs = new List<string>();
		InitDialogues ();
		scene = 0;
		GetDialogs (scene);
		timeOut = false;
		StartCoroutine (CountDown ());
	}

	void Update()
	{
		if (EditorSceneManager.GetActiveScene ().name != "Dead") 
		{
			if (timeOut) {
				timeOut = false;
				ShowDialogs ();
				StartCoroutine (CountDown ());
			}
		}

	}
		

	IEnumerator CountDown()
	{
		timeLeft = 4f;

		while (timeLeft > 0) 
		{
			timeLeft--;
			if (timeLeft == 1 && EditorSceneManager.GetActiveScene ().name != "Dead")
				CloseDialogs ();
			yield return new WaitForSeconds (1);
		}

		timeOut = true;

	}

	void OnLevelWasLoaded(int level)
	{
		
		if (level < 3) 
		{
			dialog = GameObject.Find ("DialogText").GetComponent<Text> ();
			scene = OptionManager.instance.Scene;
			GetDialogs (scene);
		}

		if (level == 3) 
		{
			dialog = null;
			endHistory = GameObject.Find ("Endtext").GetComponent<Text> ();
			scene = OptionManager.instance.Scene;
			Debug.Log (scene);
			GetDeadHistories (scene);
		}


	}

	private void ShowDialogs()
	{
		dialog.text = listDialogs [Random.Range (0, listDialogs.Count)];
		dialog.gameObject.SetActive (true);
	}

	private void CloseDialogs()
	{
		dialog.gameObject.SetActive (false);
	}

	private void GetDeadHistories(int scene)
	{
		switch (scene) 
		{

		//Minecraft
		case 7:
			endHistory.text = "After some years developing games, this guy created a masterpiece that made him rich," +
				" but the money doesn't bring happiness so he was getting sad and sad till he died of depression";
			break;
		//Ludum dare
		case 8:
			endHistory.text = "He was going to participate in the LD with his awesome iMc, but something went wrong. He died in a fire";
			break;
		//Pixel
		case 9:
			endHistory.text = "He was a gamer all his life, he lived a lot of adventures in virtual worlds, however this time the videogames need him one more time." +
				" He was killed by a giant limo lvl. 5";
			break;
		//Ovni
		case 10:
			endHistory.text = "Do you believe in conspiracies? He do. Was the first human in travel through another galaxy. He died accidentally after falling off the ship " +
				"during an hyper space jump";
			break;
		//Corrupted
		case 11:
			endHistory.text = "You either die a hero, or live long enough to see yourself become the villain. He also died but as a corrupt politician while" +
				" he was getting a fly to Sweden";
			break;
		//Normal
		case 12:
			endHistory.text = "You lived a normal life with a normal family in a normal house. He died of boredom";
			break;
		//Rockero
		case 13:
			endHistory.text = "Born to be wild! He said before the spotlight fell in his head";
			break;
		//Diogenes
		case 14:
			endHistory.text = "As a lonely and old man, he was trying to reach something in the top of that heavy boxes. Nobody went to his funeral";
			break;
		}
	}

	private void GetDialogs(int scene)
	{
		listDialogs.Clear ();

		switch (scene) 
		{
		//Kid
		case 0:
			for (int i = 0; i < 3; i++) 
			{
				listDialogs.Add(dialogues[i]);
			}
			break;

		//Fat Gamer
		case 1:
			for (int i = 3; i < 9; i++) {
				listDialogs.Add (dialogues [i]);
			}
			break;

		//Rich Guy
		case 2:
			for (int i = 16; i < 22; i++) {
				listDialogs.Add (dialogues [i]);
			}
			break;

		//Young Developer
		case 3:
			for (int i = 22; i < 28; i++) {
				listDialogs.Add (dialogues [i]);
			}
			break;
		
		//Old Gamer
		case 4:
			for (int i = 9; i < 16; i++) {
				listDialogs.Add (dialogues [i]);
			}
			break;

		//Familiar
		case 5:
			for (int i = 28; i < 32; i++) {
				listDialogs.Add (dialogues [i]);
			}
			break;

		//Lonely
		case 6:
			for (int i = 32; i < 36; i++) {
				listDialogs.Add (dialogues [i]);
			}
			break;
		}



	}

	private void InitDialogues()
	{
		dialogues = new Dictionary<int,string> ()
		{
			//Ratkid
			{0, "Yeah! Take that"},
			{1, "Boom Headshot!"},
			{2, "Woooahhh what an amazing pixels!"},
			//Fatboy 
			{3, "Hail to the Master Race"},
			{4, "Oh Yeah? Your mom"},
			{5, "I need more cheetoooos!"},
			{6, "It's sunny a day, better stay in home"},
			{7, "Only 4k? This graphics sucks!"},
			{8, "I played this game before it was mainstream"},
			//Old Gamer
			{9, "In my time, we played only with a single life"},
			{10, "This virtual reality doesn't feel real"},
			{11, "Are you crying? Go home biatch"},
			{12, "With this VR I have learned to play with only one hand"},
			{13, "This boss is so easy that I will use my Wizard lvl 1"},
			{14, "I'm too old for this shit"},
			{15, "Another DLC? In old days we payed for a complete game"},
			//Rich guy 
			{16, "Videogames are for losers"},
			{17, "The nintendos are the demon"},
			{18, "I'm rich you're poor haha!"},
			{19, "A star has been born"},
			{20, "Don't look at me, you silly bastard"},
			{21, "I will tell my dad"},
			//Young Developer
			{22, "I don't have money to eat, but I have an iMc"},
			{23, "Unity crashed... again"},
			{24, "I'm the CEO-CTO-CIO-CFO-QA of my own studio"},
			{25, "As a programmer, I don't know what I'm doing"},
			{26, "I don't know how to draw, better use Pixel Art. Still don't know how to draw"},
			{27, "Videogames are my life"},
			//Familiar
			{28, "I have raised a multicultural family"},
			{29, "My kids only want me for the money"},
			{30, "I have a dog and a flute as a sons"},
			{31, "Our dog is called PDRSNCHZ"},
			//Lonely grandpa
			{32, "I'm feel so lonely..."},
			{33, "I used to be a motorbiker, but then I took an operation in the knee"},
			{34, "If I had a family that visit me on christmas..."},
			{35, "Where did I leave my teeths"},
			{36, "I have told you that story that... Nevermind"}



		};
	}
		
}
