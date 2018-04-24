using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mineScript : MonoBehaviour {
	int baseIceOutput = 200, mineRate = 10;
	public static int _distanceToDest;
	int crewOutside = 0;
	float sumSkillMult = 0;
	public int type;
	public float[] value = new float[]{1, 1.25f, 1.5f, 2};

	public Button airlock;
	public Button callbackCrew;
	public TextMeshProUGUI airlockStatus;
	bool airlockOpen;

	WaitForSeconds wait;


	public int DistanceToDest{
		get{ return _distanceToDest; }
		set{
			if (value == 0) {
				ShipStatKeeper.shipMoving = false;
				ShipStatKeeper.canMine = true;
			}
		}
	}
	void Start () {
		airlock.onClick.AddListener(delegate {
			//ActivateAirlock ();
		});
		callbackCrew.onClick.AddListener (delegate {
			//returnCrew ();
		});

		wait = new WaitForSeconds (2);
	}

/*	IEnumerator mining(){
		float mineable = baseIceOutput + sumSkillMult+(Inventory.mineBonus[1]*Inventory.mineInv[1]/2);
		float rate = mineable * 0.5f*crewOutside+(Inventory.mineBonus[0]*Inventory.mineInv[0])+(Inventory.mineBonus[2]*Inventory.mineInv[2]);
		float iceMined = 0;

		while (mineable > 0) {
			iceMined += rate;
			ShipStatKeeper.cargo += rate;
			mineable -= rate;
			yield return wait;
		}
		if (mineable < 1) {
			yield break;
		}
	}

	void ActivateAirlock(){
		airlockOpen = !airlockOpen;
		if (ShipStatKeeper.canMine) {
			for (int i = 0; i < CrewManager.crewList.Length; i++) {
				if (CrewManager.crewList [i].outsideShip) {
					crewOutside++;
					sumSkillMult += CrewManager.crewList [i].mineSkill;
					CrewManager.crewList [i].outsideShip = true;
				}
				StartCoroutine ("mining");
			}
		} else {
			for (int i = 0; i < CrewManager.crewList.Length; i++) {
				if (CrewManager.crewList [i].currRoom==6) {
					CrewManager.crewList [i].health = 0;
				}
				Debug.Log ("o no ded");
			}
		}
		airlock.onClick.RemoveAllListeners();
	}

	void returnCrew(){
		if (crewOutside > 0) {
			for (int i = 0; i < CrewManager.crewList.Length; i++) {
				if (CrewManager.crewList [i].outsideShip) {
					CrewManager.crewList [i].outsideShip = false;
				}
				crewOutside--;
			}
		}
		StopCoroutine ("mining");
		callbackCrew.onClick.RemoveAllListeners();
	}*/
}
