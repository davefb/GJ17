using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeColor : MonoBehaviour {

    public bool startFade = false;
    public Renderer renderer;
    public Color startColor;
    public Color endColor;
	// Use this for initialization
	void Start () {
        renderer = GetComponent<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        Color color = renderer.material.color;
        color.a -= 0.1f;
        renderer.material.color = color;
    }
}
