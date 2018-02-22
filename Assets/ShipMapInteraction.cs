using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShipMapInteraction : MonoBehaviour {
	public TextMeshProUGUI detail;
	public bool selectionActive;
	private int _selectedCrew;
	private CrewPerson CPTemp;
	public int SC{
		get{ return _selectedCrew; }
		set{ 
			_selectedCrew = value;
			Debug.Log ("Initial Room: " + CrewManager.crewList [0].currRoom);
			//Use later to display crew member stats
			if (value == 0) {
				detail.text = "Engineering: " + CrewManager.crewList [0].engineerSkill + "\n" + "Plants: " + CrewManager.crewList [0].plantSkill + "\n" + "Mining: " + CrewManager.crewList [0].mineSkill + "\n";
				CPTemp = CrewManager.crewList [0];
			} else if (value == 1) {
				detail.text = "Engineering: " + CrewManager.crewList [1].engineerSkill + "\n" + "Plants: " + CrewManager.crewList [1].plantSkill + "\n" + "Mining: " + CrewManager.crewList [1].mineSkill + "\n";

			} else if (value == 2) {
				detail.text = "Engineering: " + CrewManager.crewList [2].engineerSkill + "\n" + "Plants: " + CrewManager.crewList [2].plantSkill + "\n" + "Mining: " + CrewManager.crewList [2].mineSkill + "\n";

			} else {
				detail.text = "Engineering: " +"\n" + "Plants: " +"\n" + "Mining: " +"\n";

			}
		}
	}

	public int _selectedRoom;
	public int SR{
		get{ return _selectedRoom; }
		set{ 
			_selectedRoom = value;
			if (_selectedCrew > -1 && selectionActive) {
				if (CrewManager.crewList [_selectedCrew].currRoom != value && !RoomManager.rooms [value].occupied) {
					RoomManager.rooms[CrewManager.crewList [_selectedCrew].currRoom].occupied = false;
					RoomManager.rooms [value].occupied = true;
					_selectedRoom = value;
					CrewManager.crewList [_selectedCrew].currRoom = value;
					_selectedCrew = -1; 
					//Debug.Log ("Current Room: " + CrewManager.crewList [0].currRoom);
				}
			} else {

			}
		}
	}



	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			CastRay ();
		}
	}

	void CastRay(){
		Ray mapClick = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(mapClick.origin,mapClick.direction, Mathf.Infinity);
		if(hit.collider != null){
			Debug.Log (" hit "+hit.collider.gameObject.name);
			if (hit.collider.gameObject.tag.Contains("Crew")) {
				if (hit.collider.gameObject.name.EndsWith("0")) {
					SC = 0;
					selectionActive = true;
				}
				else if (hit.collider.gameObject.name.EndsWith("1")) {
					SC = 1;
					selectionActive = true;
				}
				else if (hit.collider.gameObject.name.EndsWith("2")) {
					SC = 2;
					selectionActive = true;
				}
			}

			if (hit.collider.gameObject.tag.Contains("Map")) {
				if (hit.collider.gameObject.name.EndsWith("0")) {
					SR = 0;
					selectionActive = false;
				}
				else if (hit.collider.gameObject.name.EndsWith("1")) {
					SR = 1;
					selectionActive = false;
				}
				else if (hit.collider.gameObject.name.EndsWith("2")) {
					SR = 2;
					selectionActive = false;
				}
				else if (hit.collider.gameObject.name.EndsWith("3")) {
					SR = 3;
					selectionActive = false;
				}
				else if (hit.collider.gameObject.name.EndsWith("4")) {
					SR = 4;
					selectionActive = false;
				}
				else if (hit.collider.gameObject.name.EndsWith("5")) {
					SR = 5;
					selectionActive = false;
				}
				else if (hit.collider.gameObject.name.EndsWith("6")) {
					SR = 6;
					selectionActive = false;
				}
				else if (hit.collider.gameObject.name.EndsWith("7")) {
					SR = 7;
					selectionActive = false;
				}
			}
		}

		if (hit.collider == null) {
			SC= -1;
			selectionActive = false;
		}
	}
}
