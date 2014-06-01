using UnityEngine;
using System.Collections;

/// <summary>
/// This script will handle the scoring and the reloading/exiting of the game when a player is killed
/// or the level is complete.
/// </summary>

public class ScoreManager : MonoBehaviour {

	// Variables start_____________________

	public string userName;
	private int newScore;
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
	
		userName = "MyName";
	}
	
	// Update is called once per frame
	void OnGUI () 
	{
		if (this.endOfGame)
		{
			newScore = (int)Time.time;

			if (PlayerPrefs.HasKey("PlayerName"))
			{
				userName = PlayerPrefs.GetString("PlayerName");
			}

			// Load the GUI menu if the player has died
			GUILayout.Box ("box");

			// If there are old high scores, then we can just add a new one
			if (PlayerPrefs.HasKey("HighScore"))
			{

				// If score is higher than the last saved, add it
				if (PlayerPrefs.GetInt("HighScore") > newScore)
				{
					PlayerPrefs.SetInt("HighScore", newScore);
					PlayerPrefs.SetString("PlayerName", userName);
				}
			}
			else
			{
				GUILayout.Label ("Name");
				userName = GUILayout.TextArea(userName);
				if (GUILayout.Button ("Save"))
				{
					PlayerPrefs.SetString("PlayerName", userName);
					PlayerPrefs.SetInt("HighScore", newScore);
				}
			}

			this.endOfGame = false;
			// Reload level
			Application.LoadLevel(Application.loadedLevel);

		}
	
	}
}
