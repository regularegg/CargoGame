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
		//Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero
		if(hit.collider != null){
			Debug.Log (" hit "+hit.collider.gameObject.name);
		}
	}
}
