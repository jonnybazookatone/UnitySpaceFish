using UnityEngine;
using System.Collections;

/// <summary>
/// This script will randomly generate boxes that fall from the sky.
/// 
/// First attempt will implement a simple random value from 0,1, but should depend
/// on the width of the scene in a perfect case
/// 
/// Author: Jonathan Elliott 
/// Year:   2014
/// </summary>

public class BoxManager : MonoBehaviour {

	// Variables begin____________________
	public GameObject playerBox;
	private Vector3 randomPosition;
	private float nextBoxTime;
	private float nextBoxRate;
	// Variables end______________________

	void Start ()
	{
		// Default starting positions
		randomPosition.z = 0;
		randomPosition.y = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,0)).y+10;
		nextBoxRate = 2;
		nextBoxTime = 0;
	}

	// Update is called once per frame
	void Update () 
	{

		bool makeBox = true;
		if (makeBox && Time.time > nextBoxTime)
		{
			// Ensure we wait until the next box is created
			nextBoxTime = Time.time + nextBoxRate;

			// Generate a box at a random position
			randomPosition.x = Random.Range(-50,50);
			Instantiate(playerBox, randomPosition, Quaternion.identity);
			Vector3 tempVel = playerBox.rigidbody.velocity;
			tempVel.x = -20;
			playerBox.rigidbody.velocity = tempVel;
		}
	
	}
}
