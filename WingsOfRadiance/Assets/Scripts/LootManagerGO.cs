using UnityEngine;
using System.Collections;
using System.Reflection;

public class LootManagerGO : MonoBehaviour {

    private GameObject player;
    private int level_int;
    
    private GameObject level_selectionGO;
    private GameObject itemtype_selectionGO;
    private GameObject itemrarity_selectionGO;
    private GameObject droppeditem_selectionGO;
    public GameObject thing_to_spawn;
    public GameObject itemtodrop;
    private GameObject[] loottable;

    /*private GameObject[] playerlevelarray;
    private GameObject[] itemtypearray;
    private GameObject[] itemrarityarray;
    private GameObject[] itemGOarray;*/

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
        player = GameObject.FindGameObjectWithTag("Player");
        level_int = player.GetComponent<PlayerTraits>().playerlvl; //Defines the player's level.

        //playerlevelarray = new GameObject[this.gameObject.transform.childCount];
        level_selectionGO = this.transform.GetChild(level_int).gameObject;
        Debug.Log(level_selectionGO);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject DropAnItem()
    {
        itemtype_selectionGO = level_selectionGO.transform.GetChild(Random.Range (0,level_selectionGO.transform.childCount)).gameObject;
        Debug.Log(itemtype_selectionGO);
        //typelength = itemtypearray.Length;
        //typerng = Random.Range(0, typelength);
        //itemtype_selectionGO = itemtypearray[typerng]; //Selects the GO representing item type.

        //itemrarityarray = new GameObject[itemtype_selectionGO.transform.childCount];
        //raritylength = itemrarityarray.Length;
        //rarityrng = Random.Range(0, raritylength);
        itemrarity_selectionGO = itemtype_selectionGO.transform.GetChild(Random.Range(0, itemtype_selectionGO.transform.childCount)).gameObject;
        Debug.Log(itemrarity_selectionGO);
        //itemGOarray = new GameObject[itemrarity_selectionGO.transform.childCount];
        //droppeditemlength = itemGOarray.Length;
        //droppeditemrng = Random.Range(0, droppeditemlength);
        //droppeditem_selectionGO = itemrarity_selectionGO.transform.GetChild(Random.Range(0, itemrarity_selectionGO.transform.childCount)).gameObject;
        loottable = itemrarity_selectionGO.GetComponent<LootTable>().items;
        droppeditem_selectionGO = loottable[Random.Range(0, loottable.Length)];
        Debug.Log(droppeditem_selectionGO);

        if (itemrarity_selectionGO.name == "magic")
        {
            Debug.Log("magic item rolled, applying affix");
            AddAffix();
        }
        
        /*itemtodrop = droppeditem_selectionGO;
        
        typerng = Random.Range(0, typelength);
        rarityrng = Random.Range(0, raritylength);
        droppeditemrng = Random.Range(0, droppeditemlength);*/

        thing_to_spawn = droppeditem_selectionGO;
        return thing_to_spawn;

    }

    public void ComponentWrapper()
    {

    }

    public void AddAffix()
    {
        thing_to_spawn.AddComponent<AffixScript>();
        affix_rng = Random.Range(0, affix_GO_array.Length);
        affix_GO = affix_GO_array[affix_rng];
        affix_component = affix_GO.GetComponent<AffixScript>();

        foreach (FieldInfo fi in thing_to_spawn.GetComponent<AffixScript>().GetType().GetFields())
        {
            fi.SetValue(thing_to_spawn.GetComponents<AffixScript>(), fi.GetValue(affix_component));
        }

        Debug.Log("Your affix is" + thing_to_spawn.GetComponent<AffixScript>().teststring);
        

    }
}
