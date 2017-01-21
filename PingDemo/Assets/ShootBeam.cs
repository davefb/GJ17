using UnityEngine;
using System.Collections;

public class ShootBeam : MonoBehaviour {

    // Use this for initialization
    public LineRenderer shotLineProto;
    public PingDropper pingDropper;
	void Start () {

        pingDropper = GetComponentInChildren<PingDropper>();
        curPoint = transform.position;
        curDirection = new Vector3(1, 0, 1);
    }

    // Update is called once per frame
    int count = 0;
    Vector3 curPoint;
    Vector3 curDirection;
	void Update () {
	    if(Time.timeSinceLevelLoad > 3 * count){
           // ShootBeamTowards(curPoint, curDirection);

            pingDropper.radius = 1.0f + count * 1.0f;
            pingDropper.DrawCircle();
            count++;
        }
	}

    void ShootBeamTowards(Vector3 start , Vector3 dir)
    {
        RaycastHit r;
        if(Physics.Raycast(start, dir, out r, float.PositiveInfinity))
        {
            LineRenderer li = Instantiate<LineRenderer>(shotLineProto);
            li.SetVertexCount(2);
            li.SetPosition(0, start);
            li.SetPosition(1, r.point);
            Vector3 reflection = Vector3.Reflect(dir, r.normal);
            curPoint = r.point;
            curDirection = reflection;
        }

    }
}