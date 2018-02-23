using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour {

	bool upInTheAir = false;
	bool touchingTheGround = false;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent <Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {


	}
}
