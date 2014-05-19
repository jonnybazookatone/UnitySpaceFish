using UnityEngine;
using System.Collections;

/// <summary>
/// This script is the outline of the main menu and redirects to the correct scenes
/// 
/// Author: Jonathan Elliott
/// Year:   2014
/// </summary>

public class MainMenu : MonoBehaviour {

	// Variables start_________________
	private float boxWidth;
	private float boxHeight;
	// Variables end___________________

	void Start ()
	{
		boxWidth = Screen.width/2.0f;
		boxHeight = Screen.height/2.0f;
	}

	void OnGUI ()
	{

		GUI.Box(new Rect(Screen.width/4.0f, Screen.height/4.0f, boxWidth, boxHeight), "");
		if(GUI.Button (new Rect(Screen.width/2.0f-50, Screen.height/2.0f-150, 120, 30), "Let's move in!"))
		{
			Debug.Log ("Play game!");
		}
		if(GUI.Button (new Rect(Screen.width/2.0f-50, Screen.height/2.0f-50, 120, 30), "How shit am I?"))
		{
			Debug.Log ("See high score!");
		}
		if(GUI.Button (new Rect(Screen.width/2.0f-50, Screen.height/2.0f+50, 120, 30), "Get me out of here!"))
		{
			Debug.Log ("Quit game!");
		}
	}
}
