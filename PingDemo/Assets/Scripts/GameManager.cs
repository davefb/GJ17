using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool nextLevel;
    int levelInt;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (nextLevel == true)
        {
            //SceneM.LoadLevel("Level_" + levelInt);
            nextLevel = false;
        }
	}
    
}
