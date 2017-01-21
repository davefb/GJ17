using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {
    
    public int waveBounces;
    float angle;

    Vector3 mousePosition;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit floorhit;
            if (Physics.Raycast(ray, out floorhit, 100))
            {
                print("Hit something!");
                mousePosition = floorhit.point;
                Debug.Log(mousePosition);
            }

            Vector3 direction = (mousePosition - transform.position).normalized;
            
            RaycastHit target;
            if(Physics.Raycast(transform.position, direction, out target, Mathf.Infinity))
            Debug.Log(target.point);
            Debug.DrawRay(transform.position, target.point, Color.red);

            angle = Vector3.Angle(target.normal, target.point);
            Debug.Log(angle);
            Vector3 newDirection = Vector2.Reflect(target.point, target.normal);
            Debug.Log(newDirection);

            for (int i = waveBounces; i > 0; i--)
            {
                RaycastHit nextTarget;
                if(Physics.Raycast(target.point, newDirection, out nextTarget, Mathf.Infinity))
                {
                    Debug.Log(nextTarget);
                }
                Debug.Log(nextTarget.point);
                Debug.DrawRay(target.point, nextTarget.point, Color.red);
            }
        }

    }
}

