using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CampLightTrigger : MonoBehaviour {

    public GameObject lampPost;
    private AudioSource audio;
    public GameObject flashLight;

    public bool isTriggered = false;
    public bool isDone;
    public float duration;

    //public GameObject cameraRig; //whole camera Rig to move

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (isTriggered && !isDone)
        {
            duration -= Time.deltaTime;
            if (duration <= 0)
            {
                SceneManager.LoadScene("3. AfterCamp", LoadSceneMode.Single);
                isDone = true;
            }
        }
		
	}

    private void OnTriggerEnter(Collider other)
    {
        lampPost.SetActive(false);
        audio.Play();
        flashLight.SetActive(false);

        isTriggered = true;
    }
}
