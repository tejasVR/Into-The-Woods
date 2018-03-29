using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour {

    public AudioSource[] audioSources;
    public float[] delyas;
    public bool isTriggered = false;
    private bool isDone;
    public VisionTrigger visionTrigger;

    public bool soundPlay;
    public bool soundStop;

	// Use this for initialization
	void Start () {

        
	}

    //If we want sound to play when visionTrigger is triggered
    private void Update()
    {
        if (visionTrigger != null)
        {
            if (visionTrigger.isTriggered)
            {
                if (!isTriggered)
                {
                    if (soundPlay)
                    {
                        for (int i = 0; i < audioSources.Length; i++)
                        {
                            audioSources[i].PlayDelayed(delyas[i]);
                        }
                    }

                    if (soundStop)
                    {
                        for (int i = 0; i < audioSources.Length; i++)
                        {
                            audioSources[i].Stop();
                        }
                    }
                    
                }
                isTriggered = true;
            }
        }
    }


    //More normal triggers associated with object
    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered)
        {
            if (soundPlay)
            {
                for (int i = 0; i < audioSources.Length; i++)
                {
                    audioSources[i].PlayDelayed(delyas[i]);
                }
            }

            if (soundStop)
            {
                for (int i = 0; i < audioSources.Length; i++)
                {
                    audioSources[i].Stop();
                }
            }
        }
        isTriggered = true;
    }
}
