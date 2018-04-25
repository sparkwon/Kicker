using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit_open : MonoBehaviour {

	[SerializeField]
	GameObject[] switches;

	//[SerializeField]
	//GameObject obstacle;

	[SerializeField]
	Text switchCount;

	Animator anim;

	private BoxCollider2D levelTrigger;

	//public AudioSource openAudio;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		levelTrigger = GetComponent <BoxCollider2D> ();

		levelTrigger.enabled = false;
	}
	
	public void GetExitState()
	{

		if (AllSwitchesOn()) {
			//Destroy (obstacle); 
			anim.SetTrigger ("open");
			//openAudio.Play ();
			levelTrigger.enabled = true;
		}
	}

	bool AllSwitchesOn () {
		for (int i = 0; i < switches.Length; i++) {
			if (!switches [i].GetComponent<Switch> ().isOn) {
				return false;

			}
		}

		return true;

	}

	void Update()
	{
		//switchCount.text = GetNoOfSwitches ().ToString ();
		GetExitState ();
	}

}
