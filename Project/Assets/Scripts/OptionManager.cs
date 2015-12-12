using UnityEngine;
using System.Collections;

public class OptionManager : MonoBehaviour {

	public static OptionManager instance = null;

	void Awake()
	{
		if (instance != null) {

			DestroyImmediate (gameObject);

		}

		instance = this;

		DontDestroyOnLoad (gameObject);

	}




}
