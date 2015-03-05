using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public GameObject[] projectiles_per_shot;
    public int damage;
    public float speed;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

}
