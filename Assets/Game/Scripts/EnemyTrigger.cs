using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour {

    private EnemyAIManager enemyAIManager;
    private bool isTriggered;

	// Use this for initialization
	void Start () {
        enemyAIManager = GameObject.Find("EnemyAIManager").GetComponent<EnemyAIManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered)
        {
            //triggers enemyAIManager, then triggers itself so it can't be called again
            enemyAIManager.isTriggered = true;
            isTriggered = true;
        }
    }
}
