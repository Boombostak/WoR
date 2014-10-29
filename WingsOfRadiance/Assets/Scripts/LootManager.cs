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
        new public LootTable [] itemrarity;
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
        new public LootItemRarity [] itemtype;
    }
    [System.Serializable]
    public class LootLevel
    {
        new public LootItemType[] lootlevel;
    }


    new public LootLevel Llvl;
    
    

}


