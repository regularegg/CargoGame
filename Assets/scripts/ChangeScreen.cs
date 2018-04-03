using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeScreen : MonoBehaviour {
	public int length;
	public GameObject[] Screens;
	public GameObject[] PrefabHolder = new GameObject[10];

	int currentScreen = 0;

	public Button left, right;
	void Start () {
		Screens = new GameObject[length];
		for (int i = 0; i < length; i++) {
			Screens [i] = PrefabHolder [i];
		}
		left.onClick.AddListener (() => {
			goLeft();
		});

	}


	void goLeft(){
		if (currentScreen != 0) {
		/*	GameObject.Find*/
		}
	}

	void goRight(){

	}
}
