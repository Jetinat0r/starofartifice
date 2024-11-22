/*
--------------------------------------------------------------------------------------------------------------------------------------------------
EncounterTrigger
--------------------------------------------------------------------------------------------------------------------------------------------------

Description : This node is used for intentionally placed combat encounters, such as quest battles and bosses. When the player collides
              with the trigger, the user is sent to the combat scene (currently the temporary combat scene). The state of this trigger
			  is saved in the world state; Upon loading the parent scene of the encounter, the program will check the world state
			  file. If it sees that the user has already entered this encounter, then the program will delete the trigger and 
			  free the queue. If the user has not interacted with the trigger yet, then the trigger will appear in the scene, and
			  when the player enters the encounter, the world state will be changed accordingly. 

Further Development : Further development required to account for fleeing combat encounters.

Current Code Concerns : N/A (As of right now)
*/

using Godot;
using Microsoft.VisualBasic.FileIO;
using System;

public partial class EncounterTrigger : Area2D
{
	private string encounter = "res://Scenes/TempEncounter.tscn"; // This is the encounter that will be loaded by the trigger.
	private bool startEncounter = false; // This is used as a sentinel value to determine whether or not the scene will be loaded in this moment.
	public override void _Process(double delta) // This is the main function
    {
		// This loads the game's world state.
		WorldState state = (WorldState)GetNode("/root/WorldState");

		/* Checks whether or not the encounter has already been completed. If it has, then the encounter trigger will be deleted and it's
		memory space freed. */
		if (state.checkTestEncounter())
		{
			this.QueueFree();
		}
        base._Process(delta);
		/* Checks the sentinel value startEncounter. If the program is permitted to switch to the encounter, then the encounter will start.
		It also updates the world state so that the encounter is marked as completed. */
		if (startEncounter == true) 
		{
			performEncounterSwitch();
			state.setTestEncounterToComplete();
		}
    }

	/*
	Function : onBodyEntered
	Parameters : a Node2D "body"

	Description : This is a signal implementation, it detects if a physics body has entered the collision area of the trigger. When it
	              does, the function checks if the entering body is a player, and if it is, it sets the startEncounter variable to true
				  to start the transition to the encounter scene.
	*/
	public void onBodyEntered (Node2D body) 
	{
        // Casts the parameter "body" to the class player
		Player player = body as Player;

		/* Checks if the body entering is a valid node of the player type. If its null, then its not a player type node. If it is a
	    player, then it sets the sentinel value to allow the player to switch scenes. */
		if (player is not null) 
		{
			startEncounter = true;
		}
	}

	/* 
	Function : performEncounterSwitch
	Parameters : N/A
	
	Description : This function performs the switch to the encounter. it gets the scene tree and sets the scene to be loaded to the scene specified
	              in the encounter variable above. 
	*/
	public void performEncounterSwitch()
	{
		GetTree().ChangeSceneToFile(encounter);
	}
}
