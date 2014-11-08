using UnityEngine;
using System.Collections;


public class LootManager : MonoBehaviour
{

    

    
    
    [System.Serializable]
    public class LootTable
    {
        public string name;
        public GameObject[] items = new GameObject[3];
    }

    [System.Serializable]
    public class LootItemRarity
    {
        public string name;
        public LootTable [] itemrarity;
        public int nothing_droprate;
        public int normal_droprate;
        public int magic_droprate;
        public int rare_droprate;
        public int total_droprate;

        void Start()
        {
            total_droprate = normal_droprate + magic_droprate + rare_droprate;
        }
        

    }
    [System.Serializable]
    public class LootItemType
    {
        public string name;
        public LootItemRarity [] itemtype;
        public int weapon_droprate;
        public int chassis_droprate;
        public int computer_droprate;
        public int engine_droprate;
        public int scoop_droprate;
        public int powerplant_droprate;
        public int medalgem_droprate;
        public int misc_droprate;


    }
    [System.Serializable]
    public class LootLevel
    {
        public LootItemType[] lootlevel;
    }


    public LootLevel Llvl;
    
    

}


