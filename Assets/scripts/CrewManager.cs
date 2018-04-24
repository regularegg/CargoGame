using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrewManager : MonoBehaviour {
	public static CrewPerson[] options, crewList;
	string[] nameList;
	public Sprite[] crewpics= new Sprite[6];
	public GameObject crewDisplay1, crewDisplay2, crewDisplay3;
	public SpriteRenderer crew1main, crew2main, crew3main;
	public TextMeshProUGUI[] crewStat = new TextMeshProUGUI[3];
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

		crew1main.sprite = crewList [0].sprite;
		crew2main.sprite = crewList [1].sprite;
		crew3main.sprite = crewList [2].sprite;

	}

	void Update(){
		needsDecay (crewList [0]);
		needsDecay (crewList [1]);
		needsDecay (crewList [2]);

		for (int i = 0; i < crewList.Length; i++) {
			needsDecay (crewList [i]);
			crewStat [i].text = "Comfort:" + crewList [i].happiness + "\nEnergy: " + crewList [i].energy + "\nHunger: " + crewList [i].hunger ;
		}
	}

	void needsDecay( CrewPerson crew){
		if (ShipStatKeeper.food < ShipStatKeeper.crewAwake * 10) 
			crew.health -= 0.05f;
		if (ShipStatKeeper.temperature < 5 || ShipStatKeeper.temperature > 45) {
			crew.health -= 0.05f;
			crew.happiness -= 0.5f;
		}
		if (ShipStatKeeper.humidity > 50) {
			crew.happiness -= 0.5f;
		}

		if (crew.happiness < 1) {
			crew.health--;
		}
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
