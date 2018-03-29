using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CampCutScene : MonoBehaviour {

    public float speedDown;
    public float speedForward;
    public float speedTurn;

    public float sceneTimer;
    //public int secondsToSceneChange;
    public Scene nextScene;

    public VisionTrigger visionTrigger;
    public GameObject creditText;

    public Light sunLight;

    public float duration;

	// Use this for initialization
	void Start () {
        duration = visionTrigger.duration;
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(0, -1 * speedForward, -1 * speedDown);

        if (visionTrigger.isTriggered)
        {
            creditText.SetActive(false);
            sunLight.color = Color.black;
        }
        if (visionTrigger.isDone)
        {
            duration -= Time.deltaTime;
            if (duration <= 0)
            {
                SceneManager.LoadSceneAsync(1, LoadSceneMode.Single); //Load camp scene after vision trigger
            }
        }
       
	}

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, 1 * speedTurn);
        transform.Translate(0, 0, -1 * speedDown);
    }
}
