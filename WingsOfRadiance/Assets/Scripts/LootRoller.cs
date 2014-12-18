using UnityEngine;
using System.Collections;

public class LootRoller : MonoBehaviour {

    public GameObject lootmanager;
    public GameObject whattodrop;
    private LootWrapperClasses.LootItemType[] loottypearray;
    private LootWrapperClasses.LootItemRarity[] lootrarityarray;
    private LootWrapperClasses.LootTable[] loottablearray;
    private GameObject[] lootitemsarray;

    //randomization

    private int type_length;
    private int type_rng;
    private int rarity_length;
    private int rarity_rng; 
    private int table_length;
    private int table_rng; 
    private int items_length;
    private int items_rng;

    public GameObject RollLoot()
    {
        type_length = loottypearray.Length;
        type_rng = Random.Range(0, type_length);
        rarity_length = lootrarityarray.Length;
        rarity_rng = Random.Range(0, rarity_length);
        table_length = loottablearray.Length;
        table_rng = Random.Range(0, table_length);
        items_length = lootitemsarray.Length;
        items_rng = Random.Range(0, items_length);
        
        //lootmanager = GameObject.FindGameObjectWithTag("lootmanager");
        //Debug.Log(lootmanager + "is your lootmanager!");
        loottypearray = lootmanager.GetComponent<LootWrapperClasses>().Llvl.lootlevel;
        lootrarityarray = loottypearray[type_rng].itemtype;
        loottablearray = lootrarityarray[rarity_rng].itemrarity;
        lootitemsarray = loottablearray[table_rng].items;
        whattodrop = lootitemsarray[items_rng];

        if (whattodrop != null)
        {
            Debug.Log("dropped(?)" + whattodrop);
            Instantiate(whattodrop, this.transform.position, this.transform.rotation);
        }

        Debug.Log("attempted to drop" + whattodrop);
        return whattodrop;
    }
    
    // Use this for initialization
	void Start () {
        lootmanager = GameObject.FindGameObjectWithTag("lootmanager");
        Debug.Log(lootmanager + "is your lootmanager!");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
