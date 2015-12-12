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

	void Awake()
	{
		dialog = GameObject.Find ("DialogText").GetComponent<Text> ();
		listDialogs = new List<string>();
		InitDialogues ();
		GetDialogs ();
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

	private void ShowDialogs()
	{
		dialog.text = listDialogs [Random.Range (0, listDialogs.Count)];
		dialog.gameObject.SetActive (true);
	}

	private void CloseDialogs()
	{
		dialog.gameObject.SetActive (false);
	}

	private void GetDialogs()
	{
		listDialogs.Add (dialogues [0]);
		listDialogs.Add (dialogues [1]);

	}

	private void InitDialogues()
	{
		dialogues = new Dictionary<int,string> ()
		{
			{0, "¡Yeah! Take that"},
			{1, "¡Boom Headshot¡"}
		};
	}

	void OnLevelWasLoaded(int level)
	{
		dialog = GameObject.Find ("DialogText").GetComponent<Text> ();
	}

}
