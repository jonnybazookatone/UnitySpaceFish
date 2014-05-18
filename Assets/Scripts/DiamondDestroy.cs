using UnityEngine;
using System.Collections;

/// <summary>
/// This script destroys the diamonds created if a player collects them.
/// 
/// Incremements the private member of the PlayerMove script to change the score
/// 
/// Author: Jonathan Elliott
/// Year:   2014
/// </summary>

public class DiamondDestroy : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		// Incremement the player score if they touch it
		if (collision.gameObject.tag == "Player")
		{
			PlayerMove PMScript = collision.gameObject.GetComponent<PlayerMove>();
			PMScript.playerScore += 1;

			// Destroy the object
			Destroy (this.gameObject);
		}
	}
}