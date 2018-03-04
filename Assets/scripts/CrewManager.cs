using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewManager : MonoBehaviour {
	public static CrewPerson[] options, crewList;
	string[] nameList;
	public Sprite crewpic1, crewpic2, crewpic3;
	public GameObject crewDisplay1, crewDisplay2, crewDisplay3;

	void Start () {
		crewList = new CrewPerson[3];
		//options = new CrewPerson[5];
		nameList = new string[8];
		nameList [0] = "Womp";
		nameList [1] = "Smells";
		nameList [2] = "Mel";
		nameList [3] = "Dingo";
		nameList [4] = "Stumpy Stu";
		nameList [5] = "Cart";
		nameList [6] = "Farts";
		nameList [7] = "Hot Cheetos";


		//for (int i = 0; i < options.Length; i++) {   << for when you can actually choose your crew
		for (int i = 0; i < crewList.Length; i++) {
			string name = nameList[Random.Range(0,nameList.Length)];
			int age = Random.Range(18, 60), 
			engineering = Random.Range(18, 60), 
			fab = Random.Range(18, 60), 
			mine = Random.Range(18, 60);

			crewList [i] = new CrewPerson (name, age, engineering, fab, mine, i);
			StartCoroutine (aging (crewList [i]));
		}
	}


	IEnumerator aging(CrewPerson crew){
		if (crew.age < 100 && crew.alive && crew.awake) {
			crew.age++;
			yield return new WaitForSeconds (60);
		} else if (!crew.awake) {
			yield return null;
		}
		else if (crew.age > 100 || !crew.alive || crew.health < 1) {
			yield break;
		}
	}
}
