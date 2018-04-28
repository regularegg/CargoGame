using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/// <summary>
/// Drilling minigame - adapted from my own script
/// </summary>
public class MiniGame : MonoBehaviour {
	public GameObject lane1, lane2, lane3, lane4, player, line, hook, gameScreen;
	public GameObject[] rows;
	GameObject temp;
	Vector3[] leftLanes, rightLanes, playerLoc;
	public static Vector3 restPos;
	int currPos=1, fishSpawned = 0;
	float[] linePositions, lineScale;
	public static int fishCaught = 0;
	bool fishing, prizeWon, justspawn;
	public TextMeshProUGUI TM;
	public static bool caughtColl;

	void Start () {

		gameScreen.transform.position = Vector3.zero;
		player.transform.position = new Vector3 (0.008f, 1.1388f, -3);
		TM.enabled = true;

		linePositions = new float[]{ 0.838f, 0.6388f, 0.555f, 0.263f };
		lineScale = new float[]{1, 4, 6, 9.18f };


		rows = new GameObject[]{ lane1, lane2, lane3, lane4 };
		leftLanes = new Vector3[4]{new Vector3(-0.95f,0.66f,-3),new Vector3(-0.95f,0.28f,-3),new Vector3(-0.95f,-0.01f,-3),new Vector3(-0.95f,-0.48f,-3)};
		rightLanes = new Vector3[4]{new Vector3(0.95f,0.66f,-3),new Vector3(0.95f,0.28f,-3),new Vector3(0.95f,-0.1f,-3),new Vector3(0.95f,-0.48f,-3)};
		playerLoc = new Vector3[3]{ new Vector3 (-0.75f, 1.14f,-3), new Vector3 (0, 1.14f,-3), new Vector3 (0.74f, 1.14f,-3f) };
		restPos = new Vector2 (500, 500);

		player.transform.position = playerLoc[currPos];
		lane1.transform.position = restPos;
		lane2.transform.position = restPos;
		lane3.transform.position = restPos;
		lane4.transform.position = restPos;
		line.transform.position = restPos;
		hook.transform.position = restPos;
	}

	void Update () {
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			if ((currPos == 1||currPos == 2)&&!fishing) {
				currPos--;
				player.transform.position = playerLoc [currPos];
			} 
		}
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			if ((currPos == 1||currPos==0)&&!fishing) {
				currPos++;
				player.transform.position = playerLoc [currPos];
			} 
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			StartCoroutine (boatWait());
			lineCast ();
		}
		if (fishSpawned == 10) {

			ShipStatKeeper.cargo += fishCaught;

			endGame ();
		}

		fishSpawner ();


		TM.text = "Score: " + fishCaught;
	}

	void fishSpawner(){
		if (!justspawn) {
			int a = Random.Range (0, 4);
			if (rows [a].GetComponent<fishes> ().active == false) {
				if (Random.Range (0, 2) == 0) {
					rows [a].transform.position = leftLanes [a];
					rows [a].GetComponent<fishes> ().facingRight = true;
				} else if (Random.Range(0,2) == 1) {
					rows [a].transform.position = rightLanes [a];
					rows [a].GetComponent<fishes> ().facingRight = false;
				}
				rows [a].GetComponent<fishes> ().active = true;
			}
			justspawn = true;
			StartCoroutine (spawnWait ());
			fishSpawned++;
		}
	}

	void lineCast(){
		if (!fishing) {
			fishing = true;
			line.GetComponent<SpriteRenderer> ().enabled = true;
			hook.GetComponent<SpriteRenderer> ().enabled = true;
			hook.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (lineWait ());
		}
	}


	IEnumerator lineWait(){


		for (int i = 0; i < 5; i++) {
			if (i == 4 || caughtColl) {
				line.GetComponent<SpriteRenderer> ().enabled = false;
				hook.GetComponent<SpriteRenderer> ().enabled = false;
				hook.GetComponent<BoxCollider2D> ().enabled = false;
				fishing = false;
				caughtColl = false;
			}
			else{
				line.transform.SetParent (line.transform);
				hook.transform.SetParent (hook.transform);
				line.transform.position = new Vector3 (playerLoc[currPos].x, linePositions[i],-3);
				line.transform.localScale = new Vector3 (0.75f, lineScale [i], 0);
				hook.transform.position = new Vector3 (playerLoc[currPos].x, leftLanes[i].y,-3);

			}

			yield return new WaitForSecondsRealtime (0.75f);
		}

	}

	IEnumerator spawnWait(){
		yield return new WaitForSecondsRealtime (3);
		justspawn = false;
	}
	IEnumerator boatWait(){
		yield return new WaitForSecondsRealtime (3);
		fishing = false;
	}

	void endGame(){
		for (int i = 0; i < 4; i++) {
			rows [i].GetComponent<SpriteRenderer> ().enabled = false;
		}

		line.GetComponent<SpriteRenderer> ().enabled = false;
		hook.GetComponent<SpriteRenderer> ().enabled = false;
		player.GetComponent<SpriteRenderer> ().enabled = false;
		TM.enabled = false;
		fishCaught = 0;
		ShipStatKeeper.shipMoving = true;

		Destroy(this.gameObject);
	}



}
