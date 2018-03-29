using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtonOpen : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        device = SteamVR_Controller.Input((int)trackedObj.index);
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "doorButton")
        {
            other.GetComponent<OpenDoor>();
        }
    }
}
