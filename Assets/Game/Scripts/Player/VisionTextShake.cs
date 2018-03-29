using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionTextShake : MonoBehaviour {

    public float minRangX;
    public float maxRangX;

    public float minRangY;
    public float maxRangY;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var randX = Random.Range(minRangX, maxRangX);
        var randY = Random.Range(minRangY, maxRangY);

        transform.localPosition = new Vector3(randX, randY, 1);

    }
}
