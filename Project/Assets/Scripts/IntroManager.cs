using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {

	public CanvasGroup generalPanel, textPanel1, textPanel2, textPanel3, textPanel4;
	public Canvas historyCanvas;
	public Text text1, text2;
	private bool endText, endName, click;

	void Awake()
	{
		historyCanvas = GameObject.FindGameObjectWithTag ("HistoryCanvas").GetComponent<Canvas>();
		generalPanel = GameObject.FindGameObjectWithTag ("History").GetComponent<CanvasGroup>();
		textPanel1 = GameObject.FindGameObjectWithTag ("Panel1").GetComponent<CanvasGroup>();
		textPanel2 = GameObject.FindGameObjectWithTag ("Panel2").GetComponent<CanvasGroup>();
		textPanel3 = GameObject.Find ("TextPanel3").GetComponent<CanvasGroup>();
		textPanel4 = GameObject.Find ("TextPanel4").GetComponent<CanvasGroup>();
		text1 = GameObject.FindGameObjectWithTag ("Text1").GetComponent<Text>();
		text2 = GameObject.FindGameObjectWithTag ("Text2").GetComponent<Text>();
		generalPanel.alpha = 1;
		textPanel1.alpha = 0;
		textPanel2.alpha = 0;
		textPanel3.alpha = 0;
		textPanel4.alpha = 0;
		endText = false;
		endName = false;
		click = false;
	}
		
	void Start()
	{
		StartCoroutine (textFadeOut(0.5f,textPanel1));
		StartCoroutine (textFadeOut(0.5f,textPanel2));
	}

	void Update()
	{
		
		if (endText) 
		{
			endText = false;
			StartCoroutine (textFadeOut(0.5f,textPanel3));
		}
		if (endName) 
		{
			endName = false;
			StartCoroutine (textFadeOut(0.5f,textPanel4));
		}
		if (click) 
		{
			if(Input.GetMouseButton(0))
			{
				SceneManager.LoadScene ("Kid");
			}
		}


	}
		
	private IEnumerator generalFadeIn(float speed, CanvasGroup panel)
	{
		while (panel.alpha > 0f) 
		{
			panel.alpha -= speed * Time.deltaTime;
			yield return null;
		}
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

		if(panel.name.Equals("TextPanel4"))
		{
			click = true;
		}
		while (panel.alpha < 1f) 
		{
			panel.alpha += speed * Time.deltaTime;
			yield return null;
		}
		yield return new WaitForSeconds (1);
		switch (panel.name) 
		{
		case "TextPanel1":
			StartCoroutine (textFadeIn(0.5f,textPanel1));
			break;

		case "TextPanel2":
			StartCoroutine (textFadeIn(0.5f,textPanel2));
			break;

		case "TextPanel3":
			StartCoroutine (textFadeIn(0.5f,textPanel3));
			break;

		}



	}

	private IEnumerator textFadeIn(float speed, CanvasGroup panel)
	{
		while (panel.alpha > 0f) 
		{
			panel.alpha -= speed * Time.deltaTime;
			yield return null;
		}
		switch (panel.name) 
		{
		case "TextPanel1":
			endText = true;
			break;

		case "TextPanel2":
			endText = true;
			break;

		case "TextPanel3":
			endName = true;
			break;
		}

	}

}
