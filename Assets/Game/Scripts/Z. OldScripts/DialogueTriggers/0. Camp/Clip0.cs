using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clip0 : MonoBehaviour {

    public CampDialogue campDialogue;
    public GameObject player; //camera eye

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collision");
        if (other.gameObject == player)
        {
            campDialogue.ClipPlay(0);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.SetActive(false);
    }
}
