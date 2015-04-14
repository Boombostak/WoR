using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerTraits : MonoBehaviour {

    public string name;
    //basic stats
    public int xp;
    public int credits;
    public int gunnery_skill;
    public int reflexes_skill;
    public int tech_skill;
    //derived stats
    public int playerlvl;
    public int matter_max;
    public int energy_max;
    public int damage_reduction;
    public int damage_bonus;
    public float damage_multiplier;
    public float rof_multiplier;
    public int avoid_chance;
    public int mass_absorbtion;
    public int energy_absorbtion;
    public int bounty_collection;
    //reputation
    public int currentmatter;
    public int currentenergy;

    public float dps;

    void Start()
    {
        currentmatter = matter_max;
        currentenergy = energy_max;
    }
    
    void Update()
    {
        if (currentmatter < 1)
        {
            PlayerDied();
        }
    }

    void PlayerDied()
    {
        Debug.Log("Player has died");
    }
}
