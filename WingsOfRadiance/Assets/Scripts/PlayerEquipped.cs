using UnityEngine;
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
    private GameObject weapon1GO;
    private GameObject weapon2GO;
    
    // Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        weapon1GO = Instantiate(weapon1) as GameObject;
        weapon2GO = Instantiate(weapon2) as GameObject;
        weapon1GO.transform.SetParent(player.transform.GetChild(1));
        weapon2GO.transform.SetParent(player.transform.GetChild(1));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
