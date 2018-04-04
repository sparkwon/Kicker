using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

	private Rigidbody2D myRigidbody;

	private Animator myAnimator;

	[SerializeField]
	private float movementSpeed;

	private bool facingRight;

	void Start()
	{
		facingRight = true;	//starting off facing right
		myRigidbody = GetComponent<Rigidbody2D> (); 
		myAnimator = GetComponent<Animator> ();
	}

	void FixedUpdate()
	{
		float horizontal = Input.GetAxis ("Horizontal");

		HandleMovement (horizontal);

		Flip (horizontal);
	}

	private void HandleMovement(float horizontal)
	{
		myRigidbody.velocity = new Vector2 (horizontal * movementSpeed, myRigidbody.velocity.y);

		myAnimator.SetFloat ("speed", Mathf.Abs(horizontal));
	}

	private void Flip (float horizontal)	//for looking the correct direction while walking
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) 
		{
			facingRight = !facingRight;	

			Vector3 theScale = transform.localScale; //multplying scale with -1 to change direction
			theScale.x *= -1; 
			transform.localScale = theScale;
		}
	}

	void OnTriggerEnter2D (Collider2D c) {
		if (c.gameObject.tag == "kickable") {
			if (Input.GetMouseButtonDown (0)) {
				Debug.Log ("kick ready " + gameObject.name);
				myAnimator.SetBool ("charge", true);
			}
		}
		else if (c.gameObject.tag == "kickable" && Input.GetMouseButtonUp (0)) {
			myAnimator.SetBool("charge", false);
		} 
	}

	void OnTriggerExit2D (Collider2D c) {
		if (c.gameObject.tag == "kickable") {
			myAnimator.SetBool("finishkick", true);
		}	
}
}

