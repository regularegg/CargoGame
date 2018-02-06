﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMvmt : MonoBehaviour {
	public float speed = 10, distanceCovered, efficiency = 100; //km per L 
	//10km/sec > so there should be a delay function to calculate distance
	//500km/L > rate of consumption


	void Start () {
		distanceCovered = 0;
		InvokeRepeating ("FuelConsumption",5f, 1f);

	}
	
	// Update is called once per frame
	void Update () {
	}

	void FuelConsumption(){
		if (ShipStatKeeper.fuel != 0) {
			distanceCovered += speed;
			if (efficiency%distanceCovered == 0) {
				ShipStatKeeper.fuel--;
			}
		}
		Debug.Log (ShipStatKeeper.fuel + " " + distanceCovered%efficiency);
	}


}



//https://answers.unity.com/questions/415162/basics-of-making-a-gas-script-making-cars-get-gas.html
//https://answers.unity.com/questions/697812/call-function-every-second.html
