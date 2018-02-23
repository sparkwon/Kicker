using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour {

	bool inShootMode = false;
	bool isDraggingOnBall = false;

	public float launchForce;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inShootMode) {
			if (Input.GetMouseButtonDown (0)) {
				Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast(mousePos, Camera.main.transform.forward);

				if (hit.collider != null) {
					if (hit.collider.gameObject.tag == "kickable") {
						isDraggingOnBall = true;	
					}
				}
			}

			if (Input.GetMouseButtonUp (0)) {
				isDraggingOnBall = false;

				// code here for launching ball
				Vector2 angle = (Vector2)transform.position - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
				//

				rb.isKinematic = false;
				rb.AddForce (angle * launchForce, ForceMode2D.Impulse);
			}

			if (isDraggingOnBall) {
				// call code for drawing trajectory and your launch angle

			}
		}
	}

	void OnTriggerEnter2D (Collider2D c) {
		if (c.gameObject.tag == "Player") {
			inShootMode = true;
		}
	}

	void OnTriggerExit2D (Collider2D c) {
		if (c.gameObject.tag == "Player") {
			inShootMode = false;
		}
	}
}
