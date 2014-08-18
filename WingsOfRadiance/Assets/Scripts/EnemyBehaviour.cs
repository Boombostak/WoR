using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public float speed;
    private Vector3 movement;
    private Vector3 spawnpoint;
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update () {
        
        movement = new Vector3(0, -speed * Time.deltaTime, 0);

        transform.Translate(movement);
        
        
        
	}
}
