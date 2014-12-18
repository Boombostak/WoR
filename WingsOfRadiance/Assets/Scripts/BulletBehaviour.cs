using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour
{

    public float bullet_speed;
    public static float rof;
    public float firerate;
    public float self_destruct_timer;
    public GameObject lootmanager;
    public GameObject whattodrop;
    public LootWrapperClasses.LootItemType[] loottypearray;
    public LootWrapperClasses.LootItemRarity[] lootrarityarray;
    public LootWrapperClasses.LootTable[] loottablearray;
    public GameObject[] lootitemsarray;
    

    // Use this for initialization
    
    void Start()
    {
        rof = 1 / firerate;
        Destroy(gameObject, self_destruct_timer);
        lootmanager = GameObject.FindGameObjectWithTag("lootmanager");
        Debug.Log(lootmanager + "is your lootmanager!");
        
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
            
            
            /*if ((GameObject)othercollider.gameObject.GetComponent<LootDropper>().what_to_drop != null)
            {
                Instantiate((GameObject)othercollider.gameObject.GetComponent<LootDropper>().what_to_drop, this.transform.position, this.transform.rotation);
            }*/

            loottypearray = lootmanager.GetComponent<LootWrapperClasses>().Llvl.lootlevel;
            lootrarityarray = loottypearray[0].itemtype;
            loottablearray = lootrarityarray[0].itemrarity;
            lootitemsarray = loottablearray[0].items;
            whattodrop = lootitemsarray[0];
            
            if (whattodrop != null)
            {
                Debug.Log("dropped(?)" + whattodrop);
                Instantiate(whattodrop, this.transform.position, this.transform.rotation);
            }

            Debug.Log("attempted to drop" + whattodrop);
            Destroy(othercollider.gameObject);
            Destroy(gameObject);
             
            
        }
            //Debug.Log("hit"+othercollider);
    }

}