using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseManager : MonoBehaviour {
	public GameObject activityBox,crewBox,activityText, crewText;
	Vector3 transHolder;
	//public TextMeshProUGUI activityText, crewText;
	bool isHit;
	public int SC{
		get{ return SC; }
		set{ 
			//SC = value;
			//Use later to display crew member stats
			if (value == 0 || value == 1 || value == 2) {
				crewText.GetComponent<TextMeshProUGUI> ().text = "Engineering: " + CrewManager.crewList [value].engineerSkill + "\n" + "craft skill: " + CrewManager.crewList [value].fabSkill + "\n" + "Mining: " + CrewManager.crewList [value].mineSkill + "\n";

			} else if (value == 3 || value == 4 || value == 5) {
				int a = GetComponent<ShipMapInteraction> ().SR;

			}

			else {
				crewText.GetComponent<TextMeshProUGUI>().text = "Engineering: " +"\n" + "Plants: " +"\n" + "Mining: " +"\n";
			}
		}
	}

	void Start () {
		transHolder = new Vector3(1.25f,-.75f,-10);
	}
	
	void Update () {
		castRay ();
	}

	void castRay(){
		Ray mapClick = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(mapClick.origin,mapClick.direction, Mathf.Infinity);
		if (hit.collider != null) {
			if (hit.collider.gameObject.tag.Contains ("Crew")) {
				crewBox.GetComponent<SpriteRenderer> ().enabled = true;
				crewText.GetComponent<TextMeshProUGUI>().enabled = true;
				crewText.GetComponent<Transform> ().position = Camera.main.ScreenToWorldPoint (Input.mousePosition) + transHolder;

				if (hit.collider.gameObject.name.EndsWith ("0")) {
					SC = 0;
				} else if (hit.collider.gameObject.name.EndsWith ("1")) {
					SC = 1;
				} else if (hit.collider.gameObject.name.EndsWith ("2")) {
					SC = 2;
				}
			}
			if (hit.collider.gameObject.tag.Contains ("Selection")) {
			//	activityBox.GetComponent<SpriteRenderer> ().enabled = true;
			//	activityText.GetComponent<TextMeshProUGUI>().enabled = true;
			//	activityText.GetComponent<Transform> ().position = Camera.main.ScreenToWorldPoint (Input.mousePosition) + transHolder;

				if (hit.collider.gameObject.name.EndsWith ("0")) {
					SC = 3;
				} else if (hit.collider.gameObject.name.EndsWith ("1")) {
					SC = 4;
				} else if (hit.collider.gameObject.name.EndsWith ("2")) {
					SC = 5;
				}
			}
		} else {
			crewBox.GetComponent<SpriteRenderer> ().enabled = false;
			crewText.GetComponent<TextMeshProUGUI>().enabled = false;
//			activityBox.GetComponent<SpriteRenderer> ().enabled = false;
		//	activityText.GetComponent<TextMeshProUGUI>().enabled = false;
		}
	}
}

