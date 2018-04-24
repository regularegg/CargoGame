using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SidePanelManager : MonoBehaviour {
	public TextMeshProUGUI[] InventoryNumbers = new TextMeshProUGUI[6];
	public TextMeshProUGUI fuel, cargo, income;

	void Update(){
		InventoryNumbers [0].text = Inventory.upgradeInv [0] + "";
		InventoryNumbers [1].text = Inventory.upgradeInv [1]+ "";
		InventoryNumbers [2].text = Inventory.upgradeInv [2]+ "";
		InventoryNumbers [3].text = Inventory.mineInv [0]+ "";
		InventoryNumbers [4].text = Inventory.mineInv [1]+ "";
		InventoryNumbers [5].text = Inventory.mineInv [2]+ "";

		fuel.text = ShipStatKeeper.fuel + "";
		cargo.text = ShipStatKeeper.cargo + "";

	}

/*	public TextMeshProUGUI systemLevel, fuel, energyUse, food;
	public string opAtext, opBtext,opCtext;


	void Update () {
		int energyCount = 0;
		if (ShipStatKeeper.acOn)
			energyCount++;
		else if (ShipStatKeeper.humidOn)
			energyCount++;
		else if (ShipStatKeeper.gravOn)
			energyCount++;
		for (int i = 0; i < 3; i++) {
			if (CrewManager.crewList [i].awake)
				energyCount++;
			if (CrewManager.crewList [i].active)
				energyCount++;
		}
		systemLevel.text = "Engine Level: " + RoomManager.rooms[2].level+" \n Tool Fab Level: " + RoomManager.rooms[1].level;

		fuel.text = ""+ShipStatKeeper.fuel;
		energyUse.text = "Energy usage: "+ energyCount;
		food.text = "food: " + ShipStatKeeper.food;
	//	opA.text = "Temperature: " + ShipStatKeeper.temperature.ToString("0.#");
		//opB.text = "Humidity: " + ShipStatKeeper.humidity.ToString("0.#");
	}

	public void TextDisplayUpdate(string inp, int pos){
	}*/
}
