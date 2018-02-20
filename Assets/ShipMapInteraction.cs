using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMapInteraction : MonoBehaviour {
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
				CPTemp = CrewManager.crewList [0];
			} else if (value == 1) {
				return;
			} else if (value == 2) {
				return;
			} else {
				return;
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
					RoomManager.rooms [value].occupied = true;
					_selectedRoom = value;
					CrewManager.crewList [_selectedCrew].currRoom = value;
					_selectedCrew = -1; 

					Debug.Log ("Current Room: " + CrewManager.crewList [0].currRoom);
				}
			} else
				Debug.Log ("nothing room happened");
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
			}
		}

		if (hit.collider == null) {
			SC= -1;
			selectionActive = false;
		}
	}
}
