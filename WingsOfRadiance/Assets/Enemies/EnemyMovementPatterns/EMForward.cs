using UnityEngine;
using System.Collections;

public class EMForward : MonoBehaviour {

    public float speed = 0.1f;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Translate((Vector3.up) * speed * Time.deltaTime);//UP is y axis
	}
}
