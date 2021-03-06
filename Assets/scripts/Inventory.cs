﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour {
	public static int[] Inv = new int[]{0,0,0};
	public static int[] InvMin = new int[]{2,1,1};
	public static int[] energyMin = new int[]{2,2,1};

	int[] FabTime = new int[]{10,15,15};
	public static float[] mineBonus = new float[]{ 0.5f, 1, 1 };

	public static int[] upgradeInv = new int[]{0,0,0};
	float[] upgradeFabTime = new float[]{ 10, 5, 7 };

	public TextMeshProUGUI[] action = new TextMeshProUGUI[3];

	public int rawMaterial = 20;
	public static string[] mineItems;
	public static string[] upgradeItems;

	public Animator anim;
	public Animation walking, working;


	public WaitForSeconds wait = new WaitForSeconds (0.5f);


	void Start () {
		mineItems = new string[]{ "Mining Kit", "Repair Kit", "Self Care Kit" };
	
	}

	public void makeItemCheck(int room, int fabType, int item, int crew){
		StartCoroutine (makeItem (fabType));
		if (ShipStatKeeper.matter > InvMin [fabType] && CrewManager.crewList [crew].energy > energyMin [fabType]) {
			StartCoroutine (makeItem (fabType));
		}
	}
	IEnumerator makeItem (int fabType){
		//anim.Play ("Working");
		WaitForSeconds wait = new WaitForSeconds (1);
		for (int i = 0; i < FabTime[fabType]; i++) {
			yield return wait;
		}
		Inv [fabType]++;
		//anim.Play ("Wait");
	}




	public void fabPrep (int room, int fabType, int item)
	{
		for (int i = 0; i < CrewManager.crewList.Length; i++) {
			Debug.Log ("fabPrep loop" + i);

			if (CrewManager.crewList [i].currRoom == room) {
				Debug.Log ("fabPrep 2");
				StartCoroutine (addMineInv (item, CrewManager.crewList [i].fabSkill, CrewManager.crewList [i], i));
				break;

			} else
				Debug.Log ("next person");
		}
	}


		

	IEnumerator addMineInv(int itemIndex, float crewSkill, CrewPerson crew, int index){ // 1 progress every 0.25 sec
		Debug.Log("addMineInv started");


		float target = FabTime [itemIndex];
		float productionProgress = 0;
		while(productionProgress < target){
			productionProgress += (crewSkill * 0.01f) + (ShipStatKeeper.gravity * 0.5f);
			if (productionProgress + (crewSkill * 0.01f) + (ShipStatKeeper.gravity * 0.5f) > target) {
				Inv [itemIndex] += 1;
				Debug.Log("Made inv thing" +Inv[itemIndex]);
				crew.currentActivity = 0;
				crew.active = false;
				action [index].text = "";

				yield break;
			}
			crew.currentActivity = 3 + itemIndex;
			Debug.Log("Making" +Inv[itemIndex]);
			int temp = (int)(100*productionProgress/target);
			action [index].text = mineItems [itemIndex] + ": " + temp + "%";
			crew.active = true;
			yield return wait;
		}

		Inv [itemIndex] += 1;
		Debug.Log("Made inv thing" +Inv[itemIndex]);
		crew.currentActivity = 0;
		crew.active = false;
		action [index].text = "";

		yield break;
	}
}