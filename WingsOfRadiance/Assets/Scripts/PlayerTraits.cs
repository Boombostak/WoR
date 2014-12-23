using UnityEngine;
using System.Collections;

public class PlayerTraits : MonoBehaviour {

    //basic stats
    public int xp;
    public int credits;
    public int gunnery_skill;
    public int reflexes_skill;
    public int tech_skill;
    //derived stats
    public int playerlvl;
    public int mass_max;
    public int energy_max;
    public int damage_reduction;
    public int damage_bonus;
    public int avoid_chance;
    public int mass_absorbtion;
    public int energy_absorbtion;
    public int bounty_collection;

    public float dps;

    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
