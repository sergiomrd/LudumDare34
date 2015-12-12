using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class OptionManager : MonoBehaviour {

	public static OptionManager instance = null;
	public SpriteRenderer character, background;
	public Button option1, option2;

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
	}

	private void GettingReferences()
	{
		character = GameObject.FindGameObjectWithTag ("Character").GetComponent<SpriteRenderer>();
		background = GameObject.FindGameObjectWithTag ("bg").GetComponent<SpriteRenderer>();
		option1 = GameObject.FindGameObjectWithTag ("Option1").GetComponent<Button> ();
		option2 = GameObject.FindGameObjectWithTag ("Option2").GetComponent<Button> ();
	}


}
