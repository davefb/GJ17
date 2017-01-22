using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PingDropper : MonoBehaviour {
    public float ThetaScale = 0.01f;
    public float radius = 3f;
    private float Theta = 0f;
    private int Size;
    public DrawPing protoDrawPing;
    // Use this for initialization
    // are we in a segment that is being drawn?
    bool isHit = false;

    List<Vector3> q = new List<Vector3>();
    private List<DrawPing> segments = new List<DrawPing>();

    void Start()
    {

    }


	// Update is called once per frame
	public void DrawCircle () {
        foreach (DrawPing dp in segments) GameObject.DestroyImmediate(dp.gameObject);
        segments.Clear();
        Theta = 0f;
        Size = (int)((1f / ThetaScale) + 1f);

        for (int i = 0; i < Size; i++)
        {
            Theta += (2.0f * Mathf.PI * ThetaScale);
            float x = radius * Mathf.Cos(Theta);
            float y = radius * Mathf.Sin(Theta);
			RaycastHit rch; 
            if (Physics.Raycast(this.transform.position, new Vector3(x, 0, y), out rch, radius))
            {
                if (isHit)
                {
                    isHit = false;
                    if (q.Count > 0)
                        SpawnNewCircleSeg();

                }
		
				HitHandler hh = rch.collider.GetComponent<HitHandler> ();
				if (hh != null)
					hh.HandlePulseHit (rch);
				
            }
            else
            {
                isHit = true;
                q.Add(new Vector3(x, 0, y));
            }


        }
        if (q.Count > 0)
            SpawnNewCircleSeg();

    }

    private void SpawnNewCircleSeg()
    {
        DrawPing dp = Instantiate<DrawPing>(protoDrawPing);
        segments.Add(dp);
        dp.setPoints(q);
        q.Clear();
    }
}
