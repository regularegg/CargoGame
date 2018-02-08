using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

	public static float sliderA = ShipStatKeeper.temperature;
	public static bool toggle, button;
	public Button bt1, bt2, bt3, mpA,mpB,mpC,mpD,mpE;
	public Button[] buttonList, mapButtonList;
	public Slider slideA, slideB;
	public Toggle tog;

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
		int temp = int.Parse (butt.name);
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
		ShipStatKeeper.temperature = slideA.value;
	}

	public void ValueChangeCheckHum(){
		ShipStatKeeper.humidity = slideB.value;
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