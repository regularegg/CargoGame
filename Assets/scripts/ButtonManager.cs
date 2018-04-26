using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonManager : MonoBehaviour {

	public static float tempSlideOutput, humSlideOutput;

	public Button humButt, acButt, dockButt, gravButt, airlockButt, returnButt;
	public Button[] buttonList, mapButtonList;
	public Slider slideA, slideB, slideC;

	public TextMeshProUGUI temperature, humidity;
	public GameObject humL, acL, dockL, gravL, goL1;
	public Sprite offL, greenL, redL;

	ShipStatKeeper SSK;

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

		slideC.onValueChanged.AddListener (delegate {
			StartShip ();
		});
		slideC.wholeNumbers = true;
		slideC.maxValue = 1;
		slideC.value = 0;


		buttonList = new Button[]{ humButt, acButt, dockButt, gravButt, airlockButt, returnButt};

		for (int i = 0; i < buttonList.Length; i++) {
			Button temp = buttonList [i];
			temp.name = "" + i;
			buttonList [i].onClick.AddListener (() => {
				ButtonClicked (temp);
			});
		}
	}

	void StartShip(){
		if (slideC.value == 0) {
			ShipStatKeeper.shipMoving = true;
			goL1.GetComponent<SpriteRenderer> ().sprite = greenL;
		}

		if (slideC.value == 1) {
			ShipStatKeeper.shipMoving = false;
			goL1.GetComponent<SpriteRenderer> ().sprite = offL;
			GameObject.Find("Engine slider temp").GetComponent<Animator> ().Play ("throttle slide down");

		}

		Debug.Log(ShipStatKeeper.shipMoving + " ship going");
		ShipStatKeeper.shipMoving = !ShipStatKeeper.shipMoving;
		if (ShipStatKeeper.shipMoving) {
			goL1.GetComponent<SpriteRenderer> ().sprite = greenL;
		} else {
			goL1.GetComponent<SpriteRenderer> ().sprite = offL;
		}
	}
	void Update(){
		SSK.Humidity = Mathf.Lerp (ShipStatKeeper.humidity, currentHumidityTarget, Time.deltaTime * 0.01f);
		SSK.Temperature = Mathf.Lerp (ShipStatKeeper.temperature, currentTemperatureTarget, Time.deltaTime * 0.01f);
	}
	
	public void ButtonClicked(Button butt){
		int temp = int.Parse (butt.name);
		switch (temp) {
		case 0:
			Button0Click ();// humidity
			break;
		case 1:
			Button1Click ();// temperature
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
		}
	}


		

	public void ValueChangeCheckTemp(){
	//	temperature.text = slideB.value+"";
		if (ShipStatKeeper.acOn) {
			currentTemperatureTarget = slideA.value;
		}
	}

	public void ValueChangeCheckHum(){
	//	humidity.text = slideB.value+"";
		if (ShipStatKeeper.humidOn) {
			currentHumidityTarget = slideB.value;
		}

	}

	public void  Button0Click(){ //humidity button
		if (ShipStatKeeper.engine != 0) {
			ShipStatKeeper.humidOn = !ShipStatKeeper.humidOn;
			humButt.GetComponentInParent<Image>().color = Color.green;

			Debug.Log ("0");
		} else {
			ShipStatKeeper.humidOn = false;
			humButt.GetComponentInParent<Image>().color = Color.gray;

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

	public void  Button2Click(){//Dock
		if (ShipStatKeeper.engine != 0) {
			ShipStatKeeper.docked = true;
			Debug.Log ("2");
		} 
		SpriteRenderer SR = dockL.GetComponent<SpriteRenderer> ();
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
	public void Button4Click(){//airlock
		//nvm no need...
	}


	void TemperatureIncrease(){
		if (ShipStatKeeper.tempToAdd != 0) {
			ShipStatKeeper.temperature += ShipStatKeeper.tempToAdd/5;
			ShipStatKeeper.tempToAdd -= ShipStatKeeper.tempToAdd/5;

			Debug.Log ("added temp");
		}
	}
}
