using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampDialogue : MonoBehaviour {

    public AudioClip[] clips;
    public TalkieManager playerTalkie;

    public ButtonDialogueTriggers buttonTriggers;
    //public DayNightManager dayNightManager;

    //public float clip0Timer = 5;

    public bool[] clipPlayed;

    //public bool clip0Played; //hey is this thing on...

    //public bool clip1Played; //mic must be broken...


   // public bool clip2Played; //did you remember your flashlight...

    //public bool clip3Played; //glad your memory is coming back...

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        /*if (clip0Played == false)
        {
            clip0Timer -= Time.deltaTime;

            if (clip0Timer <= 0)
            {
                playerTalkie.PlayClip(clips[0]);
                clip0Played = true;
            }
        }

        //After first clip is played, trigger is no pressed, and second clip has not played yet
        if (clip0Played && buttonTriggers.leftGrip && !clip1Played)
        {
            playerTalkie.audio.Stop();

            playerTalkie.PlayClip(clips[1]);
            clip1Played = true;
        }

        if (clip1Played && dayNightManager.sunLight.intensity <= .2 &&  !clip2Played)
        {
            playerTalkie.audio.Stop();

            playerTalkie.PlayClip(clips[2]);
            clip2Played = true;
        }

        if (clip2Played && buttonTriggers.rightTouchpad && !clip3Played)
        {
            playerTalkie.audio.Stop();

            playerTalkie.PlayClip(clips[3]);
            clip3Played = true;
            this.GetComponent<CampDialogue>().enabled = false; //we are done with all the dialogue in this scene and we will become inactive
        }*/
	}

    public void ClipPlay(int clipIndex)
    {
        playerTalkie.PlayClip(clips[clipIndex]);
        clipPlayed[clipIndex] = true;
    }

}
