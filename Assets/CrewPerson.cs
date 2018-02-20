﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewPerson {
	public float health, happiness, engineerSkill, plantSkill, mineSkill, cost, age;
	public string name;
	public bool awake, alive;
	public int index, currRoom;

	public int currentActivity;

	public CrewPerson(string id, float currAge, float engSkill, float plSkill, float mSkill, int nindex){
		health = 100;
		happiness = 80;
		currRoom = 0;
		awake = true;
		alive = true;
		currentActivity = 0;


		engineerSkill = engSkill;
		plantSkill = plSkill;
		mineSkill = mSkill;
		name = id;
		age = currAge;
		index = nindex;
		cost = (engineerSkill + plantSkill + mineSkill) / 10;
	}

	void Start () {
		
	}
	
	void Update () {
		if (health == 0) {
			alive = false;
		}
	}

	void needsDecay(){
		if (ShipStatKeeper.food < ShipStatKeeper.crewAwake * 10) 
			health -= 0.05f;
		if (ShipStatKeeper.temperature < 5 || ShipStatKeeper.temperature > 45) {
			health -= 0.05f;
			happiness -= 0.5f;
		}
		if (ShipStatKeeper.humidity > 50) {
			happiness -= 0.5f;
		}

		if (happiness < 1) {
			health--;
		}
	}
}
