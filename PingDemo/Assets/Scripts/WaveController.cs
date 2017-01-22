using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    //this game object's Transform  
    Transform goTransform;
    //the attached line renderer  
    LineRenderer lineRenderer;


    List<Vector3> hitPoints = new List<Vector3>();

    public bool laserOn = false;

    //a ray  
    Ray ray;
    //a RaycastHit variable, to gather informartion about the ray's collision  
    RaycastHit hit;

    //reflection direction  
    Vector3 inDirection;

    //the number of reflections  
    public int nReflections = 2;

    //the number of points at the line renderer  
    int nPoints;

    void Awake()
    {
        //get the attached Transform component  
        goTransform = transform;
        //get the attached LineRenderer component  
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            laserOn = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            laserOn = false;
            lineRenderer.enabled = false;
        }
        if (laserOn)
        {            
            lineRenderer.enabled = true;
            //clamp the number of reflections between 1 and int capacity  
            nReflections = Mathf.Clamp(nReflections, 1, nReflections);
            //cast a new ray forward, from the current attached game object position  
            ray = new Ray(goTransform.position, goTransform.forward);

            //represent the ray using a line that can only be viewed at the scene tab  
            Debug.DrawRay(goTransform.position, goTransform.forward * 100, Color.red);

            //set the number of points to be the same as the number of reflections  
            nPoints = nReflections;
            //make the lineRenderer have nPoints  
            lineRenderer.SetVertexCount(nPoints);
            //Set the first point of the line at the current attached game object position  
            lineRenderer.SetPosition(0, goTransform.position);

            for (int i = 0; i <= nReflections; i++)
            {
                //If the ray hasn't reflected yet  
                if (i == 0)
                {
                    //Check if the ray has hit something  
                    if (Physics.Raycast(ray.origin, ray.direction, out hit, 100))//cast the ray 100 units at the specified direction  
                    {
                        //the reflection direction is the reflection of the current ray direction flipped at the hit normal  
                        inDirection = Vector3.Reflect(ray.direction, hit.normal);
                        //cast the reflected ray, using the hit point as the origin and the reflected direction as the direction  
                        ray = new Ray(hit.point, inDirection);

                        //Draw the normal - can only be seen at the Scene tab, for debugging purposes  
                        Debug.DrawRay(hit.point, hit.normal * 3, Color.blue);
                        //represent the ray using a line that can only be viewed at the scene tab  
                        Debug.DrawRay(hit.point, inDirection * 100, Color.red);

                        //if the number of reflections is set to 1  
                        if (nReflections == 1)
                        {
                            //add a new vertex to the line renderer  
                            lineRenderer.SetVertexCount(++nPoints);
                        }

                        //set the position of the next vertex at the line renderer to be the same as the hit point  
                        lineRenderer.SetPosition(i + 1, hit.point);
                        hitPoints.Add(hit.point);
                    }
                }
                else // the ray has reflected at least once  
                {
                    //Check if the ray has hit something  
                    if (Physics.Raycast(ray.origin, ray.direction, out hit, 100))//cast the ray 100 units at the specified direction  
                    {
                        //the refletion direction is the reflection of the ray's direction at the hit normal  
                        inDirection = Vector3.Reflect(inDirection, hit.normal);
                        //cast the reflected ray, using the hit point as the origin and the reflected direction as the direction  
                        ray = new Ray(hit.point, inDirection);

                        //Draw the normal - can only be seen at the Scene tab, for debugging purposes  
                        Debug.DrawRay(hit.point, hit.normal * 3, Color.blue);
                        //represent the ray using a line that can only be viewed at the scene tab  
                        Debug.DrawRay(hit.point, inDirection * 100, Color.red);
                        
                        //add a new vertex to the line renderer  
                        lineRenderer.SetVertexCount(++nPoints);
                        //set the position of the next vertex at the line renderer to be the same as the hit point  
                        lineRenderer.SetPosition(i + 1, hit.point);
                        hitPoints.Add(hit.point);
                    }
                }
            }
        }
    }
}

