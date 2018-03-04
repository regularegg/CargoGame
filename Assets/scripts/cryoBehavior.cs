using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cryoBehavior : MonoBehaviour {
	public static bool[] beds = new bool[]{true, true, true};
	int wakeTime = 6, sleepTime = 3;
	WaitForSeconds wait;


	void Start () {
		wait = new WaitForSeconds (1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void bedInteraction(){

	}

	IEnumerator inBed(CrewPerson crew){
		bool done = false;
		for (int i = 0; i < sleepTime; i++) {
			yield return wait;
		}
		if (done) {
			crew.awake = false;
			yield break;
		}
	}

	IEnumerator outBed(CrewPerson crew){
		bool done = false;
		for (int i = 0; i < wakeTime; i++) {
			yield return wait;
		}
		if (done) {
			crew.awake = true;
			yield break;
		}
	}
}
