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

	void Start()
	{
		anim = GetComponent<Animator> ();


		//sets switch to off sprite
		//gameObject.GetComponent<SpriteRenderer> ().sprite = SwitchOff.GetComponent<SpriteRenderer > ().sprite;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//set the switch to on sprite
		//gameObject.GetComponent<SpriteRenderer> ().sprite = switchOn.GetComponent<SpriteRenderer> ().sprite;

		anim.SetTrigger ("burst");

		isOn = true;
	}
	
}
