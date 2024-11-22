/*
--------------------------------------------------------------------------------------------------------------------------------------------------
PartyAlly
--------------------------------------------------------------------------------------------------------------------------------------------------

Description : This node is used to control the party sprites that follow the player (as the party leader) in non-combat scenes.
              The AI detects the player location and follows close behind the player. 

Further Development : When proper sprites are made, further development will be required to make the AI's animation frames 
                      match the player's movement.

Current Code Concerns : N/A (As of right now)
*/

using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class PartyAlly : CharacterBody2D
{
	private int speed = 100; // The speed of the Party AI (Should be set to the same value as the Player's speed).
	private Node2D thisPlace; // A Node2D that will be used to refer to this node.
	private int thisIndex; // Party Allies are in the "Party" Group in scenes, this variable is the index of this specific ally in the "Party" array.
	private Vector2 thisPos; // A Vector that will be used to refer to this node's global position.
	private Node2D nextPlace; // A Node2D that will be used to refer to the node in the "Party" array that proceeds this one.
	private int nextIndex; // An integer value that will be set to the index of the node using the "nextPlace" variable.
	private Vector2 nextPos; // A Vector that will be used to refer to the global position of the node using the "nextPlace" variable.
	private Vector2 travelVect; // A Vector that will be used to move the PartyAlly object

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
		/* The next 3 lines get the index of this node in the "Party" group (note that 1 has to be subtracted to account for the fact
		that arrays start with index 0.), sets to the thisPlace node to this node, and gets it's global position. */
		thisIndex = this.GetIndex() - 1;
		thisPlace = (Node2D)GetTree().GetNodesInGroup("Party")[thisIndex];
		thisPos = thisPlace.GlobalPosition;
		/* The next 3 lines get the index of the previous node in the "Party" group), sets to the thisPlace node to that node, and gets 
		it's global position. */
		nextIndex = thisIndex - 1;
		nextPlace = (Node2D)GetTree().GetNodesInGroup("Party")[nextIndex];
		nextPos = nextPlace.GlobalPosition;
		/* This line gets the distance between this node and the previous node and normalzes that distance before setting the travel 
		vector equal to this calculated vector. */
		travelVect = (nextPos - thisPos).Normalized();
		/* This if statement checks if the PartyAlly is a distance of at least 25 from it's target, and if so, it moves to the target
		at the pace of the value specified in the speed variable, while ensuring that the object is facing that target. */
		if (thisPos.DistanceTo(nextPos) > 25)
		{
			travelVect *= speed;
			Velocity = travelVect;
			MoveAndSlide();
			LookAt(travelVect);
		}
    }
	
}
