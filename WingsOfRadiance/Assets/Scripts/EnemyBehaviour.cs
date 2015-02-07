using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public float speed;
    private Vector3 movement;
    private Vector3 spawnpoint;
    public int health = 1;
    public GameObject weapon;
    public GameObject explosion;
    public GameObject item_to_drop;
    public static GameObject lootmanager;

    // Use this for initialization
	void Start () {
        lootmanager = GameObject.FindGameObjectWithTag("lootmanager");
        Debug.Log(lootmanager + "is your lootmanager!");
	
	}
	
	// Update is called once per frame
    void Update () {
        
        movement = new Vector3(0, -speed * Time.deltaTime, 0);

        transform.Translate(movement);

        if (health < 1)
        {
            item_to_drop = lootmanager.GetComponent<LootManagerGO>().DropAnItem(this.transform).gameObject;
            Debug.Log("attempted to drop" + item_to_drop);
            Instantiate(item_to_drop, this.transform.position, this.transform.rotation);
            Destroy(lootmanager.GetComponent<LootManagerGO>().thing_to_spawn);
            Destroy(this.gameObject);
        }
        
        
        
	}
}
