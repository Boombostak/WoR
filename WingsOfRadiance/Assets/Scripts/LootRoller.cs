using UnityEngine;
using System.Collections;

public class LootRoller : MonoBehaviour {

    public GameObject lootmanager;
    public GameObject whattodrop;
    public LootWrapperClasses.LootItemType[] loottypearray;
    public LootWrapperClasses.LootItemRarity[] lootrarityarray;
    public LootWrapperClasses.LootTable[] loottablearray;
    public GameObject[] lootitemsarray;

    public GameObject RollLoot()
    {
        lootmanager = GameObject.FindGameObjectWithTag("lootmanager");
        Debug.Log(lootmanager + "is your lootmanager!");
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
        return whattodrop;
    }
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
