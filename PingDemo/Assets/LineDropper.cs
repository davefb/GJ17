using UnityEngine;
using System.Collections;

public class LineDropper : MonoBehaviour {
    public DrawBeam dbProto;
	// Use this for initialization
	void Start () {
	    
	}
    public void SpawnNewBeam(Vector3 start, Vector3 towards)
    {
        DrawBeam ndb = Instantiate(dbProto);
        ndb.transform.parent = this.transform;
        ndb.SpawnNewBeam(start, towards);
    }
	public void Tick()
    {
        foreach (DrawBeam db in GetComponentsInChildren<DrawBeam>())
        {
            db.Tick();
        }
        
    }
	// Update is called once per frame
	void Update () {
	
	}
}
