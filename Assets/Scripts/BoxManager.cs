using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This script will randomly generate boxes that fall from the sky.
/// 
/// First attempt will implement a simple random value from 0,1, but should depend
/// on the width of the scene in a perfect case
/// 
/// Author: Jonathan Elliott 
/// Year:   2014
/// 
/// </summary>

public class BoxManager : MonoBehaviour {

	// Variables begin____________________
	public GameObject playerBoxRed;
	public GameObject playerBoxGreen;
	public GameObject playerBoxBlue;
	//private GameObject playerBox;
	private int numberBoxes;
	private Vector3 randomPosition;
	private float nextBoxTime;
	private float nextBoxRate;
	List<GameObject> boxObjectList = new List<GameObject>();
	// Variables end______________________

	void Start ()
	{
		// Default starting positions
		randomPosition.z = 0;
		randomPosition.y = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,0)).y+10;
		nextBoxRate = 2;
		nextBoxTime = 0;

		// Create the list to be used for box selection
		boxObjectList.Add (playerBoxRed);
		boxObjectList.Add (playerBoxGreen);
		boxObjectList.Add (playerBoxBlue);
		numberBoxes = boxObjectList.Count;
	}

	// Update is called once per frame
	void Update () 
	{

		bool makeBox = true;
		if (makeBox && Time.time > nextBoxTime)
		{
			// Ensure we wait until the next box is created
			nextBoxTime = Time.time + nextBoxRate;

			// Generate a number from 0 to numberBoxes to select the box type
			GameObject playerBox = boxObjectList[Random.Range(0, numberBoxes)];

			// Generate a box at a random position
			randomPosition.x = Random.Range(-50,50);
			Instantiate(playerBox, randomPosition, Quaternion.identity);
			Vector3 tempVel = playerBox.rigidbody.velocity;
			tempVel.x = -20;
			playerBox.rigidbody.velocity = tempVel;

		}
	
	}
}
