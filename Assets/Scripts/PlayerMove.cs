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
	public Texture RedTexture;
	public Texture BlueTexture;
	public Texture GreenTexture;
	public Texture healthTexture;
	public Texture noHealthTexture;

	// Box variables
	private float boxWidth;
	private float boxHeight;
	private float pixelRatio;
	private int numberOfColours;
	List<GameObject> boxObjectList = new List<GameObject>();
	List<Texture> boxTextureList = new List<Texture>();

	// Player health properties
	private int _playerhealth;
	public int playerHealth 
	{
		get{ return _playerhealth; }
		set{ _playerhealth = value; }
	}

	// Player score properties
	private int _playerscore;
	public int playerScore
	{
		get{ return _playerscore; }
		set{_playerscore = value; }
	}

	// Variables end_____________________

	// Use this for initialization
	void Start () 
	{
		velocityPlayer = .2f;
		forceJumpInt = 7;
		forceJump = 0.00001f * forceJumpInt;
		boxCreateRate = 1;
		jumpRate = 1;
		nextBoxTime = 0;
		nextJumpTime = 0;

		// Get the dimensions of the boxes directly
		pixelRatio = (Camera.main.orthographicSize) / Camera.main.pixelHeight * 2;

		// Create the list to be used for box selection
		boxObjectList.Add (playerBoxRed);
		boxObjectList.Add (playerBoxGreen);
		boxObjectList.Add (playerBoxBlue);

		boxTextureList.Add (RedTexture);
		boxTextureList.Add (GreenTexture);
		boxTextureList.Add (BlueTexture);

		// Default start choice: red box
		numberOfColours = 3;
		playerBoxChoice = Random.Range(0, numberOfColours-1);
		currentTexture = boxTextureList[playerBoxChoice];

		boxWidth = boxObjectList[playerBoxChoice].transform.lossyScale.x / pixelRatio;
		boxHeight = boxObjectList[playerBoxChoice].transform.lossyScale.y / pixelRatio;

		// Default playerHealth properties
		this.playerHealth = 3;
		this.playerScore = 0;
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

			Instantiate(boxObjectList[playerBoxChoice], mouseWorldPosition, Quaternion.identity);
		}

		// User can change the box that they are using
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			playerBoxChoice = 0;
			currentTexture = boxTextureList[playerBoxChoice];
			
			// Get the dimensions of the boxes directly
			boxWidth = boxObjectList[playerBoxChoice].transform.lossyScale.x / pixelRatio;
			boxHeight = boxObjectList[playerBoxChoice].transform.lossyScale.y / pixelRatio;
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			playerBoxChoice = 1;
			currentTexture = boxTextureList[playerBoxChoice];
			
			// Get the dimensions of the boxes directly
			boxWidth = boxObjectList[playerBoxChoice].transform.lossyScale.x / pixelRatio;
			boxHeight = boxObjectList[playerBoxChoice].transform.lossyScale.y / pixelRatio;
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			playerBoxChoice = 2;
			currentTexture = boxTextureList[playerBoxChoice];
			
			// Get the dimensions of the boxes directly
			boxWidth = boxObjectList[playerBoxChoice].transform.lossyScale.x / pixelRatio;
			boxHeight = boxObjectList[playerBoxChoice].transform.lossyScale.y / pixelRatio;
		}
	}

	void OnGUI ()
	{
		// Box outline that follows the mouse
		GUI.Box(new Rect((mouseScreenPosition.x-boxWidth/2.0f),(Screen.height-mouseScreenPosition.y-boxHeight/2.0f),
		                 boxWidth, boxHeight), "");

		// User stats on the boxes
		GUI.Box (new Rect(Screen.width-250, Screen.height-150, 200, 110), "");
		GUI.DrawTexture(new Rect(Screen.width-240, Screen.height-140, boxWidth-4, boxHeight-4), currentTexture);

		// Score
		GUI.Label(new Rect(Screen.width-140, Screen.height-140, 50, 50), "Score");
		GUI.Label(new Rect(Screen.width-140, Screen.height-120, 100, 50), playerScore.ToString());

		// Open portal if score is higher than a given value
		if (playerScore >= 5)
		{
			GUI.Label(new Rect(Screen.width-120, Screen.height-120, 100, 20), "PORTAL");
		}
		
		// Health
		GUI.Label(new Rect(Screen.width-140, Screen.height-100, 50, 50), "HP");
		// Draw a box for every unit of health

		switch (playerHealth)
		{
			case 3:
				GUI.DrawTexture(new Rect(Screen.width-140, Screen.height-80, 20, 20), healthTexture);
				GUI.DrawTexture(new Rect(Screen.width-110, Screen.height-80, 20, 20), healthTexture);
				GUI.DrawTexture(new Rect(Screen.width-80, Screen.height-80, 20, 20), healthTexture);
				break;

			case 2:
				GUI.DrawTexture(new Rect(Screen.width-140, Screen.height-80, 20, 20), healthTexture);
				GUI.DrawTexture(new Rect(Screen.width-110, Screen.height-80, 20, 20), healthTexture);
				GUI.DrawTexture(new Rect(Screen.width-80, Screen.height-80, 20, 20), noHealthTexture);
				break;

			case 1:
				GUI.DrawTexture(new Rect(Screen.width-140, Screen.height-80, 20, 20), healthTexture);
				GUI.DrawTexture(new Rect(Screen.width-110, Screen.height-80, 20, 20), noHealthTexture);
				GUI.DrawTexture(new Rect(Screen.width-80, Screen.height-80, 20, 20), noHealthTexture);
				break;

			default:
				GUI.DrawTexture(new Rect(Screen.width-140, Screen.height-80, 20, 20), noHealthTexture);
				GUI.DrawTexture(new Rect(Screen.width-110, Screen.height-80, 20, 20), noHealthTexture);
				GUI.DrawTexture(new Rect(Screen.width-80, Screen.height-80, 20, 20), noHealthTexture);
				break;
		}
	}
}
