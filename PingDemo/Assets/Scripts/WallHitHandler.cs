using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHitHandler : HitHandler {
	public GameObject glowParticles;

	static Material origmaterial;
	static Material glowmaterial;

	static bool[] glowingwalls;
	static int[] glowingwallstime; // takes 3 ticks for glow to dissapear

	// Use this for initialization
	void Start () {
		origmaterial = GameObject.Find("NonGlowingReference").GetComponent<Renderer>().material;
		glowmaterial = GameObject.Find("GlowingReference").GetComponent<Renderer>().material;

		int x = 0;
		foreach (Transform child in GameObject.Find("Walls").transform) {
			x++;
		}
		glowingwalls = new bool[x];
		glowingwallstime = new int[x];

		for (int i = 0; i < x; i++) {
			glowingwalls [i] = false;
			glowingwallstime [i] = 0;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void HandlePulseHit(RaycastHit rch){

		GameObject hit = rch.collider.gameObject;

		glow (hit);

//		GameObject p = Instantiate (glowParticles);
//		p.transform.position = rch.point;
//		p.SetActive (true);	
//
//		p.GetComponent<ParticleSystem>().Stop();
//		p.GetComponent<ParticleSystem>().Emit(3);
//		Destroy(
//			p,0.5f
//		);
			
	//p.GetComponent<ParticleSystem> ().
	}

	public override void HandleBeamHit(RaycastHit rch){

	}

	void glow(GameObject hit) {
		// make the hit wall emission white for a few seconds
		Renderer rend = hit.GetComponent<Renderer>();
		rend.material = glowmaterial;

		int x = 0;
		foreach (Transform child in GameObject.Find("Walls").transform) {
			if (child.gameObject.name == hit.name) {
				glowingwalls [x] = true;
				glowingwallstime [x] = 10;
			}

			x++;
		}
	}

	public static void Tick() {
		int x = 0;
		Debug.Log ("gothere");

		foreach (Transform child in GameObject.Find("Walls").transform) {
			if (glowingwalls [x]) {
				glowingwallstime [x]--;
				if (glowingwallstime [x] == 0) {
					child.gameObject.GetComponent<Renderer> ().material = origmaterial;
				}
			}
			x++;
		}
	}
}
