using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSoundMove : MonoBehaviour {

    public SoundTrigger soundTrigger;
    private AudioClip clip;
    public float soundSpeed;
    public float duration;

	// Use this for initialization
	void Start () {
        clip = GetComponent<AudioSource>().clip;
        duration = clip.length;

	}
	
	// Update is called once per frame
	void Update () {
        if (soundTrigger.isTriggered)
        {
            transform.Translate(0, 0, 1 * soundSpeed * Time.deltaTime);

            duration -= Time.deltaTime;

            if (duration <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
