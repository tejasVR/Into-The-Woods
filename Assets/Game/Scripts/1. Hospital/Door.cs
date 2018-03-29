using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public bool isLocked;

	// Use this for initialization
	void Start () {
        isLocked = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Unclock()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
