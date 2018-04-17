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

//	int noOfSwitches = 0;

	[SerializeField]
	Text switchCount;


	void Start()
	{
//		noOfSwitches = switches.Length;
//		GetNoOfSwitches ();
	}

//	public int GetNoOfSwitches()
//	{
//		int x = 0;
//
//		for (int i = 1; i < switches.Length; i++) 
//		{
//			if (switches [i].GetComponent<Switch> ().isOn == false)
//				x++; 
//
//			else if (switches[i].GetComponent<Switch>().isOn == true)
//				noOfSwitches--;
//		}
//
//		noOfSwitches = x;
//
//		return noOfSwitches;
//	}


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
