using UnityEngine;
using System.Collections;

public class enemyspawner : MonoBehaviour {

    public GameObject thing_to_spawn;
    public float time_between_spawns;
    public float countdown;
    
    // Use this for initialization
	void Start () {
        countdown = time_between_spawns;
	}
	
	// Update is called once per frame
	void Update () {
        countdown = countdown - Time.deltaTime;
        if (countdown <= 0)
        {
            Instantiate(thing_to_spawn);
            countdown = time_between_spawns;
        }
	
	}
}
