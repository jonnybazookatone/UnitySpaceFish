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
	private string text1;
	private string text2;
	private string text3;
	// Variables end___________________

	void Start ()
	{
		text1 = "1.  COLLECT FALLING FISH/DIAMONDS TO GAIN PORTAL POINTS" + System.Environment.NewLine + System.Environment.NewLine +
			    "2.  WHEN THE PORTAL OPENS YOU HAVE TO ENTER THE PORTAL BY UTILISING BLOCKS";
		
		text2 = "KEY 1: CHANGE TO BLOCK COLOUR 1 (BLUE)" + System.Environment.NewLine +
			    "KEY 2: CHANGE TO BLOCK COLOUR 2 (RED)" + System.Environment.NewLine +
				"KEY 3: CHANGE TO BLOCK COLOUR 3 (GREEN)" + System.Environment.NewLine +
				"SPACEBAR: JUMP" +System.Environment.NewLine +
				"MOUSE1: MAKE BLOCK";
		text3 = "1. BLOCKS CAN KILL YOU IF THEY FALL ON YOUR HEAD" + System.Environment.NewLine +
		     "2. LIKE-COLOURED BOXES DESTROY ONE ANOTHER";
	}

	void OnGUI ()
	{

		GUILayout.BeginHorizontal("label");
		GUILayout.Space(Screen.width/10);
		
		GUILayout.BeginVertical("label");
		// --------------------------------
		GUILayout.Space(Screen.height/10);

		// Play
		if (GUILayout.Button ("Let's move in!"))
		{
			Debug.Log ("Play game!");
			Application.LoadLevel("Main");
		}
		GUILayout.Space(50);

		// Scoreboard
		if (GUILayout.Button ("How shit am I?"))
		{
			// Load score scene?
			Debug.Log ("See high score!");
		}
		GUILayout.Space(50);

		// Quit
		if (GUILayout.Button ("Get me out of here!"))
		{
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#elif UNITY_WEBPLAYER
			Application.OpenURL(webplayerQuitURL);
			#else
			Application.Quit();
			#endif
			Debug.Log ("Quit game!");
		}


		GUILayout.EndVertical();
		// --------------------------------
	
		GUILayout.BeginVertical("label");

		GUILayout.Space (10);
		GUILayout.Label("Blockzoid v1.0");
		GUILayout.Space (-40);
		// --------------------------------
		GUILayout.Space(Screen.height/10);

		GUILayout.Label("AIM OF THE GAME");
		GUILayout.TextArea(text1);
		
		GUILayout.Label("CONTROLS");
		GUILayout.TextArea(text2);

		GUILayout.Label("WARNINGS");
		GUILayout.TextArea(text3);

		GUILayout.EndVertical();
		// --------------------------------

		GUILayout.EndHorizontal();


	}
}
