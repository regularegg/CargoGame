using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManualManager : MonoBehaviour {
	public Button lButton, rButton;
	public TextMeshProUGUI leftPage, rightPage;
	public string[] dispText = new string[] {
		"Basics:\n\nuse the throttle at the bottom left to start/stop the engine.\n\nMake sure the engine is running to move.\n\nClick on buttons to turn ship system functions like ac on.\n\n 1.",
		"Panels:\n\nuse the communicator at the top right to get crew to go to rooms on the map and perform tasks.\n\nuse the information panel on the left to check on your ship status\n\n\n\n 2. ",
		"Inventory:\nItems are required for ship upkeep and resource mining.\n\nAir filters, toolboxes, and fertilizer help fix and upgrade rooms on the ship.\n\ndrills, containers and transporters help increase resource yield during mining.\n \n 3.",
		"Upgrading:\nCertain rooms on the ship can be upgraded with the right research and materials.\n\nUse the research lab to research room upgrades.\n\nuse inventory items to upgrade the rooms.\n\n 4.",
		"Crew:\nEach crew member has unique skills.\n\ncrafting helps with item making.\n\nengineering helps with upgrades\n\nmining helps with mining operations.\n\nHover over each crew member to see their skills.\n\n 5.",
		"Crew cont'd\nCrew members will die if their health reaches 0.\n\nrunning out of oxygen and food will deplete health.\n\nworking your crewmembers too hard will deplete health\n\nopening the airlock without docking at an asteroid will kill crewmembers inside the airlock.\n\n 6."
	};
	int _count = 0;
	public int count{ // displays the pages according to count
		get{ return _count; }
		set{
			_count = value;
			if (value == 0) {
				Debug.Log ("manual pg");
				leftPage.text = dispText [0];
				rightPage.text = dispText [1];
			} else if (value == 1) {
				Debug.Log ("manual pg 1");

				leftPage.text = dispText [2];
				rightPage.text = dispText [3];
			} else if (value == 2) {
				Debug.Log ("manual pg 2");

				leftPage.text = dispText [4];
				rightPage.text = dispText [5];
			}
		}
	}
	public GameObject book;

	void Start () {
		count = 0;
		lButton.onClick.AddListener (() => {
			leftButton ();
		});
		rButton.onClick.AddListener (() => {
			rightButton ();
		});
	}

	public void leftButton(){//turns pages to the left
		Debug.Log ("leftButton");

		if (count < 2) {
			count++;
		}
	}
	public void rightButton(){// turns pages to the right
		Debug.Log ("right button");
		if (count > 0 && count < 3) {
			count--;
		}
	}

}
