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
	}
}
