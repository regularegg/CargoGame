using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShipMapInteraction : MonoBehaviour {
	public TextMeshProUGUI detail, selection, SB1, SB2, SB3;
	public GameObject holder, bg1, bg2, bg3;
	public Button b1, b2, b3;
	public bool _selectionActive;
	bool selectionActive{
		get{return _selectionActive;}
		set{
			_selectionActive = value;
			if(value == false){
				bg1.GetComponent<SpriteRenderer>().enabled = false;
				bg2.GetComponent<SpriteRenderer>().enabled = false;
				bg3.GetComponent<SpriteRenderer>().enabled = false;
			}
		}
	}
	private int _selectedCrew;
	public SpriteRenderer r0, r1, r2, r3, r4, r5, r6, r7, r8;
	SpriteRenderer[] sprites;
	string[] options1, options2, options3;

	public int SC{
		get{ return _selectedCrew; }
		set{ 
			_selectedCrew = value;
			Debug.Log ("Initial Room: " + CrewManager.crewList [0].currRoom);
			//Use later to display crew member stats
			if (value == 0) {
				bg1.GetComponent<SpriteRenderer>().enabled = !bg1.GetComponent<SpriteRenderer>().enabled;
			} else if (value == 1) {
				bg2.GetComponent<SpriteRenderer>().enabled = !bg2.GetComponent<SpriteRenderer>().enabled;
			} else if (value == 2) {
				bg3.GetComponent<SpriteRenderer>().enabled = !bg3.GetComponent<SpriteRenderer>().enabled;
			}
		}
	}

	public int _selectedRoom;
	public int SR{
		get{ return _selectedRoom; }
		set{ 
			_selectedRoom = value;
			if (_selectedCrew > -1 && selectionActive) {
				if (CrewManager.crewList [_selectedCrew].currRoom != value && !RoomManager.rooms [value].occupied &&!CrewManager.crewList[_selectedCrew].active) {
					RoomManager.rooms[CrewManager.crewList [_selectedCrew].currRoom].occupied = false;
					sprites [CrewManager.crewList [_selectedCrew].currRoom].enabled = false;
					RoomManager.rooms [value].occupied = true;

					if(_selectedCrew == 0)
						sprites [value].color = new Color (0.5f,0,0);
					else if(_selectedCrew == 1)
						sprites [value].color = new Color (0, 1, 0);
					else
						sprites [value].color = new Color (0, 0, 1);
					
					sprites [value].enabled = true;
					_selectedRoom = value;
					CrewManager.crewList [_selectedCrew].currRoom = value;
					_selectedCrew = -1; 
					roomMenu ();

					//Debug.Log ("Current Room: " + CrewManager.crewList [0].currRoom);
				}
			}
		}
	}

	void Start(){
		sprites = new SpriteRenderer[]{ r0, r1, r2, r3, r4, r5, r6, r7, r8 };
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			CastRay ();
			if (selectionActive){
				
			}
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
				}
				else if (hit.collider.gameObject.name.EndsWith("1")) {
					SR = 1;
				}
				else if (hit.collider.gameObject.name.EndsWith("2")) {
					SR = 2;
				}
				else if (hit.collider.gameObject.name.EndsWith("3")) {
					SR = 3;
				}
				else if (hit.collider.gameObject.name.EndsWith("4")) {
					SR = 4;
				}
				else if (hit.collider.gameObject.name.EndsWith("5")) {
					SR = 5;
				}
				else if (hit.collider.gameObject.name.EndsWith("6")) {
					SR = 6;
				}
				else if (hit.collider.gameObject.name.EndsWith("7")) {
					SR = 7;
				}
				else if (hit.collider.gameObject.name.EndsWith("8")) {
					SR = 8;
				}
				selectionActive = false;
			}
		}

		if (hit.collider == null) {
			SC= -1;
			selectionActive = false;
		}
	}

	void roomMenu(){
		Debug.Log ("ROOM MENU" + b1.onClick.GetPersistentEventCount() );
		holder.SetActive (true);
		b1.enabled = true;
		b2.enabled = true;
		b3.enabled = true;
		b1.onClick.AddListener (delegate {
			optA (SR);
			Debug.Log("optA");
		});
		b2.onClick.AddListener (delegate {
			optB (SR);
		});
		b3.onClick.AddListener (delegate {
			optC (SR);
		});
		if (SR == 0) {

		}
		else if (SR == 1) {
			selection.enabled = true;
			SB1.enabled = true;
			SB1.text = "Check Cargo";
		}
		else if (SR == 2) {
			selection.enabled = true;
			SB1.enabled = true;
			SB1.text = "make toolbox";
			SB2.enabled = true;
			SB2.text = "make fertilizer";
			SB3.enabled = true;
			SB3.text = "make airfilters";
		}
		else if (SR == 3) {
			selection.enabled = true;
			SB1.enabled = true;
			SB1.text = "Upgrade Engines";
			SB2.enabled = true;
			SB2.text = "fix engines";
		}
		else if (SR == 4) {
			selection.enabled = true;
			SB1.enabled = true;
			SB1.text = "make drill";
			SB2.enabled = true;
			SB2.text = "make containment unit";
			SB3.enabled = true;
			SB3.text = "make transporters";
		}
		else if (SR == 5) {
			selection.enabled = true;
			SB1.enabled = true;
			SB1.text = "Harvest Food";
			SB2.enabled = true;
			SB2.text = "Tend Plants";
		}
		else if (SR == 6) {
			selection.enabled = true;
			SB1.enabled = true;
			SB1.text = "Exit Airlock";
		}
		else if (SR == 7) {
			selection.enabled = true;
			SB1.enabled = true;
			SB1.text = "Replace Filters";
		}
		else if (SR == 8) {
			selection.enabled = true;
			SB1.enabled = true;
			SB1.text = "Enter Cryosleep";
		}
	}

	void optA(int room){
		Debug.Log ("Option 1");
		holder.SetActive(false);
		if (SR == 2) {
			Debug.Log ("Option start fabprep");

			GetComponent<Inventory> ().fabPrep (SR, 0, 0);
		} else if (SR == 4) {
			GetComponent<Inventory> ().fabPrep (SR, 1, 0);

		} else if (SR == 5) {
			GetComponent<HydroponicsB> ().harvest();

		}

		SB1.text = "";
		SB2.text = "";
		SB3.text = "";
		b1.onClick.RemoveAllListeners();
	}
	void optB(int room){
		Debug.Log ("Option 2 " + SR);
		holder.SetActive (false);
		holder.SetActive(false);
		if (SR == 2) {
			GetComponent<Inventory> ().fabPrep (SR, 0, 1);
		} else if (SR == 4) {
			GetComponent<Inventory> ().fabPrep (SR, 1, 1);
		}else if (SR == 5) {
			//GetComponent<HydroponicsB> ().fabPrep (SR, 0, 1);

		}
		SB1.text = "";
		SB2.text = "";
		SB3.text = "";
		b2.onClick.RemoveAllListeners();

	}
	void optC(int room){
		Debug.Log ("Option 3");
		holder.SetActive (false);
		holder.SetActive(false);
		if (SR == 2) {
			GetComponent<Inventory> ().fabPrep (SR, 0, 2);
		} else if (SR == 4) {
			GetComponent<Inventory> ().fabPrep (SR, 1, 2);
		}else if (SR == 5) {

		}
		SB1.text = "";
		SB2.text = "";
		SB3.text = "";
		b3.onClick.RemoveAllListeners();

	}
}
