using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMvmt : MonoBehaviour {
	public static float speed = 10, efficiency = 100; //km per L 
	//10km/sec > so there should be a delay function to calculate distance
	//500km/L > rate of consumption
	public float distanceCovered;
	float distToDestination;
	public GameObject shipSprite;
	WaitForSeconds wait;

	void Start () {
		distanceCovered = 0;
		//InvokeRepeating ("FuelConsumption",5f, 1f);
		StartCoroutine(shipMovement ());
		distToDestination = ShipStatKeeper.distanceToDestination;
		wait = new WaitForSeconds (5);
	}

	void FuelConsumption(){
		
	}

	IEnumerator shipMovement(){
		
			if (ShipStatKeeper.shipMoving) {
			Debug.Log ("Moving");
				while(ShipStatKeeper.fuel>0) {
					distanceCovered += speed;
					ShipStatKeeper.distanceTravelled = distanceCovered;
					if (distanceCovered % efficiency == 0) {
						ShipStatKeeper.fuel--;
						if (distanceCovered < 500) {
							shipSprite.transform.position += Vector3.right * 0.5f;
						} else {
							shipSprite.GetComponent<SpriteRenderer> ().flipX = true;
							shipSprite.transform.position -= Vector3.right * 0.5f;
						}
					}
				yield return wait;
				}
				if (ShipStatKeeper.fuel == 0) {
				StopCoroutine ("shipMovement");
				}

			}

	}
}



//https://answers.unity.com/questions/415162/basics-of-making-a-gas-script-making-cars-get-gas.html
//https://answers.unity.com/questions/697812/call-function-every-second.html
