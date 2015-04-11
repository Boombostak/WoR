using UnityEngine;
using System.Collections;

public class ItemBehaviour : MonoBehaviour {

    //Moves items, reflects them off camera bounds, deletes them after a time limit, allows player to pick up.
    //Should also handle inventory interactions.

    public Vector3 itemvector;
    public float speed = 0.05f;
    public Inventory inventory;
    public GameObject currentitem;
    public int size; //for inventory
    public float lifetime;
    public float countup = 0;
    public Color itemcolor;
    
    void Start()
    {
        itemvector = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f), 0f);
        inventory = GameObject.FindGameObjectWithTag("inventory").GetComponent<Inventory>();
        itemcolor = this.GetComponent<SpriteRenderer>().color;
        //StartCoroutine(ItemTimer());
    }
    
    void ItemMove()
    {
        transform.Translate(itemvector.normalized * speed);
    }

    void ItemReflect()
    {
        
    }

    //FIGURE THIS OUT! COROUTINES!
    /*IEnumerator ItemTimer()
    {
        for (float timer = lifetime; timer >= 0; timer -= Time.deltaTime)
            if (timer<=1f)
            {
                //StartCoroutine(ItemBlink());
            }
            Destroy(this.gameObject);
            yield return null;
    }

    IEnumerator ItemBlink()
    {
        for (float blinktimer = 1f; blinktimer >= 1f; blinktimer -= 0.1f)
            //itemcolor = Color.white;
            //yield return new WaitForSeconds(0.1f);
            //itemcolor = new Color (1f - itemcolor.r, 1f - itemcolor.g, 1f - itemcolor.b);
            yield return new WaitForSeconds(0.1f);
    }*/

    void OnTriggerEnter2D(Collider2D othercollider)
    {
        if (othercollider.tag == "Player")
        {
            bool full =  false;
            //Debug.Log("item touched player");
            full = inventory.AddItem(this.gameObject);
            if (!full)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    
    void ItemPickup()
    {

    }

    void Update()
    {
        ItemMove();
        //ItemTimer();
    }
}
