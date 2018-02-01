using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

	public static int slider = 0;
	public static bool toggle, button;
	public Button bt;
	public Slider slide;
	public Toggle tog;

	void Start () {
		slide.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
		slide.wholeNumbers = true;
		slide.maxValue = 10;
	}
	
	void Update () {
		
	}

	public void ValueChangeCheck(){
		Debug.Log (slide.value);
	}
}
