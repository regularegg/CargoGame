using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	public static int[] inv;
	string[] invNames;


	// Use this for initialization
	void Start () {
		inv = new int[6];
		invNames = new string[]{ "Hand Tools","Gardening Equipment", "Filters", "Drills", "Materials", "AC Coolant"};
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
