using UnityEngine;
using System.Collections;

/// <summary>
/// Destroys the player or other objects when it enters the portal.
/// </summary>

public class PortalEnd : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter (Collider collision)
	{

		Debug.Log("Hit me!");
		if (collision.gameObject.tag == "Player")
		{
			Destroy (collision.gameObject);
		}
	}
}
