using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

	private Rigidbody2D myRigidbody;

	private Animator myAnimator;

	[SerializeField]
	private float movementSpeed;

	private bool facingRight;

	[SerializeField] 
	private Transform[] groundPoints;

	[SerializeField] 
	private float groundRadius;

	[SerializeField] 
	private LayerMask whatIsGround;

	private bool isGrounded;

	private bool jump;

	[SerializeField] 
	private float jumpForce;

	void Start()
	{
		facingRight = true;	//starting off facing right
		myRigidbody = GetComponent<Rigidbody2D> (); 
		myAnimator = GetComponent<Animator> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			myAnimator.SetBool ("charge", true);
		}
		if (Input.GetMouseButtonUp (0)) {
			myAnimator.SetBool ("charge", false);
		}
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			jump = true;
		}

	}

	void FixedUpdate()
	{
		float horizontal = Input.GetAxis ("Horizontal");

		isGrounded = IsGrounded ();

		HandleMovement (horizontal);

		ResetValues ();

		Flip (horizontal);


	}

	private void HandleMovement(float horizontal)
	{
		myRigidbody.velocity = new Vector2 (horizontal * movementSpeed, myRigidbody.velocity.y);

		myAnimator.SetFloat ("speed", Mathf.Abs(horizontal));

		if (isGrounded && jump) 
		{
			isGrounded = false;
			myRigidbody.AddForce (new Vector2 (0, jumpForce));
		}
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

	private void ResetValues ()
	{
		jump = false;
	}


	private bool IsGrounded()
	{
		if (myRigidbody.velocity.y <= 0) //checks if player is standing on ground
		{ 
			foreach (Transform point in groundPoints) 
			{
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);

				for (int i = 0; i < colliders.Length; i++) 
				{
					if (colliders [i].gameObject != gameObject) 
					{
						return true;	//return true when feet are colliding on floor
					}
				}
			}
		}
		return false;	//return false if not
	}
}
