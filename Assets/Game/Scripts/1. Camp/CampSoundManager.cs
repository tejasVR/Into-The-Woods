using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampSoundManager : MonoBehaviour {

    public AudioSource[] nightSounds;

	// Use this for initialization
	void Start () {

        foreach(AudioSource nightSound in nightSounds)
        {
            //float random = Random.Range(3000, 15000);
            //ulong delay = (ulong)random;
            nightSound.PlayDelayed(Random.Range(0, 20));
        }
		
	}
}
