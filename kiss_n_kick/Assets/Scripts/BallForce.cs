using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour {

	bool inShootMode = false;
	bool isDraggingOnBall = false;
	bool ballMoving = false;

	float launchForce = 5;

	public float trajectoryPathCompensation;
	//public float maxDragDistance = 2f;


	//public GameObject obstacle;

	//public Rigidbody2D kickPoint;
	Rigidbody2D rb;

	//Variables for arc renderer
	public LineRenderer sightLine;
	public int segmentCount = 55;
	public float segmentScale = 0.25f;

	private Collider _hitObject;
	public Collider hitObject {get {return _hitObject;}}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		//sightLine.startWidth (.1f);
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

				// code here for launching ball. Middle of circle - mouse pos
				float maxMagnitude = 1.2f;
				Vector2 angle = (Vector2)transform.position - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);	//the direction of ball
				if (angle.magnitude > maxMagnitude) {
					angle = angle.normalized * maxMagnitude;
				}
					

				//Debug.Log ("shooting? magnitude: " + (angle * launchForce).magnitude);
				rb.AddForce (angle * launchForce, ForceMode2D.Impulse);
			}
				

			if (isDraggingOnBall) {
				// call code for drawing trajectory and your launch angle
				sightLine.enabled = true;
				simulatePath ();
			} else {
				sightLine.enabled = false;
			}
		}

		if (ballMoving) {
			
			Debug.Log("hit ground: " + gameObject.name);
			rb.velocity = Vector3.zero;
			rb.angularVelocity = 0f;
			transform.eulerAngles = Vector3.zero;
			ballMoving = false;

		}
	}

	void OnTriggerEnter2D (Collider2D c) {
		if (c.gameObject.tag == "Player") {
			inShootMode = true;
		}
		else if (c.gameObject.tag == "ground") {
			ballMoving = true;
		} 
	}

	void OnTriggerExit2D (Collider2D c) {
		if (c.gameObject.tag == "Player") {
			inShootMode = false;
		}

		//else if 
			
	}

	void simulatePath()
	{
		Vector3[] segments = new Vector3[segmentCount];

		Vector2 angle = (Vector2)transform.position - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

		Vector3 segVelocity = angle * launchForce * trajectoryPathCompensation;

		_hitObject = null;

		for (int i = 1; i < segmentCount; i++) 
		{
			float segTime = (segVelocity.sqrMagnitude != 0) ? segmentScale / segVelocity.magnitude : 0;

			segVelocity = segVelocity + Physics.gravity * segTime;

			//check to see if we're hitting a physics object

			RaycastHit hit;
			if (Physics.Raycast (segments [i - 1], segVelocity, out hit, segmentScale)) {
				_hitObject = hit.collider;

				segments [i] = segments [i - 1] + segVelocity.normalized * hit.distance;

				segVelocity = segVelocity - Physics.gravity * (segmentScale - hit.distance) / segVelocity.magnitude;

				segVelocity = Vector3.Reflect (segVelocity, hit.normal);
			} else {
				segments [i] = segments [i - 1] + segVelocity * segTime;
			}
		}

		Color startColor = Color.white;
		Color endColor = Color.black;
		startColor.a = 1;
		endColor.a = 0;
		sightLine.SetColors (startColor, endColor);

		sightLine.SetVertexCount (segmentCount);
		for (int j = 0; j < segmentCount; j++) {
			sightLine.SetPosition (j, segments [j]);

		}

	}
		
}
