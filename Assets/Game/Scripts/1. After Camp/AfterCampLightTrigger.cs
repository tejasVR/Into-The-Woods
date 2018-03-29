using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterCampLightTrigger : MonoBehaviour {

    public GameObject lampPostCurrent;
    public GameObject lampPostNext;

    private AudioSource audio;
    public AudioClip lightOn;
    public AudioClip lightOff;

    public float duration;

    public bool isTriggered = false;
    public bool isDone = false;

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
                audio.PlayOneShot(lightOn);
                lampPostNext.SetActive(true);
                isDone = true;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        lampPostCurrent.SetActive(false);
        audio.PlayOneShot(lightOff);
        isTriggered = true;
       

    }
}
