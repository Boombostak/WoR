using UnityEngine;
using System.Collections;


public class LootManager : MonoBehaviour
{

    [System.Serializable]
    public class LootTable
    {
        public string name;
        new public GameObject[] items;
    }

    [System.Serializable]
    public class LootItemRarity
    {
        public string name;
        new public LootTable [] itemrarity;
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