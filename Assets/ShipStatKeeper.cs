using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStatKeeper: MonoBehaviour {
	public static float temperature = 10f, humidity, fuel=6, power, distanceToDestination;
	public static float cryobedCount, crewCount, engineClass;
	public static bool light1, light2, light3;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (fuel < 10) {
			Debug.Log("fuel is" + fuel);
		}
	}
}
