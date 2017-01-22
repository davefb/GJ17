using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickMain : MonoBehaviour {

	public void Start() {

	}

	int count = 0;
	public void Update() {
		Tick ();
//
//		if (Time.timeSinceLevelLoad > count) {
//			
//			count++;
//		}


	}

	// do everything that is activated on a tick
	public void Tick() {
		WallHitHandler.Tick ();
	}
}

