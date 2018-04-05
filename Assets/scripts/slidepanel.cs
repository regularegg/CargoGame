using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidepanel : MonoBehaviour {
	public bool active, hovering; 
	public float hoverX, hoverY, openX, openY;
	public Vector3 startPos, hoverPos, openPos;
	public GameObject handle;
	public string currentPanel;

	void Start () {
		startPos = handle.transform.position;
		hoverPos = startPos + new Vector3 (hoverX, hoverY,0);
		openPos = startPos + new Vector3 (openX, openY,0);

	}
	void CastRay(){
		Ray mapClick = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(mapClick.origin,mapClick.direction, Mathf.Infinity);
		if (hit.collider != null) {
			if (hit.collider.gameObject.tag.Contains ("Panel Handle") && !active && hit.collider.gameObject.name.Contains(currentPanel)) {
				
				if (Input.GetMouseButtonUp (0)) {
					handle.transform.position = openPos;
					active = true;
					if (hit.collider.gameObject.name.Contains("side title")){
						GameObject.Find("Manual Book").transform.position = Vector3.zero;
					}
				} else
					handle.transform.position = hoverPos;
			} else if (hit.collider.gameObject.tag.Contains ("Panel Handle") && active && Input.GetMouseButtonUp (0)&& hit.collider.gameObject.name.Contains(currentPanel)) {
				handle.transform.position = startPos;
				active = false;
				if (hit.collider.gameObject.name.Contains ("side title")) {
					GameObject.Find ("Manual Book").transform.position = new Vector3 (100, 100, 0);
				}
			}
		} else if(hit.collider==null && !active) {
			handle.transform.position = startPos;
		}
	}
	void Update () {
		CastRay ();
	}
}
