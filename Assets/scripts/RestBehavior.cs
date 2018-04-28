using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestBehavior : MonoBehaviour {
	public int minHealth, kit;



	public void RestCheck(int crew){
		if (CrewManager.crewList [crew].energy < 7 && CrewManager.crewList [crew].health > 0) {
			if (Inventory.Inv [2] > 0) {
				Debug.Log ("inv not enough");

				CrewManager.crewList [crew].active = true;
				StartCoroutine (Resting (CrewManager.crewList [crew]));
			} else
				Debug.Log ("cannot heal :(");
		}
	}

	IEnumerator Resting(CrewPerson crew){
		WaitForSeconds wait = new WaitForSeconds (1);
		float multiplier = (5-crew.health)*5;
		for (int i = 0; i < multiplier; i++){

			Debug.Log ("Healing");
			yield return wait;
		}

		if (crew.health < 3) {
			crew.health += 3;
		} else if (crew.health == 3) {
			crew.health += 2;
		} else {
			crew.happiness++;
		}
		Inventory.Inv [2]--;
		crew.active = false;

	}
}
