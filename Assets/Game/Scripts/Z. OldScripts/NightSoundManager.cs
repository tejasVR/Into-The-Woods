using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightSoundManager : MonoBehaviour {

    public AudioSource[] nightSounds;
    public GameObject player; //camerEye object
    public bool nightStart;

    // Use this for initialization
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {



    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            StartNight();
        }
    }

    public void StartNight()
    {
        foreach(AudioSource nightSound in nightSounds)
        {
            float random = Random.Range(0, 3000);
            ulong delay = (ulong)random;
            nightSound.Play(delay);
            //daySound.
        }

        /*float dayVolume = 1;
        while (dayVolume < 100)
        {
            //Debug.Log("Fade day");
            dayVolume += Time.deltaTime;
            foreach (AudioSource daySound in daySounds)
            {
                daySound.volume = daySound.volume / dayVolume;
            }

            if (dayVolume == 100)
            {
                foreach (AudioSource daySound in daySounds)
                {
                    daySound.Stop();
                }
            }
        }*/
    }
}
