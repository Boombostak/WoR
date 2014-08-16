using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

    GameObject bullet;
    
    // Use this for initialization
	void Start () {

        

	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(0, 1f * Time.deltaTime, 0);
	}
}
