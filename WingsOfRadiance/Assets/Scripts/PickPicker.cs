using UnityEngine;
using System.Collections;

public class PickPicker : MonoBehaviour {

    public static PickPicker instance;
    private LootManager.LootItemType lvl_table; //the (area?)level to use
    private LootManager.LootItemRarity rarity_table;
    private LootManager.LootTable gotable_table;    
    private int type_length; //the number of types to randomize between
    private int rarity_length; //the number of rarities to randomize between
    private int gotable_length; //the length of the table to choose a GO from
    new public GameObject item; //the item to choose
    private int rng_type; //returns the index of the item type
    private int rng_rarity; //returns the index of the items rarity
    private int rng_gotable; //returns the index of the table to roll on
    private int rng_item; //returns the index of the GO to spawn
    private int numberofpicks; //how many drops the enemy makes
    private int currentlvl; //current playerlvl
    GameObject lootmanager;
    public string string_lvl;
    public string string_type;
    public string string_rarity;
    public string string_item;

    // Use this for initialization
	void Start () {

        instance = this;

        lootmanager = GameObject.Find("LootManagerGO");
        
        currentlvl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLvl>().playerlvl;
    }

    public GameObject RollLoot()
    
        {

    
        
        lvl_table = lootmanager.GetComponent<LootManager>().Llvl.lootlevel[currentlvl];
        type_length = lvl_table.itemtype.Length;
        rng_type = Random.Range(0, type_length);
        
        rarity_table = lvl_table.itemtype[rng_type];
        rarity_length = rarity_table.itemrarity.Length;
        rng_rarity = Random.Range(0, lootmanager.GetComponent<LootManager>());

        


        gotable_table = rarity_table.itemrarity[rng_rarity];
        gotable_length = gotable_table.items.Length;
        rng_gotable = Random.Range(0, gotable_length);

        item = (GameObject) GameObject.Instantiate(gotable_table.items[rng_gotable]);

        string_lvl = "" + currentlvl;
        string_type = "" + rarity_table;
        string_rarity = "" + gotable_table;
        string_item = "" + item;
        
    }
        
}
