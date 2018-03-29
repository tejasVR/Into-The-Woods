using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour {

    public CampDialogue campDialogue;

    public GameObject player; //camerEye object

    public AudioSource[] daySounds;
    public bool dayFade;

    public AudioSource[] nightSounds;
    public bool nightStart;

    public Terrain terrain;
    public int newTreeDistance;
    public int newDetailDistance;

    public Light sunLight;
    public float sunSpeed; //how fast the sun will rotate
    public float sunLightDim; //how fast the sun will dim

    // Use this for initialization
    void Start () {

        foreach (AudioSource daySound in daySounds)
        {
            daySound.Play();
            //daySound.
        }
    }

    // Update is called once per frame
    void Update () {

        //If the player is past a certain point in the game, start transitioning between day and night
        /*if (campDialogue.clip1Played)
        {
            sunLight.intensity -= Time.deltaTime * sunLightDim;
            sunLight.transform.Rotate(Time.deltaTime * sunSpeed, 0, 0);
        }*/

        if (sunLight.intensity <= .2 && dayFade == false)
        {
            FadeDaySounds();
            StartNightSounds();
            

            //sunLight.enabled = false;
            dayFade = true;
        }

        if (sunLight.intensity <= 0)
        {
            TerrainChange();
            sunLight.enabled = false;
        }

    }

    /*public void OnTriggerEnter(Collider other)
    {
        
        
        if (other.gameObject == player)
        {
            
        }
    }*/

    public void FadeDaySounds()
    {
        //float volume -= Time.deltaTime;

        foreach (AudioSource daySound in daySounds)
        {
            daySound.Stop();
        }
    }
    public void StartNightSounds()
    {
        foreach (AudioSource nightSound in nightSounds)
        {
            float random = Random.Range(3000, 15000);
            ulong delay = (ulong)random;
            nightSound.Play(delay);
            //daySound.
        }
    }

    public void TerrainChange()
    {
        terrain.treeDistance = newTreeDistance;
        terrain.detailObjectDistance = newDetailDistance;
    }
 }
