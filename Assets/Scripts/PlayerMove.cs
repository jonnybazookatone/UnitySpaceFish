using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This script will control the player's movements.
/// It is probably more efficient to use inbuilt controls, but this is for practise
/// 
/// Ability to jump on spacebar
/// 
/// Ability to move with arrows or wasd
/// 
/// Ability to create boxes at the screen position when the user clicks mouse 1
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
	private float nextBoxTime;
	private float boxCreateRate;
	private float nextJumpTime;
	private float jumpRate;
	private int playerBoxChoice;
	private Vector3 mouseScreenPosition;
	private Vector3 mouseWorldPosition;
	public GameObject playerBoxRed;
	public GameObject playerBoxBlue;
	public GameObject playerBoxGreen;
	private Texture currentTexture;

	// Box variables
	private float boxWidth;
	private float boxHeight;
	List<GameObject> boxObjectList = new List<GameObject>();


	// Variables end_____________________

	// Use this for initialization
	void Start () 
	{
		velocityPlayer = .2f;
		forceJumpInt = 5;
		forceJump = 0.00001f * forceJumpInt;
		boxCreateRate = 1;
		jumpRate = 1;
		nextBoxTime = 0;
		nextJumpTime = 0;

		// Get the dimensions of the boxes directly
		Mesh playerMesh = playerBoxRed.GetComponent<MeshFilter>().sharedMesh;
		float pixelRatio = (Camera.main.orthographicSize) / Camera.main.pixelHeight;
		//Debug.Log(pixelRatio);
		boxWidth = playerMesh.bounds.size.x / pixelRatio;
		boxHeight = playerMesh.bounds.size.y / pixelRatio;

		// Create the list to be used for box selection
		boxObjectList.Add (playerBoxRed);
		boxObjectList.Add (playerBoxGreen);
		boxObjectList.Add (playerBoxBlue);

		// Default start choice: red box
		playerBoxChoice = 0;
		currentTexture = boxObjectList[playerBoxChoice].renderer.sharedMaterial.mainTexture;
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
		if (Input.GetButton ("Jump") && Time.time > nextJumpTime)
		{
			nextJumpTime = Time.time + jumpRate;

			GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
			Rigidbody playerRigidBody = playerObject.GetComponent<Rigidbody>();
			playerRigidBody.AddForce(0, forceJump, 0);
		}

		// User can change the box that they are using
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			playerBoxChoice = 0;
			currentTexture = boxObjectList[playerBoxChoice].renderer.material.mainTexture;

		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			playerBoxChoice = 1;
			currentTexture = boxObjectList[playerBoxChoice].renderer.material.mainTexture;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			playerBoxChoice = 2;
			currentTexture = boxObjectList[playerBoxChoice].renderer.material.mainTexture;
		}
	}

	void Update ()
	{
		// This is to allow it to follow the mouse on the screen
		mouseScreenPosition = Input.mousePosition;

		// If the mouse button is pressed then act upon box creation
		if (Input.GetButton("Fire1") && Time.time > nextBoxTime)
		{
			nextBoxTime = Time.time + boxCreateRate;

			mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
			mouseWorldPosition.z = 0;
			//Debug.Log(mouseWorldPosition);

			//playerBox = GameObject.FindGameObjectWithTag("FishyBox");
			Instantiate(boxObjectList[playerBoxChoice], mouseWorldPosition, Quaternion.identity);
		}
	}

	void OnGUI ()
	{
		GUI.Box(new Rect((mouseScreenPosition.x-boxWidth/2.0f),(Screen.height-mouseScreenPosition.y-boxHeight/2.0f),
		                 boxHeight, boxWidth), "");

		GUI.Box(new Rect(10, 10, boxHeight*2, boxWidth*2), "Player");

		GUI.DrawTexture(new Rect(10, 10, 10, 10), currentTexture);

	}
}
