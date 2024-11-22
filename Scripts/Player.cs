/*
--------------------------------------------------------------------------------------------------------------------------------------------------
Player
--------------------------------------------------------------------------------------------------------------------------------------------------

Description : This node is used to implement player movement on the overworld and locations. This currently uses arrow keys for movement.
              
Further Development : Further development will also allow WASD movement. Not sure if any other functions are needed here - will be added as
			          needed.

Current Code Concerns : N/A (As of right now)
*/

using Godot;
using System;

// Code based on "TOP DOWN MOVEMENT" from Maker Tech on youtube.

public partial class Player : CharacterBody2D
{
	private int speed = 100; // Speed variable to set character speed on overworld and area maps.
	private Vector2 currVelocity; // Vector to be used in the move and slide function.

	public override void _PhysicsProcess(double delta) // This is the main function
	{
		base._PhysicsProcess(delta);
		movementInput();
		Velocity = currVelocity;
		MoveAndSlide();
	}

	/*
	Function : movementInput
	Parameters : N/A

	Description : This function takes user input to move the player, right now it uses the arrow keys. The player moves at the
	              pace of the value specified in the speed variable.
	*/
	public void movementInput() 
	{
		currVelocity = Input.GetVector("ui_left","ui_right","ui_up","ui_down");
		currVelocity *= speed;
	}

}
