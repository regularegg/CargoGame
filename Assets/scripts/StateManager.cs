using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {
	public GameObject 
		SelectionScreen,
		Map,
		MapLabels,
		ProgressBar;


	public int state;
	public int State{
		get{ return state; }
		set{ 
			if (value == state) {
				return;
			} else if ((value != state)&&(value == 0)) {
				state = value;
				crewSelect ();

			} else if ((value != state)&&(value == 1)) {
				state = value;
				startGame ();

			}else if ((value != state)&&(value == 2)) {
				state = value;
			}
		}
	}


	void Start () {
		state = 5;
	}
	
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			State = 1;
		}
		if (Input.GetKey (KeyCode.S)) {
			State = 0;
		}
	}


	void crewSelect(){
		GameObject currentScreen = Instantiate (SelectionScreen);

		if (state != 1)
			Destroy (currentScreen);
	}

	void startGame(){
		Destroy (GameObject.Find ("currentScreen"));
		Destroy (GameObject.Find ("Center Map(Clone)"));
		Destroy (GameObject.Find ("Ship Progression(Clone)"));
		Destroy (GameObject.Find ("Map Label Holder(Clone)"));

	}
}
