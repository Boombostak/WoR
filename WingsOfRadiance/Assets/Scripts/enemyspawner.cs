﻿using UnityEngine;
using System.Collections;

public class enemyspawner : MonoBehaviour {

    public GameObject enemymanager;
    public GameObject thing_to_spawn;
    public float time_between_spawns;
    public float countdown;
    
    // Use this for initialization
	void Start () {
        countdown = time_between_spawns;
        enemymanager = GameObject.FindGameObjectWithTag("enemymanager");
	}
	
	// Update is called once per frame
	void Update () {
        countdown = countdown - Time.deltaTime;
        if (countdown <= 0)
        {
            thing_to_spawn = enemymanager.GetComponent<EnemyManagerGO>().SpawnAnEnemy(this.transform);
            GameObject.Instantiate (thing_to_spawn, this.transform.position, this.transform.rotation);
            countdown = time_between_spawns;
        }
	
	}
}
