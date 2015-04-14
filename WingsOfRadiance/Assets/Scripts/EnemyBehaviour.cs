using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour, IDestructible, IDamageable {

    public float speed;
    private Vector3 movement;
    private Vector3 spawnpoint;
    public int health = 1;
    public GameObject weapon;
    public GameObject explosion;
    public GameObject item_to_drop;
    public static GameObject lootmanager;
    public int dropchance = 30;
    public int drop_rng;

    public string movement_pattern_string;
    public float sine_formula_x;
    public float sine_formula_y;

    // Use this for initialization
	void Start () {
        lootmanager = GameObject.FindGameObjectWithTag("lootmanager");
        //Debug.Log(lootmanager + "is your lootmanager!");
        drop_rng = UnityEngine.Random.Range(0, 100);
	}
	
	// Update is called once per frame
    void Update () {

        Move(movement_pattern_string);

        if (health < 1)
        {
            if (drop_rng < dropchance)
            {
            item_to_drop = lootmanager.GetComponent<LootManagerGO>().DropAnItem(this.transform);
            Debug.Log("attempted to drop" + item_to_drop);
            Instantiate(item_to_drop, this.transform.position, Quaternion.identity);
            Destroy(lootmanager.GetComponent<LootManagerGO>().thing_to_spawn); 
            }
            DestroyThis();
        }
        
        
        
	}

    public void DamageThis(int damage)
    {

    }

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }

    void Move(string movement_pattern_string)
    {
        switch (movement_pattern_string)
        {
            case "forward":
                movement = new Vector3(0, -speed * Time.deltaTime, 0);
                transform.Translate(movement);
                Debug.Log("I am moving forward!");
                break;
            case "sine_wave":
                movement = new Vector3((sine_formula_y), (sine_formula_y), 0f) * speed * Time.deltaTime;
                transform.Translate(movement);
                Debug.Log("I am moving in a sine wave!");
                break;
            case default(string):
                Debug.Log("No pattern selected! ERROR");
                break;
        }
    }
}
