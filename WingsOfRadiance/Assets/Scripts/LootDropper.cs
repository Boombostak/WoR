using UnityEngine;
using System.Collections;

public class LootDropper : MonoBehaviour
{
    public GameObject what_to_drop;
    public bool dropbool;
    private int rng_drop;
    private int rng_what;
    public int droppercentage;
    //public GameObject[] droparray;

    void Start()
    {
        rng_drop = Random.Range(0, 100);
        //rng_what = Random.Range(0, droparray.Length);
            
        /*
         * if (rng_drop <= droppercentage)
            {
                dropbool = true;
            }
         */

        dropbool = true;

        if (dropbool == true)
            {
                what_to_drop = GetComponent<PickPicker>().item;
            //what_to_drop = (GameObject) droparray.GetValue(rng_what);
                Debug.Log("Trying to drop " + what_to_drop + "code" + PickPicker.instance.string_lvl + PickPicker.instance.string_type +PickPicker.instance.string_rarity +PickPicker.instance.string_item);
            }
    
    }

}