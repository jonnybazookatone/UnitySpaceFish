using UnityEngine;
using System.Collections;

/// <summary>
/// This script will control the player's movements.
/// It is probably more efficient to use inbuilt controls, but this is for practise
/// 
/// Author: Jonathan Elliott 
/// Year:   2014
/// </summary>

public class PlayerMove : MonoBehaviour {

	// Variables start___________________
	private float velocityPlayer;
	private float inVelocity;
	private float forceJump;
	private float forceJumpInt;
	// Variables end_____________________

	// Use this for initialization
	void Start () 
	{
		velocityPlayer = .2f;
		forceJumpInt = 4;
		forceJump = 0.00001f * forceJumpInt;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		// Physics should be placed within the FixedUpdate function which is in-sync with
		// that of the physics engine updates. The update function is in-sync with the graphics
		// rendering, and so this can result in strange effects.
		//
		// see; http://answers.unity3d.com/questions/10993/whats-the-difference-between-update-and-fixedupdat.html
		//

		// On left or right button, move left or right
		inVelocity = Input.GetAxis("Horizontal") * velocityPlayer;

		// Transform position is a Vector3. You cannot modify single components in C#
		Vector3 playerPosition = transform.position;
		playerPosition.x += inVelocity;

		// Update the player position
		transform.position = playerPosition;

		// Check if the jump key is pressed. Currently set to space bar.
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
			Rigidbody playerRigidBody = playerObject.GetComponent<Rigidbody>();
			playerRigidBody.AddForce(0, forceJump, 0);
		}
	}
}
