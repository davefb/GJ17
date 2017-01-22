using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public Transform player;

	AudioSource[] click;
	public float bpm;
	float delta;
    float loopdelta;
	float nextTime = 0;
    float nextTimeLoop = 0;
    float delay = 2f;
    float cliptime = 8; int clipi = 0;
	// Use this for initialization
	void Start () {
        click = GetComponentsInChildren<AudioSource>();
		delta = 60.0f/bpm ;
        loopdelta = 60.0f / (4*bpm);
    }


    bool first = true;
	// Update is called once per frame
	void FixedUpdate () {

        if (Time.timeSinceLevelLoad  > nextTime + delay) {
   
            if (Time.timeSinceLevelLoad > cliptime *clipi + delay )
            {
                Debug.Log("Playing....");
//                click[0].Stop();
//                click[0].Play();
                clipi++;
            }

      //click[1].Stop();
      //      click[1].Play();
			nextTime += delta;
            //player.BroadcastMessage ("Tick");
//            GameObject.Find("Keys").BroadcastMessage("Tick");
//            player.root.BroadcastMessage("Tick");
            WallHitHandler.Tick();
            
        }

        //Debug.Log(Time.timeSinceLevelLoad + " " +  nextTime + " " + Time.timeSinceLevelLoad % cliptime);
	}
}
