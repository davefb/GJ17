using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public LineDropper lineDropper;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
            if(hit.transform.gameObject.layer != 8)
            {
                hit.point = new Vector3(hit.point.x, 0, hit.point.z);
            }
            else
            {
                Debug.DrawLine(ray.origin, hit.point);
                
            }
            transform.LookAt(hit.point);
        if (Input.GetKeyDown(KeyCode.Mouse0) && GetComponent<WaveController>().laserOn == true)
        {
            lineDropper.SpawnNewBeam(transform.position, hit.point);
            GetComponent<WaveController>().laserOn = false;
        }
    }

}
