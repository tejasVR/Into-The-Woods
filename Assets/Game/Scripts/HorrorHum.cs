using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorHum : MonoBehaviour {

    public float humTimer;
    public float humFrequency; //the time in seconds of how frequent the horror hum should play

    public AudioSource audio;

    //public GameObject player; //the cameraHead in the scene

	// Use this for initialization
	void Start () {

        AudioSource audio = GetComponent<AudioSource>();
        //humTimer = humFrequency;
		
	}
	
	// Update is called once per frame
	void Update () {

        //transform.position = player.transform.position;

        humTimer -= Time.deltaTime;
        if (humTimer <= 0f)
        {
            audio.Play();
            humTimer = humFrequency;
        }
		
	}
}
