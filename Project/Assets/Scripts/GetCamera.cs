using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetCamera : MonoBehaviour {

	private Canvas canvas;

	void Awake()
	{

		canvas = gameObject.GetComponent<Canvas> ();

		if (canvas.worldCamera == null)
			canvas.worldCamera = Camera.main;
	}
}
