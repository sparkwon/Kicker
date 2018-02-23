﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour {

	public Rigidbody2D rb;
	public Rigidbody2D hook;

	public float releaseTime=.15f;
	public float maxDragDistance = 2f;

	private bool isPressed = false;

	
	// Update is called once per frame
	void Update () 
	{
		if (isPressed) 
			{
				Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

				if (Vector3.Distance (mousePos, hook.position) > maxDragDistance) {
					rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
				}
				else{
					rb.position = mousePos;	//conver mouse position into world points
				}
			}
		}
	void OnMouseDown ()
	{
		isPressed = true;
		rb.isKinematic = true;
	}

	void OnMouseUp()
	{
		isPressed = false;
		rb.isKinematic = false;

		StartCoroutine (Release ());
	}

	IEnumerator Release ()
	{
		yield return new WaitForSeconds(releaseTime);

		GetComponent<SpringJoint2D> ().enabled = false;

		this.enabled = false;
	}


}

	