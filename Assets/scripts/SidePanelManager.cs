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
		InventoryNumbers [3].text = Inventory.Inv [0]+ "";
		InventoryNumbers [4].text = Inventory.Inv [1]+ "";
		InventoryNumbers [5].text = Inventory.Inv [2]+ "";

		fuel.text = ShipStatKeeper.fuel + "";
		cargo.text = ShipStatKeeper.cargo + "";

	}
}
