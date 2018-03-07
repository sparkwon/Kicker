using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

	private Rigidbody2D myRigidbody;

	private Animator myAnimator;

	[SerializeField]
	private float movementSpeed;

	private bool facingRight;

	public bool nearBall;

	void Start()
	{
		facingRight = true;	//starting off facing right
		nearBall = false;
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

	private void Kick ()
	{
		
	}
}

