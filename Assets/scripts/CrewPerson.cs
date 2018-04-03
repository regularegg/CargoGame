using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewPerson {
	public float _health, happiness, engineerSkill, fabSkill, mineSkill, cost, age;
	public float health{
		get{ return _health; }
		set{
			_health = value;
			if (value == 0) {
				alive = false;
			}
		}
	}
	public string name;
	public bool awake, alive, outsideShip, active;
	public int index, currRoom, energy;
	public Sprite sprite;
	public int currentActivity;

	public CrewPerson(string id, float currAge, float engSkill, float fbSkill, float mSkill, int nindex, Sprite sp){
		health = 100;
		happiness = 80;
		currRoom = 0;
		awake = true;
		alive = true;
		currentActivity = 0;
		active = false;
		sprite = sp;
		energy = 100;

		engineerSkill = engSkill;
		fabSkill = fbSkill;
		mineSkill = mSkill;
		name = id;
		age = currAge;
		index = nindex;
		cost = (engineerSkill + fbSkill + mineSkill) / 10;
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
