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
    public float damage_reduction;
    public float damage_bonus;
    public float avoid_chance;
    public float mass_absorbtion;
    public float energy_absorbtion;
    public float bounty_collection;

    public float dps;

    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
