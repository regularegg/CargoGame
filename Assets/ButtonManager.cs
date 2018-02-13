using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonManager : MonoBehaviour,IPointerUpHandler {

	public static float tempSlideOutput, humSlideOutput;
	public static bool toggle, button;
	public Button bt1, bt2, bt3, mpA,mpB,mpC,mpD,mpE;
	public Button[] buttonList, mapButtonList;
	public Slider slideA, slideB;
	public Toggle tog;

	public TextMeshProUGUI temperature, humidity;
	public GameObject light1, light2;

	public GameObject mapA, mapB, mapC, mapD, mapE;
	public GameObject[] mapButt;

	WaitForSeconds wait;

	private float currentHumidityTarget;

	//public delegate void onChangeTemp();
	//public static event onChangeTemp changetemp;

	void Start () {
		slideA.onValueChanged.AddListener (delegate {
			ValueChangeCheckTemp ();
		});
		slideA.wholeNumbers = true;
		slideA.maxValue = 100;
		slideA.value = 25;

		slideB.onValueChanged.AddListener (delegate {
			ValueChangeCheckHum ();
		});
		slideB.wholeNumbers = true;
		slideB.maxValue = 100;
		slideB.value = 25;
		//make the actual temperature and set AC/humidifier temperature separate - takes time for real temperature to catch up to ship temp

		tog.onValueChanged.AddListener (delegate {
			LightToggle ();
		});


		buttonList = new Button[]{ bt1, bt2, bt3 };

		for (int i = 0; i < buttonList.Length; i++) {
			Button temp = buttonList [i];
			temp.name = "" + i;
			buttonList [i].onClick.AddListener (() => {
				ButtonClicked (temp);
			});
		}
		mapButtonList = new Button[]{ mpA, mpB, mpC, mpD, mpE };

		for (int i = 0; i < mapButtonList.Length; i++) {
			Button temp = mapButtonList [i];
			temp.name = "" + i;
			mapButtonList [i].onClick.AddListener (() => {
				MapButtonClicked (temp);
			});
		}

		mapButt = new GameObject[]{ mapA, mapB, mapC, mapD, mapE };


		wait = new WaitForSeconds (0.25f);
	}
	void Update(){
		ShipStatKeeper.humidity = (float)System.Math.Round (Mathf.Lerp (ShipStatKeeper.humidity, currentHumidityTarget, Time.deltaTime * 0.01f), 2);
		//UPDATE
	}
	
	public void ButtonClicked(Button butt){
		//int temp = int.Parse (butt.name);
	}

	public void MapButtonClicked(Button butt){
		int temp = int.Parse (butt.name);
		mapButt [temp].GetComponent<SpriteRenderer> ().enabled = !mapButt [temp].GetComponent<SpriteRenderer> ().enabled;
	}

	public bool ButtonChecker(int button){
		

		return false;
	}
	//make something check if the right button is pressed, no need to return anything






	public void ValueChangeCheckTemp(){
		ShipStatKeeper.tempToAdd = slideA.value;
		temperature.text = slideA.value+"";
		Debug.Log (ShipStatKeeper.tempToAdd);
		TemperatureIncrease ();
	}

	public void ValueChangeCheckHum(){
		ShipStatKeeper.humToAdd = slideB.value;
		humidity.text = slideB.value+"";
		currentHumidityTarget = slideB.value;

		//Debug.Log (ShipStatKeeper.humToAdd); // i think ienum is going to be needed to fix this
		/*if ((slideB.value - ShipStatKeeper.humidity) > 0) {
			StartCoroutine (HumidityIncrease (slideB.value));
		} else {
			StartCoroutine (HumidityDecrease (slideB.value));
		}*/
	}/*
	IEnumerator HumidityIncrease(float value){
		if (slideB.value > ShipStatKeeper.humidity) {
			ShipStatKeeper.humidity += Mathf.Sqrt (slideB.value);
			Debug.Log ("increased");
			//yield return wait;
			yield return new WaitForSeconds(0.5f);
		}
		if (Mathf.Approximately(value, ShipStatKeeper.humidity)){
			Mathf.Floor (ShipStatKeeper.humidity);
			yield break;
		}
	}

	IEnumerator HumidityDecrease(float value){
		if (slideB.value < ShipStatKeeper.humidity) {
			ShipStatKeeper.humidity -= Mathf.Sqrt (slideB.value);
			Debug.Log ("decreased");
			yield return wait;

		}
		if (Mathf.Approximately(value, ShipStatKeeper.humidity)){
			Debug.Log ("good enough");
			Mathf.Ceil (ShipStatKeeper.humidity);
			yield break;
		}
	}
*/

	public int Button1Click(){
		return 0;
	}

	public int Button2Click(){
		return 1;
	}

	public int Button3Click(){
		return 2;
	}

	public void LightToggle(){
		ShipStatKeeper.light1 = !ShipStatKeeper.light1;
	}


	void TemperatureIncrease(){
		if (ShipStatKeeper.tempToAdd != 0) {
			ShipStatKeeper.temperature += ShipStatKeeper.tempToAdd/5;
			ShipStatKeeper.tempToAdd -= ShipStatKeeper.tempToAdd/5;

			Debug.Log ("added temp");
		}
	}

	public void OnPointerUp(PointerEventData pointerData){
		Debug.Log ("pointer up");
	}
}
/* Notes:
 * buttons should be added onto control board to represent interactive map (they should glow when hovered)
 * IDEA: events taht require user to press buttons???!?!
 * http://www.hopesandfears.com/hopes/culture/film/214001-the-ultimate-guide-to-control-panels-in-movies
 */