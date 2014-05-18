using UnityEngine;
using System.Collections;

/// <summary>
/// This script destroys boxes if they are of the same type.
/// 
/// This script reduces the player health if the player is hit from a box above
/// 
/// Author: Jonathan Elliott 
/// Year:   2014
/// 
/// </summary>

public class BoxDestroy : MonoBehaviour {

	void OnCollisionEnter(Collision collision) 
	{

		// If two boxes collide
		if (collision.gameObject.tag == this.gameObject.tag)
		{
			Destroy (collision.gameObject);
			Destroy (this.gameObject);
		}

		// If box collides with the player while the box is moving
		if ( (collision.gameObject.tag == "Player") && (this.gameObject.rigidbody.velocity.magnitude > 0) )
		{

			// Get the collision point and make sure it is coming from an upward direction
			if (collision.contacts[0].normal == Vector3.up)
			{
				//Debug.Log ("contact normal;" + collision.contacts[0].normal);

				// Remove the cube
				Destroy(this.gameObject);

				// Update the player's health
				PlayerMove PScript = collision.gameObject.GetComponent<PlayerMove>();
				if (PScript.playerHealth <= 0)
					{
						Destroy (collision.gameObject);
						// Launch game over
					}
					else
					{
						PScript.playerHealth--;
					}
			}
		}
	}
}
