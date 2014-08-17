using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

    public BulletBehaviour bulletbehaviour;
    public float bullet_speed;
    public static float rof;
    public float firerate;
    
    // Use this for initialization
	void Start () {
        rof = 1/firerate;
        

	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(0, bullet_speed * Time.deltaTime, 0);
        
	}
}
