using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class researchBehavior : MonoBehaviour {
	public static int ID = 0;
	public int[] roomLevels;
	float[] researchT = new float[]{10f, 15f, 20f};
	float[] engineT = new float[]{10f, 15f, 20f};
	float[] toolFabT = new float[]{10f, 15f, 20f};
	float[] mineFabT = new float[]{10f, 15f, 20f};
	float[] gardenT = new float[]{5f, 10f, 15f};
	float[] airFilterT = new float[]{10f, 15f, 20f};

	int _research;
	int Research{
		get{ return _research; }
		set{

		}
	}
	int _engine;
	int Engine{
		get{ return _engine; }
		set{

		}
	}
	int _toolFab;
	int ToolFab{
		get{ return _toolFab; }
		set{

		}
	}
	int _mineFab;
	int MineFab{
		get{ return _mineFab; }
		set{

		}
	}
	int _garden;
	int Garden{
		get{ return _garden; }
		set{

		}
	}
	int _filter;
	int Filter{
		get{ return _filter; }
		set{

		}
	}



	void Start () {
		roomLevels = new int[]{ Research, Engine, ToolFab, MineFab, Garden, Filter };
	}
	
	void Update () {
		
	}
}
/* be able to research upgrades for ship
 * integers of ship level (w/ get n set)
 * array of research time requirements corresponding to each level
 * research coroutine that takes ( integer to be upgraded, float time for upgrade)
 */
