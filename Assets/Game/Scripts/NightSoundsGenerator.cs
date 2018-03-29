using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightSoundsGenerator : MonoBehaviour {

    public GameObject cricket1;
    public GameObject cricket2;
    public GameObject fox1;
    public GameObject owl1;
    public GameObject leavesRustle1;

    public GameObject cameraRig;

    private float cricket1Timer;
    private float cricket2Timer;
    private float fox1Timer;
    private float owl1Timer;
    private float leavesRustle1Timer;




    // Use this for initialization
    void Start () {

        // Properties for when the sound first plays. Where would it be in world space, what is the delay
        RandomCoordinates(cricket1, -15, -3, 3, 15, .5f, Random.Range(1, 5));
        RandomCoordinates(cricket2, -15, -3, 3, 15, .5f, Random.Range(1, 5));
        RandomCoordinates(fox1, -60, -50, 50, 60, .5f, Random.Range(30, 60));
        RandomCoordinates(owl1, -15, -10, 10, 15, 10f, Random.Range(5, 15));
        RandomCoordinates(leavesRustle1, -7, -5, 5, 7, 0f, Random.Range(30, 60));



        cricket1Timer = RandomTimer(cricket1Timer, 10, 30);
        cricket2Timer = RandomTimer(cricket2Timer, 10, 30);
        fox1Timer = RandomTimer(fox1Timer, 50, 70);
        owl1Timer = RandomTimer(owl1Timer, 50, 70);
        leavesRustle1Timer = RandomTimer(leavesRustle1Timer, 30, 50);
    }

    // Update is called once per frame
    void Update () {
        cricket1Timer = SoundCountdown(cricket1, cricket1Timer, 10, 30, // Timer Properties
            -15, -3, 3, 15, .5f,                                        // Random Coordinates
            Random.Range(1,5));                                         // Sound Delay
        cricket2Timer = SoundCountdown(cricket2, cricket2Timer, 10, 30, 
            -15, -3, 3, 15, .5f, 
            Random.Range(1, 5));

        fox1Timer = SoundCountdown(fox1, fox1Timer, 50, 70, 
            -60, -50, 50, 60, .5f, 
            Random.Range(30, 60));

        owl1Timer = SoundCountdown(owl1, owl1Timer, 50, 70, 
            -15, -10, 10, 15, .5f, 
            Random.Range(10, 15));

        leavesRustle1Timer = SoundCountdown(leavesRustle1, leavesRustle1Timer, 30, 50,
           -7, -5, 5, 7, 0f, 
           0f);
    }

    public void RandomCoordinates(GameObject gameObject, float minRandLow, float maxRandLow, float minRandHigh, float maxRandHigh, float yPos, float soundDelay)
    {

        int coinFlip = Mathf.FloorToInt(Random.Range(0, 4));


        float randXLow = Random.Range(minRandLow, maxRandLow);
        float randXHigh = Random.Range(minRandHigh, maxRandHigh);
        float randZLow = Random.Range(minRandLow, maxRandLow);
        float randZHigh = Random.Range(minRandLow, maxRandLow);

        Vector3 randomCoordinates;

        if (coinFlip == 0) { randomCoordinates = cameraRig.transform.position + new Vector3(randXLow, yPos, randZLow); }
        else if (coinFlip == 1) { randomCoordinates = cameraRig.transform.position + new Vector3(randXLow, yPos, randZHigh); }
        else if (coinFlip == 2) { randomCoordinates = cameraRig.transform.position + new Vector3(randXHigh, yPos, randZHigh); }
        else { randomCoordinates = cameraRig.transform.position + new Vector3(randXHigh, yPos, randZLow); }

        gameObject.transform.position = randomCoordinates;
        SoundPlay(gameObject, soundDelay);

    }

    public float SoundCountdown(GameObject gameObject, float timer, float minTimer, float maxTimer, //Timer properties
        float minRandLow, float maxRandLow, float minRandHigh, float maxRandHigh, float yPos, // ransom coordinate properties
        float soundDelay) // Sound delay properties
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //Debug.Log("timer is zero");
            timer = RandomTimer(timer, minTimer, maxTimer);
            RandomCoordinates(gameObject, minRandLow, maxRandLow, minRandHigh, maxRandHigh, yPos, soundDelay);
        }
        return timer;
    }

    public float RandomTimer(float timer, float minTimer, float maxTimer)
    {
        timer = Random.Range(minTimer, maxTimer);
        return timer;
    }

    public void SoundPlay(GameObject gameObject, float soundDelay)
    {
        gameObject.GetComponent<AudioSource>().PlayDelayed(soundDelay);
    }
}
