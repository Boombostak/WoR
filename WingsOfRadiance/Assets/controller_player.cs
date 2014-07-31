using UnityEngine;
using System.Collections;

public class controller_player : MonoBehaviour {

//Movement
    public float speed;
    private float x_dir;
    private float y_dir;
    private Vector3 movement;
    public  float diagonal_modifier;
    public bool analogue;

//Shooting
    public float fire_rate;

// Use this for initialization
	void Start () {
        
	}
	
// Update is called once per frame
	void Update () {
//Move the player based on analogue input
        if (analogue)
        {
            x_dir = Input.GetAxis("Horizontal");
            y_dir = Input.GetAxis("Vertical");
        }
        //Move the player based on digital, boolean input
        else
        {
            x_dir = Input.GetAxisRaw("Horizontal");
            y_dir = Input.GetAxisRaw("Vertical");
        }
        movement = new Vector3(x_dir, y_dir, 0);
        if (movement.magnitude > 1) 
        { 
            movement.Normalize(); 
        }
        movement = movement * speed * Time.deltaTime;
        
        transform.Translate(movement);
        
        Debug.Log(movement.magnitude);
    }
}