using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHitHandler : HitHandler {
    enum State { INACTIVE, ACTIVE, HIT};
    bool lightOn = false;
    State currentState = State.INACTIVE;
    public int[] activeBeats;
    public Material hitColor;
    public Material activeColor;
    public Material inactiveColor;
    int currentTick = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (lightOn)
        {
            this.GetComponentInChildren<Light>().intensity = 1.5f;
        }
        else
        {
            this.GetComponentInChildren<Light>().intensity = 0f;
        }
    }
    public void Tick()
    {
        bool found = false;
        for(int i = 0; i < activeBeats.Length; i++)
        {
            if(currentTick%4 == activeBeats[i])
            {
                found = true;

            
            }

            UpdateMaterial();
        }

        if (found)
        {
            currentState = State.ACTIVE;
        }
        else
        {
            currentState = State.INACTIVE;
        }
        currentTick++;
    }
    public override void HandleBeamHit(RaycastHit rch)
    {
        
        base.HandleBeamHit(rch);
        if (currentState == State.ACTIVE)
        {
            currentState = State.HIT;
            Debug.Log("hit", this);
            UpdateMaterial();
        }


    }
   
    public override void HandlePulseHit(RaycastHit rch)
    {

        base.HandleBeamHit(rch);
        
        StartCoroutine( offLight() );
    }

    IEnumerator offLight()
    {
        this.lightOn = true;
        yield return new WaitForSeconds(2);
        this.lightOn = false;
    }
    public void UpdateMaterial()
    {
        switch (currentState)
        {
            case State.HIT:
                StartCoroutine(offLight());
                GetComponent<Renderer>().material = hitColor;
                break;
            case State.ACTIVE:
                // lightOn = false;
                GetComponent<Renderer>().material = activeColor;
                break;
            case State.INACTIVE:
                //lightOn = false;
                GetComponent<Renderer>().material = inactiveColor;
                break;

        }

    }
}
