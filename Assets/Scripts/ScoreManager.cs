using UnityEngine;
using System.Collections;

/// <summary>
/// This script will handle the scoring and the reloading/exiting of the game when a player is killed
/// or the level is complete.
/// </summary>

public class ScoreManager : MonoBehaviour {

	// Variables start_____________________

	private bool _endOfGame;
	public bool endOfGame
	{
		get{ return _endOfGame; }
		set { _endOfGame = value; }
	}

	// Variables end_______________________

	// Use this for initialization
	void Start () 
	{
		// Ensure not end of game
		// Testing: set to true
		this.endOfGame = true;
	}
	
	// Update is called once per frame
	void OnGUI () 
	{
		if (this.endOfGame)
		{
			// Load the GUI menu if the player has died
			GUILayout.Box ("box");
		}
	
	}
}
