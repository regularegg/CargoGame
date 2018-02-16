using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMapInteraction : MonoBehaviour {


	void Start () {
		
	}
	
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			CastRay ();
		}
	}

	void CastRay(){
		Ray mapClick = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(mapClick.origin,mapClick.direction, Mathf.Infinity);
		if(hit.collider != null){
			Debug.Log (" hit "+hit.collider.gameObject.name);
			if (hit.collider.gameObject.tag.Contains("Crew")) {
				Debug.Log (" hit Crew");
			}
		}

	}
}
