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
		room2 (rooms[2].occupied);
		room3 (rooms[3].occupied);
		room4 ();
		room5 ();
		room6 ();
		room7 ();
		room8 ();
	}
	//Bridge
	void room0(){
		
	}
	//Cargo
	void room1(){
		bool Occupied;
		int health = 100;

	}
	//Engineering
	void room2(bool Occupied){
		int health = 100;
		if (!Occupied) {
			if (Random.Range (0, 100) < 5) {
				health--;
			}
		} else {
			if ((Random.Range (0, 100) < 10)&&(health<100)) {
				health++;
			}
		}

		if (health < 50) {

		}

	}
	//Hydroponics
	void room3(bool Occupied){
		int health = 100;
		if (!Occupied) {
			if ((ShipStatKeeper.temperature > 40) ||(ShipStatKeeper.temperature < 10) || (ShipStatKeeper.humidity <10)) {
				health--;
			}
		} else {
			if ((Random.Range (0, 100) < 10)&&(health<100)) {
				health++;
			}
		}
		if (health < 30) {
			ShipStatKeeper.food -= 0.5f;
			ShipStatKeeper.oxygen -= 0.5f;
		} else {
			if (ShipStatKeeper.food < 100) {
				ShipStatKeeper.food++;
			}
			if (ShipStatKeeper.oxygen < 100) {
				ShipStatKeeper.oxygen++;
			}
		}
	}
	//Crew Quarters
	void room4(){
		bool Occupied;
		int health = 100;

	}
	//Airlock
	void room5(){
		bool Occupied;
		int health = 100;

	}
	//Tool Fabrication
	void room6(){
		bool Occupied;
		int health = 100;

	}
	//Tool Storage
	void room7(){
		bool Occupied;
		int health = 100;

	}
	//Tool Fab 2
	void room8(){
		bool Occupied;
		int health = 100;

	}

	void Maintenance(int crewSkill){
		int multiplier = crewSkill / 40;
		if ((Random.Range (0, 100) * multiplier)>70) {
		//	health++;
		}
	}
}
