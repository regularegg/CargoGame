using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class researchBehavior : MonoBehaviour {
	public static int ID = 0;
	public static int[] roomLevels;
	float[] researchT = new float[]{10f, 15f, 20f};
	float[] engineT = new float[]{10f, 15f, 20f};
	float[] toolFabT = new float[]{10f, 15f, 20f};
	float[] mineFabT = new float[]{10f, 15f, 20f};
	float[] gardenT = new float[]{5f, 10f, 15f};
	float[] airFilterT = new float[]{10f, 15f, 20f};
	WaitForSeconds wait;
	int _research;
	int Research{
		get{ return _research; }
		set{

		}
	}
	int _engine;
	int Engine{
		get{ return _engine; }
		set{
			_engine = value;
			ShipStatKeeper.engineCanUpgrade = true;
		}
	}
	int _toolFab;
	int ToolFab{
		get{ return _toolFab; }
		set{
			_toolFab = value;
			//ShipStatKeeper.engi = true;
		}
	}
	int _mineFab;
	int MineFab{
		get{ return _mineFab; }
		set{
			_mineFab = value;
			//ShipStatKeeper.filterCanUpgrade = true;
		}
	}
	int _garden;
	int Garden{
		get{ return _garden; }
		set{

		}
	}
	int _filter;
	int Filter{
		get{ return _filter; }
		set{
			_filter = value;
			ShipStatKeeper.filterCanUpgrade = true;
		}
	}


	void Start () {
		roomLevels = new int[]{ Research, Engine, ToolFab, MineFab, Garden, Filter };
		wait = new WaitForSeconds (1f);
	}

	public void upgradeCheck(int room, int crew){
		for (int i = 0; i < CrewManager.crewList.Length; i++) {
			Debug.Log ("fabPrep loop" + i);

			if (CrewManager.crewList [i].currRoom == 1) {
				StartCoroutine (research (room,CrewManager.crewList[i]));
				break;
			} else
				Debug.Log("next person");
		}
		if (RoomManager.rooms [room].level >= 3) {
			Debug.Log("Room level maxed");
		}
	}
	IEnumerator research(int room, CrewPerson crew){
		if (room == 2)
			wait = new WaitForSeconds (engineT [RoomManager.rooms [room].level]);
		else if (room ==1)
			wait = new WaitForSeconds (toolFabT [RoomManager.rooms [room].level]);
		else if (room == 6)
			wait = new WaitForSeconds (airFilterT [RoomManager.rooms [room].level]);
		
		int target = 0;
		while (target < 10 + RoomManager.rooms [room].level) {
			target++;
			Debug.Log ("researching");

			yield return wait;
		}
		if (target >= 10 + RoomManager.rooms [room].level) {
			Debug.Log ("done w level research");
			if (room == 1)
				ToolFab++;
			else if (room == 2)
				Engine++;
			else if (room == 6)
				Filter++;
		}
		
	}
}
/* be able to research upgrades for ship
 * integers of ship level (w/ get n set)
 * array of research time requirements corresponding to each level
 * research coroutine that takes ( integer to be upgraded, float time for upgrade)
 */
