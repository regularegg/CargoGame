using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSystemDecay : MonoBehaviour {
	public float cargoHealth = 100, hydroponicHealth = 100, airfilterHealth = 100, foodSupply = 100, oxygenLevel = 100, energyLevel = 100;
	float temperatureHolder, humidityHolder;
	public delegate void tempChange(float temp);
	WaitForSeconds wait = new WaitForSeconds(3f);
	int count = 0;
	void Start () {
		StartCoroutine (oxygenDecay ()); 
		StartCoroutine(foodDecay ());
	}
	
	// Update is called once per frame
	void Update () {
		//HumidityIncrease ();
		//TemperatureIncrease ();
	}

	void CargoDecay(int cargoType){
		if (cargoType == 0) {

		}
		if (cargoType == 1) {
			
		}
	}
	void awakeCounter(){
		int tempCount = 0;
		for (int i = 0; i < CrewManager.crewList.Length; i++) {
			if (CrewManager.crewList [i].awake) {
				tempCount++;
				Debug.Log ("Awake Counter: "+tempCount);
			}
		}
		count = tempCount;
		tempCount = 0;
	}

	IEnumerator foodDecay(){
		awakeCounter ();
		for (float i = ShipStatKeeper.food; i > 0; i--) {
			ShipStatKeeper.food -= 0.5f * count;
			yield return wait;
		}
		if (ShipStatKeeper.food == 0) {
			yield return null;
		}
	}

	IEnumerator oxygenDecay(){
		while (ShipStatKeeper.oxygen > 0) {
			if (ShipStatKeeper.airfilter < 80 || ShipStatKeeper.garden < 40) {
				ShipStatKeeper.oxygen -= 0.25f * ShipStatKeeper.crewAwake;
			} else if (ShipStatKeeper.airfilter < 80 && ShipStatKeeper.garden < 40) {
				ShipStatKeeper.oxygen -= 0.5f * ShipStatKeeper.crewAwake;
			} else if ((ShipStatKeeper.airfilter > 80 && ShipStatKeeper.garden > 40) && ShipStatKeeper.oxygen != 100) {
				ShipStatKeeper.oxygen += 0.75f;
			}
			yield return wait;
		}
		if (ShipStatKeeper.oxygen == 0) {
			for (int i = 0; i < CrewManager.crewList.Length; i++) {
				CrewManager.crewList [i].health = 0;
				CrewManager.crewList [i].alive = false;
			}
		}
	}




}
