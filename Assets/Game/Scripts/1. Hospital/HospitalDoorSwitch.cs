using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalDoorSwitch : MonoBehaviour {

    public GameObject glowLight;
    public GameObject door;
    private Animator animator;
    public Light switchLight;
    public float switchPower = 0;
    public bool isPowered;

	// Use this for initialization
	void Start () {
        //switchLight = GetComponent<Light>();
        isPowered = false;
        //switchLight.color = Color.green;

    }

    // Update is called once per frame
    void Update () {

        if (Vector3.Distance(transform.position, glowLight.transform.position) < .2 && isPowered == false)
        {
            switchPower += .1f;
            
            
        }

        if (switchPower >= 100 && isPowered == false)
        {
            animator = door.GetComponent<Animator>();
            animator.SetTrigger("DoorTrigger");
            //Debug.Log("door opened");
            //switchLight.color = Color.green;

            isPowered = true;

        }

        if (0 > switchPower || switchPower >= 50 && switchPower < 51)
        {
            float t = switchPower / 50;
            switchLight.color = Color.Lerp(Color.red, Color.yellow, t);
        }

        if (50 > switchPower && switchPower >= 100)
        {
            float t = switchPower / 100;
            switchLight.color = Color.Lerp(Color.yellow, Color.green, t);
        }



    }
}
