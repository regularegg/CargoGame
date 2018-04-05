using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textKeeper : MonoBehaviour {

	public static string[] introduction = new string[]{
		" ",
		"Hello there and welcome to the Space Miners Corp.",
		"My name is Fish Face and I will be your training guide.",
		"Due to the longstanding resource shortages on Earth 2, we have been forced to turn to the stars even the most basic elements.",
		"Your job is to travel to asteroids to mine resources and bring them back to earth.",
		"As the Company Representative Captain, you must keep the ship and its crew at peak productivity.",
		"While intersystem flight is not dangerous, your ship will be under a lot of strain and must be maintained.",
		"You can monitor each system's status on your SHIP STAT PANEL to the far LEFT.",
		"The systems can be adjusted using your control panel.",
		"In the very likely event that a system malfunctions or deteriorates beyond usability, ask a crew member to repair it.",
		"You can do so by clicking on their ID in the communications panel and indicating the desired room and action.",
		"As a class D ship, your crewmembers are human and therefore have varying skill levels.",
		"Be aware that these skills can have a big impact on the quality of their work.",
		"Other onboard factors like having Gravity on, a comfortable temperature, etc. can also effect the speed of their work.",
		"Each member can only perform 1 action at a time and only 1 person can occupy a room at a time.",
		"Many maintenance actions cannot be performed without the required tools.",
		"You can hover over an action to see what it needs and have the tools made in the fabrication rooms.",
		"Tools for ship upkeep can be made in the TOOL FABRICATION room.",
		"There are also tools that can be made in the MINING FABRICATION room for use when mining.",
		"Mining tools can only be used at the asteroid but will determine the speed and amount of resources you can bring back.",
		"Now, enough chit chat. We have just released your ship from near Earth 2 orbit so we suggest you get along now.",
		"Good luck, CR Captain."};
	public static string[] asteroid = new string[]{
		"Good job captain, you've just arrived at the asteroid.",
		"This one looks very promising. I suggest you send some crew to survey the area.",
		"Once your crew is there, they'll take care of the mining business.",
		"Your job is to keep an eye on their progress and return them using the return crew button when they are done.",
		"Be careful, if you press that button too early, they will return to ship and abort their mining mission."
	};
	public static string[] eventAlerts = new string[]{
		"Temperature inhabitable!",
		"Filters getting clogged",
		"Fuel use not sustainable!"
	};
		
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
