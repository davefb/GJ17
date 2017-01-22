using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHitHandler : HitHandler {
    enum State { INACTIVE, ACTIVE, HIT};
    int lightOn = 0;
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
        if (lightOn>0)
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
            if(currentTick% 8 == activeBeats[i])
            {
                found = true;

            
            }

            
        }

        if (found)
        {
            currentState = State.ACTIVE;
        }
        else
        {
            currentState = State.INACTIVE;
        }
        UpdateMaterial();
        currentTick++;
    }
    public override void HandleBeamHit(RaycastHit rch)
    {
        
        base.HandleBeamHit(rch);
        if (this.GetComponentInChildren<PingDropper>() != null) this.GetComponentInChildren<PingDropper>().fire();
        if (currentState == State.ACTIVE)
        {
            currentState = State.HIT;
            Debug.Log("hit", this);
            UpdateMaterial();
        }
        else
        {
            StartCoroutine(offLight());
        }


    }
   
    public override void HandlePulseHit(RaycastHit rch)
    {

        //base.HandleBeamHit(rch);
        
        StartCoroutine( offLight() );
    }

    IEnumerator offLight()
    {
        this.lightOn++;
        yield return new WaitForSeconds(2);
        this.lightOn--;
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
