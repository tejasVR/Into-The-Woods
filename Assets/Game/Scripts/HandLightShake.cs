using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLightShake : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;

    //public GameObject rigEye;

    public Light light;

    public bool isLight;

    public float shakeThreshold;
    public float maxIntensity;
    public float maxRange;

    public float shakeAddIntensity;
    public float shakeAddRange;

    public float reduceIntensity;
    public float reduceRange;

    //public GameObject humSound;
    //private AudioSource audioSource;

    //public AudioClip clickDown;
    //public AudioClip clickUp;
    //public AudioClip lightHum;


    // Use this for initialization
    void Start()
    {
        //light = GetComponent<Light>();
        light.enabled = true;

        light.intensity = 0;
        light.range = 0;

        isLight = true;

        //audioSource = humSound.GetComponent<AudioSource>();

        //audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {

        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);

        //Debug.Log(trackedObj);

        //Debug.Log(device.angularVelocity);

        //Controller Shakle for Light
        if (device.velocity.magnitude >= shakeThreshold)
        {
            light.intensity = Mathf.Lerp(light.intensity, light.intensity + shakeAddIntensity, Time.deltaTime);
            isLight = true;
            light.range = Mathf.Lerp(light.range, light.range + shakeAddRange, Time.deltaTime);

            if (light.intensity >= maxIntensity)
            {
                light.intensity = maxIntensity;
            }

            if (light.range >= maxRange)
            {
                light.range = maxRange;
            }

        }
        else
        {
            light.intensity -= reduceIntensity;
            light.range -= reduceRange;
            isLight = false;
        }

        //audioSource.volume = light.intensity / 5;

        ////Touchpad CLick for Light
        /*if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            AudioSource.PlayClipAtPoint(clickDown, transform.position);

            if (isLight == false)
            {
                light.enabled = true;
                rigEye.GetComponent<Grayscale>().enabled = false;
                audioSource.Play();
                //AudioSource.PlayClipAtPoint(lightHum, transform.position);
                //audioSource.loop
                //Debug.Log("Light on");
            }

            if (isLight == true)
            {
                light.enabled = false;
                rigEye.GetComponent<Grayscale>().enabled = true;
                audioSource.Stop();

                //Debug.Log("Light off");
            }
        }

        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            AudioSource.PlayClipAtPoint(clickUp, transform.position);

            if (light.enabled == true)
            {
                isLight = true;

                //Debug.Log("Yes isLight");

            }

            if (light.enabled == false)
            {
                isLight = false;

                //Debug.Log(" Not isLight");

            }

        }*/


        /*if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && isLight == true)
        {
            light.enabled = false;

            //if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
            //{
                isLight = false;
            //}

            Debug.Log("Light off");

        }*/



        /*}
        else if (isLight == true)
        {
            light.enabled = false;
            */
    }
}
