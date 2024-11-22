/*
--------------------------------------------------------------------------------------------------------------------------------------------------
PartyStats ----> This node is on autoload
--------------------------------------------------------------------------------------------------------------------------------------------------

Scene File : PartyStats.tscn
Script File : PartyStats.cs
Description : This node is not developed yet. It will serve as the framework for implementing the stats of each party member, like
              health, mana, XP, gold, etc.

Further Development : Everything in this class

Current Code Concerns : N/A (As of right now)
*/

using Godot;
using System;

public partial class PartyStats : Node2D
{
	private int Gold = 0; // This represent's the party's current wealth.
	private int XP = 0; // This represents a character's current experience (Will likely be moved to a character class).
	private int XPToNextLevel = 0; //This represents the experience required for a character to level up (Will also likely be moved).
	
}
