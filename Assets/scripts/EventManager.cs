using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class EventManager : MonoBehaviour {
	
	public bool[] introChecklist = new bool[textKeeper.introduction.Length];
	public string[] introText;
	public GameObject pic, alert1, alert2, alert3, throttle;
	public SpriteRenderer commLight;
	public Sprite fish,offLight, onLight;
	public TextMeshProUGUI speech, alert;

	public AudioSource FishTalking;

	GameObject holder;

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
				FindObjectOfType<ButtonManager> ().enabled = false;
				StartCoroutine (textDisplay (textKeeper.introduction));


			} else if (value == 1) {
				pic.GetComponent<SpriteRenderer> ().sprite = fish;
				pic.GetComponent<SpriteRenderer> ().enabled = true;
				speech.enabled = true;
				GetComponent<ShipMapInteraction> ().enabled = false;
				FindObjectOfType<ButtonManager> ().enabled = false;
				StartCoroutine (textDisplay (textKeeper.asteroid));
			}
		}
	}
	int _introCount;
	int introCount{
		get{ return _introCount; }
		set{
			_introCount = value;
			if (value == 2) {
				commLight.sprite = onLight;
				holder = GameObject.Find ("Communication Screen");
				holder.GetComponent<slidepanel> ().handle.transform.position = holder.GetComponent<slidepanel> ().openPos;
				holder.GetComponent<slidepanel> ().active = true;
			} else if (value == 3) {
				commLight.sprite = offLight;
			}else if (value == 7) {
				alert1.GetComponent<SpriteRenderer> ().enabled = true;
				holder = GameObject.Find ("Info Panel");
				holder.GetComponent<slidepanel> ().handle.transform.position = holder.GetComponent<slidepanel> ().openPos;
				holder.GetComponent<slidepanel> ().active = true;
			} else if (value == 8) {
				alert1.GetComponent<SpriteRenderer> ().enabled = false;
				holder = GameObject.Find ("Info Panel");
				holder.GetComponent<slidepanel> ().handle.transform.position = holder.GetComponent<slidepanel> ().startPos;
				holder.GetComponent<slidepanel> ().active = false;
			} else if (value == 9) {
				alert2.GetComponent<SpriteRenderer> ().enabled = true;
			} else if (value == 10) {
				alert2.GetComponent<SpriteRenderer> ().enabled = false;
			} else if (value == 18) {
				alert3.GetComponent<SpriteRenderer> ().enabled = true;
			} else if (value == 19) {
				alert3.GetComponent<SpriteRenderer> ().enabled = false;
			}else if (value == textKeeper.introduction.Length) {
				holder = GameObject.Find ("Communication Screen");
				holder.GetComponent<slidepanel> ().handle.transform.position = holder.GetComponent<slidepanel>().startPos;
 				holder.GetComponent<slidepanel> ().active = false;
				throttle.GetComponent<Animator> ().Play ("throttle slide up");
				ShipStatKeeper.matter += 10;
			}
		}
	}
	int _trigger;
	int trigger{
		get{ return _trigger; }
		set{
			_trigger = value;
			if (value == 100) {
				speech.text = "OH NO! A DOG THAT SOMEONE SMUGGLED ONBOARD HAS PEED ON THE AIRFILTERS! FILTER HEALTH CRITICAL!";
				commLight.sprite = onLight;
				ShipStatKeeper.airfilter = 10;
			}
			if (value == 150) {
				speech.text = CrewManager.crewList[1].name+" done messed up. The garden is all goofed!";
				commLight.sprite = onLight;
				ShipStatKeeper.garden = 10;
			}
		}
	}
	int _asteroidCount;
	int asteroidCount{
		get{ return _asteroidCount; }
		set{
			_asteroidCount = value;
			if (value == 1) {
				commLight.sprite = onLight;
				holder.GetComponent<slidepanel> ().handle.transform.position = holder.GetComponent<slidepanel> ().openPos;
				holder.GetComponent<slidepanel> ().active = true;

			} else if (value == 2) {
				commLight.sprite = offLight;
			} else if (value == textKeeper.asteroid.Length) {
				holder.GetComponent<slidepanel> ().handle.transform.position = holder.GetComponent<slidepanel> ().startPos;
				holder.GetComponent<slidepanel> ().active = false;
			}
		}
	}
	void Awake () {
		state = 0;
		wait = new WaitForSeconds (0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator accidents(){
		for (int i = 0; i < 200; i++) {
			trigger++;
			//Debug.Log ("Trigger " + trigger);
			yield return wait;
		}
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
					FindObjectOfType<ButtonManager> ().enabled = true;
					if (state == 0) {
						StartCoroutine (accidents ());
					}
				}
				yield return wait;
				FishTalking.Play ();
			} 
			else {
				yield return null;
			}
		}
	}
}
