using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

    public int damage;
    public float speed;
    public GameObject hitplayer;
    public PlayerTraits enemy_script;

    void Start()
    {
        this.gameObject.CreatePool();
    }

    void Update()
    {
        this.transform.Translate(0f, 1 * Time.deltaTime * speed, 0f);
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
            this.gameObject.Recycle();
        }
        //Debug.Log("hit"+othercollider);
    }
}
