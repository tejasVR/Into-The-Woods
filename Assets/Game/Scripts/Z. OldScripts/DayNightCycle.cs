using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

    public float sunSpeed;
    public float sunLightDim;
    private Light sunLight;

	// Use this for initialization
	void Start () {
        sunLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        //transform.RotateAround(Vector3.zero, Vector3.right, 10f*Time.deltaTime);
        //transform.LookAt(Vector3.zero);


        //transform.rotation.eulerAngles.x 

        transform.Rotate(Time.deltaTime * sunSpeed, 0, 0);

        sunLight.intensity -= Time.deltaTime * sunLightDim;

	}
}
