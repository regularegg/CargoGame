using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehavior {
	public bool occupied;
	public int health, ID, level;
	public bool[] slots = new bool[3]; 

	public RoomBehavior(int RID){
		ID = RID;
		health = 100;
		level = 0;
	}
}
