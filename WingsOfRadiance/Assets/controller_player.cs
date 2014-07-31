using UnityEngine;
using System.Collections;

public class controller_player : MonoBehaviour {

    public float speed;
    
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("left"))
            transform.Translate(-speed * Time.deltaTime, 0 , 0);
        if (Input.GetButton("right"))
            transform.Translate(speed * Time.deltaTime, 0, 0);
        if (Input.GetButton("down"))
            transform.Translate(0, -speed * Time.deltaTime, 0);
        if (Input.GetButton("up"))
            transform.Translate(0, -speed * Time.deltaTime, 0);

	}
}
