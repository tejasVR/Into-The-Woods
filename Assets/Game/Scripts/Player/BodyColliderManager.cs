using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyColliderManager : MonoBehaviour {

    private Rigidbody rb;
    public GameObject player;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

        //transform.position = player.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //rb.MovePosition(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
		
	}
}
