using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineeringB : MonoBehaviour {
	public bool occupied;
	public int health, ID;

	// Use this for initialization
	void Start () {
		health = 100;
		ID = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Decay(){
		if (Random.Range (0, 100) < 5) {
			health--;
		}
	}


}
