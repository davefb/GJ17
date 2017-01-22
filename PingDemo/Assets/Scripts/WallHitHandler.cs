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

    static Dictionary<GameObject, int> glowingwalls = new Dictionary<GameObject, int>();
//	static WallHitHandler[] walls;
//    Color lerpColor;
     const int BLANK_FADE = 0;
	// Use this for initialization
	void Start () {
		origmaterial = GameObject.Find("NonGlowingReference").GetComponent<Renderer>().material;
		glowmaterial1 = GameObject.Find("GlowingReference1").GetComponent<Renderer>().material;
		glowmaterial2 = GameObject.Find("GlowingReference2").GetComponent<Renderer>().material;
		glowmaterial3 = GameObject.Find("GlowingReference3").GetComponent<Renderer>().material;

        glowingwalls.Add(this.gameObject, BLANK_FADE);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public override void HandlePulseHit(RaycastHit rch){

		GameObject hit = rch.collider.gameObject;

		if ( glowingwalls.ContainsKey(hit) ){
			Renderer rend = hit.GetComponent<Renderer>();
			rend.material = glowmaterial3;
			glowingwalls[hit] = 3;
		}
	}

	public override void HandleBeamHit(RaycastHit rch){

	}

	public static void Tick() {
//        if(walls == null)
//        {
//            walls = GameObject.FindGameObjectWithTag("Walls").GetComponentsInChildren<WallHitHandler>();
//        }
//		int x = 0;

		foreach (KeyValuePair<GameObject, int> entry in glowingwalls) {
			
			if (entry.Value == 3) {
				entry.Key.GetComponent<Renderer> ().material = glowmaterial3;
				glowingwalls [entry.Key] = 2;
			} else if (entry.Value == 2) {
				entry.Key.GetComponent<Renderer> ().material = glowmaterial2;
				glowingwalls [entry.Key] = 1;
			} else if (entry.Value == 1) {
				entry.Key.GetComponent<Renderer> ().material = glowmaterial1;
				glowingwalls [entry.Key] = 0;
			} else if (entry.Value == 0) {
				entry.Key.GetComponent<Renderer> ().material = origmaterial;
			}
		}

//        foreach (WallHitHandler childGameobject in walls)
//        {
//            GameObject child = childGameobject.gameObject;
//            MeshRenderer mRenderer = childGameobject.GetComponent<MeshRenderer>();
//            if (glowingwalls.ContainsKey(child)) {
//            	glowingwalls [child]--;
//            	if (glowingwalls[child] == 3) {
//            		child.gameObject.GetComponent<Renderer> ().material = glowmaterial3;
//            	} else if (glowingwalls[child]  == 2) {
//            		child.gameObject.GetComponent<Renderer> ().material = glowmaterial2;
//            	} else if (glowingwalls[child] == 1) {
//            		child.gameObject.GetComponent<Renderer> ().material = glowmaterial1;
//            	} else if (glowingwalls[child]  == 0) {
//            		child.gameObject.GetComponent<Renderer> ().material = origmaterial;
//            	}
//            }
//            x++;
//		}
	}
}
