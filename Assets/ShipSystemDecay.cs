using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSystemDecay : MonoBehaviour {
	public float cargoHealth = 100, hydroponicHealth = 100, airfilterHealth = 100, foodSupply = 100, oxygenLevel = 100, energyLevel = 100;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		HydroponicDecay ();
		AirFilterDecay ();
		oxygenDecay ();

	}

	void CargoDecay(int cargoType){
		if (cargoType == 0) {

		}
		if (cargoType == 1) {
			
		}
	}

	void HydroponicDecay(){
		if (ShipStatKeeper.temperature > 30) {
			hydroponicHealth -= 0.5f;
		} else if (ShipStatKeeper.temperature < 20) {
			hydroponicHealth -= 0.25f;
		} else if (hydroponicHealth < 20) {
			hydroponicHealth--;
		}
		//add humidity later
	}

	void AirFilterDecay(){
		if (hydroponicHealth < 75) {
			airfilterHealth -= 0.5f;
		} else {
			airfilterHealth -= 0.15f;//add randomness later
		}
	}

	void foodDecay(){
		if (ShipStatKeeper.crewAwake != 0) {
			ShipStatKeeper.food -= 0.5f * ShipStatKeeper.crewAwake;
		}
		if (hydroponicHealth < 50) {
			ShipStatKeeper.food--;
		}
	}

	void oxygenDecay(){
		if (airfilterHealth < 80 || hydroponicHealth < 40) {
			oxygenLevel -= 0.25f * ShipStatKeeper.crewAwake;
		} else if (airfilterHealth < 80 && hydroponicHealth < 40) {
			oxygenLevel -= 0.5f * ShipStatKeeper.crewAwake;
		} else if ((airfilterHealth > 80 && hydroponicHealth > 40) && oxygenLevel != 100) {
			oxygenLevel += 0.75f;
		}
	}


}
