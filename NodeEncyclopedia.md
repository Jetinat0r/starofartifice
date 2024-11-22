--------------------------------------------------------------------------------------------------------------------------------------------------
    *    *         *              *          *          *        *  *        *     *        *       *         *      *     *
	*		*		    * *        STARS OF ARTIFACE  *     *        *       *  *        *     *  *      *        *        *     *  *
	  *     *     *     *   *      *   *      *       *        *       *        *       *       *    *    *  *   *   *  *   *
    *     *    *         Node Encyclopedia  *  *  *      *    *     *     *       *      *      *      *      *   *   *  *  *
 *   *  *     *    *    *   *       *   *   *    *    *    *     *         *       *      *    **          *        *       *
--------------------------------------------------------------------------------------------------------------------------------------------------


This is a documentation file to log all of the classes and scenes that are in the project, more specific details in each node's script file.
The information for each node in this file can also be found in the headers of each individual node. This is a general document to see
all of the nodes at one if we need to get a general overview of the project's code.

--------------------------------------------------------------------------------------------------------------------------------------------------
EncounterTrigger
--------------------------------------------------------------------------------------------------------------------------------------------------

Scene File : EncounterTrigger.tscn
Script File : EncounterTrigger.cs
Description : This node is used for intentionally placed combat encounters, such as quest battles and bosses. When the player collides
              with the trigger, the user is sent to the combat scene (currently the temporary combat scene). The state of this trigger
			  is saved in the world state; Upon loading the parent scene of the encounter, the program will check the world state
			  file. If it sees that the user has already entered this encounter, then the program will delete the trigger and 
			  free the queue. If the user has not interacted with the trigger yet, then the trigger will appear in the scene, and
			  when the player enters the encounter, the world state will be changed accordingly. 

Further Development : Further development required to account for fleeing combat encounters.

Current Code Concerns : N/A (As of right now)

--------------------------------------------------------------------------------------------------------------------------------------------------
OverworldExit
--------------------------------------------------------------------------------------------------------------------------------------------------

Scene File : OverworldExit.tscn
Script File : OverworldExit.cs
Description : This node is used to permit the user to exit out of locations to the overworld. If the user goes over the exit
              marker, then they can press "Tab" to exit the location.

Further Development : N/A (As of right now)

Current Code Concerns : N/A (As of right now)

--------------------------------------------------------------------------------------------------------------------------------------------------
OverworldLocation
--------------------------------------------------------------------------------------------------------------------------------------------------

Scene File : OverworldLocation.tscn
Script File : OverworldLocation.cs
Description : This node is used to permit the user to enter scenes from the overworld. If the user goes over the location on the map,
              then they can press "Enter" to enter the location.

Further Development : N/A (As of right now)

Current Code Concerns : N/A (As of right now)

--------------------------------------------------------------------------------------------------------------------------------------------------
PartyAlly
--------------------------------------------------------------------------------------------------------------------------------------------------

Scene File : PartyAlly.tscn
Script File : PartyAlly.cs
Description : This node is used to control the party sprites that follow the player (as the party leader) in non-combat scenes.
              The AI detects the player location and follows close behind the player. 

Further Development : When proper sprites are made, further development will be required to make the AI's animation frames 
                      match the player's movement.

Current Code Concerns : N/A (As of right now)

--------------------------------------------------------------------------------------------------------------------------------------------------
PartyStats ----> This node is on autoload
--------------------------------------------------------------------------------------------------------------------------------------------------

Scene File : PartyStats.tscn
Script File : PartyStats.cs
Description : This node is not developed yet. It will serve as the framework for implementing the stats of each party member, like
              health, mana, XP, gold, etc.

Further Development : Everything in this class

Current Code Concerns : N/A (As of right now)

--------------------------------------------------------------------------------------------------------------------------------------------------
Player
--------------------------------------------------------------------------------------------------------------------------------------------------

Scene File : Player.tscn
Script File : Player.cs
Description : This node is used to implement player movement on the overworld and locations. This currently uses arrow keys for movement.
              
Further Development : Further development will also allow WASD movement. Not sure if any other functions are needed here - will be added as
			          needed.

Current Code Concerns : N/A (As of right now)

--------------------------------------------------------------------------------------------------------------------------------------------------
RandomEncounterZone
--------------------------------------------------------------------------------------------------------------------------------------------------

Scene File : RandomEncounterZone.tscn
Script File : RandomEncounterZone.cs
Description : This node is used to implement random enemy encounters if the player enters an area on the map (a la. Pokemon or something like that)
              If the user enters an area on the map, this node will set a timer to generate a random number between 1 - 10. If the number equals 5,
			  then the player will be loaded into a combat encounter (Currently the same encounter as the encounter trigger). 

Further Development : Further development required to implement the following features : 
                      - Leading to a new scene with random enemies.
					  - Lowering encounter frequency if preferable.
					  - Perhaps linking encounter chance with the "guidance" skill?

Current Code Concerns : I couldn't get the timer linked to the area to actually turn off, so I implemented a control structure to stop
                        executing the rng function if the user is in the area. I'm not sure how to check this in Godot, but I suspect
						that the timer may still be ticking in the background. If this is the case, then this needs to be fixed to 
						prevent excessive RAM usage or memory leaks.

--------------------------------------------------------------------------------------------------------------------------------------------------
TempEncounter
--------------------------------------------------------------------------------------------------------------------------------------------------

Scene File : TempEncounter.tscn
Script File : TempEncounter.cs

Description : This node is a placeholder for the combat encounters until the combat system is ready to be added here. Right now you can
              just press "Tab" to exit out of this scene.

Further Development : Implementation of combat system required.

Current Code Concerns : N/A, to be seen after combat system is implemented.

--------------------------------------------------------------------------------------------------------------------------------------------------
WorldState ----> This node is on autoload
--------------------------------------------------------------------------------------------------------------------------------------------------

Scene File : WorldState.tscn
Script File : WorldState.cs

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
