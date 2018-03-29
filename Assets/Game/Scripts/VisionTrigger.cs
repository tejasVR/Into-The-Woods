using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VisionTrigger : MonoBehaviour {

    public VisionManager visionManager;
    public float duration;
    public bool isTriggered = false;
    public bool isDone = false;

    private AudioSource audio;
    public AudioClip clip;

    public GameObject[] appearObjects;

    public GameObject visionTextObject;
    public string visionText;


    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();

        if (appearObjects != null)
        {
            foreach (GameObject appearObject in appearObjects)
            {
                appearObject.SetActive(false);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (isTriggered)
        {
            duration -= Time.deltaTime;
            if (duration <= 0)
            {
                visionManager.Normal();
                audio.Stop();

                if (appearObjects != null)
                {
                    foreach (GameObject appearObject in appearObjects)
                    {
                        appearObject.SetActive(false);
                    }
                }

                visionTextObject.GetComponent<TextMeshPro>().text = "";
                visionTextObject.SetActive(false);

                isDone = true;
            }
        }

        if (isDone)
        {
            this.gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //if (!isTriggered)
        {
            visionManager.Vision();
            audio.PlayOneShot(clip);
            if (appearObjects != null)
            {
                foreach (GameObject appearObject in appearObjects)
                {
                    appearObject.SetActive(true);
                }
            }
            visionTextObject.SetActive(true);
           
            visionTextObject.GetComponent<TextMeshPro>().text = visionText;
            isTriggered = true;
        }
    }

}
