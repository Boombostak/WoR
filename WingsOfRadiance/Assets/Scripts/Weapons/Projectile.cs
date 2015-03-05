using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public int damage;
    public float speed;
    public Weapon weapon;
    public GameObject hit_enemy;
    public EnemyBehaviour enemy_script;
    private int enemy_health;

    void Start()
    {
        damage = weapon.finaldamage;
        speed = weapon.projectile_speed;
    }

    void OnTriggerEnter2D(Collider2D othercollider)
    {
        if (othercollider.tag == "enemy")
        {
            hit_enemy = othercollider.gameObject;
            enemy_script = hit_enemy.GetComponent<EnemyBehaviour>();

            if (enemy_script.health >= 1)
            {
                enemy_script.health -= damage;
            }


            Destroy(gameObject);
        }
        //Debug.Log("hit"+othercollider);
    }
}
