using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewManager : MonoBehaviour {
	CrewPerson[] options, crewList;
	string[] nameList;

	void Start () {
		crewList = new CrewPerson[3];
		options = new CrewPerson[5];
		nameList = new string[8];
		nameList [0] = "Womp";
		nameList [1] = "Smells";
		nameList [2] = "Mel";
		nameList [3] = "Dingo";
		nameList [4] = "Stumpy Stu";
		nameList [5] = "Cart";
		nameList [6] = "Fi";
		nameList [7] = "Hot Cheetos";


		for (int i = 0; i < options.Length; i++) {
			string name = nameList[Random.Range(0,nameList.Length)];
			int age = Random.Range(18, 60), 
			engineering = Random.Range(18, 60), 
			plant = Random.Range(18, 60), 
			mine = Random.Range(18, 60);

			options [i] = new CrewPerson (name, age, engineering, plant, mine);
		}
	}
	
	void Update () {
		
	}
}
