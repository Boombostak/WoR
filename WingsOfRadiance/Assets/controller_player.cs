using UnityEngine;
using System.Collections;

public class controller_player : MonoBehaviour {

    public float speed;
    private float x_dir;
    private float y_dir;
    private Vector3 movement;
    public  float diagonal_modifier;

    // Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        
        x_dir = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        y_dir = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        movement = new Vector3(x_dir * diagonal_modifier, y_dir * diagonal_modifier, 0);
        diagonal_modifier = (x_dir != 0 && y_dir != 0) ? 0.7071f : 1f ;
        transform.Translate(movement);
        Debug.Log(movement.magnitude);
    }
}