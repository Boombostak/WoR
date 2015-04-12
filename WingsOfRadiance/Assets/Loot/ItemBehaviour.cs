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
    //public float countup = 0;
    public Color itemcolor;
    public bool isblinking = false;
    
    void Start()
    {
        itemvector = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f), 0f);
        inventory = GameObject.FindGameObjectWithTag("inventory").GetComponent<Inventory>();
        itemcolor = this.GetComponent<SpriteRenderer>().color;
        if (Application.loadedLevelName == "test")//this prevents timers from running in inventory scenes
        {
            StartCoroutine(ItemTimer());
        }
    }
    
    void ItemMove()
    {
        transform.Translate(itemvector.normalized * speed);
    }

    void ItemReflect()
    {
        
    }

    //FIGURE THIS OUT! COROUTINES!
    //Works now!
    IEnumerator ItemTimer()
    {
        float timer = lifetime;
        Debug.Log("timer"+ timer);
        while (timer > 2f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        while (timer <= 2f && timer > 0)
        {
            if (isblinking == false)
            {
                StartCoroutine(ItemBlink());
            }
            timer -= Time.deltaTime;
            yield return null;
        }
        while (timer <= 0f)
        {
            Destroy(this.gameObject);
            yield return null;
        }
    }

    IEnumerator ItemBlink()
    {
        yield return new WaitForSeconds(0.2f);
        this.renderer.enabled = !this.renderer.enabled;
        isblinking = true;
        Debug.Log("called itemblink)");
    }

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

    void Update()
    {
        ItemMove();
    }
}
