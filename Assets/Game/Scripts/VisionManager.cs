using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class VisionManager : MonoBehaviour {

    //public SteamVR_TrackedObject trackedObj;
    //private SteamVR_Controller.Device device;

    public PostProcessingProfile normal;
    public PostProcessingProfile vision;

    public GameObject player;
    //public GameObject visionText;

    

   

	// Use this for initialization
	void Start () {
        //var test = player.GetComponent<PostProcessingBehaviour>().profile;

        /*if (visionText != null)
        {
            visionText.SetActive(false);
        }*/
    }
	
	// Update is called once per frame
	void Update () {
        /*device = SteamVR_Controller.Input((int)trackedObj.index);
		if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Vision();
        }
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            Normal();
        }*/
	}

    public void Vision()
    {
        player.GetComponent<PostProcessingBehaviour>().profile = vision;
        /*if (visionText != null)
        {
            visionText.SetActive(true);
        }*/
    }

    public void Normal()
    {
        player.GetComponent<PostProcessingBehaviour>().profile = normal;
    }
}
