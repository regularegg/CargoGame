﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStatKeeper: MonoBehaviour {
	public SpriteRenderer BG;
	public Sprite[] sky = new Sprite[4];
	public static float 
	temperature = 25, 
	humidity = 25, 
	fuel=20, //going towards power
	power = 100, //will take -0.01 fuel per mvmt for each system on
	distanceToDestination = 50,
	distanceTravelled,
	food = 50, 
	gravity = 1, // only effects crew health
	oxygen = 100, 
	airfilter = 100,
	garden = 100,
	cargo=0,
	engine = 100,
	bots = 3, // slow rate of decay when there are more bots, more bots can be made in fab room
	matter = 0;
//	float foodDecay = 1, oxygenDecay = 0, airFilterDecay = 1, hydroponicsDecay = 0.5f, botsDecay = 1;
	public static float tempToAdd, humToAdd;
	public static float cryobedCount, crewCount, engineClass;
	public static bool  shipMoving, acOn, humidOn, _gravOn, docked, canMine, 
	engineCanUpgrade,
	filterCanUpgrade;
	public static int crewAwake = 3;

	public delegate void ShipMovementChange(bool shipStatus);
	public static event ShipMovementChange shipMovementChange;

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
	public static bool gravOn{
		get{return _gravOn;}
		set{
			if (value) {
				gravity = 1;
			} else
				gravity = 0;

			_gravOn = value;
		}
	}
	void Update () {
		if (fuel < 10) {
			//Debug.Log("fuel is" + fuel);
		}
		HumidityIncrease ();
		TemperatureIncrease ();
		if (shipMoving) {
			BG.sprite = sky [0];
		}
		else if (!shipMoving) {
			if (docked) {
				BG.sprite= sky [2];
			}else{
				BG.sprite = sky [1];
			}
		}
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
		if (garden > 75) {
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
			garden -= 0.05f;
		} else {
			garden--;
		}
	}

}
