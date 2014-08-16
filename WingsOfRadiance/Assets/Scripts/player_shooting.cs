using UnityEngine;
using System.Collections;

public class player_shooting : MonoBehaviour
{



    public GameObject shot;
    
    //void Update()
    //{
      //  if (Input.GetButtonDown("Fire1"))
        //    Instantiate(shot, transform.position, transform.rotation);
    //}



    
    
    //Shooting
    public float fire_rate; // number of shots per second
    public float damage; //damage per shot
    private bool shooting;
    private float shot_countdown = 0;
    private bool ready_to_shoot = true;

    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        //shooting plan:
        //shot allowed when timer is at zero
        //start timer at zero
        //if shooting is true and timer is zero, fire a shot, and increment shot countdown by 1/fire_rate
        //on update, decrement countdown by 1*deltatime
        
        shooting = Input.GetButton("Fire1");

        if (shooting && ready_to_shoot)
        {
            Instantiate(shot, transform.position, transform.rotation);//fire a shot
        }

	}
}