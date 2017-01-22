using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHitHandler : HitHandler {
	public GameObject glowParticles;

	static Material origmaterial;
	static Material glowmaterial1;
	static Material glowmaterial2;
	static Material glowmaterial3;

    static Dictionary<GameObject, int> glowingwalls = new Dictionary<GameObject, int>();
	static WallHitHandler[] walls;
     const int BLANK_FADE = 0;
	// Use this for initialization
	void Start () {
		origmaterial = GameObject.Find("NonGlowingReference").GetComponent<Renderer>().material;
		glowmaterial1 = GameObject.Find("GlowingReference").GetComponent<Renderer>().material;
		glowmaterial2 = GameObject.Find("GlowingReference1").GetComponent<Renderer>().material;
		glowmaterial3 = GameObject.Find("GlowingReference2").GetComponent<Renderer>().material;

		int x = 0;
        glowingwalls.Add(this.gameObject, BLANK_FADE);




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
        rend.material.SetColor("_EmissionColor", new Color(1, 1, 1, 1));
        DynamicGI.UpdateMaterials(rend);
        DynamicGI.UpdateEnvironment();

        hit.GetComponent<FadeColor>().StartFade();

        //if ( glowingwalls.ContainsKey(hit) ){
        //    rend.material = glowmaterial1;
        //    glowingwalls[hit] = 4;
        //}
    
	}

	public static void Tick() {
        if(walls == null)
        {
            walls = GameObject.FindGameObjectWithTag("Walls").GetComponentsInChildren<WallHitHandler>();
        }
		int x = 0;

        foreach (WallHitHandler childGameobject in walls)
        {
            GameObject child = childGameobject.gameObject;
            MeshRenderer mRenderer = childGameobject.GetComponent<MeshRenderer>();
            if (glowingwalls.ContainsKey(child)) {
            	//glowingwalls [child]--;
            	//if (glowingwalls[child] == 3) {
            	//	child.gameObject.GetComponent<Renderer> ().material = glowmaterial1;
            	//} else if (glowingwalls[child]  == 2) {
            	//	child.gameObject.GetComponent<Renderer> ().material = glowmaterial2;
            	//} else if (glowingwalls[child] == 1) {
            	//	child.gameObject.GetComponent<Renderer> ().material = glowmaterial3;
            	//} else if (glowingwalls[child]  == 0) {
            	//	child.gameObject.GetComponent<Renderer> ().material = origmaterial;
            	//}
            }
            x++;
		}
	}
}
