using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineeringB : MonoBehaviour {
	int _health;
	public int health{
		get{ return _health; }
		set{
			_health = value;
			ShipStatKeeper.engine = value;
		}
	}
	public int heatOutput = 1;
	public static int ID = 2;
	int _engineLevel = 0;
	public int engineLevel{
		get{ return _engineLevel; }
		set{
			_engineLevel = value;
			if (value == 1) {
				ShipMvmt.efficiency += 10;
				researchBehavior.roomLevels [2]++;
				RoomManager.rooms [2].level++;
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
		InvokeRepeating ("Decay", 1f, 4f);
	}

	void Decay(){
		if (health > 10) {
			if (Random.Range (0, 100) < 10) {
				health--;
				if (!ShipStatKeeper.acOn)
					ShipStatKeeper.temperature += heatOutput / 2;
			}
		} else if (health <= 10 && health > 0) {
			if (Random.Range (0, 100) < 50) {
				health--;
				if (!ShipStatKeeper.acOn)
					ShipStatKeeper.temperature += heatOutput;
			}
		} else if (health == 0) {

		}
	}

	public void fix(int toolbox, CrewPerson crew){
		if (toolbox >= 1 && health<100) {
			Inventory.upgradeInv [0] -= 2;
			crew.active = true;
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
		Debug.Log ("Upgrade check");

		if (toolbox>=5 && ShipStatKeeper.engineCanUpgrade) {
			crew.active = true;
			Inventory.upgradeInv [0] -= 4;
			crew.active = true;
			StartCoroutine (_upgrade (crew));
			Debug.Log ("Started upgrade");
		} else {
			Debug.Log (" NOT enough toolboxes");
		}
	}
		
	IEnumerator _upgrade(CrewPerson crew){
		int count = -10;
		while (count < 100){
			Debug.Log ("Upgrading");

			count += 10;
			yield return upgradeWait;
		}
		if (count >= 100) {
			Debug.Log ("Finsihed upgrade");
			crew.active = false;
			engineLevel++;
			yield break;
		}
	}
}
