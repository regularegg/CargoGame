using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonManager : MonoBehaviour,IPointerUpHandler {

	public GameObject cam;
	public static float tempSlideOutput, humSlideOutput;
	public static bool oggle, button;
	public Button humButt, acButt, dockButt, gravButt, airlockButt, returnButt;
	public Button[] buttonList, mapButtonList;
	public Slider slideA, slideB;
	public Toggle tog;

	public TextMeshProUGUI temperature, humidity;
	public GameObject humL, acL, botL, gravL;
	public Sprite offL, greenL, redL;

	ShipStatKeeper SSK;

	WaitForSeconds wait;


	private float currentHumidityTarget, currentTemperatureTarget;

	void Start () {
		SSK = FindObjectOfType<ShipStatKeeper> ();
			
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
			GoToggle ();
		});


		buttonList = new Button[]{ humButt, acButt, dockButt, gravButt, airlockButt, returnButt};

		for (int i = 0; i < buttonList.Length; i++) {
			Button temp = buttonList [i];
			temp.name = "" + i;
			buttonList [i].onClick.AddListener (() => {
				ButtonClicked (temp);
			});
		}
		wait = new WaitForSeconds (0.25f);
	}
	void Update(){
		SSK.Humidity = Mathf.Lerp (ShipStatKeeper.humidity, currentHumidityTarget, Time.deltaTime * 0.01f);
		SSK.Temperature = Mathf.Lerp (ShipStatKeeper.temperature, currentTemperatureTarget, Time.deltaTime * 0.01f);
	}
	
	public void ButtonClicked(Button butt){
		int temp = int.Parse (butt.name);
		switch (temp) {
		case 0:
			Button0Click ();
			break;
		case 1:
			Button1Click ();
			break;
		case 2:
			Button2Click ();
			break;
		case 3:
			Button3Click ();
			break;
		case 4:
			Button4Click ();
			break;
		case 5:
			Button5Click ();
			break;
		
		}
	}

		

	public void ValueChangeCheckTemp(){
	//	temperature.text = slideB.value+"";
		currentTemperatureTarget = slideA.value;
	}

	public void ValueChangeCheckHum(){
	//	humidity.text = slideB.value+"";
		currentHumidityTarget = slideB.value;

	}

	public void  Button0Click(){ //humidity button
		if (ShipStatKeeper.engine != 0) {
			ShipStatKeeper.humidOn = !ShipStatKeeper.humidOn;

			Debug.Log ("0");
		} else {
			ShipStatKeeper.humidOn = false;
		}
		SpriteRenderer SR = humL.GetComponent<SpriteRenderer> ();

		if (ShipStatKeeper.humidOn) {
			SR.sprite = greenL;
		} else
			SR.sprite = offL;
	}
	public void  Button1Click(){//AC button
		if (ShipStatKeeper.engine != 0) {
			ShipStatKeeper.acOn = !ShipStatKeeper.acOn;
			Debug.Log ("1");
		} else
			ShipStatKeeper.acOn = false;
		SpriteRenderer SR = acL.GetComponent<SpriteRenderer> ();
		if (ShipStatKeeper.acOn) {
			SR.sprite = greenL;
		} else
			SR.sprite = offL;
	}

	public void  Button2Click(){//Bot deploy button
		if (ShipStatKeeper.engine != 0) {
			ShipStatKeeper.docked = true;
			Debug.Log ("2");
		} 
		SpriteRenderer SR = botL.GetComponent<SpriteRenderer> ();
		if (ShipStatKeeper.docked) {
			SR.sprite = greenL;
		} else
			SR.sprite = offL;
	}

	public void  Button3Click(){//gravity button
		if (ShipStatKeeper.engine != 0) {
			ShipStatKeeper.gravOn = !ShipStatKeeper.gravOn;

			Debug.Log ("3");
		} else {
			ShipStatKeeper.gravOn = false;
		}
		SpriteRenderer SR = gravL.GetComponent<SpriteRenderer> ();
		if (ShipStatKeeper.gravOn) {
			SR.sprite = greenL;
		} else
			SR.sprite = offL;
	}
	public void Button4Click(){
		
	}
	public void Button5Click(){

	}

	public void GoToggle(){
		ShipStatKeeper.shipMoving = !ShipStatKeeper.shipMoving;

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