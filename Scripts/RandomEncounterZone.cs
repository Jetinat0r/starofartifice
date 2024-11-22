/*
--------------------------------------------------------------------------------------------------------------------------------------------------
RandomEncounterZone
--------------------------------------------------------------------------------------------------------------------------------------------------

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
*/

using Godot;
using System;
using System.Timers;

public partial class RandomEncounterZone : Area2D
{
	private string encounter = "res://Scenes/TempEncounter.tscn"; // This is the encounter that will be loaded by the trigger.
	private bool startEncounterRolling = false; // This is used as a sentinel value to determine when to start rolling for random encounter chance.
	private bool startEncounter = false; // This is used as a sentinel value to determine whether or not the scene will be loaded in this moment.
	private bool stopRolling = false; // This is used as a sentinel value to determine when to stop rolling for random encounter chance.
	private Random rnd = new Random(); // This is the Random object that will be used to generate a random integer for the encounter rolls.

	public override void _Process(double delta) // This is the main function
    {
        base._Process(delta);
		/* The next two lines start the random encounter rolling when the player moves into the area and rolls until the generator returns a 5, 
		at which point it sets startEncounter to true and switches to the combat encounter.*/
		encounterRolling();
		if (startEncounter == true)
		{
			enterCombat();
		}
    }

	/*
	Function : onBodyEntered
	Parameters : a Node2D "body"

	Description : This is a signal implementation, it detects if a physics body has entered the collision area of the trigger. When it
	              does, the function checks if the entering body is a player, and if it is, it sets the startEncounterRolling variable to true
				  to start the process of encounter rolling.
	*/
	public void onBodyEntered (Node2D body)
	{
		// Casts the parameter "body" to the class player
		Player player = body as Player;

		/* Checks if the body entering is a valid node of the player type. If its null, then its not a player type node. If it is a
	    player, then it sets the sentinel value to start encounter rolling. */
		if (player is not null) 
		{
			startEncounterRolling = true;
		}
	}
	
	/*
	Function : randomStart
	Parameters : any type of object as a source and an object of type ElapsedEventsArgs refered to as a.

	Description : This function checks if the chance of a random encounter is supposed to be rolling. If it is not, it returns and
	              does nothing. If it is, then it defines and int named randNum and rolls an integer between 1 and 10. If it rolls
				  a 5, then it sets the sentinel value stopRolling to true.
	*/
	public void randomStart (object source, ElapsedEventArgs a) 
	{
		// This checks if the generator has already given a 5, if it has, then it returns with no output.
		if (stopRolling)
		{
			return;
		}
		int randNum; // an integer value that will be set to a random number between 1 and 10.
		/* The next few lines set the randNum value to a number between 1 and 10 (the 11 is not inclusive), and if it is a 5, it sets
		the sentinel value to true. */
		randNum = rnd.Next(1,11);
		if (randNum == 5)
		{
			stopRolling = true;
		}
	}

	/*
	Function : encounterRolling
	Parameters : N/A

	Description : When the sentinel value startEncounterRolling is true, this function will create a timer object, and at every 1000 ticks,
	              it will call the randomStart function to generate a new random number. When the randomStart function sets stopRolling to true
				  and returns with no output, then this function will turn off the clock (Well its supposed to turn it off, it doesn't actually
				  seem to be doing so) and sets the startEncounter sentinel value to true to start a random encounter.
	*/
	public void encounterRolling()
	{
		// This checks if the program is allowed to start rolling for random encounters.
		if (startEncounterRolling == true) 
		{	
			// The next 3 lines create a new timer, sets its event interval to 1000 ticks (1/10,000th of a second), and starts the timer.
			System.Timers.Timer clock = new System.Timers.Timer();
			clock.Interval = 1000;
			clock.Enabled = true;
			if (clock.Enabled) {
				/* When the timer is on, each interval will call the randomStart function to get a random number until it gets a 5,
				at which point stopRolling will be set to true and this function will stop the timer and set the startEncounter
				sentinel value to true to start the random enounter. */
				clock.Elapsed += new ElapsedEventHandler(randomStart);
				if (stopRolling == true)
				{
					clock.Enabled = false;
					startEncounter = true;
				}
			}
		}
	}

	/* 
	Function : enterCombat
	Parameters : N/A
	
	Description : This function performs the switch to the encounter. it gets the scene tree and sets the scene to be loaded to the scene specified
	              in the encounter variable above. 
	*/
	public void enterCombat()
	{
		GetTree().ChangeSceneToFile(encounter);
	}
}
