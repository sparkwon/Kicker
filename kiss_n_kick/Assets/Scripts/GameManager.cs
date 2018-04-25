using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	[SerializeField]
	GameObject[] switches;

	[SerializeField]
	GameObject obstacle;

	[SerializeField]
	Text switchCount;

	void Start()
	{

	}
		
	public void GetObstacleState()
	{
		
		if (AllSwitchesOn()) {
			Destroy (obstacle); 
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
		GetObstacleState ();
	}

}
