using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomManager : MonoBehaviour {
	public static RoomBehavior[] rooms;
	public RoomBehavior[] roomDsp;
	public GameObject[] guys = new GameObject[18];
	// 5 = rooms, 3 = guys
	public static bool[,] roomGuys = new bool[6, 3] ;

	void Start () {
		rooms = new RoomBehavior[6];
		for (int i = 0; i < rooms.Length; i++) {
			rooms [i] = new RoomBehavior (i);
		}

		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 3; j++){
				roomGuys [i, j] = false;
			}
		}

		roomDsp = rooms;
	}
}
