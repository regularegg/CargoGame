using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSystemDecay : MonoBehaviour {
	public float cargoHealth = 100, hydroponicHealth = 100, airfilterHealth = 100, foodSupply = 100, oxygenLevel = 100, energyLevel = 100;
	float temperatureHolder, humidityHolder;
	public delegate void tempChange(float temp);

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		HydroponicDecay ();
		AirFilterDecay ();
		oxygenDecay ();
		//HumidityIncrease ();
		//TemperatureIncrease ();
	}

	void CargoDecay(int cargoType){
		if (cargoType == 0) {

		}
		if (cargoType == 1) {
			
		}
	}

	void HydroponicDecay(){
		if ((ShipStatKeeper.temperature > 30)&&(ShipStatKeeper.humidity<20&&ShipStatKeeper.humidity>60)) {
			hydroponicHealth -= 0.5f;
		} else if (ShipStatKeeper.temperature < 20&&(ShipStatKeeper.humidity>20&&ShipStatKeeper.humidity<60)) {
			hydroponicHealth -= 0.25f;
		} else if (hydroponicHealth < 20) {
			hydroponicHealth--;
		} else if (ShipStatKeeper.temperature < 30 && ShipStatKeeper.temperature > 20 && hydroponicHealth < 100&&(ShipStatKeeper.humidity>20&&ShipStatKeeper.humidity<60)) {
			hydroponicHealth += 0.5f;
		}
		//add humidity later
	}

	void AirFilterDecay(){
		if ((hydroponicHealth < 75)&&(ShipStatKeeper.humidity>80)) {
			airfilterHealth -= 0.05f;
		} else {
			airfilterHealth -= 0.025f;//add randomness later
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
