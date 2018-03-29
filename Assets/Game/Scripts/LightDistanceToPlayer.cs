using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDistanceToPlayer : MonoBehaviour {

    public Light[] lights;
    public GameObject player; //camerEye object
    public float distanceToPlayer;
    public float startIntensity;

    private bool isLightOn = false;

	// Use this for initialization
	void Start () {
        //light = GetComponent<Light>();
        //startIntensity = light.intensity;
	}
	
	// Update is called once per frame
	void Update () {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        
        //if player is 50 units from light
		if (distanceToPlayer <= 50)
        {
            if (!isLightOn)
            {
                LightsEnabled();
            }
            foreach(Light light in lights)
            {
                light.intensity = startIntensity * ((50 - distanceToPlayer) / 50);
            }
            
        } else
        {
            LightsDisabled();
        }
	}

    public void LightsEnabled()
    {
        foreach (Light light in lights)
        {
            light.enabled = true;
        }
        isLightOn = true;
    }

    public void LightsDisabled()
    {
        foreach (Light light in lights)
        {
            light.enabled = false;
        }
        isLightOn = false;
    }
}
