using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenAManager : MonoBehaviour {
	public TextMeshProUGUI opA, opB, opC;
	public TextMeshProUGUI[] screenText; 
	public string opAtext, opBtext,opCtext;
	/*
	 * Screen A will contain: 
	 * minimap with realtime crew location
	 * room stats (refine later)
	 * room names
	 */

	void Start () {
		screenText = new TextMeshProUGUI[]{opA, opB, opC};
	}
	
	void Update () {
		opA.text = ShipStatKeeper.temperature+ "";
	}

	public void TextDisplayUpdate(string inp, int pos){
		screenText [pos].text = inp;
	}
}
