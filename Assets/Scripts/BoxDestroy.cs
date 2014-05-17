using UnityEngine;
using System.Collections;

/// <summary>
/// This script destroys boxes if they are of the same type.
/// 
/// Author: Jonathan Elliott 
/// Year:   2014
/// 
/// </summary>

public class BoxDestroy : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {

		// If two boxes collide
		if (collision.gameObject.tag == this.gameObject.tag)
		{
			Destroy (collision.gameObject);
			Destroy (this.gameObject);
		}

		// If box collides with the player
		if (collision.gameObject.tag == "Player")
		{

			// Downwards in the y-axis
			Vector3 Downwards = new Vector3(0, -1, 0);
			RaycastHit hit;
			//Physics.Raycast(this.transform.position, Downwards, out hit);

			Physics.Raycast(this.transform.position, Downwards, out hit);


			hit.point = hit.transform.InverseTransformPoint(hit.point);
			hit.normal = hit.transform.InverseTransformDirection(hit.normal);
			//Debug.Log("Hit position" + hit.point);
			Debug.Log ("Hit vector:" + hit.normal);


			Destroy(this.gameObject);
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
