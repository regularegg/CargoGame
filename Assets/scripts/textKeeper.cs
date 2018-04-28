using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textKeeper : MonoBehaviour {

	public static string[] introduction = new string[]{
		" ",
		"Hello there and welcome to the Space Miners Corp.",
		"My name is Fish Face and I will be your training guide.",
		"Due to the longstanding resource shortages on Earth 2, we have been forced to turn to the stars for even the most basic elements.",
		"Your job is to travel to asteroids to mine resources and bring them back to earth.",
		"As the Company Representative Captain, you must keep the ship and its crew at peak productivity.",
		"While intersystem flight is not dangerous, your ship will be under a lot of strain and must be maintained.",
		"You can monitor each system's status on your SHIP STAT PANEL to the far LEFT.",
		"In the very likely event that a system malfunctions or deteriorates beyond usability, it is your job to fix it.",
		"First, make sure that you have enough repair kits and assign a crew member through the intercom system to the job.",
		"As a class D ship, your crewmembers are human and therefore have varying skill levels.",
		"Use these icons to call your crewmembers to do the tasks.",
		"Each member can only perform 1 action at a time and only 1 person can occupy a room at a time.",
		"Many maintenance actions cannot be performed without the required tools.",
		"You can hover over an action to see what it needs and have the tools made in the fabrication rooms.",
		"Tools for ship upkeep can be made in the TOOL FABRICATION room.",
		"There are also tools that can be made in the MINING FABRICATION room for use when mining.",
		"Mining tools can only be used at the asteroid but will determine the speed and amount of resources you can bring back.",
		"Now, enough chit chat. Use the throttle to start the ship and get going.",
		"Good luck Captain."};
	public static string[] asteroid = new string[]{
		"Good job captain, you've just arrived at the asteroid.",
		"This one looks very promising. I suggest you send some crew down ASAP",
		"Our fuel is limited and can't stay on this vector of motion for long.",
		"As soon as I'm finished, a crew member will be dispatched to the surface",
		"use the Left and right arrow keys to guide them and use spacebar to launch their super drill"
	};
	public static string[] eventAlerts = new string[]{
		"Temperature inhabitable!",
		"Filters getting clogged",
		"Fuel use not sustainable!"
	};
	public static string[] noDrills = new string[] {
		"uh oh, seems like you forgot to bring a drill to a drilling job!",
		"Unfortunately, there is no more time to make the drills either.",
		"Looks like you've failed"
	};
}
