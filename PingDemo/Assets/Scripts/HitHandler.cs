using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHandler : MonoBehaviour {
	public GameObject glowParticles;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public virtual void HandlePulseHit(RaycastHit rch){
		GameObject p = Instantiate (glowParticles);
		p.transform.position = rch.point;
		p.SetActive (true);
	}

	public virtual void HandleBeamHit(RaycastHit rch){

	}
}
