/*
--------------------------------------------------------------------------------------------------------------------------------------------------
OverworldExit
--------------------------------------------------------------------------------------------------------------------------------------------------

Description : This node is used to permit the user to exit out of locations to the overworld. If the user goes over the exit
              marker, then they can press "Tab" to exit the location.

Further Development : N/A (As of right now)

Current Code Concerns : N/A (As of right now)
*/

using Godot;
using System;

public partial class OverworldExit : Area2D
{

	private string overworld = "res://Scenes/Overworld.tscn"; // The overworld scene file to be loaded
	private bool exitScene = false; // This is used as a sentinel value to determine whether or not the scene will be exited in this moment. 
	private Label exitText; // This is a label object used later to refer to the "Press 'Tab' to exit" text.

    public override void _Process(double delta) // This is the main function
    {
        base._Process(delta);
		// Checks the sentinel value exitScene. If the program is permitted to exit the scene, it will do so.
		if (exitScene == true) 
		{
			performOverworldSwitch();
		}
    }

	/*
	Function : onBodyEntered
	Parameters : a Node2D "body"

	Description : This is a signal implementation, it detects if a physics body has entered the collision area of the trigger. When it
	              does, the function checks if the entering body is a player, and if it is, it sets the exitScene value to true so that
				  when the user presses 'Tab', they will exit out to the overworld. It also sets the visibility of the exitText to true
				  so the player can see that they can see that they can exit here.
	*/
	public void onBodyEntered (Node2D body)
	{
		// Casts the parameter "body" to the class player and gets the label object in marker's node.
		Player player = body as Player;
		exitText = (Label)GetNode("ExitText");

		/* Checks if the body entering is a valid node of the player type. If its null, then its not a player type node. If it is a
	    player, then it sets the visibility of the exit text to true and the sentinel value to true. */
		if (player is not null) 
		{
			exitText.Visible = true;
			exitScene = true;
			
		}
	}

	/*
	Function : onBodyExited
	Parameters : a Node2D "body"

	Description : This is a signal implementation, it detects if a physics body has exited the collision area of the trigger. When it
	              does, the function checks if the entering body is a player, and if it is, it sets the visiblity of the exit text to 
				  false.
	*/
	public void onBodyExited (Node2D body) 
	{
		// Casts the parameter "body" to the class player
		Player player = body as Player;
		
		/* Checks if the body exiting is a valid node of the player type. If its null, then its not a player type node. If it is a
	    player, then it sets the visibility of the exit text to false. */
		if (player is not null) 
		{
			exitText.Visible = false;
		}
	}

	/* 
	Function : performEncounterSwitch
	Parameters : N/A
	
	Description : This function performs the exit to overworld. it gets the scene tree and sets the scene to be loaded to the 
	              overworld scene. 
	*/
	public void performOverworldSwitch()
	{
		
		if (Input.IsActionPressed("Exit Location")) 
		{
			GetTree().ChangeSceneToFile(overworld);
		}
	}
	
}

