using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public static AudioManager Instance { get; private set; }

	void Awake()
	{
		if (Instance != null && Instance != this) {

			Destroy (gameObject);

		} else 
		{
			Instance = this;


			DontDestroyOnLoad (gameObject);
		}
	}
}
