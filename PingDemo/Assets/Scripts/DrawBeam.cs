using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawBeam : MonoBehaviour {
    Dictionary<LineRenderer, int> decay = new Dictionary<LineRenderer, int>();
    LineRenderer shotLineProto;
    Vector3 curPoint;
    Vector3 curDirection;
    int maxBounce = 10;
    int curBounce = 0;

    LineRenderer li;
 

	public int getCurBounce(){
		return curBounce;
	}
    // Use this for initialization
    void Start () {
        shotLineProto = GetComponentInChildren<LineRenderer>();


    }

    public void SpawnNewBeam(Vector3 start, Vector3 towards)
    {
        this.curPoint = start;
        this.curDirection = towards;
        //this.maxBounce = maxBounce;
    }
    public void Tick()
    {
        
        ShootBeamTowards(curPoint, curDirection);
        Fade();
    }
    // Update is called once per frame
    void Update () {
	
	}
    // Why there is no getter for LineRenderer.width, idk....
    public float initialLW = 0.2f;


    void ShootBeamTowards(Vector3 start, Vector3 dir)
    {
        if (curBounce >= maxBounce) return;
        RaycastHit r;
        // if (li != null) GameObject.Destroy(li.gameObject);
        if (Physics.Raycast(start, dir, out r, float.PositiveInfinity))
        {
            
      

            li = Instantiate<LineRenderer>(shotLineProto);
            li.transform.parent = this.transform;
            decay.Add(li, maxBounce);
            li.SetVertexCount(2);
            li.SetPosition(0, start);
            li.SetPosition(1, r.point);
            Vector3 reflection = Vector3.Reflect(dir, r.normal);

            curPoint = r.point;
            curDirection = reflection;
            curBounce += 1;

			HitHandler hh = r.collider.GetComponent<HitHandler> ();
			if (hh!= null)
            {
				hh.HandleBeamHit (r);
            }

        }

    }

    private void Fade()
    {
        Dictionary<LineRenderer, int> nextdecay = new Dictionary<LineRenderer, int>();
        foreach (LineRenderer lr in decay.Keys)
        {
            if (decay[lr] == 7)
            {
                GameObject.Destroy(lr.gameObject);
            }
            else
            {
                nextdecay.Add(lr, decay[lr] - 1);
                float newWidth = initialLW / (maxBounce - decay[lr] + 1);
                lr.SetWidth(newWidth, newWidth);
            }
        }
        decay = nextdecay;
    }
}
