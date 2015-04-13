using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

    public int damage;
    public float speed;
    public GameObject hitplayer;
    public PlayerTraits enemy_script;

    void Start()
    {

    }

    void Update()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D othercollider)
    {
        if (othercollider.tag == "Player")
        {
            hitplayer = othercollider.gameObject;
            enemy_script = hitplayer.GetComponent<PlayerTraits>();

            if (enemy_script.currentmatter >= 1)
            {
                enemy_script.currentmatter -= damage;
            }
            Destroy(this.gameObject);
        }
        //Debug.Log("hit"+othercollider);
    }
}
