using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonVRCameraMove : MonoBehaviour {

    public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
	}
}
