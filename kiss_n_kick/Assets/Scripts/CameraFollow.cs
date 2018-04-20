using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	[SerializeField]
	private float xMax; //maximum value of x when going right
	[SerializeField]
	private float yMax;
	[SerializeField]
	private float xMin;
	[SerializeField]
	private float yMin;

	private Transform target;




	// Use this for initialization
	void Start () {
		target = GameObject.Find ("avatar").transform;	//reference for the player's position
	}
	

	void Update()
	{


	}

	// LateUpdate to make sure the player has moved
	void LateUpdate () 
	{
		transform.position = new Vector3 (Mathf.Clamp (target.position.x, xMin, xMax),
			Mathf.Clamp (target.position.y, yMin, yMax), transform.position.z);
	}


}
