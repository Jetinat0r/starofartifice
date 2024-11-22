/*
--------------------------------------------------------------------------------------------------------------------------------------------------
WorldState ----> This node is on autoload
--------------------------------------------------------------------------------------------------------------------------------------------------

Description : This node holds the state of locations, placed encounters, and triggers in the overworld. This node is currently only
              used to determine if the test encounter trigger should be loaded onto the map or not. This node is highly important for
			  the game's overworld and locations, as it will be constantly referred to make changes to locations, determine the completion
			  of encounters and other general game states.

Further Development : Further development required for further features : 
                      - Ability to change the state of locations (if this is a feature we want to add)
					  - More options for deciding the outcome of encounters (if this is a feature we want to add)
					  - Linking the world state to quest conditions when questing is implemented.
					  - This node's potential uses are open ended depending on how much we want to be able to change world states,
					    any additional uses we want to implemented can be added here.

Current Code Concerns : N/A (As of right now)
*/

using Godot;
using System;

public partial class WorldState : Node2D
{
	private bool testEncounterComplete = false; //boolean value to determine if a combat encounter has been completed or not.

	/*
	Function : setTestEncounterToComplete
	Parameters : N/A

	Description : This is a setter function to make an encounter set to complete. 
	*/
	public void setTestEncounterToComplete()
	{
		testEncounterComplete = true;
	}

	/*
	Function : checkTestEncounter
	Parameters : N/A

	Description : This is a getter function to check the status of an encounter.
	*/
	public bool checkTestEncounter()
	{
		return testEncounterComplete;
	}
}
