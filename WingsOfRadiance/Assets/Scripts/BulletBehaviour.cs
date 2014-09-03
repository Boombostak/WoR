using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour
{

    public float bullet_speed;
    public static float rof;
    public float firerate;
    public float self_destruct_timer;

    // Use this for initialization

    void Start()
    {
        rof = 1 / firerate;
        Destroy(gameObject, self_destruct_timer);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0, bullet_speed * Time.deltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D othercollider)
    {
        if (othercollider.tag == "enemy")
        {
            Destroy(othercollider.gameObject);
            Destroy(gameObject);
        }
            //Debug.Log("hit"+othercollider);
    }

}