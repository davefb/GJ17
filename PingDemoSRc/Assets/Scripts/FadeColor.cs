using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeColor : MonoBehaviour {

    public bool startFade = false;
    public float fadeUntil;
    public AnimationCurve curve;
    float fadeTime = 3;
    float startTime;
    float colorValue;
    public Renderer rend;
    public Color lerpColor;
    public Color endColor;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startFade == true)
        {
            //smooth fade-->
            colorValue = curve.Evaluate((Time.time - startTime) / 10);
            lerpColor = new Color(colorValue, colorValue, colorValue, colorValue);

            rend.material.SetColor("_EmissionColor", lerpColor);
            DynamicGI.UpdateMaterials(rend);

            //coarse fade -->
            //    if (Time.time > fadeUntil)
            //    {
            //        rend.material = WallHitHandler.glowmaterial3;
            //        if (Time.time > fadeUntil + fadeTime*2)
            //        {
            //            rend.material = WallHitHandler.glowmaterial2;
            //            if (Time.time > fadeUntil + fadeTime*3)
            //            {
            //                rend.material = WallHitHandler.glowmaterial1;
            //                if (Time.time > fadeUntil + fadeTime*4)
            //                {
            //                    rend.material = WallHitHandler.origmaterial;
            //                }
            //            }
            //        }
            //    }
        }
    }
    public void StartFade()
    {
        startTime = Time.time;
        fadeUntil = Time.time + fadeTime;
        startFade = true;
    }

}
