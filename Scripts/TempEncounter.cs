/*
--------------------------------------------------------------------------------------------------------------------------------------------------
TempEncounter
--------------------------------------------------------------------------------------------------------------------------------------------------

Description : This node is a placeholder for the combat encounters until the combat system is ready to be added here. Right now you can
              just press "Tab" to exit out of this scene.

Further Development : Implementation of combat system required.

Current Code Concerns : N/A, to be seen after combat system is implemented.

*/
using Godot;
using System;

public partial class TempEncounter : Node2D
{
	private string overworld = "res://Scenes/Overworld.tscn"; // The overworld scene file to be loaded
	public override void _Process(double delta) // This is the main function
	{
		// Right now this scene is just to get the transistion working; There is no content here, so you can just press tab to back out.
		if (Input.IsActionPressed("Exit Location")) 
		{
			GetTree().ChangeSceneToFile(overworld);
		}
	}
}
