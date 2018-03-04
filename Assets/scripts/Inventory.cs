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
	public static string[] mineItems;
	public static string[] upgradeItems;

	public GameObject[] crewSB = new GameObject[3];

	public WaitForSeconds wait = new WaitForSeconds (0.5f);


	void Start () {
		mineItems = new string[]{ "Drills", "Containers", "Transporters" };
		upgradeItems = new string[]{ "Toolbox", "Fertilizer", "Air Filter" };
	
	}


	public void fabPrep(int room, int fabType, int item){

		for (int i = 0; i < CrewManager.crewList.Length; i++) {
			Debug.Log ("fabPrep loop" + i);

			if (CrewManager.crewList [i].currRoom == room) {
				Debug.Log ("fabPrep 2");
				if (fabType == 1) {
					StartCoroutine (addMineInv (item,CrewManager.crewList[i].fabSkill, CrewManager.crewList[i], i));
					break;

				} else
					StartCoroutine (addUpgradeInv (item,CrewManager.crewList[i].fabSkill, CrewManager.crewList[i], i));
				break;

			} else
				Debug.Log("next person");
		}
	}

	IEnumerator addMineInv(int itemIndex, float crewSkill, CrewPerson crew, int index){ // 1 progress every 0.25 sec
		Debug.Log("addMineInv");

		float target = mineFabTime [itemIndex];
		float productionProgress = 0;
		while(productionProgress < target){
			productionProgress += (crewSkill * 0.01f) + (ShipStatKeeper.gravity * 0.5f);
			crew.currentActivity = 3 + itemIndex;
			Debug.Log("Making" +mineInv[itemIndex]);
			crewSB[index].transform.localScale = (productionProgress * Vector3.left/60)+(Vector3.up);
			crew.active = true;

			yield return wait;
		}

		mineInv [itemIndex] += 1;
		Debug.Log("Made inv thing" +mineInv[itemIndex]);
		crew.currentActivity = 0;
		crew.active = false;
		yield break;
	
	}

	IEnumerator addUpgradeInv(int itemIndex, float crewSkill, CrewPerson crew, int index){ // 1 progress every 0.25 sec
		Debug.Log("addUpgradeInv");

		float target = upgradeFabTime [itemIndex];
		float productionProgress = 0;
		while(productionProgress < target){
			productionProgress += (crewSkill * 0.01f) + (ShipStatKeeper.gravity * 0.5f);
			crew.currentActivity = 3 + itemIndex;
			crew.active = true;
			crewSB[index].transform.localScale = (productionProgress * Vector3.left/60)+(Vector3.up);

			Debug.Log("Making" +mineInv[itemIndex]);
			yield return wait;
		}
			upgradeInv [itemIndex] += 1;
		crew.currentActivity = 0;

			Debug.Log("Made inv thing" +upgradeInv[itemIndex]);
			crew.active = false;
			yield break;

	}
}
