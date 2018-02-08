using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStatKeeper: MonoBehaviour {
	public static float temperature = 25, humidity = 25, fuel=6, power, distanceToDestination, food;
	public static float tempToAdd, humToAdd;
	public static float cryobedCount, crewCount, engineClass;
	public static bool light1, light2, light3;
	public static int crewAwake = 1;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (fuel < 10) {
			Debug.Log("fuel is" + fuel);
		}
		HumidityIncrease ();
		TemperatureIncrease ();
	}

	void HumidityIncrease(){
		if (humToAdd != 0) {
			humidity += 0.5f;
			humToAdd -= 0.5f;
			Debug.Log ("added hum");
		}
	}
	void TemperatureIncrease(){
		if (tempToAdd != 0) {
			temperature += 0.5f;
			tempToAdd -= 0.5f;

			Debug.Log ("added temp");
		}
	}
}
