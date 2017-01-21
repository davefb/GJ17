using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

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
                Debug.Log(hit.point);
            }
            else
            {
                Debug.DrawLine(ray.origin, hit.point);
                
            }
            transform.LookAt(hit.point);
    }
}
