﻿using UnityEngine;
using System.Collections;

public class ItemBehaviour : MonoBehaviour {

    //Moves items, reflects them off camera bounds, deletes them after a time limit, allows player to pick up.

    public Vector3 itemvector;
    public float speed = 0.05f;
    public Inventory inventory;
    public GameObject currentitem;
    public int size;
    public float lifetime;
    public float countup = 0;
    
    void Start()
    {
        itemvector = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f), 0f);
        inventory = GameObject.FindGameObjectWithTag("inventory").GetComponent<Inventory>();
        ItemTimer();
    }
    
    void ItemMove()
    {
        transform.Translate(itemvector.normalized * speed);
    }

    void ItemReflect()
    {
        
    }

    void ItemTimer()
    {
        float lt = lifetime;
        countup += Time.deltaTime;
        if (countup >= lt)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D othercollider)
    {
        if (othercollider.tag == "Player")
        {
            Debug.Log("item touched player");
            inventory.AddItem(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
    
    void ItemPickup()
    {

    }

    void Update()
    {
        ItemMove();
        ItemTimer();
    }
}
