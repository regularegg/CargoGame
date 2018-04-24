﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ShipMapInteraction : MonoBehaviour {
	public AudioSource HeyYa;
	public AudioSource HeyYa1;
	public AudioSource HeyYa2;

	public TextMeshProUGUI selection, SB1, SB2, SB3;
	public GameObject holder, bg1, bg2, bg3, crewCommVisual;
	public Button b1, b2, b3;
	int SCHold;
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
	public SpriteRenderer r0, r1, r2, r3, r4, r5, r6, r7;
	public Animator a0, a1, a2, a3, a4, a5, a6, a7; //temp
	SpriteRenderer[] sprites;
	Animator[] animators;

	Animation turn, working, walking;

	string[] options1, options2, options3;

	public int SC{
		get{ return _selectedCrew; }
		set{ 
			_selectedCrew = value;
			if (value > -1) {
				if (CrewManager.crewList [value].alive) {

					//Use later to display crew member stats
					if (value == 0) {

						selection.enabled = true;
						selection.text = "Where do you want me to go boss";

						bg1.GetComponent<SpriteRenderer> ().enabled = !bg1.GetComponent<SpriteRenderer> ().enabled;
						crewCommVisual.GetComponent<SpriteRenderer> ().enabled = true;
						crewCommVisual.GetComponent<SpriteRenderer> ().sprite = CrewManager.crewList [0].sprite;
						crewCommVisual.GetComponent<SpriteRenderer> ().color = Color.red;
					} else if (value == 1) {

						selection.enabled = true;
						selection.text = "Where do you want me to go boss";

						bg2.GetComponent<SpriteRenderer> ().enabled = !bg2.GetComponent<SpriteRenderer> ().enabled;
						crewCommVisual.GetComponent<SpriteRenderer> ().enabled = true;
						crewCommVisual.GetComponent<SpriteRenderer> ().sprite = CrewManager.crewList [1].sprite;
						crewCommVisual.GetComponent<SpriteRenderer> ().color = Color.green;

					} else if (value == 2) {

						selection.enabled = true;
						selection.text = "Where do you want me to go boss";

						bg3.GetComponent<SpriteRenderer> ().enabled = !bg3.GetComponent<SpriteRenderer> ().enabled;
						crewCommVisual.GetComponent<SpriteRenderer> ().enabled = true;
						crewCommVisual.GetComponent<SpriteRenderer> ().sprite = CrewManager.crewList [2].sprite;
						crewCommVisual.GetComponent<SpriteRenderer> ().color = Color.blue;

					}
					Debug.Log ("TEST " + CrewManager.crewList[value].currRoom);

				} else {
					selection.text = "Crew dead";
					SC = -1;
					selectionActive = false;
				}
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
					//RoomManager.rooms[CrewManager.crewList [_selectedCrew].currRoom].occupied = false;
					for (int i = 0; i < 3; i++) {
						if (!RoomManager.roomGuys[value,i]){
							Debug.Log (RoomManager.roomGuys [value, i]);

							RoomManager.roomGuys[value,i] = true;
							GetComponent<RoomManager> ().guys [value * i + i].SetActive(true);

							if(CrewManager.crewList[SC].currAnim != -1){
								GetComponent<RoomManager> ().guys [CrewManager.crewList [SC].currAnim].SetActive(true);
							//	GetComponent<RoomManager> ().guys [CrewManager.crewList [SC].currAnim].GetComponent<Animator> ().enabled = false;
							}
							CrewManager.crewList [SC].currAnim = value * i + i;
						}
					}
					sprites [CrewManager.crewList [_selectedCrew].currRoom].enabled = false;
					//RoomManager.rooms [value].occupied = true;

					if(_selectedCrew == 0)
						sprites [value].color = new Color (1,0,0);
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
		sprites = new SpriteRenderer[]{ r0, r1, r2, r3, r4, r5, r6, r7 };
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
					SCHold = SC;
					selectionActive = true;
					b1.onClick.RemoveAllListeners();
					b2.onClick.RemoveAllListeners();
					b3.onClick.RemoveAllListeners();
					HeyYa.Play ();
				}
				else if (hit.collider.gameObject.name.EndsWith("1")) {
					SC = 1;
					SCHold = SC;
					selectionActive = true;
					b1.onClick.RemoveAllListeners();
					b2.onClick.RemoveAllListeners();
					b3.onClick.RemoveAllListeners();
					HeyYa1.Play ();
				}
				else if (hit.collider.gameObject.name.EndsWith("2")) {
					SC = 2;
					SCHold = SC;
					selectionActive = true;
					b1.onClick.RemoveAllListeners();
					b2.onClick.RemoveAllListeners();
					b3.onClick.RemoveAllListeners();
					HeyYa2.Play ();
				}
			}

			if (hit.collider.gameObject.tag.Contains("Map")) {
				

				if (hit.collider.gameObject.name.EndsWith ("0")) {
					SR = 0;
				} else if (hit.collider.gameObject.name.EndsWith ("1")) {
					SR = 1;
				} else if (hit.collider.gameObject.name.EndsWith ("2")) {
					SR = 2;
				} else if (hit.collider.gameObject.name.EndsWith ("3")) {
					SR = 3;
				} else if (hit.collider.gameObject.name.EndsWith ("4")) {
					SR = 4;
				} else if (hit.collider.gameObject.name.EndsWith ("5")) {
					SR = 5;
				} else if (hit.collider.gameObject.name.EndsWith ("6")) {
					SR = 6;
				} else if (hit.collider.gameObject.name.EndsWith ("7")) {
					SR = 7;
				} else if (hit.collider.gameObject.name.EndsWith ("8")) {
					SR = 8;
				} else
					SR = -1;
				selectionActive = false;
			}
		}

		if (hit.collider == null) {
			SC= -1;
			selectionActive = false;
			selection.text = "";
			SB1.text = "";
			SB2.text = "";
			SB3.text = "";
			crewCommVisual.GetComponent<SpriteRenderer> ().enabled = false;
		}
	}

	void roomMenu(){
		Debug.Log ("ROOM MEN LISTENR COUNT: " + b1.onClick.GetPersistentEventCount() );
		holder.SetActive (true);
		b1.enabled = true;
		b2.enabled = true;
		b3.enabled = true;
		selection.text = "What do you want me to do?";

		b1.onClick.AddListener (delegate {
			Debug.Log("listener added");
			optA (SR);
		});
		b2.onClick.AddListener (delegate {
			optB (SR);
		});
		b3.onClick.AddListener (delegate {
			optC (SR);
		});
		if (SR == 0) { // Fabrication room
			selection.enabled = true;
			SB1.enabled = true;
			SB1.text = "Make Mining Kit (-2 material, -2 energy)";
			SB2.enabled = true;
			SB2.text = "Make Repair Kit (-2 material, -1 energy)";
			SB3.enabled = true;
			SB3.text = "Make Self Care kit(-1 material, -1 energy)";
		}
		else if (SR == 1) { // Dormitries 
			selection.enabled = true;
			SB1.enabled = true;
			SB1.text = "Rest (+3 Energy, -1 Self Care Kit)";
		}
		else if (SR == 2) { // Medical Bay
			selection.enabled = true;
			SB1.enabled = true;
			SB1.text = "Heal (+3 Health, +1 Energy, -1 Self Care Kit)";
		}
		else if (SR == 3) { // Garden
			selection.enabled = true;
			SB1.enabled = true;
			SB1.text = "Tend Garden (+1 happiness, -1 repair kit)";
			SB2.enabled = true;
			SB2.text = "Relax (+2 Energy, +2 happiness)";
		}
		else if (SR == 4) { // Machine Room
			selection.enabled = true;
			SB1.enabled = true;
			SB1.text = "Repair Damages (-1 toolbox, -2 energy)";
			SB2.enabled = true;
			SB2.text = "Maintain Ship (-1 toolbox)";
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
			SB1.text = "Upgrade Air Filtration Pumps";
			SB2.enabled = true;
			SB2.text = "Replace Filters";
		}
		else if (SR == 8) {
			selection.enabled = true;
			SB1.enabled = true;
			SB1.text = "Enter Cryosleep";
		}
	}
	//keeps duplicating actions?!?!?
	void optA(int room){
		Debug.Log ("Option 1");
		/*
		if (SR == 2) {
			Debug.Log ("Option start fabprep");
			GetComponent<Inventory> ().fabPrep (SR, 0, 0);
		} else if (SR == 1) {
			GetComponent<researchBehavior> ().upgradeCheck (2, SCHold);
		}else if (SR == 4) {
			GetComponent<Inventory> ().fabPrep (SR, 1, 0);
		} else if (SR == 3) {
			GetComponent<EngineeringB> ().upgrade (Inventory.upgradeInv [0], CrewManager.crewList [SCHold]);//upgrade engines
		}else if (SR == 7) {
			StartCoroutine(GetComponent<airFilterBehavior>().filterUpgrade(CrewManager.crewList[SCHold]));//upgrade filters
		}else if (SR == 5) {
			GetComponent<HydroponicsB> ().harvest ();
		}*/
		if (SR == 0) {
			GetComponent<Inventory> ().makeItemCheck (0, 0, 0, SC);
		} else if (SR == 1) {
		//	CrewManager.crewList [SC].energy = 5;
		}else if (SR == 2) {
			if (Inventory.Inv [2] >= 1) {
				CrewManager.crewList [SC].health += 3;
				if (CrewManager.crewList [SC].energy < 5) {
					CrewManager.crewList [SC].energy += 1;
				}
			}
		}else if (SR == 3) {

		}else if (SR == 4) {

		}
		else if (SR == -1) {
			b1.onClick.RemoveAllListeners();
		}
		selection.text = "";
	
		SCHold = -1;

		crewCommVisual.GetComponent<SpriteRenderer> ().enabled = false;
		b1.onClick.RemoveAllListeners();
	}
	void optB(int room){
		Debug.Log ("Option 2 " + SR);
		/*
		if (SR == 2) {
			GetComponent<Inventory> ().fabPrep (SR, 0, 1);
		} else if (SR == 1) {
			GetComponent<researchBehavior> ().upgradeCheck (1, SC);

		} else if (SR == 4) {
			GetComponent<Inventory> ().fabPrep (SR, 1, 1);

		} else if (SR == 3) {
			GetComponent<EngineeringB> ().fix (Inventory.upgradeInv [0], CrewManager.crewList [SCHold]);

		} else if (SR == 7) {
			GetComponent<airFilterBehavior> ().fix (Inventory.upgradeInv [2], CrewManager.crewList [SCHold]);

		} else if (SR == 8) {
			GetComponent<HydroponicsB> ().tend ();

		} else if (SR == -1) {
			b2.onClick.RemoveAllListeners();
		}*/
		if (SR == 0) {
			GetComponent<Inventory> ().makeItemCheck (0, 1, 1, SC);
		} else if (SR == 1) {
			//crew rest, no option 2
		}else if (SR == 2) {
			//crew garden
		}else if (SR == 3) {

		}else if (SR == 4) {

		}
		else if (SR == -1) {
			b1.onClick.RemoveAllListeners();
		}
		selection.text = "";
		SB1.text = "";
		SB2.text = "";
		SB3.text = "";
		SCHold = -1;
		crewCommVisual.GetComponent<SpriteRenderer> ().enabled = false;
		b2.onClick.RemoveAllListeners();

	}
	void optC(int room){
		Debug.Log ("Option 3");
		/*if (SR == 2) {
			GetComponent<Inventory> ().fabPrep (SR, 0, 2);

		}else if (SR == 1) {
			GetComponent<researchBehavior> ().upgradeCheck (3, SCHold);

		} else if (SR == 4) {
			GetComponent<Inventory> ().fabPrep (SR, 1, 2);

		}else if (SR == 5) {
			
		}else if (SR == -1) {
			b3.onClick.RemoveAllListeners();
		}*/
		if (SR == 0) {
			GetComponent<Inventory> ().makeItemCheck (0, 2, 2, SR);
		} else if (SR == 1) {

		}else if (SR == 2) {

		}else if (SR == 3) {

		}else if (SR == 4) {

		}
		else if (SR == -1) {
			b1.onClick.RemoveAllListeners();
		}
		selection.text = "";
		SB1.text = "";
		SB2.text = "";
		SB3.text = "";	
		SCHold = -1;

		crewCommVisual.GetComponent<SpriteRenderer> ().enabled = false;

	}
}


//note: make sure listeners are removed if players dont select option