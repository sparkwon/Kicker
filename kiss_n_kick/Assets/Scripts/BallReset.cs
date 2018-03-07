using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour {

	bool touchingTheGround = false;

	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent <Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {
//		if (touchingTheGround) {
//			rb.velocity = Vector3.zero;
//			//rb.angularVelocity = Vector3.zero;
//			rb.isKinematic = true;
//		}

	}

	void onTriggerEnter2D (Collider2D c)
	{
		if (c.gameObject.tag == "ground") {
			touchingTheGround = true;
		}
	}

}