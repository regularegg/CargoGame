using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {
	public static RoomBehavior[] rooms;
	public RoomBehavior[] roomDsp;

	void Start () {
		rooms = new RoomBehavior[8];
		for (int i = 0; i < rooms.Length; i++) {
			rooms [i] = new RoomBehavior (i);
		}

		roomDsp = rooms;
	}
}
