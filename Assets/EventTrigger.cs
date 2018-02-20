using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour {

	public GameObject screenA, screenB, screenC;
	public ScreenAManager SAM;
	public ScreenBMAnager SBM;
	public ScreenCManager SCM;

	public ButtonManager BM;

	public int[] inventory;

	// Use this for initialization
	void Start () {
		inventory = new int[5];

	}


	// Update is called once per frame
	void Update () {
		}

	//	BM.ButtonClicked():
	//}
	//askWhichoption(){
	//	"do you want A or B"
	//}

	// have multistage fixes for problems (ex. have person go to machine room, make thing, go to place b, do thing, fix)
}
