using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicalOutput : MonoBehaviour {
	public GameObject temperature, humidity;
	public float temperatureHold;
	Transform temp, hum;

	void Start () {
		temp = temperature.transform;
//		hum = humidity.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (temperatureHold != ShipStatKeeper.temperature) {
			temperatureScale ();
			temperatureHold = ShipStatKeeper.temperature;
		}
	}

	void temperatureScale(){
		temperature.transform.localScale = (ShipStatKeeper.temperature * Vector3.up/10)+(Vector3.right);
		//temperature.transform.localPosition = new Vector3(0, temperature.transform.localScale.y+temp.transform.position.y/2, 0);
	}
}
