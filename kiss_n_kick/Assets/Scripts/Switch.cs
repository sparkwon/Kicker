using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour 
{
	//[SerializeField]
	//GameObject switchOn;

	//[SerializeField]
	//GameObject SwitchOff;

	public bool isOn = false;

	Animator anim;

	private CircleCollider2D popTrigger;

	void Start()
	{
		popTrigger = GetComponent <CircleCollider2D> ();

		anim = GetComponent<Animator> ();
		popTrigger.enabled = true;

		//sets switch to off sprite
		//gameObject.GetComponent<SpriteRenderer> ().sprite = SwitchOff.GetComponent<SpriteRenderer > ().sprite;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "kickable") {
			//set the switch to on sprite
			//gameObject.GetComponent<SpriteRenderer> ().sprite = switchOn.GetComponent<SpriteRenderer> ().sprite;
			popTrigger.enabled = false;
			anim.SetTrigger ("burst");
			GetComponent<AudioSource> ().Play ();﻿

			isOn = true;
		}
	}
	
}
