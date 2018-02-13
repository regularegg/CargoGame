using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HumiditySliderControl : MonoBehaviour,IPointerUpHandler {

	public void OnPointerUp(PointerEventData eventData)
	{
		Debug.Log("Sliding finished");  
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
