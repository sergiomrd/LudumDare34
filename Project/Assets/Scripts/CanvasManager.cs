using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

	public CanvasGroup generalPanel, textPanel1, textPanel2;
	public Canvas historyCanvas;
	public Text text1, text2;
	private int scene;

	void Awake()
	{
		historyCanvas = GameObject.FindGameObjectWithTag ("HistoryCanvas").GetComponent<Canvas>();
		generalPanel = GameObject.FindGameObjectWithTag ("History").GetComponent<CanvasGroup>();
		textPanel1 = GameObject.FindGameObjectWithTag ("Panel1").GetComponent<CanvasGroup>();
		textPanel2 = GameObject.FindGameObjectWithTag ("Panel2").GetComponent<CanvasGroup>();
		text1 = GameObject.FindGameObjectWithTag ("Text1").GetComponent<Text>();
		text2 = GameObject.FindGameObjectWithTag ("Text2").GetComponent<Text>();
		scene = OptionManager.Instance.Scene;
		generalPanel.alpha = 0;
		textPanel1.alpha = 0;
		textPanel2.alpha = 0;
		SetHistoryLines (0);
	}

	void OnLevelWasLoaded(int level)
	{
		if (level < 3) 
		{
			generalPanel = GameObject.FindGameObjectWithTag ("History").GetComponent<CanvasGroup>();
		}
			
	}

	private IEnumerator generalFadeIn(float speed, CanvasGroup panel)
	{
		while (panel.alpha > 0f) 
		{
			panel.alpha -= speed * Time.deltaTime;
			yield return null;
		}
		historyCanvas.sortingOrder = 0;
	}

	private IEnumerator generalFadeOut(float speed, CanvasGroup panel)
	{
		while (panel.alpha < 1f) 
		{
			panel.alpha += speed * Time.deltaTime;
			yield return null;
		}

		StartCoroutine (textFadeOut(1,textPanel1));
		StartCoroutine (textFadeOut(1,textPanel2));
		yield return new WaitForSeconds (5);
		StartCoroutine (generalFadeIn (3, generalPanel));
	}

	private IEnumerator textFadeOut(float speed, CanvasGroup panel)
	{
		while (panel.alpha < 1f) 
		{
			panel.alpha += speed * Time.deltaTime;
			yield return null;
		}

	}

	private void SetHistoryLines(int scene)
	{
		switch (scene) {

		//Kid
		case 0:
			text1.text = "There was a boy...";
			text2.text = "...That dreams with ";
			break;
			//Fat gamer
		case 1: 
			text1.text = "The boy keep playing";
			text2.text = "and grown as a fat gamer";
			break;

			//Rich Guy
		case 2:
			text1.text = "The boy decided to stop playing and go outside";
			text2.text = "to be raised as a snob";
			break;

			//Young Developer
		case 3:
			text1.text = "Stop playing games";
			text2.text = "to start making them";
			break;

			//Old Gamer
		case 4:
			text1.text = "Stop playing games";
			text2.text = "to start making them";
			break;
			//Familiar
		case 5:
			text1.text = "The only thing he wants all his life";
			text2.text = "was to form a family";
			break;
			//Lonely
		case 6:
			text1.text = "The only thing he wants";
			text2.text = "was to form a family and become a great politician";
			break;
		}
	}


	void Update()
	{
		if (Input.GetKeyDown (KeyCode.A)) 
		{
			historyCanvas.sortingOrder = 2;
			StartCoroutine(generalFadeOut (3, generalPanel));
		}
	}
}
