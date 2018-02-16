using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {
	public GameObject SelectionScreen;


	public static int state;
	public static int State{
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
		state = 0;
	}
	
	void Update () {
	}

	void shipSelect(){

	}

	void cargoSelect(){

	}

	static void crewSelect(){

	}

	static void startGame(){

	}
}
