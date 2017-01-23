using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public Transform player;
    public Canvas winMessage;

    AudioSource[] click;
    public float bpm;
    float delta;
    float loopdelta;
    float nextTime = 0;
    float nextTimeLoop = 0;
    float delay = 2f;
    float cliptime = 8; int clipi = 0;

    int loadedlevel=1;

    // Use this for initialization
    void Start() {
        //DontDestroyOnLoad(gameObject);
        click = GetComponentsInChildren<AudioSource>();
        delta = 60.0f / bpm;
        loopdelta = 60.0f / (4 * bpm);
    }


    bool first = true;
    // Update is called once per frame
    void FixedUpdate() {

        if (Time.timeSinceLevelLoad > nextTime + delay) {

            if (Time.timeSinceLevelLoad > cliptime * clipi + delay)
            {
                Debug.Log("Playing....");
                click[0].Stop();
                click[0].Play();
                clipi++;
            }

            //click[1].Stop();
            //      click[1].Play();
            nextTime += delta;
            //player.BroadcastMessage ("Tick");
            GameObject.Find("Keys").BroadcastMessage("Tick");
            player.root.BroadcastMessage("Tick");
            WallHitHandler.Tick();

            GameObject go = GameObject.Find("Keys");
            if (go != null)
            {
                bool gameover = true;
                foreach (KeyHitHandler khh in go.GetComponentsInChildren<KeyHitHandler>()) {
                    gameover &= (khh.currentState == KeyHitHandler.State.HIT);
                }
                if (gameover)
                {
                    Debug.Log("YOU WINN!!");
                    if (!isQuitting) {
                        isQuitting = true; 
                      StartCoroutine(QuitAfterDelay());
                    }
                }
            }
            else
            {
                Debug.LogAssertion("Can't find keys!");
            }

        }

        //Debug.Log(Time.timeSinceLevelLoad + " " +  nextTime + " " + Time.timeSinceLevelLoad % cliptime);
    }
    bool isQuitting = false;
    IEnumerator QuitAfterDelay()
    {
        winMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(10);
        loadedlevel += 1;
       ;

        SceneManager.LoadScene("Level_" + (SceneManager.GetActiveScene().buildIndex + 2));
        // move on 
    }
}
