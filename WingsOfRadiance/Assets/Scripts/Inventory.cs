using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class Inventory : MonoBehaviour {

    public List<GameObject> contents;
    public int maxstorage;
    public int storage;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddItem(GameObject item)
    {
        contents.Add(item);
    }
}
