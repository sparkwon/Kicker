using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour {

	public GameObject obstacle;
	bool isHit = false;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (isHit) {
			Destroy (obstacle);
		}
	}

	void onTriggerEnter2D (Collider2D c)
	{
		if (c.gameObject.tag == "kickable") {
			isHit = true;
		}
	}
}


