﻿using UnityEngine;
using System.Collections;

public class PlayerEquipped : MonoBehaviour {

	public GameObject fuselage;
    public GameObject cockpit;
    public GameObject engine;
    public GameObject scoop;
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject medal1;
    public GameObject medal2;
    private GameObject player;
    private GameObject fuselageGO;
    private GameObject weapon1GO;
    private GameObject weapon2GO;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fuselageGO = Instantiate(fuselage) as GameObject;
        fuselageGO.transform.SetParent(player.transform.FindChild("fuselage"));//currently works
    }
    
    // Use this for initialization
	void Start () {
        weapon1GO = Instantiate(weapon1) as GameObject;
        weapon2GO = Instantiate(weapon2) as GameObject;
        weapon1GO.transform.SetParent(player.transform.FindChild("weapons"));
        weapon2GO.transform.SetParent(player.transform.FindChild("weapons"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}