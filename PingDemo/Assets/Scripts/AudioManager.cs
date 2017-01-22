using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public Transform player;
	AudioSource click;
	public float bpm;
	float delta;
	float nextTime = 0;
	// Use this for initialization
	void Start () {
		click = GetComponent<AudioSource> ();
		delta = bpm ;
	}



	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad  > nextTime/60.0f) {
			//click.PlayOneShot (click.clip);
			nextTime += delta;
			player.BroadcastMessage ("Tick");
			WallHitHandler.Tick ();
		}


	}
}
