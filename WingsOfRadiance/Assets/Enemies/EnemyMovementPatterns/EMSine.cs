using UnityEngine;
using System.Collections;

public class EMSine : MonoBehaviour {

    public float amplitude = 1;
    public float linear_speed=1;
    public Vector3 sinevector;
    public Vector3 linearvector;
    public Vector3 movevector;
	
	// Update is called once per frame
    void Start()
    {
        linearvector = Vector3.up * linear_speed;
    }
    
    void Update () {

        sinevector = new Vector3(Mathf.Sin(transform.position.y), 0, 0) * amplitude;
        movevector = (sinevector + linearvector);//should keep a consistent speed.
        transform.Translate(movevector * Time.deltaTime);
	}
}
