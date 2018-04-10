using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airFilterBehavior : MonoBehaviour {
	int crewAwake;
	public static string[] requirements = new string[]{ "cost: 1 filter", "cost: 4 filter" };

	float _health = 100;
	public float health{
		get{ return _health; }
		set{
			_health = value;
		}
	}
	public static int ID = 6;
	WaitForSeconds wait, oxygenWait;

	void Start () {
		health = ShipStatKeeper.airfilter;
		wait = new WaitForSeconds (1f);
		oxygenWait = new WaitForSeconds (2f);
		InvokeRepeating ("AirFilterDecay", 1, 1f);
		InvokeRepeating ("OxygenDecay", 1, 2f);
	}

	void AirFilterDecay(){
		if ((ShipStatKeeper.garden < 75)&&(ShipStatKeeper.humidity>50)) {
			health -= 1f;
		} else {
			health -= 0.25f;
		}
	}
	void OxygenDecay(){
		for (int i = 0; i < CrewManager.crewList.Length; i++) {
			if (CrewManager.crewList [i].awake)
				crewAwake++;
		}
		if (health > 75 && ShipStatKeeper.oxygen<100) {
			ShipStatKeeper.oxygen++;
		}else if (health < 50 && health > 25) {
			ShipStatKeeper.oxygen -= 0.5f*crewAwake;
		} else if (health < 25 && health > 0) {
			ShipStatKeeper.oxygen -= 0.75f*crewAwake;
		} else if (health < 1) {
			ShipStatKeeper.oxygen -= 1f*crewAwake;
		}
		crewAwake = 0;
	}

	public void fix(int filters, CrewPerson crew){
		if (health < 100&& filters>=1){
			Inventory.upgradeInv [3]--;
			crew.active = true;
			StartCoroutine (filterReplace(crew));
		}
	}

	IEnumerator filterReplace(CrewPerson crew){
		crew.active = true;
		int count = -10;
		while (count < 100){
			count += 10;
			yield return oxygenWait;
		}
		if (count >= 100) {
			crew.active = false;
			health = 100;
			yield break;
		}
	}
	public IEnumerator filterUpgrade(CrewPerson crew){
		if (ShipStatKeeper.filterCanUpgrade && Inventory.upgradeInv [2] > 3) {
			int count = -10;
			Inventory.upgradeInv [2] -= 3;
			while (count < 100) {
				count += 10;
				yield return oxygenWait;
			}
			if (count >= 100) {
				crew.active = false;
				researchBehavior.roomLevels [7]++;
				ShipStatKeeper.filterCanUpgrade = false;
				yield break;
			}
		} else {
			if (!ShipStatKeeper.filterCanUpgrade) {
				Debug.Log ("Can't upgrade! insufficient research");
			}else if (Inventory.upgradeInv [2] <= 3) {
				Debug.Log ("Can't upgrade! insufficient filters");
			}
		}
	}
}
