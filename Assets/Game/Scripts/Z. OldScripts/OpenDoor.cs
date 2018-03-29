using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    public GameObject[] tubes;
    public GameObject door;

    public Material greenTube;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TurnGreen()
    {
        foreach (GameObject tube in tubes)
        {
            Renderer rend = tube.GetComponent<Renderer>();
            tube.GetComponent<Renderer>().material = greenTube;
        }

       // door.
    }

}
