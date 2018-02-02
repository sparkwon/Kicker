using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))] 

public class LaunchArcRenderer : MonoBehaviour {

	LineRenderer lr;

	public float velocity;
	public float angle;
	public int resolution = 10; 	//how many segments arc will have

	float g; //force of gravity on y axis
	float radianAngle;	//angle in radians not degrees for projectile formula



	void Awake()
	{
		lr = GetComponent<LineRenderer> (); 

		g = Mathf.Abs(Physics2D.gravity.y);

	}

	void OnValidate()
	{
		//check that lr is not null and that game is playing
		if (lr != null && Application.isPlaying) {
			RenderArc ();
		}
	}

	// Use this for initialization
	void Start () {
		RenderArc ();

	}

	//populating the LineRender 
	void RenderArc()	//populate parameter with the float for velocity and float for angle etc...
	{
		lr.SetVertexCount (resolution + 1);
		lr.SetPositions (CalculateArcArray ());
	}

	//creates array of Vector 3 positions for arc
	Vector3[] CalculateArcArray ()
	{
		Vector3[] arcArray = new Vector3[resolution + 1];

		radianAngle = Mathf.Deg2Rad * angle;
		float maxDistance = (velocity * velocity * Mathf.Sin (2 * radianAngle)) / g;

		for (int i = 0; i < resolution + 1; i++) //determines how far we are along the arc
		{
			float t = (float)i / (float)resolution;
			arcArray [i] = CalculateArcPoint (t, maxDistance);
		}

		return arcArray;
	}

	//calculate height and distance of each vertex, done through another method that returns a vector3
	//needs two info: progress we're making along array AND maximum distance for horizontal distance along the array
	Vector3 CalculateArcPoint(float t, float maxDistance)
	{
		float x = t * maxDistance;
		float y = x * Mathf.Tan(radianAngle) - ((g*x*x)/(2*velocity*velocity*Mathf.Cos(radianAngle)*Mathf.Cos(radianAngle) ));	//hieght at x formula
		return new Vector3(x,y);
	}

}