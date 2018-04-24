using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMvmt : MonoBehaviour {
	public static float speed = 10, efficiency = 100; //km per L 
	//10km/sec > so there should be a delay function to calculate distance
	//500km/L > rate of consumption
	float initfuel = ShipStatKeeper.fuel;
	public float distanceCovered;
	float distToDestination;
	public GameObject ship;
	WaitForSeconds wait;
	bool asteroid;

	void Start () {
		distanceCovered = 0;
		InvokeRepeating ("FuelConsumption", 5f, 5f);
		distToDestination = ShipStatKeeper.distanceToDestination;
		wait = new WaitForSeconds (5);
	}

	void FuelConsumption(){
		if (ShipStatKeeper.shipMoving) {
			if(ShipStatKeeper.fuel>0) {
				distanceCovered += speed;
				ShipStatKeeper.distanceTravelled = distanceCovered;
				if (distanceCovered % efficiency == 0) {
					ShipStatKeeper.fuel--;
				}
				if (distanceCovered < (speed*(initfuel/2-1))&&!asteroid) {
					ship.transform.position += Vector3.right * 0.5f;
					Debug.Log ("Sprite Moving");
				} else if(distanceCovered >= (speed*(initfuel/2-1))&&!asteroid){
					Debug.Log("AT ASTEROID");
					GetComponent<EventManager> ().state = 1;
					ShipStatKeeper.shipMoving = false;
					asteroid = true;
				}else if (asteroid){
					ship.GetComponent<SpriteRenderer> ().flipX = true;
					ship.transform.position -= Vector3.right * 0.5f;
				}else if(distanceCovered >= (speed * initfuel)){
					Debug.Log ("VICTORY!!!");
				}
			}
			if (ShipStatKeeper.fuel == 0) {
				return;
			}
		}
		if (!ShipStatKeeper.shipMoving) {
			Debug.Log ("waiting");
		}
	}

	IEnumerator shipMovement(){
		Debug.Log ("GOING");
	
			if (ShipStatKeeper.shipMoving) {
			Debug.Log ("Moving");
				while(ShipStatKeeper.fuel>0) {
					distanceCovered += speed;
					ShipStatKeeper.distanceTravelled = distanceCovered;
					if (distanceCovered % efficiency == 0) {
						ShipStatKeeper.fuel--;
						if (distanceCovered < 500) {
							//shipSprite.transform.position += Vector3.right * 0.5f;
						} else {
							//shipSprite.GetComponent<SpriteRenderer> ().flipX = true;
							//shipSprite.transform.position -= Vector3.right * 0.5f;
						}
					if (ShipStatKeeper.distanceTravelled == (speed*(ShipStatKeeper.fuel/2-1))){
						Debug.Log("AT ASTEROID");
						ShipStatKeeper.shipMoving = false;
						yield return null;
						}
					}
					yield return wait;
				}
				if (ShipStatKeeper.fuel == 0) {
				StopCoroutine ("shipMovement");
				}
			}
		if (!ShipStatKeeper.shipMoving) {
			Debug.Log ("waiting");
			yield return wait;
		}
		yield return wait;
	}
}



//https://answers.unity.com/questions/415162/basics-of-making-a-gas-script-making-cars-get-gas.html
//https://answers.unity.com/questions/697812/call-function-every-second.html
