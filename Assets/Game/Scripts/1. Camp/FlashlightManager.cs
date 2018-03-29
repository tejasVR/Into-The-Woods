using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightManager : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;

    public Light[] lights;


    public GameObject flashlightPickup;
    public bool hasFlashLight;

    public GameObject flashlightModel;
    public GameObject handModel;

    public bool isLightOn;

    public AudioClip clickUp;
    public AudioClip clickDown;
    public AudioSource audio;

	// Use this for initialization
	void Start () {
        //handModel.SetActive(true);
        flashlightModel.SetActive(true);

        foreach (Light light in lights)
        {
            light.enabled = false;
        }

        isLightOn = false;

        hasFlashLight = true;

    }
	
	// Update is called once per frame
	void Update () {
        device = SteamVR_Controller.Input((int)trackedObj.index);


        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && hasFlashLight)
        {
            LightManager();
        }
	}

    private void OnTriggerStay(Collider other)
    {
        /*if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            if (other.gameObject == flashlightPickup)
            {
                hasFlashLight = true;
                flashlightModel.SetActive(true);
                handModel.SetActive(false);
                Destroy(other.gameObject);
                //other.gameObject.SetActive(false);
            }
        }*/
    }

    public void LightManager()
    {
        if (!isLightOn)
        {
            foreach (Light light in lights)
            {
                light.enabled = true;
            }
           
            audio.PlayOneShot(clickUp);
            isLightOn = true;
        }
        else
        {
            foreach (Light light in lights)
            {
                light.enabled = false;
            }
           
            audio.PlayOneShot(clickDown);
            isLightOn = false;

        }
    }

}
