using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public LineDropper lineDropper;
    public GameObject StartAnchor;

    GameObject[] Anchors;
    Anchor currentAnchor;
    // Use this for initialization
    void Start () {
        if (StartAnchor != null)
        {
            Anchors = GameObject.FindGameObjectsWithTag("Anchor");
            transform.position = StartAnchor.transform.position;
            currentAnchor = StartAnchor.GetComponent<Anchor>();
            currentAnchor.GetComponent<MeshRenderer>().enabled = false;
        }
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
		if (Input.GetMouseButtonDown(0)) //&& GetComponent<WaveController>().laserOn == true)
        {
            lineDropper.SpawnNewBeam(transform.position, (hit.point-transform.position));
            //Debug.DrawRay(transform.position, (hit.point - transform.position));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveTo(currentAnchor.wAnchor);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveTo(currentAnchor.aAnchor);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveTo(currentAnchor.sAnchor);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveTo(currentAnchor.dAnchor);
        }
    }
    void MoveTo(Anchor target)
    {
        if (target != null)
        {
            GetComponent<WaveController>().changeTransform();
            transform.position = target.transform.position;
            currentAnchor.GetComponent<MeshRenderer>().enabled = true;
            currentAnchor = target;
            currentAnchor.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
