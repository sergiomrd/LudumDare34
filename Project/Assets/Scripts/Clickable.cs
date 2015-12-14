using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Clickable : MonoBehaviour {

	public enum type_dialog { character, furniture};
	private float timePassed, timeEnd;
	public type_dialog type;
	public int value;
	public GameObject toInstantiate;

	void Awake()
	{
		timePassed = 0f;
		timeEnd = 0.5f;
	}

	void OnMouseDown()
	{
		if (Time.time > timePassed + timeEnd) 
		{
			GameManager.Instance.GetComponent<DialogManager> ().ShowDialogs (type, value, toInstantiate);
			StartCoroutine (GameManager.Instance.GetComponent<DialogManager> ().CountDown ());
			timePassed = Time.time;
		}

	}
}
