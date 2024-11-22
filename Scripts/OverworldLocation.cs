/*
--------------------------------------------------------------------------------------------------------------------------------------------------
OverworldLocation
--------------------------------------------------------------------------------------------------------------------------------------------------

Description : This node is used to permit the user to enter scenes from the overworld. If the user goes over the location on the map,
              then they can press "Enter" to enter the location.

Further Development : N/A (As of right now)

Current Code Concerns : N/A (As of right now)
*/

using Godot;
using System;

public partial class OverworldLocation : Area2D
{

	private string targetScene = "res://Scenes/TestScene.tscn"; // The target scene file to be loaded
	private bool changeScene = false; // This is used as a sentinel value to determine whether or not the scene will be entered in this moment. 
	private Label enterText; // This is a label object used later to refer to the "Press 'Enter' to enter" text.

    public override void _Process(double delta) // This is the main function
    {
        base._Process(delta);
		// Checks the sentinel value exitScene. If the program is permitted to enter the scene, it will do so.
		if (changeScene == true) 
		{
			performSceneSwitch();
		}
    }

	/*
	Function : onBodyEntered
	Parameters : a Node2D "body"

	Description : This is a signal implementation, it detects if a physics body has entered the collision area of the trigger. When it
	              does, the function checks if the entering body is a player, and if it is, it sets the changeScene value to true so that
				  when the user presses 'Enter', they will enter the scene. It also sets the visibility of the enterText to true
				  so the player can see that they can see that they can enter the scene from here.
	*/
	public void onBodyEntered (Node2D body) 
	{
		// Casts the parameter "body" to the class player and gets the label object in marker's node.
		Player player = body as Player;
		enterText = (Label)GetNode("EnterText");

		/* Checks if the body entering is a valid node of the player type. If its null, then its not a player type node. If it is a
	    player, then it sets the visibility of the enter text to true and the sentinel value to true. */
		if (player is not null) 
		{
			enterText.Visible = true;
			changeScene = true;
		}
	}

	/*
	Function : onBodyExited
	Parameters : a Node2D "body"

	Description : This is a signal implementation, it detects if a physics body has exited the collision area of the trigger. When it
	              does, the function checks if the entering body is a player, and if it is, it sets the visiblity of the enter text to 
				  false.
	*/
	public void onBodyExited (Node2D body) 
	{
		// Casts the parameter "body" to the class player
		Player player = body as Player;
		
		/* Checks if the body exiting is a valid node of the player type. If its null, then its not a player type node. If it is a
	    player, then it sets the visibility of the enter text to false. */
		if (player is not null) 
		{
			enterText.Visible = false;
		}
	}

	/* 
	Function : performEncounterSwitch
	Parameters : N/A
	
	Description : This function performs the switch to the locaton's scene. it gets the scene tree and sets the scene to be loaded to the 
	              target scene. 
	*/
	public void performSceneSwitch()
	{
		if (Input.IsActionPressed("Enter Location")) 
		{
			GetTree().ChangeSceneToFile(targetScene);
		}
	}
}
