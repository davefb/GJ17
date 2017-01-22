using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHitHandler : HitHandler {
	public GameObject glowParticles;
    public AnimationCurve fadeWave;

	static Material origmaterial;
	static Material glowmaterial1;
	static Material glowmaterial2;
	static Material glowmaterial3;

	static bool[] glowingwalls;
	static int[] glowingwallstime; // takes 3 ticks for glow to dissapear

    Color lerpColor;

	// Use this for initialization
	void Start () {
		origmaterial = GameObject.Find("NonGlowingReference").GetComponent<Renderer>().material;
		glowmaterial1 = GameObject.Find("GlowingReference1").GetComponent<Renderer>().material;
		glowmaterial2 = GameObject.Find("GlowingReference2").GetComponent<Renderer>().material;
		glowmaterial3 = GameObject.Find("GlowingReference3").GetComponent<Renderer>().material;

		int x = 0;
        foreach (GameObject childGameobject in GameObject.FindGameObjectsWithTag("Walls"))
        {
            Transform child = childGameobject.transform;
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
		rend.material = glowmaterial3;

		int x = 0;
		foreach (GameObject childGameobject in GameObject.FindGameObjectsWithTag("Walls")) {
            Transform child = childGameobject.transform;
			if (child.gameObject.name == hit.name) {
				glowingwalls [x] = true;
				glowingwallstime [x] = 4;
			}

			x++;
		}
	}

	public static void Tick() {
		int x = 0;

        foreach (GameObject childGameobject in GameObject.FindGameObjectsWithTag("Walls"))
        {
            Transform child = childGameobject.transform;
            MeshRenderer mRenderer = childGameobject.GetComponent<MeshRenderer>();
            //         if (glowingwalls [x]) {
            //	glowingwallstime [x]--;
            //	if (glowingwallstime [x] == 3) {
            //		child.gameObject.GetComponent<Renderer> ().material = glowmaterial3;
            //	} else if (glowingwallstime [x] == 2) {
            //		child.gameObject.GetComponent<Renderer> ().material = glowmaterial2;
            //	} else if (glowingwallstime [x] == 1) {
            //		child.gameObject.GetComponent<Renderer> ().material = glowmaterial1;
            //	} else if (glowingwallstime [x] == 0) {
            //		child.gameObject.GetComponent<Renderer> ().material = origmaterial;
            //	}
            //}
            x++;
		}
	}
}
