using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

	public static float slider = ShipStatKeeper.temperature;
	public static bool toggle, button;
	public Button bt1, bt2, bt3;
	public Button[] buttonList;
	public Slider slide;
	public Toggle tog;

	void Start () {
		slide.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
		slide.wholeNumbers = true;
		slide.maxValue = 10;

		tog.onValueChanged.AddListener (delegate {
			LightToggle();
		});


		buttonList = new Button[]{bt1, bt2, bt3};

		/*bt1.onClick.AddListener (delegate {
			Button1Click ();
		});
		bt2.onClick.AddListener (delegate {
			Button2Click ();
		});
		bt3.onClick.AddListener (delegate {
			Button3Click ();
		});*/

		for (int i = 0; i < buttonList.Length; i++){
			Button temp = buttonList [i];
			temp.name = ""+i;
			buttonList[i].onClick.AddListener(() => {ButtonClicked(temp);});
		}
	}
	
	public void ButtonClicked(Button butt){
		int temp = int.Parse (butt.name);
		Debug.Log (temp);
	}


	public bool ButtonChecker(int button){
		

		return false;
	}
	//make something check if the right button is pressed, no need to return anything






	public void ValueChangeCheck(){
		ShipStatKeeper.temperature = slide.value;
		Debug.Log (slide.value);
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
