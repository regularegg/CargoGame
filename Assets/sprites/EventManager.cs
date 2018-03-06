using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventManager : MonoBehaviour {
	
	public bool[] introChecklist = new bool[textKeeper.introduction.Length];
	public string[] introText;
	public GameObject pic, alert1, alert2;
	public Sprite fish;
	public TextMeshProUGUI speech, alert;
	WaitForSeconds wait;
	int _state;
	public int state{
		get{ return _state; }
		set{ _state = value;
			if (value == 0) {
				pic.GetComponent<SpriteRenderer> ().sprite = fish;
				pic.GetComponent<SpriteRenderer> ().enabled = true;
				speech.enabled = true;
				GetComponent<ShipMapInteraction> ().enabled = false;
				StartCoroutine (textDisplay (textKeeper.introduction));

			} else if (value == 1) {
				pic.GetComponent<SpriteRenderer> ().sprite = fish;
				pic.GetComponent<SpriteRenderer> ().enabled = true;
				speech.enabled = true;
				GetComponent<ShipMapInteraction> ().enabled = false;
				StartCoroutine (textDisplay (textKeeper.asteroid));
			}
		}
	}
	int _introCount;
	int introCount{
		get{ return _introCount; }
		set{
			_introCount = value;
			if (value == 7){
				alert1.GetComponent<SpriteRenderer> ().enabled = true;
			}
			else if (value == 8){
				alert1.GetComponent<SpriteRenderer> ().enabled = false;
			}
			else if (value == 10) {
				alert2.GetComponent<SpriteRenderer> ().enabled = true;
			}
			else if (value == 11) {
				alert2.GetComponent<SpriteRenderer> ().enabled = false;
			}
		}
	}
	int _trigger;
	int trigger{
		get{ return _trigger; }
		set{
			_trigger = value;
			if (value == 5000) {
				alert.text = "OH NO! A DOG THAT SOMEONE SMUGGLED ONBOARD HAS PEED ON THE AIRFILTERS! FILTER HEALTH CRITICAL!";
				ShipStatKeeper.airfilter = 10;
			}
			if (value == 10000) {
				alert.text = CrewManager.crewList[1].name+" ";
				ShipStatKeeper.airfilter = 10;
			}
		}
	}
	int asteroidCount;
	void Start () {
		state = 0;
		wait = new WaitForSeconds (0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator textDisplay(string[] textInput){
		Debug.Log ("intro started");
		int length = textInput.Length;
		bool mouseClicked = false;
		int count = 0;
		while (count < length){
			if (count == 0) {
				speech.text = textInput [count];
				count++;
				if (state == 0)
					introCount++;
				else if (state == 1)
					asteroidCount++;
				yield return wait;
			}
			if (Input.GetKeyUp (KeyCode.Mouse0)) {
				mouseClicked = true;
			}
			if (mouseClicked) {
				speech.text = textInput [count];
				mouseClicked = false;
				count++;
				if (state == 0)
					introCount++;
				else if (state == 1)
					asteroidCount++;

				if (count == length) {
					GetComponent<ShipMapInteraction> ().enabled = true;
					pic.GetComponent<SpriteRenderer> ().enabled = false;
					speech.enabled = false;
				}
				yield return wait;
			} 
			else {
				yield return null;
			}
		}
	}
}
