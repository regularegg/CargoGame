﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMvmt : MonoBehaviour {
	public float speed = 10, distanceCovered, efficiency = 100; //km per L 
	//10km/sec > so there should be a delay function to calculate distance
	//500km/L > rate of consumption
	public GameObject shipSprite;


	void Start () {
		distanceCovered = 0;
		InvokeRepeating ("FuelConsumption",5f, 1f);

	}

	void FuelConsumption(){
		if (ShipStatKeeper.shipMoving) {
			if (ShipStatKeeper.fuel != 0) {
				distanceCovered += speed;
				if (distanceCovered % efficiency == 0) {
					ShipStatKeeper.fuel--;
					if (distanceCovered < 500) {
						shipSprite.transform.position += Vector3.right * 0.5f;
					} else {
						shipSprite.GetComponent<SpriteRenderer> ().flipX = true;
						shipSprite.transform.position -= Vector3.right * 0.5f;
					}
				}
			}
			if (ShipStatKeeper.fuel == 0) {
				Debug.Log ("EMPTY");

			}
	}


}
}



//https://answers.unity.com/questions/415162/basics-of-making-a-gas-script-making-cars-get-gas.html
//https://answers.unity.com/questions/697812/call-function-every-second.html
