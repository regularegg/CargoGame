using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSystemDecay : MonoBehaviour {
	public float cargoHealth = 100, hydroponicHealth = 100, airfilterHealth = 100, foodSupply = 100, oxygenLevel = 100, energyLevel = 100;
	float temperatureHolder, humidityHolder;
	public delegate void tempChange(float temp);
	WaitForSeconds wait = new WaitForSeconds(1f);
	int count = 0;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		oxygenDecay ();
		foodDecay ();
		//HumidityIncrease ();
		//TemperatureIncrease ();
	}

	void CargoDecay(int cargoType){
		if (cargoType == 0) {

		}
		if (cargoType == 1) {
			
		}
	}

	IEnumerable decay(){
		foodDecay ();
		oxygenDecay ();
		yield return wait;
	}



	void foodDecay(){
		for (int i = 0; i < CrewManager.crewList.Length; i++) {
			if (CrewManager.crewList [i].awake) {
				count++;
			}
		}
		if (count > 1000&&ShipStatKeeper.food>0) {
			ShipStatKeeper.food--;
		}
	}

	void oxygenDecay(){
			if (ShipStatKeeper.airfilter < 80 || ShipStatKeeper.garden < 40) {
				ShipStatKeeper.oxygen -= 0.25f * ShipStatKeeper.crewAwake;
			} else if (ShipStatKeeper.airfilter  < 80 && ShipStatKeeper.garden < 40) {
				ShipStatKeeper.oxygen -= 0.5f * ShipStatKeeper.crewAwake;
			} else if ((ShipStatKeeper.airfilter  > 80 && ShipStatKeeper.garden > 40) && ShipStatKeeper.oxygen != 100) {
				ShipStatKeeper.oxygen += 0.75f;
			}
		}




}
