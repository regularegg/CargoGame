using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewPerson {
	public float _health, happiness, hunger, engineerSkill, fabSkill, mineSkill, cost, age;
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
	public int index, currRoom, energy, currAnim;
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
		energy = 10;
		hunger = 80;
		currAnim = -1;

		engineerSkill = engSkill;
		fabSkill = fbSkill;
		mineSkill = mSkill;
		name = id;
		age = currAge;
		index = nindex;
		cost = (engineerSkill + fbSkill + mineSkill) / 10;
	}
		
}
