using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewManager : MonoBehaviour {
	public static CrewPerson[] options, crewList;
	string[] nameList;
	public Sprite[] crewpics= new Sprite[6];
	public GameObject crewDisplay1, crewDisplay2, crewDisplay3;
	int _awake;
	public int CrewAwake{
		get{ return _awake; }
		set{
			_awake = value;
			ShipStatKeeper.crewAwake = value;
		}
	}

	void Awake () {
		crewList = new CrewPerson[3];
		//options = new CrewPerson[5];
		nameList = new string[9];
		nameList [0] = "Womp";
		nameList [1] = "Smells";
		nameList [2] = "Mel";
		nameList [3] = "Dingo";
		nameList [4] = "Stumpy Stu";
		nameList [5] = "Cart";
		nameList [6] = "Farts";
		nameList [7] = "Hot Cheetos";
		nameList [8] = "Messy Jesse";

		//for (int i = 0; i < options.Length; i++) {   << for when you can actually choose your crew
		for (int i = 0; i < crewList.Length; i++) {
			string name = nameList[Random.Range(0,nameList.Length)];
			int age = Random.Range(18, 60), 
			engineering = Random.Range(18, 60), 
			fab = Random.Range(18, 60), 
			mine = Random.Range(18, 60);
			crewList [i] = new CrewPerson (name, age, engineering, fab, mine, i, crewpics[Random.Range(0,crewpics.Length)]);
			StartCoroutine (aging (crewList [i]));
		}


		crewDisplay1.GetComponent<SpriteRenderer> ().sprite = crewList [0].sprite;
		crewDisplay2.GetComponent<SpriteRenderer> ().sprite = crewList [1].sprite;
		crewDisplay3.GetComponent<SpriteRenderer> ().sprite = crewList [2].sprite;
	}


	IEnumerator aging(CrewPerson crew){
		if (crew.age < 100 && crew.alive && crew.awake) {
			crew.age++;

			yield return new WaitForSeconds (30);
		} else if (!crew.awake) {
			yield return null;
		}
		else if (crew.age > 100 || !crew.alive || crew.health < 1) {
			yield break;
		}
	}

}
