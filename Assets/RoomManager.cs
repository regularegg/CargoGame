using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {
	public static RoomBehavior[] rooms;
	void Start () {
		rooms = new RoomBehavior[9];
		for (int i = 0; i < rooms.Length; i++) {
			rooms [i] = new RoomBehavior (i);
		}
	}
	
	void Update () {
		room0 ();
		room1 ();
		room2 ();
		room3 ();
		room4 ();
		room5 ();//airlock
		room6 ();
		room7 ();
		room8 ();
	}
	//Bridge
	void room0(){
		
	}
	//Cargo
	void room1(){

	}
	//Engineering
	void room2(){
		string[] options = new string[]{"Upgrade Engines \n cost: 4 toolboxes", "fix engines \n cost: 1 toolbox"};
	}
	//Hydroponics
	void room3(){
		string[] options = new string[]{"Tend plants \n cost: 1 fertilizer"};
	}
	//Crew Quarters
	void room4(){
		string[] options = new string[]{"Enter cryosleep"};

	}
	//Airlock
	void room5(){
		string[] options = new string[]{"Exit Airlock \n warning: must be docked"};
	

	}
	//upgrade Tool Fabrication
	void room6(){
		string[] options = new string[]{"Make toolboxes", "Make fertilizer", "Make filters"};

	}
	//Tool Storage
	void room7(){
		
	}
	//mine Tool Fab 2
	void room8(){
		string[] options = new string[]{"Make drills", "Make containment units", "Make transporters"};

	}

	void Maintenance(int crewSkill){
		int multiplier = crewSkill / 40;
		if ((Random.Range (0, 100) * multiplier)>70) {
		//	health++;
		}
	}
}
