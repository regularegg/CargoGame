using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBehavior : MonoBehaviour {
	public int minHealth, kit;



	public void HealCheck(int crew){
		if (CrewManager.crewList [crew].health < 5 && CrewManager.crewList [crew].health > 0) {
			if (Inventory.Inv [2] > 0) {
				Debug.Log ("inv not enough");

				CrewManager.crewList [crew].active = true;
				StartCoroutine (Healing (CrewManager.crewList [crew]));
			} else
				Debug.Log ("cannot heal :(");
		}
	}

	IEnumerator Healing(CrewPerson crew){
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
		crew.active = false;

	}
}
