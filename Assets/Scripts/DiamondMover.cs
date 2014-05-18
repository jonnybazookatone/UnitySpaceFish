using UnityEngine;
using System.Collections;

/// <summary>
/// Maintains the movement of the Diamond
/// 
/// In the future, it will most likely include other features
/// 
/// Author: Jonathan Elliott
/// Year:   2014
/// 
/// </summary>

public class DiamondMover : MonoBehaviour {

	private Transform diamondTransform;

	// Update is called once per frame
	void Update () 
	{
		//diamondTransform = transform;
		transform.Rotate(5, 10, 5);
	}
}
