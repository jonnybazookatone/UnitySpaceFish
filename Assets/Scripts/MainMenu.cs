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
		boxWidth = Screen.width/5.0f;
		boxHeight = Screen.height/2.0f-50;
	}

	void OnGUI ()
	{

		// Standard play button
		GUI.Box(new Rect(Screen.width/5.0f, Screen.height/4.0f, boxWidth, boxHeight), "");

		if(GUI.Button (new Rect(Screen.width/5.0f+50, Screen.height/2.0f-150, boxWidth-100, 30), "Let's move in!"))
		{
			Debug.Log ("Play game!");
			Application.LoadLevel("Main");
		}

		// Standard quit button
		if(GUI.Button (new Rect(Screen.width/5.0f+50, Screen.height/2.0f+50, boxWidth-100, 30), "Get me out of here!"))
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

		// How to
		GUI.Box(new Rect(Screen.width/5.0f+100+boxWidth, Screen.height/4.0f, boxWidth+110, boxHeight), "");
		GUI.Label(new Rect (Screen.width/5.0f+boxWidth*1.5f, Screen.height/4.0f, 300, 100), "AIM OF THE GAME");

		string text1 = "1.  COLLECT FALLING FISH/DIAMONDS TO GAIN PORTAL POINTS" + System.Environment.NewLine + System.Environment.NewLine +
					   "2.  WHEN THE PORTAL OPENS YOU HAVE TO ENTER THE PORTAL BY UTILISING BLOCKS";

		string text2 = "KEY 1:    CHANGE TO BLOCK COLOUR 1 (BLUE)" + System.Environment.NewLine +
			           "KEY 2:    CHANGE TO BLOCK COLOUR 2 (RED)" + System.Environment.NewLine +
				       "KEY 3:    CHANGE TO BLOCK COLOUR 3 (GREEN)" + System.Environment.NewLine +
		               "SPACEBAR: JUMP" +System.Environment.NewLine +
				       "MOUSE1:   MAKE BLOCK";

		GUI.Label(new Rect (Screen.width/5.0f+boxWidth*1.5f, Screen.height/4.0f, 300, 100), "AIM OF THE GAME");
		GUI.TextArea(new Rect (Screen.width/5.0f+boxWidth*1.5f, Screen.height/4.0f+30, 250, 100), text1);

	
		GUI.Label(new Rect (Screen.width/5.0f+boxWidth*1.5f, Screen.height/4.0f+135, 300, 100), "CONTROLS");
		GUI.TextArea(new Rect (Screen.width/5.0f+boxWidth*1.5f, Screen.height/4.0f+160, 320, 100), text2);

		GUI.Label(new Rect (Screen.width/5.0f+boxWidth*1.5f, Screen.height/4.0f+270, 300, 100), "WARNINGS");

		//GUI.Box(new Rect(Screen.width/5.0f+boxWidth*1.5f, Screen.height/4.0f+50, 200, 500), "");

		//GUI.Label(new Rect (Screen.width/5.0f+boxWidth*1.5f, Screen.height/4.0f+50, 200, 500), "AIM OF THE GAME:" + System.Environment.NewLine +
		//          "1. COLLECT FALLING FISH/DIAMONDS TO GAIN PORTAL POINTS" + System.Environment.NewLine +
		//          "2. WHEN THE PORTAL OPENS YOU HAVE TO ENTER THE PORTAL BY UTILISING BLOCKS" +System.Environment.NewLine +
		//          "3. KEYS 1, 2, 3 CHANGE THE BLOCKS YOU CAN CREATE WITH MOUSE-1" +System.Environment.NewLine +
		//          "4. SPACEBAR IS JUMP" +System.Environment.NewLine +
		//          "5. BLOCKS CAN KILL YOU IF THEY FALL ON YOUR HEAD" + System.Environment.NewLine);
		
		// Scoreboard
		if(GUI.Button (new Rect(Screen.width/5.0f+50, Screen.height/2.0f-50, boxWidth-100, 30), "How shit am I?"))
		{
			// Load score scene?
			Debug.Log ("See high score!");
		}

	}
}
