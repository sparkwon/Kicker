using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

	public float camSize;
	public float camSizeLimit;
	public float increment;
	public float timeLerp;
	public float timeLerpValue;

	public bool shouldZoomIn = false;
	public bool shouldZoomOut = false;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) 
		{
			anim.SetTrigger ("zoomOut");
			//shouldZoomOut = true;
			//shouldZoomIn = false;
		}
		if (Input.GetMouseButtonUp (0)) 
		{
			anim.SetTrigger ("zoomIn");
			//shouldZoomOut = false;
			//shouldZoomIn = true;
		}

		if (shouldZoomOut) 
		{
			ZoomOut ();
		}

		if (shouldZoomIn) 
		{
			ZoomIn ();
		}

		camSize = GetComponent<Camera> ().orthographicSize; //UnityEngine.Camera.main.orthographicSize;	
		timeLerpValue = timeLerp * Time.deltaTime;

	}

	void ZoomOut()
	{
		if (Camera.main.orthographicSize < camSizeLimit) {	//checks if camera hits zoom out camsize limit so it can stop zooming out
			Mathf.Lerp (Camera.main.orthographicSize, Camera.main.orthographicSize + increment, timeLerp * Time.deltaTime);

		} 
		else if (Camera.main.orthographicSize > camSizeLimit) 
		{
			shouldZoomOut = false;
		}
	}

	void ZoomIn()
	{
		if (Camera.main.orthographicSize > 2f) {	
			Mathf.Lerp (Camera.main.orthographicSize, Camera.main.orthographicSize + -increment, timeLerp * Time.deltaTime);

		} 
		else if (Camera.main.orthographicSize < 2f) 
		{
			shouldZoomIn = false;
		}
	}
}


