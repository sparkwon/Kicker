using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class level_control : MonoBehaviour {

	public int index;

	public Image black;
	public Animator anim;


	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			StartCoroutine (Fading ());
		}
	}

	IEnumerator Fading()
	{
		anim.SetBool ("fade", true);
		yield return new WaitUntil (() => black.color.a == 1);
		SceneManager.LoadScene (index); 
	}
}
