using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydroponicsB : MonoBehaviour {
	public static int ID = 4;

	float _health = 100;
	public float Health{
		get{ return _health; }
		set{
			_health = value;
			ShipStatKeeper.garden = value;
			if (value > 75) {
				foodOutput = 2;
				foodRate = new WaitForSeconds (3f);
			} else if (value <= 75 && value > 50) {
				foodOutput = 2;
				foodRate = new WaitForSeconds (5f);

			} else if (value <= 50 && value > 25) {
				foodOutput = 1;
				foodRate = new WaitForSeconds (6f);

			} else if (value <= 25 && value > 0) {
				foodOutput = 1;
				foodRate = new WaitForSeconds (10f);

			} else if (value < 1) {
				foodOutput = 0;
			}
		}
	}
	WaitForSeconds decayRate, foodRate;
	int foodOutput;
	public static int foodStore;


	void Start () {
		decayRate = new WaitForSeconds (5f);
		foodRate = new WaitForSeconds (3f);
		StartCoroutine ("gardenDecay");
		StartCoroutine ("foodGrowth");
	}

	IEnumerator gardenDecay(){
		Health--;
		yield return decayRate;
	}
	IEnumerator foodGrowth(){
		if (foodOutput > 0) {
			foodStore += foodOutput;
			yield return foodRate;
		} else {
			yield return null;
		}
	}
	public void harvest(){
		ShipStatKeeper.food += foodStore;
		foodStore = 0;
		Debug.Log (ShipStatKeeper.food);
	}
}


/* Garden behavior: decay health by decayValue (int) for every decayRate (seconds)
 * makes 1 food for every foodOutput (seconds), which will be stored in food
 * 75-100 health = 3 seconds  +1 food
 * 50-75 health = 5 seconds +1 food
 * 25-50 health = 7 seconds +1 food
 * 25> health = 10 seconds +1 food
 * 0 health = no food
 * requires 1 fertilizer to tend, each tend +25% health
 */