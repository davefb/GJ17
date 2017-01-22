using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHitHandler : HitHandler {
	public GameObject glowParticles;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public override void HandlePulseHit(RaycastHit rch){
		GameObject p = Instantiate (glowParticles);
		p.transform.position = rch.point;
		p.SetActive (true);	

		p.GetComponent<ParticleSystem>().Stop();
		p.GetComponent<ParticleSystem>().Emit(3);
		Destroy(
			p,0.5f
		);
	//p.GetComponent<ParticleSystem> ().
	}

	public override void HandleBeamHit(RaycastHit rch){

	}
}
