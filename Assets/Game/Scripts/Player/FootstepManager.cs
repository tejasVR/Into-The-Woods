using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour {

    public GameObject startPos;

    public GameObject cameraEye;

    public AudioSource audioSource;

    public AudioClip[] footSteps;

    public float distance;

    public float walkPoint;

    /*
    public AudioClip foot1;
    public AudioClip foot2;
    public AudioClip foot3;
    public AudioClip foot4;
    */

    public bool ifStep;

    // Use this for initialization
    void Start()
    {

        startPos.transform.position = transform.position;
        ifStep = false;

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(cameraEye.transform.position.x, 0f, cameraEye.transform.position.z);

        distance = Vector3.Distance(transform.position, startPos.transform.position);

        if (distance > walkPoint)
        {
            //footStep();
            startPos.transform.position = transform.position;
            audioSource.clip = footSteps[Random.Range(0, footSteps.Length)];
            audioSource.Play();

        }

    }
}
