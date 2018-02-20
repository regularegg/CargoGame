using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStatKeeper: MonoBehaviour {
	public static float temperature = 25, humidity = 25, fuel=8, power = 100, distanceToDestination, food, gravity, oxygen;
	public static float tempToAdd, humToAdd;
	public static float cryobedCount, crewCount, engineClass;
	public static bool light1, light2, light3;
	public static int crewAwake = 1;

	private float _temperature = temperature;
	public float Temperature{
		get{ return _temperature; }
		set{ 
			if (value == _temperature) {
				return;
			} else {
				_temperature = value;
				temperature = _temperature;
			}
		}
	}
	private float _humidity = humidity;
	public float Humidity{
		get{ return _humidity; }
		set{ 
			if (value == _humidity) {
				return;
			} else {
				_humidity = value;
				humidity = _humidity;
			}
			if (value > 30)
				Debug.Log ("noice");
		}
	}
	void Update () {
		if (fuel < 10) {
			//Debug.Log("fuel is" + fuel);
		}
		HumidityIncrease ();
		TemperatureIncrease ();
	}

	void HumidityIncrease(){
		if (humToAdd != 0) {
			humidity += 0.5f;
			humToAdd -= 0.5f;
		}
	}
	void TemperatureIncrease(){
		if (tempToAdd != 0) {
			temperature += 0.5f;
			tempToAdd -= 0.5f;
		}
	}
}
