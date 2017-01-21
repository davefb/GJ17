using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DrawPing : MonoBehaviour {

    private LineRenderer circleLineRenderer;
    public Vector3[] pts = new Vector3[0];


    // Use this for initialization
    void Start () {
        circleLineRenderer = GetComponent<LineRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        circleLineRenderer.SetVertexCount(pts.Length);
        circleLineRenderer.SetPositions(pts);
    }

    internal void setPoints(List<Vector3> q)
    {
        pts = q.ToArray();
    }
}
