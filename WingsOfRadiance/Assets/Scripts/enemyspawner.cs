using UnityEngine;
using System.Collections;
using System;

public class enemyspawner : MonoBehaviour {

    public GameObject enemymanager;
    public GameObject thing_to_spawn;
    public float time_between_spawns;
    public float countdown;
    public enum Movement_Pattern {forward, sine_wave, chase_player};
    public Movement_Pattern movement_switch;
    public string movement_pattern;
    public string sine_formula_x_string;//write out the vector3 x, y fields as a string.
    public string sine_formula_y_string;
    public float sine_formula_x_float;
    public float sine_formula_y_float;
    
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
            sine_formula_x_float = Convert.ToSingle(sine_formula_x_string);
            thing_to_spawn.GetComponent<EnemyBehaviour>().sine_formula_x = sine_formula_x_float;
            sine_formula_y_float = Convert.ToSingle(sine_formula_y_string);
            thing_to_spawn.GetComponent<EnemyBehaviour>().sine_formula_y = sine_formula_y_float;
            Debug.Log("Your sine floats are" + sine_formula_y_float + "," + sine_formula_y_float);
            GameObject.Instantiate (thing_to_spawn, this.transform.position, this.transform.rotation);
            countdown = time_between_spawns;
        }
	
	}
}
