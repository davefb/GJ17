using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DrawPing : MonoBehaviour {

    private LineRenderer circleLineRenderer;
    public Vector3[] pts = new Vector3[0];


    // Use this for initialization
    void Awake () {
        circleLineRenderer = GetComponent<LineRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        

    }

    internal void setPoints(List<Vector3> q)
    {
        pts = q.ToArray();
        if (circleLineRenderer != null)
        {
            circleLineRenderer.SetVertexCount(pts.Length);
            circleLineRenderer.SetPositions(pts);
        }
    }
}
