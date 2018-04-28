using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GraphicalOutput : MonoBehaviour {
	public GameObject temperature, humidity, fuel, power, trutemp, truhum;
	public GameObject crw0, crw1, crw2;
	public float temperatureHold, humhold, oxygenhold, powerhold;
	public TextMeshProUGUI cstats0, cstats1, cstats2, detail, fueltxt, energy, filter, inventory, cargo, income;
	float fuelInit;


	string[] roomNames;


	void Start () {
		fuelInit = ShipStatKeeper.fuel;
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
		InventoryDisplay ();
		if (temperatureHold != ShipStatKeeper.temperature) {
			//temperatureScale ();
			temperatureHold = ShipStatKeeper.temperature;
		}
		if (humhold != ShipStatKeeper.humidity) {
			//humidityScale ();
			humhold = ShipStatKeeper.temperature;
		}
		if (oxygenhold != ShipStatKeeper.oxygen) {
			//oxygenScale ();
			oxygenhold = ShipStatKeeper.fuel;
		}

		CrewDataManager ();
	}




	void CrewDataManager(){
		cstats0.text = CrewManager.crewList [0].name + "\n" + CrewManager.crewList [0].age+"\n" + CrewManager.crewList [0].health + "\n" + roomNames[CrewManager.crewList [0].currRoom];

		cstats1.text = CrewManager.crewList [1].name + "\n" + CrewManager.crewList [1].age + "\n" + CrewManager.crewList [1].health + "\n" + roomNames[CrewManager.crewList [1].currRoom];

		cstats2.text = CrewManager.crewList [2].name + "\n" + CrewManager.crewList [2].age+ "\n" + CrewManager.crewList [2].health + "\n" + roomNames[CrewManager.crewList [2].currRoom];

	}
	void InventoryDisplay(){
		inventory.text = 
			Inventory.mineItems[0] +": "+Inventory.Inv [0] + "\n" +
			Inventory.mineItems[1] +": "+Inventory.Inv [1] + "\n" +
			Inventory.mineItems[2] +": " +Inventory.Inv [2];
		
		
	}
}
