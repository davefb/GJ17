﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ShootBeam : MonoBehaviour {

    // Use this for initialization

     PingDropper pingDropper;
     LineDropper lineDropper;

	void Awake () {

        pingDropper = GetComponentInChildren<PingDropper>();
        lineDropper = GetComponentInChildren<LineDropper>();
        //        curPoint = transform.position;
        //ector3 curDirection = new Vector3(1, 0, 1);
      //  lineDropper.SpawnNewBeam(transform.position, new Vector3(1, 0, 1));
      //  lineDropper.SpawnNewBeam(transform.position, new Vector3(0, 0, -1));
    }

    // Update is called once per frame
    int count = 0;

    void Update () {
		pingDropper.radius+= Time.deltaTime ;
		pingDropper.DrawCircle();

	}



}