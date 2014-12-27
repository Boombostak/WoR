﻿using UnityEngine;
using System.Collections;
using System.Reflection;

public class LootManagerGO : MonoBehaviour {

    private GameObject player;
    private int level_int;
    
    private GameObject level_selectionGO;
    private GameObject itemtype_selectionGO;
    private GameObject itemrarity_selectionGO;
    private GameObject droppeditem_selectionGO;
    private GameObject clone_to_spawn;
    public GameObject thing_to_spawn;
    public GameObject itemtodrop;
    private GameObject[] loottable;

    private int typerng;
    private int typelength;
    private int rarityrng;
    private int raritylength;
    private int droppeditemrng;
    private int droppeditemlength;

    public GameObject[] affix_GO_array;
    public int affix_rng;
    public GameObject affix_GO;
    public AffixScript affix;
    public Component affix_component;
    
    
    // Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player"); //Finds player GO.
        level_int = player.GetComponent<PlayerTraits>().playerlvl; //Defines the player's level.
        level_selectionGO = this.transform.GetChild(level_int).gameObject;
        //Debug.Log(level_selectionGO);
        thing_to_spawn = new GameObject();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject DropAnItem()
    {
        itemtype_selectionGO = level_selectionGO.transform.GetChild(Random.Range (0,level_selectionGO.transform.childCount)).gameObject;
        Debug.Log(itemtype_selectionGO);
        itemrarity_selectionGO = itemtype_selectionGO.transform.GetChild(Random.Range(0, itemtype_selectionGO.transform.childCount)).gameObject;
        Debug.Log(itemrarity_selectionGO);
        loottable = itemrarity_selectionGO.GetComponent<LootTable>().items;
        droppeditem_selectionGO = loottable[Random.Range(0, loottable.Length)];
        clone_to_spawn = Instantiate (droppeditem_selectionGO, transform.position, transform.rotation) as GameObject;
        clone_to_spawn.SetActive(false);
        //Debug.Log(droppeditem_selectionGO);

        if (itemrarity_selectionGO.name == "magic")
        {
            //Debug.Log("magic item rolled, applying affix");
            AddAffix();
        }

        thing_to_spawn = clone_to_spawn;
        thing_to_spawn.SetActive(true);
        Destroy(clone_to_spawn);
        return thing_to_spawn;

    }

    public void AddAffix()
    {
        affix_rng = Random.Range(0, affix_GO_array.Length);
        affix_GO = affix_GO_array[affix_rng];
        affix_component = affix_GO.GetComponent<AffixScript>();
        CopyComponent(affix_component, clone_to_spawn);
        (affix_component as MonoBehaviour).enabled = true;
        Debug.Log("Your affix is" + clone_to_spawn.GetComponent<AffixScript>().teststring);
    }

     public Component CopyComponent(Component original, GameObject destination)
    {
     System.Type type = original.GetType();
     Component copy = destination.AddComponent(type);
     // Copied fields can be restricted with BindingFlags
     System.Reflection.FieldInfo[] fields = type.GetFields(); 
     foreach (System.Reflection.FieldInfo field in fields)
     {
        field.SetValue(copy, field.GetValue(original));
     }
     return copy;
    }

        
        

    }