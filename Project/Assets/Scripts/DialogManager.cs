using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogManager : MonoBehaviour {

	public Text dialog;
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
		if (timeOut) {
			timeOut = false;
			ShowDialogs ();
			StartCoroutine (CountDown ());
		}
	}
		

	IEnumerator CountDown()
	{
		timeLeft = 4f;

		while (timeLeft > 0) 
		{
			timeLeft--;
			if (timeLeft == 1)
				CloseDialogs ();
			yield return new WaitForSeconds (1);
		}

		timeOut = true;

	}

	void OnLevelWasLoaded()
	{
		dialog = GameObject.Find ("DialogText").GetComponent<Text> ();
		scene = OptionManager.instance.Scene;
		GetDialogs (scene);
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
			for (int i = 3; i < 9; i++) {
				listDialogs.Add (dialogues [i]);
			}
			break;
		
		//Old Gamer
		case 4:
			for (int i = 3; i < 9; i++) {
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
			{16, "Videogames are for loosers"},
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
			{27, "Videogames are my life"}



		};
	}
		
}
