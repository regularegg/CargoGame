using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour {

	public GameObject screenA, screenB, screenC;
	public ScreenAManager SAM;
	public ScreenBMAnager SBM;
	public ScreenCManager SCM;

	public ButtonManager BM;

	// Use this for initialization
	void Start () {
		
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			SAM.TextDisplayUpdate ("hello", 1);
		}

		BM.ButtonClicked():
	}
	askWhichoption(){
		"do you want A or B"
	}


}
