using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GraphicalOutput : MonoBehaviour {
	public GameObject temperature, humidity, fuel, power;
	public GameObject crw0, crw1, crw2;
	public float temperatureHold, humhold, fuelhold, powerhold;
	public TextMeshProUGUI cstats0, cstats1, cstats2, detail;

	string[] roomNames;


	void Start () {
		roomNames = new string[] {
			"Bridge",
			"Cargo",
			"Tool Fab",
			"Engine",
			"Tool Storage",
			"Hydro",
			"Airlock",
			"Filtration",
			"Cryo"
		};
	}
	
	// Update is called once per frame
	void Update () {
		if (temperatureHold != ShipStatKeeper.temperature) {
			temperatureScale ();
			temperatureHold = ShipStatKeeper.temperature;
		}
		if (humhold != ShipStatKeeper.humidity) {
			humidityScale ();
			humhold = ShipStatKeeper.temperature;
		}
		if (fuelhold != ShipStatKeeper.fuel) {
			fuelScale ();
			fuelhold = ShipStatKeeper.fuel;
		}

		CrewDataManager ();
	}

	void temperatureScale(){
		temperature.transform.localScale = (ShipStatKeeper.temperature * Vector3.up/10)+(Vector3.right);
	}
	void humidityScale(){
		humidity.transform.localScale = (ShipStatKeeper.humidity * Vector3.up/10)+(Vector3.right);
	}
	void fuelScale(){
		fuel.transform.localScale = (ShipStatKeeper.fuel * Vector3.up/10)+(Vector3.right);
	}

	void CrewClick(){

	}
	void CrewDataManager(){
		cstats0.text = CrewManager.crewList [0].name + "\n" + CrewManager.crewList [0].age+"\n" + CrewManager.crewList [0].health + "\n" + roomNames[CrewManager.crewList [0].currRoom];

		cstats1.text = CrewManager.crewList [1].name + "\n" + CrewManager.crewList [1].age + "\n" + CrewManager.crewList [1].health + "\n" + roomNames[CrewManager.crewList [1].currRoom];

			cstats2.text = CrewManager.crewList [2].name + "\n" + CrewManager.crewList [2].age+ "\n" + CrewManager.crewList [2].health + "\n" + roomNames[CrewManager.crewList [2].currRoom];

	}
}
