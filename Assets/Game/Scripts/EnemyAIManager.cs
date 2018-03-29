using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIManager : MonoBehaviour {

    public GameObject flashlight; //
    public GameObject cameraRig;
    public GameObject enemy;
    private Collider checkCapsule; //The collider that checks the enemy spawns in a collision-free zone
    public GameObject capsuleCheckObject; //The object that checks the enemy spawns outside the player's field of view

    public bool isActive;
    public bool isFollowing;
    public bool isTriggered;
    public bool canFit;

    public float distanceFromPlayer;

    public float appearTimer;
    public float angleToLight;
    public float angleInLightViewMin;
    public float angleInLightViewMax;

    //public float angleNotInLightViewMin;
    //public float angleNotInLightViewMax;

    Vector3 rayDirection;
    Vector3 rayGetPoint;

    public bool rayCast;

    public Ray enemyRay;

    public bool isLookedAt = false;

    //public float randXLow;
    //public float randXHigh;
    //public float randZLow;
    //public float randZHigh;


    // Use this for initialization
    void Start () {
        enemy.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        appearTimer -= Time.deltaTime;
        if (appearTimer < 0 && !isTriggered)
        {
            appearTimer = 0;
            isTriggered = true;
        }

        distanceFromPlayer = Vector3.Distance(cameraRig.transform.position, enemy.transform.position);

        angleToLight = Vector3.Dot(rayDirection, flashlight.transform.forward);
        enemy.transform.LookAt(cameraRig.transform.position);

        // If the action to scare to the player is not triggered, and we have not yet cast a ray
        if (isTriggered)
        {
            if (!canFit && !rayCast)
            {
                FlashlightRay();
            } else
            {
                rayCast = true;
            }

            if (canFit && Vector3.Dot(rayDirection, flashlight.transform.forward) > 0.8f)
            {
                enemy.gameObject.SetActive(true);
                enemy.transform.position = rayGetPoint;
                isActive = true;
            }
        }

        if (isActive && angleToLight > .8f)
        {
            isLookedAt = true;
        }

        if (isLookedAt && angleToLight < .7f)
        {
            enemy.gameObject.SetActive(false);
            isActive = false;
            isTriggered = false; //end of triggered actions
            isLookedAt = false;
            
        }
    }

    public void RandomCoordinates(float minRandLow, float maxRandLow, float minRandHigh, float maxRandHigh)
    {
        if (!isActive)
        {
            int coinFlip = Mathf.FloorToInt(Random.Range(0, 4));


            float randXLow = Random.Range(minRandLow, maxRandLow);
            float randXHigh = Random.Range(minRandHigh, maxRandHigh);
            float randZLow = Random.Range(minRandLow, maxRandLow);
            float randZHigh = Random.Range(minRandLow, maxRandLow);

            Vector3 randomCoordinates;

            if (coinFlip == 0) { randomCoordinates = cameraRig.transform.position + new Vector3(randXLow, capsuleCheckObject.transform.position.y, randZLow); }
            else if (coinFlip == 1) { randomCoordinates = cameraRig.transform.position + new Vector3(randXLow, capsuleCheckObject.transform.position.y, randZHigh); }
            else if (coinFlip == 2) { randomCoordinates = cameraRig.transform.position + new Vector3(randXHigh, capsuleCheckObject.transform.position.y, randZHigh); }
            else { randomCoordinates = cameraRig.transform.position + new Vector3(randXHigh, capsuleCheckObject.transform.position.y, randZLow); }

            //randomCoordinates = cameraRig.transform.position + new Vector3(randXLow, capsuleCheckObject.transform.position.y, randZLow);

            //Vector3 playerPosition = cameraRig.transform.position; //Get player's position

            //creates random position from player's current position
            //Vector3 randomPosition = new Vector3(player.transform.position.x + Random.Range(-10, 10), transform.position.y, player.transform.position.z + Random.Range(-10, 10));

            //Check if there is a capsule object can be placed collision-free at the random position point

            if (!Physics.CapsuleCast(randomCoordinates, new Vector3(randomCoordinates.x, randomCoordinates.y, randomCoordinates.z), .97f, transform.forward, 0))
            {
                //capsuleCheckObject.transform.position = randomCoordinates;
                //capsuleCheckObject.transform.LookAt(cameraRig.transform.position);
                isActive = true;
                enemy.gameObject.SetActive(true);
                enemy.transform.position = randomCoordinates;
                enemy.transform.LookAt(cameraRig.transform.transform.position);
                Debug.Log("Capsulecast");
            }

            /*if (Physics.CheckCapsule(new Vector3(randomCoordinates.x, capsuleCheckObject.transform.position.y, randomCoordinates.z), randomCoordinates, .97f))
            {
                //To check that the enemy will spawn  outside of the player's field of view, spawn in the location, and face the player
                

                enemy.gameObject.SetActive(true);
                enemy.transform.position = transform.position;
                enemy.transform.LookAt(cameraRig.transform.position);


                //isActive = true;
                //If the random position is outside the player's field of view and collision-free, spawn enemy
                /*if (angleInLightViewMin > angleToLight && angleToLight < angleInLightViewMax)
                {
                    //transform.position = randomCoordinates;
                    enemy.transform.position = transform.position;
                    enemy.gameObject.SetActive(true);
                    //Debug.Log("I Am Collision Free!!");
                    enemy.transform.LookAt(cameraRig.transform.position);
                    //appearTimer = 4;
                   
                }
            }*/



        }
        //Debug.Log(appearTimer);








    }

    public void FlashlightRay()
    {
        if (!canFit)
        {
            RayPointCreate();
            //Debug.Log("Checking");
            // If there is an overlap in colliders...
            if (EnemyCanFit(rayGetPoint, new Vector3(rayGetPoint.x, 2f, rayGetPoint.z), .97f))
            {
                rayDirection = enemyRay.direction;
                capsuleCheckObject.transform.position = rayGetPoint;
                canFit = true;
            } else
            {
                capsuleCheckObject.transform.position = rayGetPoint;
            }
        }
    }

    public bool EnemyCanFit (Vector3 startPt, Vector3 endPt, float width)
    {
        //Debug.Log(Physics.CheckCapsule(startPt, endPt, width));
        return Physics.CheckCapsule(startPt, endPt, width);
    }

    public void RayPointCreate()
    {
        Vector3 rayRandomDirection;

        int coinFlip = Mathf.FloorToInt(Random.Range(0, 2));

        if (coinFlip == 0) { rayRandomDirection = Quaternion.AngleAxis(Random.Range(70, 90), transform.up) * flashlight.transform.forward; }
        else { rayRandomDirection = Quaternion.AngleAxis(Random.Range(250, 270), transform.up) * flashlight.transform.forward; }

        //Create a beginning ray in a random direction
        enemyRay = new Ray(flashlight.transform.position, rayRandomDirection);

        //Get a point along this ray, now we need to see if this space is clear of colliders
        rayGetPoint = enemyRay.GetPoint(Random.Range(5, 7));
        rayGetPoint.y = 0;
    }
}
