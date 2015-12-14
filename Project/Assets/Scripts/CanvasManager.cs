using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour {

	public CanvasGroup generalPanel, textPanel1, textPanel2;
	public Canvas historyCanvas;
	public Text text1, text2;
	private int scene;
	private bool endText;

	void Awake()
	{
		GetReferences ();
		generalPanel.alpha = 0;
		textPanel1.alpha = 0;
		textPanel2.alpha = 0;
		SetHistoryLines (0);
	}

	void OnLevelWasLoaded(int level)
	{
		if (level < 4) 
		{
			GetReferences ();

			if (level == 1) 
			{
				generalPanel.alpha = 1;
				historyCanvas.sortingOrder = 2;
				StartCoroutine(generalFadeOut(0.5f,generalPanel));
			}

			SetHistoryLines (scene);
			generalPanel.alpha = 1;
			historyCanvas.sortingOrder = 2;
			StartCoroutine(generalFadeOut(0.5f,generalPanel));
		}
			
	}

	private void GetReferences()
	{
		historyCanvas = GameObject.FindGameObjectWithTag ("HistoryCanvas").GetComponent<Canvas>();
		generalPanel = GameObject.FindGameObjectWithTag ("History").GetComponent<CanvasGroup>();
		textPanel1 = GameObject.FindGameObjectWithTag ("Panel1").GetComponent<CanvasGroup>();
		textPanel2 = GameObject.FindGameObjectWithTag ("Panel2").GetComponent<CanvasGroup>();
		text1 = GameObject.FindGameObjectWithTag ("Text1").GetComponent<Text>();
		text2 = GameObject.FindGameObjectWithTag ("Text2").GetComponent<Text>();
		scene = OptionManager.Instance.Scene;
		historyCanvas.sortingOrder = 0;
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

		StartCoroutine (textFadeOut(0.5f,textPanel1));
		StartCoroutine (textFadeOut(0.5f,textPanel2));
		yield return new WaitForSeconds (5);
		StartCoroutine (generalFadeIn (5, generalPanel));
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
			text1.text = "There was a time";
			text2.text = "when a boy was only a dreamer";
			break;
			//Fat gamer
		case 1: 
			text1.text = "The boy continued playing";
			text2.text = "and was grown as a Fat Gamer";
			break;

			//Rich Guy
		case 2:
			text1.text = "The boy decided to stop playing and go outside";
			text2.text = "to be raised as a Snob";
			break;

			//Young Developer
		case 3:
			text1.text = "The Fat Gamer stops playing games";
			text2.text = "and starts making his own";
			break;

			//Old Gamer
		case 4:
			text1.text = "The Fat Gamer keeps playing and eating doritos";
			text2.text = "for the rest of his life";
			break;
			//Familiar
		case 5:
			text1.text = "The only thing he dreams all his life";
			text2.text = "was to form a family.";
			break;
			//Lonely
		case 6:
			text1.text = "He decides to not form a family.";
			text2.text = "He was the only thing he have in his life";
			break;
		}
	}


	void Update()
	{
		if (Input.GetMouseButtonDown (0) && SceneManager.GetActiveScene().name != "Dead") 
		{
			
			StopAllCoroutines ();
			historyCanvas.sortingOrder = 0;
			generalPanel.alpha = 0;
		}
	}
}
