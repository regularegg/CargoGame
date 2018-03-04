using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airFilterBehavior : MonoBehaviour {
	int crewAwake;
	public static string[] requirements = new string[]{ "cost: 1 filter", "cost: 4 filter" };

	float _health;
	public float health{
		get{ return _health; }
		set{
			health = value;
		}
	}
	public static int ID = 6;
	WaitForSeconds wait, oxygenWait;

	void Start () {
		health = ShipStatKeeper.airfilter;
		wait = new WaitForSeconds (1f);
		oxygenWait = new WaitForSeconds (2f);
		StartCoroutine ("AirFilterDecay");
	}

	IEnumerator AirFilterDecay(){
		if ((ShipStatKeeper.garden < 75)&&(ShipStatKeeper.humidity>50)) {
			health -= 1f;
		} else {
			health -= 0.25f;//add randomness later
		}
		yield return wait;
	}
	IEnumerator OxygenDecay(){
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

		yield return oxygenWait;
	}

	public void fix(int filters, CrewPerson crew){
		if (health < 100&& filters>=1){
			Inventory.upgradeInv [3]--;
			crew.active = true;
			StartCoroutine (filterReplace(crew));
		}
	}

	IEnumerator filterReplace(CrewPerson crew){
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
}
