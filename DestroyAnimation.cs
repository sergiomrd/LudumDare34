using UnityEngine;
using System.Collections;

public class DestroyAnimation : MonoBehaviour {

	private Animator clip;

	void Awake()
	{
		clip = gameObject.GetComponent<Animator> ();
	}

	void Update () {
	
		if (clip.GetCurrentAnimatorStateInfo (0).normalizedTime > 1 && !clip.IsInTransition(0)) 
		{
			Destroy (gameObject);
		}
			

	}
}
