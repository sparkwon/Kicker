using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour 
{
	public bool scrolling;
	public bool parallax;

	public float backgroundSize;	//size of background texture
	public float parallaxSpeed;

	private Transform cameraTransform;	//track camera
	private Transform[] layers;	
	private float viewZone = 10;
	private int leftIndex;
	private int rightIndex;
	private float lastCameraX;


	private void Start()
	{
		cameraTransform = Camera.main.transform;	//grab main camera
		lastCameraX = cameraTransform.position.x;
		layers = new Transform[transform.childCount]; //goes through the three background childs in background
		for (int i = 0; i < transform.childCount; i++)
			layers [i] = transform.GetChild (i);

		leftIndex = 0;
		rightIndex = layers.Length - 1;

	}

	private void Update()
	{
		if (parallax) {
			float deltaX = cameraTransform.position.x - lastCameraX;
			transform.position += Vector3.right * (deltaX * parallaxSpeed); 
		}

		lastCameraX = cameraTransform.position.x;

		if (scrolling) {
			if (cameraTransform.position.x < (layers [leftIndex].transform.position.x + viewZone)) {
				ScrollLeft ();
			}

			if (cameraTransform.position.x > (layers [rightIndex].transform.position.x - viewZone)) {
				ScrollRight ();
			}
		}
	}

	private void ScrollLeft()
	{
		int lastRight = rightIndex;	//if we walk to the end of the left side
		layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize); //take very right image and put it on left
		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex <0)
			rightIndex = layers.Length-1;

	}

	private void ScrollRight()
	{
		int lastLeft = leftIndex;	//if we walk to the end of the right side
		layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize); //take very left image and put it on right
		rightIndex = leftIndex;
		leftIndex++;
		if (leftIndex == layers.Length)
			leftIndex = 0;
	}
}
