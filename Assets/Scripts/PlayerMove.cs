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
	// Variables end_____________________

	// Use this for initialization
	void Start () 
	{
		velocityPlayer = .5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
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
			playerRigidBody.AddForce(0, 0.1f, 0);
		}



	}
}
