using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour {

	public Text dialog, endHistory;
	private List<string> characterDialogs;
	private Dictionary<int,string> dialogues;
	private float timeLeft;
	private bool timeOut;
	private int scene;
	private bool anim = true;


	void Awake()
	{
		dialog = GameObject.Find ("DialogText").GetComponent<Text> ();
		characterDialogs = new List<string>();
		InitDialogues ();
		scene = 0;
		GetDialogs (scene);
	
	}

	void Update()
	{
		/*
		if (SceneManager.GetActiveScene ().name != "Dead") 
		{
			if (timeOut) {
				timeOut = false;
				ShowDialogs ();
				StartCoroutine (CountDown ());
			}
		}
*/
	}
		

	public IEnumerator CountDown()
	{
		timeLeft = 4f;
		while (timeLeft > 0) 
		{
			timeLeft--;
			yield return new WaitForSeconds (1);
		}
		CloseDialogs ();
			

	}

	void OnLevelWasLoaded(int level)
	{
		
		if (level > 0 && level < 4) 
		{
			endHistory = null;
			dialog = GameObject.Find ("DialogText").GetComponent<Text> ();
			scene = OptionManager.Instance.Scene;
			GetDialogs (scene);
		}

		if (level == 4) 
		{
			dialog = null;
			endHistory = GameObject.Find ("Endtext").GetComponent<Text> ();
			scene = OptionManager.Instance.Scene;
			GetDeadHistories (scene);
		}


	}

	/// <summary>
	/// Shows the dialogs.
	/// </summary>
	/// <param name="type">Type dialogs.</param>
	public void ShowDialogs(Clickable.type_dialog type, int value, GameObject toInstantiate)
	{
		StopCoroutine (CountDown());
		StartCoroutine (CountDown ());
		switch (type) 
		{
		case Clickable.type_dialog.character:
			dialog.text = characterDialogs [Random.Range (0, characterDialogs.Count)];
			dialog.gameObject.SetActive (true);
			break;
		
		case Clickable.type_dialog.furniture:

			anim = true;

			switch (scene) 
			{

			//Kid
			case 0:

				switch (value) 
				{
				case 0:
					
					Instantiate (toInstantiate, toInstantiate.gameObject.transform.position, Quaternion.identity);
					anim = false;
					break;
				case 1:
					dialog.text = "A magazine with all bets results between 1950 and 2000? Meh! I don't like sports";
					break;
				case 2:
					dialog.text = "It's midnight and there is a wet hair ball... What happened?";
					break;
				}

				break;

			//fat
			case 1:

				switch (value) 
				{
				case 0:
					dialog.text = "I only have two reasons to love Katarina";
					break;
				case 1:
					dialog.text = "I will be your Big Daddy, Elisabeth";
					break;
				case 2:
					dialog.text = "I only do gameplays of innovative games. Like Call of Duty";
					break;
				case 3:
					
					Instantiate (toInstantiate, toInstantiate.gameObject.transform.position, Quaternion.identity);
					anim = false;
					break;
				}

				break;
			//Old
			case 4:

				switch (value) 
				{
				case 3:
					
					Instantiate (toInstantiate, toInstantiate.gameObject.transform.position, Quaternion.identity);
					anim = false;
					break;
				case 1:
					dialog.text = "I remember when the PC was a master race and not a legend race like now";
					break;
				case 2:
					dialog.text = "What if I could have been a game developer...? Nevermind, let's back to the game";
					break;
				}

				break;
			//Rich
			case 2:

				switch (value) 
				{
				case 0:
					dialog.text = "Eagle Trump is my idol";
					break;
				case 1:
					dialog.text = "I can say I have studied in harvard, but only the girls subject. The academic results were on count of my dad";
					break;
				case 2:
					dialog.text = "I'm the wolf of Wall Street! *Hits his chest* Hmmm...Hmmm...Hmmmm...";
					break;
				}

				break;

			case 3:

				switch (value) 
				{
				case 0:
					
					Instantiate (toInstantiate, toInstantiate.gameObject.transform.position, Quaternion.identity);
					anim = false;
					break;
				case 1:
					dialog.text = "It's the only woman that entertains me. It's a load bearing poster too.";
					break;
				}

				break;

			case 5:

				switch (value) 
				{
				case 0:
					dialog.text = "See that columns, they look a bit pixelated but It cost hundred of billions";
					break;
				case 1:
					dialog.text = "Smile, because yes, you can be as rich as me";
					break;
				case 2:
					dialog.text = "This is my family, but I wouldn't vote for them";
					break;
				}

				break;

			case 6:

				switch (value) 
				{
				case 0:
					dialog.text = "I have lost everything, my purchased harvard diploma, my girlfriend, my popularity...";
					break;
				case 1:
					dialog.text = "This is... ehm... ehm... I'm a rubber, you are glue";
					break;
				}

				break;
			}




			break;
			}

		if (anim) 
		{
			dialog.gameObject.SetActive (true);
			anim = false;
		}

		Debug.Log (anim);
			
	}

	/// <summary>
	/// Closes the dialogs.
	/// </summary>
	private void CloseDialogs()
	{
		dialog.gameObject.SetActive (false);
	}

	private void ClearDialogs()
	{
		characterDialogs.Clear ();
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
			endHistory.text = "He was going to participate in the LD with his awesome iMc, but something went wrong. He died in flames";
			break;
		//Pixel
		case 9:
			endHistory.text = "He was a gamer all his life, he lived a lot of adventures in all kind of virtual worlds, however this time the videogames need him one more time." +
				" He was killed by a giant limo lvl. 5";
			break;
		//Ovni
		case 10:
			endHistory.text = "Do you believe in conspiracies? He did. Was the first human in travel through another galaxy. He died accidentally after falling off the ship " +
				"during an hyper space jump";
			break;
		//Corrupted
		case 11:
			endHistory.text = "You either die a hero, or live long enough to see yourself become the villain. He also died but as a corrupt politician while" +
				" he was getting a fly to Switzerland";
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
		ClearDialogs ();

		switch (scene) 
		{
		//Kid
		case 0:
			for (int i = 0; i < 3; i++) 
			{
				characterDialogs.Add(dialogues[i]);

			}

			break;

		//Fat Gamer
		case 1:
			for (int i = 3; i < 9; i++) {
				characterDialogs.Add (dialogues [i]);
			}
		
			break;

		//Rich Guy
		case 2:
			for (int i = 16; i < 22; i++) {
				characterDialogs.Add (dialogues [i]);
			}
		
			break;

		//Young Developer
		case 3:
			for (int i = 22; i < 28; i++) {
				characterDialogs.Add (dialogues [i]);
			}

			break;
		
		//Old Gamer
		case 4:
			for (int i = 9; i < 16; i++) {
				characterDialogs.Add (dialogues [i]);
			}
	
			break;

		//Familiar
		case 5:
			for (int i = 28; i < 32; i++) {
				characterDialogs.Add (dialogues [i]);
			}
		
			break;

		//Lonely
		case 6:
			for (int i = 32; i < 36; i++) {
				characterDialogs.Add (dialogues [i]);
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
			{2, "Woooahhh what an amazing pixels! This is so realistic"},
			//Fatboy 
			{3, "Hail to the Master Race"},
			{4, "Oh Yeah? Your mom"},
			{5, "I'm running out of supplies. I need more cheetoooos!"},
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
			{25, "As a programmer, I don't know what I'm doing when I'm coding"},
			{26, "I don't know how to draw, better use Pixel Art. Still don't know how to draw"},
			{27, "I'm glad to be an Indie developer"},
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
