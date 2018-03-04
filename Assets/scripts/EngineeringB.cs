using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineeringB : MonoBehaviour {
	public int health;
	public static int ID = 2;
	int _engineLevel = 0;
	public int engineLevel{
		get{ return _engineLevel; }
		set{
			if (value == 1) {
				ShipMvmt.efficiency += 10;
			} else if (value == 2) {
				ShipMvmt.speed += 3;
			} else if (value == 3) {
				ShipMvmt.efficiency += 10;
				ShipMvmt.speed += 2;
			}
		}
	}

	WaitForSeconds wait, upgradeWait;

	// Use this for initialization
	void Start () {
		health = 100;
		wait = new WaitForSeconds (4f);
		upgradeWait = new WaitForSeconds (2f);
		StartCoroutine ("Decay");
	}

	IEnumerator Decay(){
		if (health > 10) {
			if (Random.Range (0, 100) < 10) {
				health--;
			}
			yield return wait;
		} else if (health <= 10 && health > 0) {
			if (Random.Range (0, 100) < 45) {
				health--;
			}
			yield return wait;
		} else {
			yield return null;
		}
	}

	public void fix(int toolbox, CrewPerson crew){
		if (toolbox >= 1 && health<100) {
			Inventory.upgradeInv [0] -= 2;
			crew.active = true;
			StartCoroutine (_fix(crew));
		}
	}
	IEnumerator _fix(CrewPerson crew){
		int count = -10;
		while (count < 100){
			count += 10;
			yield return wait;
		}
		if (count >= 100) {
			crew.active = false;
			health += 50;
			yield break;
		}
	}

	public void upgrade(int toolbox, CrewPerson crew){
		if (toolbox >= 5&&engineLevel<4) {
			Inventory.upgradeInv [0] -= 4;
			crew.active = true;
			StartCoroutine (_upgrade(crew));
		}
	}
		
	IEnumerator _upgrade(CrewPerson crew){
		int count = -10;
		while (count < 100){
			count += 10;
			yield return upgradeWait;
		}
		if (count >= 100) {
			crew.active = false;
			engineLevel++;
			yield break;
		}
	}
}
