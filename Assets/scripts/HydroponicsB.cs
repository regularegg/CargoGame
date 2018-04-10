using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HydroponicsB : MonoBehaviour {
	public static int ID = 4;
	public static string[] requirements = new string[]{ "1 Fertilizer" };
	public TextMeshProUGUI output;
	public GameObject level;

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
	public static int foodStore = 0;


	void Start () {
		Health = ShipStatKeeper.garden;
		decayRate = new WaitForSeconds (5f);
		foodRate = new WaitForSeconds (3f);

		InvokeRepeating ("gardenDecay", 1,5f);
		InvokeRepeating ("foodGrowth", 1, 5f);
	}
	void Update(){
		scale ();
	}

	public void tend(){
		if (Inventory.upgradeInv[0] > 0&&ShipStatKeeper.garden<100){
			Inventory.upgradeInv [0]--;
			ShipStatKeeper.garden += 25;

		}
	}
	void gardenDecay(){
		Debug.Log("garden decay 2"); 	

		if ((ShipStatKeeper.temperature > 30) && (ShipStatKeeper.humidity < 20 && ShipStatKeeper.humidity > 60)) {
			Health -= 0.5f;

			ShipStatKeeper.humidity++;
		} else if (ShipStatKeeper.temperature < 20 && (ShipStatKeeper.humidity > 20 && ShipStatKeeper.humidity < 60)) {
			Health -= 0.25f;
		} else if (Health < 20) {
			Health--;
		} else if (ShipStatKeeper.temperature < 30 && ShipStatKeeper.temperature > 20 && Health < 100 && (ShipStatKeeper.humidity > 20 && ShipStatKeeper.humidity < 60)) {
			Health += 0.25f;
		}
	}

	void foodGrowth(){
		if (foodOutput > 0) {
			foodStore += foodOutput;
		}
	}

	IEnumerator _gardenDecay(){
		while (ShipStatKeeper.fuel > 0) {
			Debug.Log("garden decay 1"); 	

			if ((ShipStatKeeper.temperature > 30) && (ShipStatKeeper.humidity < 20 && ShipStatKeeper.humidity > 60)) {
				Health -= 0.5f;
				Debug.Log("garden decay 2"); 	

				ShipStatKeeper.humidity++;
			} else if (ShipStatKeeper.temperature < 20 && (ShipStatKeeper.humidity > 20 && ShipStatKeeper.humidity < 60)) {
				Health -= 0.25f;
			} else if (Health < 20) {
				Health--;
			} else if (ShipStatKeeper.temperature < 30 && ShipStatKeeper.temperature > 20 && Health < 100 && (ShipStatKeeper.humidity > 20 && ShipStatKeeper.humidity < 60)) {
				Health += 0.25f;
			}
			yield return decayRate;
		}
	}

	IEnumerator _foodGrowth(){
		Debug.Log("food enum122s"); 	
		while (ShipStatKeeper.fuel > 0) {
			Debug.Log("food enum555"); 	

			if (foodOutput > 0) {
				Debug.Log("food 77"); 	

				foodStore += foodOutput;
				output.text = "FOOD :"+ foodStore;// TEMPORARY PLS CHANGE TO OUTPUT THE FOOD IN INV INSTEAD
				Debug.Log("food enum"); 	
				yield return foodRate;
			} else {
				yield return null;
			}
		yield return decayRate;
	}
}
	public void harvest(){
		ShipStatKeeper.food += foodStore;
		foodStore = 0;
		Debug.Log (ShipStatKeeper.food);
	}
	void scale(){
		level.transform.localScale = (foodStore * Vector3.up/10)+(Vector3.right);
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