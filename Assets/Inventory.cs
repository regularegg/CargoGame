using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour {
	public static int[] mineInv = new int[]{0,0,0};
	float[] mineFabTime = new float[]{10,15,15};
	float[] mineBonus = new float[]{ 0.5f, 1, 1 };
	public static int[] upgradeInv = new int[]{0,0,0};
	float[] upgradeFabTime = new float[]{ 10, 5, 7 };

	public int rawMaterial = 20;
	string[] mineItems;
	string[] upgradeItems;

	public WaitForSeconds wait = new WaitForSeconds (0.25f);


	void Start () {
		mineItems = new string[]{ "Drills", "Containers", "Transporters" };
		upgradeItems = new string[]{ "Toolbox", "Fertilizer", "Air Filter" };
	
	}


	public void fabPrep(int room, int fabType, int item){
		for (int i = 0; i < CrewManager.crewList.Length; i++) {
			if (CrewManager.crewList [i].currRoom == room) {
				if (fabType == 1) {
					StartCoroutine (addMineInv (item,CrewManager.crewList[i].fabSkill));
				} else
					StartCoroutine (addUpgradeInv (item,CrewManager.crewList[i].fabSkill));
			} else
				return;
		}
	}

	IEnumerator addMineInv(int itemIndex, float crewSkill){ // 1 progress every 0.25 sec
		float target = mineFabTime [itemIndex];
		float productionProgress = 0;
		while(productionProgress < target){
			productionProgress += (crewSkill * 0.01f) + (ShipStatKeeper.gravity * 0.5f);
			Debug.Log("Making" +mineInv[itemIndex]);

			yield return wait;
		}
		if (productionProgress >= target) {
			mineInv [itemIndex] += 1;
			Debug.Log("Made inv thing" +mineInv[itemIndex]);

			yield break;
		}
	}

	IEnumerator addUpgradeInv(int itemIndex, float crewSkill){ // 1 progress every 0.25 sec
		float target = upgradeFabTime [itemIndex];
		float productionProgress = 0;
		while(productionProgress < target){
			productionProgress += (crewSkill * 0.01f) + (ShipStatKeeper.gravity * 0.5f);

			Debug.Log("Making" +mineInv[itemIndex]);
			yield return wait;
		}
		if (productionProgress >= target) {
			upgradeInv [itemIndex] += 1;
			Debug.Log("Made inv thing" +upgradeInv[itemIndex]);
			yield break;
		}
	}
}
