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

	WaitForSeconds wait;

	// Use this for initialization
	void Start () {
		health = 100;
		wait = new WaitForSeconds (4f);
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


}
