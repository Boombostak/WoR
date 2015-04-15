using UnityEngine;
using System.Collections;
using System;

public class enemyspawner : MonoBehaviour {

    public GameObject enemymanager;
    public GameObject thing_to_spawn;

    public float time_between_spawns;
    public int number_to_spawn;
    public float countdown;

    public enum Movement_Pattern {forward, sine_wave, chase_player};
    public Movement_Pattern movement_switch;

    public string movement_pattern;
    public float sineamplitude;
    public float speed_multiplier=1;
    
    // Use this for initialization
	void Start () {
        countdown = time_between_spawns;
        enemymanager = GameObject.FindGameObjectWithTag("enemymanager");
        Debug.Log("Your enemymanager is" + enemymanager);

        
        switch (movement_switch)
        {
            case Movement_Pattern.forward: movement_pattern = "forward";
                break;
            case Movement_Pattern.sine_wave: movement_pattern = "sine_wave";
                break;
            case Movement_Pattern.chase_player : movement_pattern = "chase_player";
                break;
            default :Debug.Log("No movement pattern!!!");
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        countdown = countdown - Time.deltaTime;
        if (countdown <= 0)
        {
            thing_to_spawn = enemymanager.GetComponent<EnemyManagerGO>().SpawnAnEnemy(this.transform);
            thing_to_spawn.GetComponent<EnemyBehaviour>().movement_pattern_string = movement_pattern;
            thing_to_spawn.GetComponent<EnemyBehaviour>().sineamplitude = sineamplitude;
            thing_to_spawn.GetComponent<EnemyBehaviour>().speed_multiplier = speed_multiplier;
            GameObject.Instantiate (thing_to_spawn, this.transform.position, thing_to_spawn.transform.rotation);
            countdown = time_between_spawns;
        }
	
	}
}
