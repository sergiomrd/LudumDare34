using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

	public static AudioManager Instance { get; private set; }
	public List<AudioClip> listSongs = new List<AudioClip>();
	private AudioSource audioSource;

	void Awake()
	{
		if (Instance != null && Instance != this) {

			Destroy (gameObject);

		} else 
		{
			Instance = this;


			DontDestroyOnLoad (gameObject);
		}

		audioSource = gameObject.GetComponent<AudioSource> ();
		GetRandomSong ();

	}

	public void GetRandomSong()
	{
		audioSource.clip = listSongs [Random.Range (0, listSongs.Count)];
		audioSource.Play ();
	}
}
