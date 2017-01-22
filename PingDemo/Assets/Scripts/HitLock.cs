using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitLock : HitHandler {

    [Range(0,10)]
    public int bounceNumber;

    /*[HideInInspector]*/public bool locked = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void HandleBeamHit(RaycastHit rch)
    {
        OnBeamHit(8);
    }
    public override void HandlePulseHit(RaycastHit rch)
    {
        base.HandleBeamHit(rch);
    }
    void OnBeamHit(int _bonceNumber)
    {
        locked = false;
        if (bounceNumber == _bonceNumber)
        {
            locked = false;
        }
    }
    
}
