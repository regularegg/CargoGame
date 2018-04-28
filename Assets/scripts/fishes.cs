using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishes : MonoBehaviour {
	SpriteRenderer SR;
	BoxCollider2D BC;
	public bool active, facingRight;
	int movepause = 0;

	void Start () {
		SR = GetComponent<SpriteRenderer> ();
		BC = GetComponent<BoxCollider2D> ();
	}
	void OnTriggerEnter2D(Collider2D coll){
		//if (coll.gameObject.tag == "hook"){
		Debug.Log ("HIT");
		active = false;
		movepause = 0;
		transform.position = MiniGame.restPos;
		MiniGame.fishCaught++;
		MiniGame.caughtColl = true;	
		//	}
	}
	void Update () {
		if (active && movepause == 0) {
			BC.enabled = true;
			if (facingRight) {
				SR.flipX = false;
				transform.position += Vector3.right * 0.1f;
				movepause ++;
			} else {
				SR.flipX = true;
				transform.position -= Vector3.right * 0.1f;
				movepause++;
			}

			if ((transform.position.x > 0.95f) || (transform.position.x < -0.95f)) {
				transform.position = MiniGame.restPos;
				active = false;
				BC.enabled = false;
			}
		} else if (movepause > 20)
			movepause = 0;
		else
			movepause++;
	}

	IEnumerator moveWait(){
		yield return new WaitForSecondsRealtime (1f);
	}


}
