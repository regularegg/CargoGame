using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStatKeeper: MonoBehaviour {
	public static float 
	temperature = 25, 
	humidity = 25, 
	fuel=10, //going towards power
	power = 100, //will take -0.01 fuel per mvmt for each system on
	distanceToDestination, 
	food = 100, 
	gravity = 1, // only effects crew health
	oxygen = 100, 
	airfilter = 100,
	hydroponics = 100,
	bots = 3; // slow rate of decay when there are more bots, more bots can be made in fab room
//	float foodDecay = 1, oxygenDecay = 0, airFilterDecay = 1, hydroponicsDecay = 0.5f, botsDecay = 1;
	public static float tempToAdd, humToAdd;
	public static float cryobedCount, crewCount, engineClass;
	public static bool shipMoving;
	public static int crewAwake = 3;

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
			if (value > 30) {
			}
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

	static void filterDecay(){
		if (hydroponics > 75) {
			airfilter--;
		} else {
			airfilter -= 2;
		}

		if(Random.Range(0,1000)>950){
			airfilter = 0;
		}
		if (airfilter < 10) {
			oxygen--;
		}
	}
	static void hydroDecay(){
		if ((temperature < 40) && (temperature > 10)) {
			hydroponics -= 0.05f;
		} else {
			hydroponics--;
		}
	}

}
