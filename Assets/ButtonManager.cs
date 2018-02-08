using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour {

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
		ShipStatKeeper.tempToAdd = slideA.value-ShipStatKeeper.humidity;
		temperature.text = slideA.value+"";
		Debug.Log (ShipStatKeeper.tempToAdd);

	}

	public void ValueChangeCheckHum(){
		ShipStatKeeper.humToAdd = slideB.value-ShipStatKeeper.temperature;
		humidity.text = slideB.value+"";
		Debug.Log (ShipStatKeeper.humToAdd);


	}

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


}
/* Notes:
 * buttons should be added onto control board to represent interactive map (they should glow when hovered)
 * IDEA: events taht require user to press buttons???!?!
 * http://www.hopesandfears.com/hopes/culture/film/214001-the-ultimate-guide-to-control-panels-in-movies
 */